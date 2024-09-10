
// [2,1,3,null,4] => 7

using Leetcode.P337;

namespace Leetcode.Test;

public class P337Test
{
    [Theory]
    [InlineData("[2,1,3,null,4]", 7)]
    public void Test1(string s, int expectedValue)
    {
        var solution = new Solution();

        var root = s.ToTreeNode();
        var actualResult = solution.Rob(root);
        Assert.Equal(expectedValue, actualResult);
    }
}