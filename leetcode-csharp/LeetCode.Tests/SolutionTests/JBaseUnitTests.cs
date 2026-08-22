namespace LeetCode.Tests.SolutionTests;

public class JobSchedulingUnitTest
{
    public static TheoryData<int[], int[], int[], int> Data => new()
    {
        { [1, 2, 3, 3], [3, 4, 5, 6], [50, 10, 40, 70], 120 },
        { [1, 2, 3, 4, 6], [3, 5, 10, 6, 9], [20, 20, 100, 70, 60], 150 },
        { [1, 1, 1], [2, 3, 4], [5, 6, 4], 6 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] startTime, int[] endTime, int[] profit, int expected)
    {
        int actual = Solution.JobScheduling(startTime, endTime, profit);
        Assert.Equal(expected, actual);
    }
}

public class JumpUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [2, 3, 1, 1, 4], 2 }, { [2, 3, 0, 1, 4], 2 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.Jump(nums);
        Assert.Equal(expected, actual);
    }
}
