// https://leetcode.com/problems/merge-k-sorted-lists/description/
using System.Formats.Asn1;

namespace Leetcode
{

    namespace P23
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class Solution
        {
            public ListNode MergeKLists(ListNode[] lists)
            {
                if (lists.Length == 0)
                {
                    return null;
                }

                ListNode answer = null;

                foreach (var list in lists)
                {
                    answer = MergeList(answer, list);
                }

                return answer;

            }

            private ListNode MergeList(ListNode x, ListNode y)
            {
                if (x == null || y == null)
                {
                    return x ?? y;
                }

                ListNode head = new();
                var xCurrent = x;
                var yCurrent = y;
                var current = head;

                while (xCurrent != null && yCurrent != null)
                {
                    if (xCurrent.val <= yCurrent.val)
                    {
                        current.next = xCurrent;
                        xCurrent = xCurrent.next;
                    }
                    else
                    {
                        current.next = yCurrent;
                        yCurrent = yCurrent.next;
                    }
                    current = current.next;
                }
                if (xCurrent != null)
                {
                    current.next = xCurrent;
                }
                else
                {
                    current.next = yCurrent;
                }
                return head.next;
            }
        }

    }
}