using Leetcode.P1905;

namespace Leetcode.Test;

public class P11905Test
{
    [Fact]
    public void Test1()
    {
        var grid1 = "[[1,1,1,0,0],[0,1,1,1,1],[0,0,0,0,0],[1,0,0,0,0],[1,1,0,1,1]]".ToJaggedArray();
        var grid2 = "[[1,1,1,0,0],[0,0,1,1,1],[0,1,0,0,0],[1,0,1,1,0],[0,1,0,1,0]]".ToJaggedArray();

        var solution = new Solution();
        var result = solution.CountSubIslands(grid1, grid2);
        Assert.Equal(3, result);
    }
}