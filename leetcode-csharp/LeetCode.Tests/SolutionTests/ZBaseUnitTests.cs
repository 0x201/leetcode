namespace LeetCode.Tests.SolutionTests;

public class ZeroEvenOddUnitTest
{
    public static TheoryData<int, string> Data => new() { { 1, "01" }, { 2, "0102" }, { 5, "0102030405" } };

    [Theory]
    [MemberData(nameof(Data))]
    public async Task Test(int n, string expected)
    {
        var zeroEvenOdd = new ZeroEvenOdd(n);
        string actual = "";
        var zeroTask = Task.Run(() => zeroEvenOdd.Zero((int n) => actual += n), TestContext.Current.CancellationToken);
        var evenTask = Task.Run(() => zeroEvenOdd.Even((int n) => actual += n), TestContext.Current.CancellationToken);
        var oddTask = Task.Run(() => zeroEvenOdd.Odd((int n) => actual += n), TestContext.Current.CancellationToken);

        await Task.WhenAll(zeroTask, evenTask, oddTask);

        Assert.Equal(expected, actual);
    }
}

public class ZigZagConvertUnitTest
{
    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("A", 1, "A")]
    public void Test(string s, int numRows, string expected)
    {
        string actual = Solution.ZipZagConvert(s, numRows);
        Assert.Equal(expected, actual);
    }
}
