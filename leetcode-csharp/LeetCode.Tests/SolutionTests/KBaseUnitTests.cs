namespace LeetCode.Tests.SolutionTests;

public class KthGrammarUnitTest
{
    [Theory]
    [InlineData(1, 1, 0)]
    [InlineData(2, 1, 0)]
    [InlineData(2, 2, 1)]
    public void MultipleDataTest(int n, int k, int expected)
    {
        int actual = Solution.KthGrammar(n, k);
        Assert.Equal(expected, actual);
    }
}



public class KthLargestUnitTest
{
    [Fact]
    public void Test()
    {
        int[] nums = [4, 5, 8, 2];
        var kthLargest = new KthLargest(3, nums);
        int actual = kthLargest.Add(3);
        int expected = 4;
        Assert.Equal(expected, actual);

        actual = kthLargest.Add(5);
        expected = 5;
        Assert.Equal(expected, actual);

        actual = kthLargest.Add(10);
        expected = 5;
        Assert.Equal(expected, actual);


        actual = kthLargest.Add(9);
        expected = 8;
        Assert.Equal(expected, actual);

        actual = kthLargest.Add(4);
        expected = 8;
        Assert.Equal(expected, actual);
    }
}


