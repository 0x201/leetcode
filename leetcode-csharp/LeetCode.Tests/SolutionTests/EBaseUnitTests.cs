namespace LeetCode.Tests.SolutionTests;

public class ExamRoomUnitTest
{
    [Fact]
    public void SingleTest()
    {
        ExamRoom er = new(10);
        Assert.Equal(0, er.Seat());
        Assert.Equal(9, er.Seat());
        Assert.Equal(4, er.Seat());
        Assert.Equal(2, er.Seat());
        er.Leave(4);
        Assert.Equal(5, er.Seat());
    }
}

public class ExclusiveTimeUnitTest
{
    public static TheoryData<int, IList<string>, int[]> Data => new()
    {
        { 2, ["0:start:0", "1:start:2", "1:end:5", "0:end:6"], [3, 4] },
        { 1, ["0:start:0", "0:start:2", "0:end:5", "0:start:6", "0:end:6", "0:end:7"], [8] },
        { 2, ["0:start:0", "0:start:2", "0:end:5", "1:start:6", "1:end:6", "0:end:7"], [7, 1] },
        { 2, ["0:start:0", "0:start:2", "0:end:5", "1:start:7", "1:end:7", "0:end:8"], [8, 1] },
        { 1, ["0:start:0", "0:end:0"], [1] },
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(ExclusiveTimeUnitTest))]
    public void MultipleDataTest(int n, IList<string> logs, int[] expected)
    {
        int[] actual = Solution.ExclusiveTime(n, logs);
        Assert.Equal(expected, actual);
    }
}
