namespace Leetcode.P1945
{
    public class Solution
    {
        public int GetLucky(string s, int k)
        {
            if (k < 1)
            {
                return -1;
            }

            var result = 1;
            var digits = new List<int>();
            foreach (var ch in s)
            {
                var digit = ch - 'a' + 1;
                if (digit < 10)
                {
                    digits.Add(digit);
                }
                else
                {
                    digits.Add(digit / 10);
                    digits.Add(digit % 10);
                }
            }
            result = digits.Aggregate(0, (acc, x) => acc + x);

            for (var i = 1; i < k; i++)
            {
                result = Transform(result);
            }

            return result;
        }

        private int Transform(int source)
        {
            if (source < 10)
            {
                return source;
            }
            var result = 0;
            int current = source;
            while (current > 0)
            {
                result += current % 10;
                current /= 10;
            }
            return result;
        }
    }
}