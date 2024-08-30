using System;
using System.Text;
using Leetcode.P23;

namespace Leetcode;

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
}