namespace LeetCode.Tests.SolutionTests;

public class ValidAnagramUnitTest
{
    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData("rat", "car", false)]
    public void Test(string s, string t, bool expected)
    {
        bool actual = Solution.IsAnagram(s, t);
        Assert.Equal(expected, actual);
    }
}

public class ValidateStackSequencesUnitTest
{
    public static TheoryData<int[], int[], bool> Data => new()
    {
        { [1, 2, 3, 4, 5], [4, 5, 3, 2, 1], true }, { [1, 2, 3, 4, 5], [4, 3, 5, 1, 2], false }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] pushed, int[] popped, bool expected)
    {
        bool actual = Solution.ValidateStackSequences(pushed, popped);
        Assert.Equal(expected, actual);
    }
}

public class ValidIpAddressUnitTest
{
    [Theory]
    [InlineData("172.16.254.1", "IPv4")]
    [InlineData("2001:0db8:85a3:0:0:8A2E:0370:7334", "IPv6")]
    [InlineData("256.256.256.256", "Neither")]
    [InlineData("056.256.256.256", "Neither")]
    [InlineData("0.016.056.056", "Neither")]
    [InlineData("12.12.12.12.12", "Neither")]
    [InlineData("12.12..12.12", "Neither")]
    [InlineData("0az:12:12:12:12:123:23:32", "Neither")]
    [InlineData("0az:12:12:12:12:123", "Neither")]
    [InlineData("0a:12:12:12:12:123:23:32:11", "Neither")]
    [InlineData("0a:12:12:12::123:23:0A", "Neither")]
    public void Test(string address, string expected)
    {
        string actual = Solution.ValidIpAddress(address);
        Assert.Equal(expected, actual);
    }
}

public class ValidParenthesesUnitTest
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("([)]", false)]
    [InlineData("{[]}", true)]
    public void MultipleDataTest(string s, bool expected)
    {
        bool actual = Solution.IsValid(s);
        Assert.Equal(expected, actual);
    }
}
