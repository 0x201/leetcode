namespace LeetCode.Tests.SolutionTests;

public class LargestPerimeterUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [2, 1, 2], 5 }, { [1, 2, 1], 0 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.LargestPerimeter(nums);
        Assert.Equal(expected, actual);
    }
}

public class LengthOfLastWordUnitTest
{
    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    public void MultipleDataTest(string s, int expected)
    {
        int actual = Solution.LengthOfLastWord(s);
        Assert.Equal(expected, actual);
    }
}

public class LengthOfLongestSubstringUnitTest
{
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("", 0)]
    public void Test_Input_Palindromic_Alphas_Should_OK(string s, int expected)
    {
        int actual = Solution.LengthOfLongestSubstring(s);
        Assert.Equal(expected, actual);
    }
}

public class LetterCasePermutationUnitTest
{
    public static TheoryData<string, string[]> Data => new()
    {
        { "a1b2", ["a1b2", "A1b2", "a1B2", "A1B2"] }, { "3z4", ["3z4", "3Z4"] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string input, string[] expected)
    {
        List<string> actual = Solution.LetterCasePermutation(input);
        Assert.Equal(expected, actual);
    }
}

public class LetterCombinationsUnitTest
{
    public static TheoryData<string, string[]> Data => new()
    {
        { "23", ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"] }, { "", [] }, { "2", ["a", "b", "c"] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(string digits, string[] expected)
    {
        IList<string> actual = Solution.LetterCombinations(digits);
        Assert.Equal(expected, actual);
    }
}

public class LexicalOrderUnitTest
{
    public static TheoryData<int, IList<int>> Data => new()
    {
        { 13, [1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9] }, { 2, [1, 2] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(LexicalOrderUnitTest))]
    public void MultipleDataTest(int n, IList<int> expected)
    {
        IList<int> actual = Solution.LexicalOrder(n);
        Assert.Equal(expected, actual);
    }
}

public class LongestCommonPrefixUnitTest
{
    public static TheoryData<string[], string> Data => new()
    {
        { ["flower", "flow", "flight"], "fl" }, { ["dog", "racecar", "car"], "" }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(string[] words, string expected)
    {
        string actual = Solution.LongestCommonPrefix(words);
        Assert.Equal(expected, actual);
    }
}

public class LongestPalindromicSubstringUnitTest
{
    [Theory]
    [InlineData("babad", new[] { "bab", "aba" })]
    [InlineData("cbbd", new[] { "bb" })]
    public void Test(string input, string[] expected)
    {
        string actual = Solution.LongestPalindrome(input);
        Assert.Contains(actual, expected);
    }
}

public class LongestUnivaluePathUnitTest
{
    public static TheoryData<TreeNode, int> Data => new()
    {
        { Util.GenerateTreeNode([5, 4, 5, 1, 1, null, 5]), 2 },
        { Util.GenerateTreeNode([1, 4, 5, 4, 4, null, 5]), 2 }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(LongestUnivaluePathUnitTest))]
    public void MultipleDataTest(TreeNode root, int expected)
    {
        int actual = Solution.LongestUnivaluePath(root);
        Assert.Equal(expected, actual);
    }
}

public class LongestValidParenthesesUnitTest
{
    [Theory]
    [InlineData("()()()(()", 6)]
    [InlineData("(()", 2)]
    [InlineData("()()()(())", 10)]
    public void Test(string s, int expected)
    {
        int actual = Solution.LongestValidParentheses(s);
        Assert.Equal(expected, actual);
    }
}

public class LuckyNumbersUnitTest
{
    public static TheoryData<int[][], List<int>> Matrix => new()
    {
        { [[3, 7, 8], [9, 11, 13], [15, 16, 17]], [15] },
        { [[1, 10, 4, 2], [9, 3, 8, 7], [15, 16, 17, 12]], [12] },
        { [[7, 8], [1, 2]], [7] }
    };


    [Theory]
    [MemberData(nameof(Matrix), MemberType = typeof(LuckyNumbersUnitTest))]
    public void Test1(int[][] matrix, List<int> expected)
    {
        var actual = Solution.LuckyNumbers(matrix).ToList();
        Assert.Equal(expected, actual);
    }
}
