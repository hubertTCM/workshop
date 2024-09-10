
using Microsoft.VisualBasic;

namespace P2807
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
        public ListNode InsertGreatestCommonDivisors(ListNode head)
        {
            ListNode current = head;
            while (current != null && current.next != null)
            {
                var next = current.next;

                var gcd = GreatestCommonDivisor(current.val, next.val);

                current.next = new ListNode(gcd, next);

                current = next;
            }
            return head;
        }

        private static int GreatestCommonDivisor(int x, int y)
        {
            if (x == y)
            {
                return x;
            }

            if (x > y)
            {
                return GreatestCommonDivisor(y, x);
            }

            // x<y
            if (y % x == 0)
            {
                return x;
            }
            return GreatestCommonDivisor(y % x, x);
        }
    }
}