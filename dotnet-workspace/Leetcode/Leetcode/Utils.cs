using System;
using System.Net.Http.Headers;
using System.Text;
using Leetcode.P23;

namespace Leetcode;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public static class Utils
{
    public static ListNode ToListNode(this string source)
    {
        // Remove any leading or trailing brackets
        var str = source.Trim('[', ']');

        // Check for empty list
        if (string.IsNullOrEmpty(str))
        {
            return null;
        }

        // Split the string by comma (delimiter) and convert each value to int
        var values = str.Split(',').Select(int.Parse).ToArray();

        // Create a List to store the ListNode objects
        //var list = new List<ListNode>();
        var head = new ListNode(values[0]);
        // Build the linked list by iterating through values and linking nodes
        ListNode current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }

        return head;
    }

    public static string ConvertListToString(this ListNode node)
    {
        if (node == null)
        {
            return string.Empty;
        }

        var stringBuilder = new StringBuilder();
        var current = node;
        while (current != null)
        {
            if (stringBuilder.Length > 0)
            {
                stringBuilder.Append(',');
            }
            stringBuilder.Append(current.val);
            current = current.next;
        }
        return $"[{stringBuilder}]";
    }

    // "[[1,1,1,0,0],[0,1,1,1,1]]";
    public static int[][] ToJaggedArray(this string input)
    {
        // Split the input string into individual grids
        string[] gridStrings = input.Split(new[] { "],[", "], [" }, StringSplitOptions.None);

        // Create a jagged array to store the converted grids
        int[][] jaggedArray = new int[gridStrings.Length][];

        // Iterate through each grid string and convert it to an array of integers
        for (int i = 0; i < gridStrings.Length; i++)
        {
            string[] gridElements = gridStrings[i].Trim('[', ']').Split(',');
            jaggedArray[i] = new int[gridElements.Length];

            for (int j = 0; j < gridElements.Length; j++)
            {
                jaggedArray[i][j] = int.Parse(gridElements[j]);
            }
        }

        return jaggedArray;
    }

    // [2,1,3,null,4]
    public static TreeNode ToTreeNode(this string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return null;
        }
        var s = source.Trim('[', ']');
        var valueQueue = new Queue<string>(s.Split(',').ToArray());

        if (valueQueue.Count == 0)
        {
            return null;
        }

        var nodeQueue = new Queue<TreeNode>();
        var root = new TreeNode(int.Parse(valueQueue.Dequeue()));
        nodeQueue.Enqueue(root);

        while (valueQueue.Count > 0)
        {
            var node = nodeQueue.Dequeue();
            var left = valueQueue.Dequeue();
            if (left != "null")
            {
                node.left = new TreeNode(int.Parse(left));
                nodeQueue.Enqueue(node.left);
            }
            if (valueQueue.Count > 0)
            {
                var right = valueQueue.Dequeue();
                if (right != "null")
                {
                    node.right = new TreeNode(int.Parse(right));
                    nodeQueue.Enqueue(node.right);
                }
            }
        }


        return root;
    }
}