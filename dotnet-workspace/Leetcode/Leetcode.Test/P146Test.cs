using Leetcode.P146;

namespace Leetcode.Test;

public class P146Test
{
    [Fact]
    public void Test1()
    {

        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(1, 1); // cache is {1=1}
        lRUCache.Put(2, 2); // cache is {1=1, 2=2}
        var result = lRUCache.Get(1);    // return 1
        Assert.Equal(1, result);
        lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        result = lRUCache.Get(2);    // returns -1 (not found)
        Assert.Equal(-1, result);
        lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        result = lRUCache.Get(1);    // return -1 (not found)
        Assert.Equal(-1, result);
        result = lRUCache.Get(3);    // return 3
        Assert.Equal(3, result);
        result = lRUCache.Get(4);    // return 4
        Assert.Equal(4, result);
    }
}