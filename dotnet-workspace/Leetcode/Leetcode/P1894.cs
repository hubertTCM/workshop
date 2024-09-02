using System.ComponentModel;
using System.Xml.XPath;

namespace Leetcode.P1894
{
    public class Solution
    {
        public int ChalkReplacer(int[] chalk, int k)
        {
            var sum = 0;
            for (int i = 0; i < chalk.Length; i++)
            {
                sum += chalk[i];
                if (sum > k)
                {
                    return i;
                }
            }
            return ChalkReplacer(chalk, k % sum);
        }
    }
}