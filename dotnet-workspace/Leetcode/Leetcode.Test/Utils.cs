using System;
using System.Text;
using Leetcode.P23;

namespace Leetcode.Test;

public static class Utils
{
    public static ListNode ToListNode(string source)
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
}