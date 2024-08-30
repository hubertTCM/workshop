using System.ComponentModel;
using System.Xml.XPath;

namespace Leetcode.P1905
{
    public class Solution
    {
        public int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            if (grid1.Length != grid2.Length)
            {
                return 0;
            }

            var visited = new Boolean[grid1.Length][];
            for (int i = 0; i < grid1.Length; i++)
            {
                if (grid1[i].Length != grid2[i].Length)
                {
                    return 0;
                }

                visited[i] = new Boolean[grid1[i].Length];
            }

            var result = 0;
            for (int i = 0; i < grid1.Length; i++)
            {
                for (int j = 0; j < grid1[i].Length; j++)
                {
                    if (grid2[i][j] == 0 || visited[i][j])
                    {
                        continue;
                    }
                    if (IsSubIsland(i, j, grid2, grid1, visited))
                    {
                        result += 1;
                    }
                }
            }
            return result;
        }


        private bool IsSubIsland(int startX, int startY, int[][] grid2, int[][] grid1, Boolean[][] visited)
        {

            if (startX < 0 || startX >= grid2.Length || startY < 0 || startY >= grid2[startX].Length)
            {
                return true;
            }
            if (visited[startX][startY])
            {
                return true;
            }

            visited[startX][startY] = true;
            var result = true;

            if (grid2[startX][startY] == 0)
            {
                return true;
            }

            if (grid1[startX][startY] != 1)
            {
                result = false;
            }

            int[,] delta = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

            for (int i = 0; i < delta.GetLength(0); i++)
            {
                var deltaX = delta[i, 0];
                var deltaY = delta[i, 1];
                var newX = startX + deltaX;
                var newY = startY + deltaY;
                if (newX < 0 || newX >= grid2.Length || newY < 0 || newY >= grid2[startX].Length)
                {
                    continue;
                }
                if (grid2[newX][newY] == 0)
                {
                    continue;
                }

                result = IsSubIsland(newX, newY, grid2, grid1, visited) && result;
            }

            return result;
        }
    }
}