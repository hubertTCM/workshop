using Leetcode.P23;


namespace Leetcode.Test;



public class P23Test
{
    [Theory]
    [InlineData("[1,4,5]", "[1,3,4]", "[2,6]", "[1,1,2,3,4,4,5,6]")]
    public void Test1(params string[] lists)
    {
        var expectedResult = lists.Last();
        var input = lists.SkipLast(1);
        var nodes = lists.SkipLast(1).Select(Utils.ToListNode).ToArray();

        var solution = new Solution();
        var merged = solution.MergeKLists(nodes);
        Assert.Equal(expectedResult, merged.ConvertListToString());
    }
}