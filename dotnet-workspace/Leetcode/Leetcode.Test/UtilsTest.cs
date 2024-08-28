
namespace Leetcode.Test;

public class UtilsTest
{
    bool AreJaggedArraysEqual(int[][] array1, int[][] array2)
    {
        // Check if the arrays have the same number of dimensions
        if (array1.Length != array2.Length)
        {
            return false;
        }

        // Check if each inner array has the same length
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i].Length != array2[i].Length)
            {
                return false;
            }
        }

        // Compare elements using SequenceEqual
        return array1.All(innerArray => array2.Any(innerArray2 => innerArray.SequenceEqual(innerArray2)));
    }

    [Fact]
    public void TestToJaggedArray()
    {
        var input = "[[1,1,1,0,0],[0,1,1,1,1]]";
        var result = input.ToJaggedArray();
        int[][] expectedResult = {
            [1,1,1,0,0],
            [0,1,1,1,1]
        };

        Assert.True(AreJaggedArraysEqual(result, expectedResult));
    }
}