namespace LeetCode.Tests.SolutionTests;

public class HammingWeightUnitTest
{
    [Theory]
    [InlineData(11, 3)]
    [InlineData(128, 1)]
    [InlineData(4294967293, 31)]
    public void Test(uint n, int expected)
    {

        int actual = Solution.HammingWeight(n);
        Assert.Equal(expected, actual);
    }
}


