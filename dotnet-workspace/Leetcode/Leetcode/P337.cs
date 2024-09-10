namespace Leetcode.P337;



public class Solution
{
    public class CacheItem
    {
        public TreeNode Node { get; set; }
        public int ValueWithNode { get; set; }
        public int ValueWithoutNode { get; set; }
    }

    public int Rob(TreeNode root)
    {
        var cache = new List<CacheItem>([new CacheItem()]);

        Rob(root, cache);

        var item = cache.Find(item => item.Node == root);
        if (item != null)
        {
            return Math.Max(item.ValueWithNode, item.ValueWithoutNode);
        }
        return 0;
    }

    private int Max(int value, params int[] values)
    {
        var max = value;
        foreach (var item in values)
        {
            max = Math.Max(item, max);
        }
        return max;
    }

    private CacheItem Rob(TreeNode root, List<CacheItem> cache)
    {
        var item = cache.Find(temp => temp.Node == root);
        if (item != null)
        {
            return item;
        }

        if (root.left == null && root.right == null)
        {
            item = new CacheItem()
            {
                Node = root,
                ValueWithNode = root.val,
                ValueWithoutNode = 0
            };
            cache.Add(item);
            return item;
        }


        item = new CacheItem() { Node = root };
        var left = Rob(root.left, cache);
        var right = Rob(root.right, cache);

        item.ValueWithNode = root.val + left.ValueWithoutNode + right.ValueWithoutNode;
        item.ValueWithoutNode = Max(left.ValueWithNode + right.ValueWithNode,
            left.ValueWithNode + right.ValueWithoutNode,
            left.ValueWithoutNode + right.ValueWithNode,
            left.ValueWithoutNode + right.ValueWithoutNode);

        cache.Add(item);

        return item;
    }
}
