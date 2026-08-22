namespace LeetCode.Tests.SolutionTests;

public class DistanceTraveledUnitTest
{
    [Theory]
    [InlineData(5, 10, 60)]
    [InlineData(1, 2, 10)]
    public void Test(int mainTank, int additionalTank, int expected)
    {
        int actual = Solution.DistanceTraveled(mainTank, additionalTank);
        Assert.Equal(expected, actual);
    }
}

public class DistinctSubseqIiUnitTest
{
    [Theory]
    [InlineData("abc", 7)]
    [InlineData("aba", 6)]
    [InlineData("aaa", 3)]
    public void MultipleDataTest(string s, int expected)
    {
        int actual = Solution.DistinctSubseqIi(s);
        Assert.Equal(expected, actual);
    }
}

public class DiStringMatchUnitTest
{
    public static TheoryData<string, int[]> Data => new()
    {
        { "IDID", [0, 4, 1, 3, 2] }, { "III", [0, 1, 2, 3] }, { "DDI", [3, 2, 0, 1] },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(string s, int[] expected)
    {
        int[] actual = Solution.DiStringMatch(s);
        Assert.Equal(expected, actual);
    }
}

public class DivideUnitTest
{
    [Theory]
    [InlineData(10, 3, 3)]
    [InlineData(7, -3, -2)]
    [InlineData(0, 1, 0)]
    [InlineData(1, 1, 1)]
    public void Test(int dividend, int divisor, int expected)
    {
        int actual = Solution.Divide(dividend, divisor);
        Assert.Equal(expected, actual);
    }
}



public class DistributeCandiesUnitTest
{
    [Theory]
    [InlineData(new[] { 1, 1, 2, 2, 3, 3 }, 3)]
    [InlineData(new[] { 1, 1, 2, 3 }, 2)]
    [InlineData(new[] { 6, 6, 6, 6 }, 1)]
    public void Test(int[] candyType, int expected)
    {
        int actual = Solution.DistributeCandies(candyType);
        Assert.Equal(expected, actual);
    }
}
