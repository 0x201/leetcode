namespace LeetCode.Tests.SolutionTests;

public class RandomizedSetUnitTest
{
    [Fact]
    public void Test()
    {
        var randomizedSet = new RandomizedSet();
        Assert.True(randomizedSet.Insert(1));
        Assert.False(randomizedSet.Remove(2));
        Assert.True(randomizedSet.Insert(2));
        Assert.Contains(randomizedSet.GetRandom(), new List<int> { 1, 2 });
        Assert.True(randomizedSet.Remove(1));
        Assert.False(randomizedSet.Insert(2));
        Assert.Equal(2, randomizedSet.GetRandom());
    }
}

public class ReadBinaryWatchUnitTest
{
    public static TheoryData<int, string[]> Data => new()
    {
        { 1, ["0:01", "0:02", "0:04", "0:08", "0:16", "0:32", "1:00", "2:00", "4:00", "8:00"] }, { 9, [] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int turnedOn, string[] expected)
    {
        IList<string> actual = Solution.ReadBinaryWatch(turnedOn);
        Assert.Equal(expected.ToList(), actual);
    }
}

public class RearrangeCharactersUnitTest
{
    [Theory]
    [InlineData("ilovecodingonleetcode", "code", 2)]
    [InlineData("abcba", "abc", 1)]
    [InlineData("abbaccaddaeea", "aaaaa", 1)]
    public void MultipleDataTest(string s, string target, int expected)
    {
        int actual = Solution.RearrangeCharacters(s, target);
        Assert.Equal(expected, actual);
    }
}

public class ReformatNumberUnitTest
{
    [Theory]
    [InlineData("1-23-45 6", "123-456")]
    [InlineData("123 4-567", "123-45-67")]
    [InlineData("123 4-5678", "123-456-78")]
    public void MultipleDataTest(string number, string expected)
    {
        string actual = Solution.ReformatNumber(number);
        Assert.Equal(expected, actual);
    }
}

public class ReformatUnitTest
{
    [Theory]
    [InlineData("a0b1c2", "a0b1c2")]
    [InlineData("leetcode", "")]
    [InlineData("1229857369", "")]
    public void MultipleDataTest(string input, string expected)
    {
        string actual = Solution.Reformat(input);
        Assert.Equal(expected, actual);
    }
}

public class RemoveDuplicatesFromSortedArrayIiUnitTest
{
    public static TheoryData<int[], int> Data =>
        new() { { [1, 1, 1, 2, 2, 3], 5 }, { [0, 0, 1, 1, 1, 1, 2, 3, 3], 7 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int expected)
    {
        int actual = Solution.RemoveDuplicatesV2(nums);
        Assert.Equal(expected, actual);
    }
}

public class RemoveDuplicatesUnitTest
{
    public static TheoryData<int[], int> Data = new() { { [1, 1, 2], 2 }, { [0, 0, 1, 1, 1, 2, 2, 3, 3, 4], 5 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.RemoveDuplicates(nums);
        Assert.Equal(expected, actual);
    }
}

public class RemoveElementUnitTest
{
    public static TheoryData<int[], int, int> Data => new()
    {
        { [3, 2, 2, 3], 3, 2 }, { [0, 1, 2, 2, 3, 0, 4, 2], 2, 5 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int value, int expected)
    {
        int actual = Solution.RemoveElement(nums, value);
        Assert.Equal(expected, actual);
    }
}

public class RemoveNthFromEndUnitTest
{
    public static TheoryData<ListNode, int, ListNode> Data => new()
    {
        { Util.GenerateListNode([1, 2, 3, 4, 5]), 2, Util.GenerateListNode([1, 2, 3, 5]) },
        { Util.GenerateListNode([1]), 1, Util.GenerateListNode([]) },
        { Util.GenerateListNode([1, 2]), 1, Util.GenerateListNode([1]) }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(RemoveNthFromEndUnitTest))]
    public void Test_Input_Normal_Nodes_Should_OK(ListNode input, int n, ListNode expected)
    {
        ListNode actual = Solution.RemoveNthFromEnd(input, n);
        Assert.Equal(expected, actual, new ListNodeComparer());
    }
}

public class ReorderSpacesUnitTest
{
    [Theory]
    [InlineData("  this   is  a sentence ", "this   is   a   sentence")]
    [InlineData(" practice   makes   perfect", "practice   makes   perfect ")]
    [InlineData(" practice  ", "practice   ")]
    public void MultipleDataTest(string text, string expected)
    {
        string actual = Solution.ReorderSpaces(text);
        Assert.Equal(expected, actual);
    }
}

public class RepeatedCharacterUnitTest
{
    [Theory]
    [InlineData("abccbaacz", 'c')]
    [InlineData("abcdd", 'd')]
    [InlineData("aa", 'a')]
    [InlineData("zz", 'z')]
    public void Test(string s, char expected)
    {
        char actual = Solution.RepeatedCharacter(s);
        Assert.Equal(expected, actual);
    }
}

public class RepeatedNTimesUniTest
{
    public static TheoryData<int[], int> Data => new()
    {
        { [1, 2, 3, 3], 3 }, { [2, 1, 2, 5, 3, 2], 2 }, { [5, 1, 5, 2, 5, 3, 5, 4], 5 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.RepeatedNTimes(nums);
        Assert.Equal(expected, actual);
    }
}

public class ReverseIntegerUnitTest
{
    [Theory]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    [InlineData(0, 0)]
    public void MultipleDataTest(int input, int expected)
    {
        int actual = Solution.ReverseInteger(input);
        Assert.Equal(expected, actual);
    }
}

public class ReverseKGroupUnitTest
{
    public static TheoryData<ListNode, int, ListNode> Data => new()
    {
        { Util.GenerateListNode([1, 2, 3, 4, 5]), 2, Util.GenerateListNode([2, 1, 4, 3, 5]) },
        { Util.GenerateListNode([1, 2, 3, 4, 5]), 3, Util.GenerateListNode([3, 2, 1, 4, 5]) }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(ReverseKGroupUnitTest))]
    public void MultipleDataTest(ListNode head, int k, ListNode expected)
    {
        ListNode actual = Solution.ReverseKGroup(head, k);
        Assert.Equal(expected, actual, new ListNodeComparer());
    }
}

public class ReverseListUnitTest
{
    public static TheoryData<ListNode, ListNode> Nodes => new()
    {
        { Util.GenerateListNode([1, 2, 3, 4, 5]), Util.GenerateListNode([5, 4, 3, 2, 1]) },
        { Util.GenerateListNode([1, 2]), Util.GenerateListNode([2, 1]) },
        { null, null }
    };


    [Theory]
    [MemberData(nameof(Nodes), MemberType = typeof(ReverseListUnitTest))]
    public void Test(ListNode head, ListNode expectedNode)
    {
        ListNode actualNode = Solution.ReverseList(head);
        string actual = actualNode?.ToString();
        string expected = expectedNode?.ToString();
        Assert.Equal(expected, actual);
    }
}

public class ReverseOnlyLettersUnitTest
{
    [Theory]
    [InlineData("ab-cd", "dc-ba")]
    [InlineData("a-bC-dEf-ghIj", "j-Ih-gfE-dCba")]
    [InlineData("Test1ng-Leet=code-Q!", "Qedo1ct-eeLg=ntse-T!")]
    public void Test(string s, string expected)
    {
        string actual = Solution.ReverseOnlyLetters(s);
        Assert.Equal(expected, actual);
    }
}

public class ReverseStringUnitTest
{
    public static TheoryData<char[], char[]> Data => new()
    {
        { ['h', 'e', 'l', 'l', 'o'], ['o', 'l', 'l', 'e', 'h'] },
        { ['H', 'a', 'n', 'n', 'a', 'h'], ['h', 'a', 'n', 'n', 'a', 'H'] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(char[] actual, char[] expected)
    {
        Solution.ReverseString(actual);
        Assert.Equal(expected, actual);
    }
}

public class ReverseWordsUnitTest
{
    [Theory]
    [InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
    [InlineData("God Ding", "doG gniD")]
    public void Test1(string s, string expected)
    {
        string actual = Solution.ReverseWords(s);
        Assert.Equal(expected, actual);
    }
}

public class RomanToIntUnittest
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void MultipleDataTest(string s, int expected)
    {
        int actual = Solution.RomanToInt(s);
        Assert.Equal(expected, actual);
    }
}

public class RotateImageUnitTest
{
    public static TheoryData<int[][], int[][]> Data => new()
    {
        { [[1, 2, 3], [4, 5, 6], [7, 8, 9],], [[7, 4, 1], [8, 5, 2], [9, 6, 3],] },
        {
            [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16],],
            [[15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11],]
        }
    };


    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] nums, int[][] expected)
    {
        Solution.Rotate(nums);
        Assert.Equal(expected, nums);
    }
}

public class RotateRightUnitTest
{
    public static TheoryData<ListNode, int, ListNode> Data => new()
    {
        { Util.GenerateListNode([1, 2, 3, 4, 5]), 2, Util.GenerateListNode([4, 5, 1, 2, 3]) }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(RotateRightUnitTest))]
    public void MultipleDataTest(ListNode head, int k, ListNode expected)
    {
        ListNode actual = Solution.RotateRight(head, k);
        Assert.Equal(expected, actual, new ListNodeComparer());
    }
}
