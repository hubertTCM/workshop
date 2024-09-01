namespace Leetcode.P2022
{
    public class Solution
    {
        public int[][] Construct2DArray(int[] original, int m, int n)
        {
            if (m * n != original.Length || original.Length == 0)
            {
                return [];
            }

            var result = new int[m][];
            for (int i = 0; i < original.Length; i++)
            {
                var row = i / n;
                var column = i % n;

                if (result[row] == null)
                {
                    result[row] = new int[n];
                }
                result[row][column] = original[i];
            }
            return result;
        }
    }
}