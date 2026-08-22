namespace LeetCode.Tests.SolutionTests;

public class UniqueLetterStringUnitTest
{
    [Theory]
    [InlineData("ABC", 10)]
    [InlineData("ABA", 8)]
    [InlineData("LEETCODE", 92)]
    public void MultipleDataTest(string s, int expected)
    {
        int actual = Solution.UniqueLetterString(s);
        Assert.Equal(expected, actual);
    }
}

public class UniqueMorseRepresentationsUnitTest
{
    public static TheoryData<string[], int> Data => new() { { ["gin", "zen", "gig", "msg"], 2 }, { ["a"], 1 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(string[] words, int expected)
    {
        int actual = Solution.UniqueMorseRepresentations(words);
        Assert.Equal(expected, actual);
    }
}

public class UniquePathsUnitTest
{
    [Theory]
    [InlineData(3, 7, 28)]
    [InlineData(3, 2, 3)]
    public void MultipleDataTest(int m, int n, int expected)
    {
        int actual = Solution.UniquePaths(m, n);
        Assert.Equal(expected, actual);
    }
}

public class UniquePathsWithObstaclesUnitTest
{
    public static TheoryData<int[][], int> Data => new() { { [[0, 0, 0], [0, 1, 0], [0, 0, 0]], 2 }, { [[0, 1], [0, 0]], 1 }, };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[][] obstacleGrid, int expected)
    {
        int actual = Solution.UniquePathsWithObstacles(obstacleGrid);
        Assert.Equal(expected, actual);
    }
}
