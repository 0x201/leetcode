namespace LeetCode.Tests.SolutionTests;

public class BackspaceCompareUnitTest
{
    [Theory]
    [InlineData("ab#c", "ad#c", true)]
    [InlineData("ab##", "c#d#", true)]
    [InlineData("a##c", "#a#c", true)]
    [InlineData("a#c", "b", false)]
    public void Test(string s, string t, bool expected)
    {
        bool actual = Solution.BackspaceCompare(s, t);
        Assert.Equal(expected, actual);
    }
}

public class BuildArrayUnitTest
{
    public static TheoryData<int[], int, IList<string>> Data => new()
    {
        { [1, 3], 3, ["Push", "Push", "Pop", "Push"] },
        { [1, 2, 3], 3, ["Push", "Push", "Push"] },
        { [1, 2], 4, ["Push", "Push"] }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(BuildArrayUnitTest))]
    public void Test(int[] targets, int n, IList<string> expected)
    {
        IList<string> actual = Solution.BuildArray(targets, n);
        Assert.Equal(expected, actual);
    }
}
