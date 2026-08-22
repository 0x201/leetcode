// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.Tests.SolutionTests;

public class AddBinaryUnitTest
{
    [Theory]
    [InlineData("11", "1", "100")]
    [InlineData("1010", "1011", "10101")]
    public void MultipleDataTest(string a, string b, string expected)
    {
        string actual = Solution.AddBinary(a, b);
        Assert.Equal(expected, actual);
    }
}

public class AddDigitsUnitTest
{
    [Theory]
    [InlineData(38, 2)]
    [InlineData(0, 0)]
    [InlineData(int.MaxValue, 1)]
    public void MultipleDataTest(int input, int expected)
    {
        int actual = Solution.AddDigits(input);
        Assert.Equal(expected, actual);
    }
}

public class AddOneRowUnitTest
{
    public static TheoryData<TreeNode, int, int, TreeNode> Data => new()
    {
        {
            Util.GenerateTreeNode([4, 2, 6, 3, 1, 5]), 1, 2, Util.GenerateTreeNode([4, 1, 1, 2, null, null, 6, 3, 1, 5])
        },
        { Util.GenerateTreeNode([4, 2, null, 3, 1]), 1, 3, Util.GenerateTreeNode([4, 2, null, 1, 1, 3, null, null, 1]) }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(AddOneRowUnitTest))]
    public void MultipleDataTest(TreeNode root, int val, int depth, TreeNode expectedNode)
    {
        TreeNode actualNode = Solution.AddOneRow(root, val, depth);
        List<int> actual = Util.PreorderTraversal(actualNode);
        List<int> expected = Util.PreorderTraversal(expectedNode);
        Assert.Equal(expected, actual);
    }
}

public class AddStringsUnitTest
{
    [Theory]
    [InlineData("1345", "8656", "10001")]
    [InlineData("245", "356", "601")]
    [InlineData("999", "1231", "2230")]
    public void AddStringsTest1(string number1, string number2, string expected)
    {
        string actual = Solution.AddStrings(number1, number2);
        Assert.Equal(expected, actual);
    }
}

public class AddTwoNumbersUnitTest
{
    public static TheoryData<ListNode, ListNode, ListNode> Data => new()
    {
        { Util.GenerateListNode([2, 4, 3]), Util.GenerateListNode([5, 6, 4]), Util.GenerateListNode([7, 0, 8]) },
        { Util.GenerateListNode([0]), Util.GenerateListNode([0]), Util.GenerateListNode([0]) },
        {
            Util.GenerateListNode([9, 9, 9, 9, 9, 9, 9]), Util.GenerateListNode([9, 9, 9, 9]),
            Util.GenerateListNode([8, 9, 9, 9, 0, 0, 0, 1])
        }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(AddTwoNumbersUnitTest))]
    public void Test(ListNode l1, ListNode l2, ListNode expected)
    {
        ListNode actual = Solution.AddTwoNumbers(l1, l2);
        Assert.Equal(expected, actual, new ListNodeComparer());
    }
}

public class AdvantageCountUnitTest
{
    public static TheoryData<int[], int[], int[]> Data => new()
    {
        { [2, 7, 11, 15], [1, 10, 4, 11], [2, 11, 7, 15] }, { [12, 24, 8, 32], [13, 25, 32, 11], [24, 32, 8, 12] }
    };


    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums1, int[] nums2, int[] expected)
    {
        int[] actual = Solution.AdvantageCount(nums1, nums2);
        Assert.Equal(expected, actual);
    }
}

public class AllOneUnitTest
{
    [Fact]
    public void Test()
    {
        var allOne = new AllOne();
        allOne.Inc("hello");
        allOne.Inc("hello");
        string actualMaxKey1 = allOne.GetMaxKey();
        string actualMinKey1 = allOne.GetMinKey();
        Assert.Equal("hello", actualMaxKey1);
        Assert.Equal("hello", actualMinKey1);
        allOne.Inc("leet");
        string actualMaxKey2 = allOne.GetMaxKey();
        string actualMinKey2 = allOne.GetMinKey();
        Assert.Equal("hello", actualMaxKey2);
        Assert.Equal("leet", actualMinKey2);
    }


    [Fact]
    public void Test2()
    {
        var allOne = new AllOne();
        allOne.Inc("a");
        allOne.Inc("b");
        allOne.Inc("b");
        allOne.Inc("b");
        allOne.Inc("b");
        allOne.Dec("b");
        allOne.Dec("b");
        string actualMaxKey1 = allOne.GetMaxKey();
        string actualMinKey1 = allOne.GetMinKey();
        Assert.Equal("b", actualMaxKey1);
        Assert.Equal("a", actualMinKey1);
    }
}

public class AreAlmostEqualUnitTest
{
    [Theory]
    [InlineData("bank", "kanb", true)]
    [InlineData("attack", "defend", false)]
    [InlineData("kelb", "kelb", true)]
    public void MultipleDataTest(string s1, string s2, bool expected)
    {
        bool actual = Solution.AreAlmostEqual(s1, s2);
        Assert.Equal(expected, actual);
    }
}

public class AreNumberAscendingUnitTest
{
    [Theory]
    [InlineData("1 box has 3 blue 4 red 6 green and 12 yellow marbles", true)]
    [InlineData("hello world 5 x 5", false)]
    [InlineData("sunset is at 7 51 pm overnight lows will be in the low 50 and 60 s", false)]
    public void MultipleDataTest(string s, bool expected)
    {
        bool actual = Solution.AreNumberAscending(s);
        Assert.Equal(expected, actual);
    }
}

public class AtoiUnitTest
{
    [Theory]
    [InlineData("42", 42)]
    [InlineData("   -42", -42)]
    [InlineData("4193 with words", 4193)]
    public void MultipleDataTest(string input, int expected)
    {
        int actual = Solution.Atoi(input);
        Assert.Equal(expected, actual);
    }
}

public class AverageUnitTest
{
    public static TheoryData<int[], double> Data => new()
    {
        { [4000, 3000, 1000, 2000], 2500.00000 }, { [1000, 2000, 3000], 2000.00000 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] salary, double expected)
    {
        double actual = Solution.Average(salary);
        Assert.Equal(expected, actual);
    }
}
