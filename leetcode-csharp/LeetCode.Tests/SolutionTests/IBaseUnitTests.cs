namespace LeetCode.Tests.SolutionTests;

public class InsertIntoMaxTreeUnitTest
{
    public static TheoryData<TreeNode, int, TreeNode> Data => new()
    {
        {
            Util.GenerateTreeNode([4, 1, 3, null, null, 2]), 5, Util.GenerateTreeNode([5, 4, null, 1, 3, null, null, 2])
        },
        { Util.GenerateTreeNode([5, 2, 4, null, 1]), 3, Util.GenerateTreeNode([5, 2, 4, null, 1, null, 3]) },
        { Util.GenerateTreeNode([5, 2, 3, null, 1]), 4, Util.GenerateTreeNode([5, 2, 4, null, 1, 3]) }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(InsertIntoMaxTreeUnitTest))]
    public void MultipleDataTest(TreeNode root, int val, TreeNode expected)
    {
        TreeNode actual = Solution.InsertIntoMaxTree(root, val);
        Assert.Equal(expected, actual, new TreeNodeComparer());
    }
}

public class IntToRomanUnitTest
{
    [Theory]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(9, "IX")]
    [InlineData(58, "LVIII")]
    [InlineData(1994, "MCMXCIV")]
    public void MultipleDataTest(int num, string expected)
    {
        string actual = Solution.IntToRoman(num);
        Assert.Equal(expected, actual);
    }
}

public class IsAlienSortedUnitTest
{
    public static TheoryData<string[], string, bool> Data => new()
    {
        { ["hello", "leetcode"], "hlabcdefgijkmnopqrstuvwxyz", true },
        { ["word", "world", "row"], "worldabcefghijkmnpqstuvxyz", false },
        { ["apple", "app"], "abcdefghijklmnopqrstuvwxyz", false }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string[] words, string order, bool expected)
    {
        bool actual = Solution.IsAlienSorted(words, order);
        Assert.Equal(expected, actual);
    }
}

public class IsMatchUnitTest
{
    [Theory]
    [InlineData("aa", "a", false)]
    [InlineData("aa", "a*", true)]
    [InlineData("ab", ".*", true)]
    public void MultipleDataTest(string s, string p, bool expected)
    {
        bool actual = Solution.IsMatch(s, p);
        Assert.Equal(expected, actual);
    }
}

public class IsPalindromeUnitTest
{
    public static TheoryData<int[], bool> Data => new() { { [1, 2, 2, 1], true }, { [1, 2], false } };


    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, bool expected)
    {
        ListNode head = Util.GenerateListNode(nums);
        bool actual = Solution.IsPalindrome(head);
        Assert.Equal(expected, actual);
    }
}

public class IsPrefixOfWordUnitTest
{
    [Theory]
    [InlineData("i love eating burger", "burg", 4)]
    [InlineData("this problem is an easy problem", "pro", 2)]
    [InlineData("i am tired", "you", -1)]
    public void Test(string sentence, string searchWord, int expected)
    {
        int actual = Solution.IsPrefixOfWord(sentence, searchWord);
        Assert.Equal(expected, actual);
    }
}

public class IsValidSerializationUnitTest
{
    public static TheoryData<string, bool> Data =>
        new() { { "9,3,4,#,#,1,#,#,2,#,6,#,#", true }, { "1,#", false }, { "9,#,#,1", false }, };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string preorder, bool expected)
    {
        bool actual = Solution.IsValidSerialization(preorder);
        Assert.Equal(expected, actual);
    }
}

public class IsValidSudokuUnitTest
{
    public static TheoryData<char[][], bool> Data => new()
    {
        {
            [
                ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
                ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                ['.', '.', '.', '.', '8', '.', '.', '7', '9']
            ],
            true
        },
        {
            [
                ['8', '3', '.', '.', '7', '.', '.', '.', '.'],
                ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                ['.', '.', '.', '.', '8', '.', '.', '7', '9']
            ],
            false
        }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(char[][] board, bool expected)
    {
        bool actual = Solution.IsValidSudoku(board);
        Assert.Equal(expected, actual);
    }
}
