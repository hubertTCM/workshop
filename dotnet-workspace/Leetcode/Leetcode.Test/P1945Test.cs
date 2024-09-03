using Leetcode.P1945;

namespace Leetcode.Test;
public class P1945Test
{
    [Theory]
    [InlineData("leetcode", 2, 6)]
    public void Test(string input, int k, int expected)
    {
        var solution = new Solution();
        var actualReuslt = solution.GetLucky(input, k);
        Assert.Equal(expected, actualReuslt);
    }
}