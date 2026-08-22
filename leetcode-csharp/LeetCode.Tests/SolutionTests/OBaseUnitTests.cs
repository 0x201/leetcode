namespace LeetCode.Tests.SolutionTests;

public class OptimalDivisionUnitTest
{
    public static TheoryData<int[], string> Data => new()
    {
        { [1000, 100, 10, 2], "1000/(100/10/2)" }, { [2, 3, 4], "2/(3/4)" }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, string expected)
    {
        string actual = Solution.OptimalDivision(nums);
        Assert.Equal(actual, expected);
    }
}

public class OrangeRottingUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { new int[][] { [2, 1, 1], [1, 1, 0], [0, 1, 1] }, 4 }, { new int[][] { [0, 2] }, 0 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[][] grid, int expected)
    {
        int actual = Solution.OrangeRotting(grid);
        Assert.Equal(expected, actual);
    }
}
