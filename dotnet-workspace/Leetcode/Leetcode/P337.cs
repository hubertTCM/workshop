namespace Leetcode.P337;



public class Solution
{
    public class CacheItem
    {
        public TreeNode Node { get; set; }
        public int ValueWithNode { get; set; } = -1;
        public int ValueWithoutNode { get; set; } = -1;
    }

    public int Rob(TreeNode root)
    {
        var cache = new List<CacheItem>();
        Rob(root, cache);

        var item = cache.Find(item => item.Node == root);
        if (item != null)
        {
            return Math.Max(item.ValueWithNode, item.ValueWithoutNode);
        }
        return 0;
    }

    private CacheItem Rob(TreeNode root, List<CacheItem> cache)
    {
        if (root == null)
        {
            return null;
        }

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

        var subWithoutNodeTotal = (left?.ValueWithoutNode ?? 0) + (right?.ValueWithoutNode ?? 0);
        var subWithNodeTotal = (left?.ValueWithNode ?? 0) + (right?.ValueWithNode ?? 0);

        item.ValueWithNode = root.val + (left?.ValueWithoutNode ?? 0) + (right?.ValueWithoutNode ?? 0);
        item.ValueWithoutNode = Math.Max(subWithNodeTotal, subWithoutNodeTotal);

        cache.Add(item);

        return item;
    }
}
