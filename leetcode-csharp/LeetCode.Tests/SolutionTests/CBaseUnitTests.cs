namespace LeetCode.Tests.SolutionTests;

public class CalculateMinimumHpUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { [[-2, -3, 3], [-5, -10, 1], [10, 30, -5]], 7 }, { [[0]], 1 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] dungeon, int expected)
    {
        int actual = Solution.CalculateMinimumHp(dungeon);
        Assert.Equal(expected, actual);
    }
}

public class CalPointsUnitTest
{
    public static TheoryData<string[], int> Data => new()
    {
        { ["5", "2", "C", "D", "+"], 30 }, { ["5", "-2", "4", "C", "D", "9", "+", "+"], 27 }, { ["1"], 1 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string[] input, int expected)
    {
        int actual = Solution.CalPoints(input);
        Assert.Equal(expected, actual);
    }
}

public class CanConstructUnitTest
{
    [Theory]
    [InlineData("a", "b", false)]
    [InlineData("aa", "ab", false)]
    [InlineData("aa", "aab", true)]
    public void Test(string ransomNote, string magazine, bool expected)
    {
        bool actual = Solution.CanConstruct(ransomNote, magazine);
        Assert.Equal(expected, actual);
    }
}

public class CanJumpUnitTest
{
    public static TheoryData<int[], bool> Data => new() { { [2, 3, 1, 1, 4], true }, { [3, 2, 1, 0, 4], false } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, bool expected)
    {
        bool actual = Solution.CanJump(nums);
        Assert.Equal(expected, actual);
    }
}

public class CanPartitionKSubsetsUnitTest
{
    public static TheoryData<int[], int, bool> Data => new()
    {
        { [4, 3, 2, 3, 5, 2, 1], 4, true }, { [1, 2, 3, 4], 3, false }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int k, bool expected)
    {
        bool actual = Solution.CanPartitionKSubsets(nums, k);
        Assert.Equal(expected, actual);
    }
}

public class CanTransformUnitTest
{
    [Theory]
    [InlineData("RXXLRXRXL", "XRLXXRRLX", true)]
    [InlineData("R", "L", false)]
    public void MultipleDataTest(string start, string end, bool expected)
    {
        bool actual = Solution.CanTransform(start, end);
        Assert.Equal(expected, actual);
    }
}

public class CheckInclusionUnitTest
{
    [Theory]
    [InlineData("ab", "eidbaooo", true)]
    [InlineData("ab", "eidboaoo", false)]
    public void Test_Should_Return_True(string s1, string s2, bool expected)
    {
        bool actual = Solution.CheckInclusion(s1, s2);
        Assert.Equal(expected, actual);
    }
}

public class CheckOnesSegmentUnitTest
{
    [Theory]
    [InlineData("1001", false)]
    [InlineData("110", true)]
    public void MultipleDataTest(string s, bool expected)
    {
        bool actual = Solution.CheckOnesSegment(s);
        Assert.Equal(expected, actual);
    }
}

public class CheckPossibilityUnitTest
{
    public static TheoryData<int[], bool> Data => new() { { [4, 2, 3], true }, { [4, 2, 1], false } };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, bool expected)
    {
        bool actual = Solution.CheckPossibility(nums);
        Assert.Equal(expected, actual);
    }
}

public class CodecUnitTest
{
    public static TheoryData<TreeNode, TreeNode> Data => new()
    {
        { Util.GenerateTreeNode([2, 1, 3]), Util.GenerateTreeNode([2, 1, 3]) }, { null, null }
    };

    private readonly Codec _codec = new();


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(CodecUnitTest))]
    public void MultipleDataTest(TreeNode root, TreeNode expected)
    {
        string treeNodeString = _codec.Serialize(root);
        TreeNode actual = _codec.Deserialize(treeNodeString);
        Assert.Equal(expected, actual, new TreeNodeComparer());
    }
}

public class CombinationSum2UnitTest
{
    public static TheoryData<int[], int, IList<IList<int>>> Data => new()
    {
        { [10, 1, 2, 7, 6, 1, 5], 8, [[2, 6], [1, 7], [1, 2, 5], [1, 1, 6]] },
        { [2, 5, 2, 1, 2], 5, [[5], [1, 2, 2]] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(CombinationSum2UnitTest))]
    public void MultipleDataTest(int[] candidates, int target, IList<IList<int>> expected)
    {
        IList<IList<int>> actual = Solution.CombinationSum2(candidates, target);
        Assert.Equal(expected, actual);
    }
}

public class CombinationSumUnitTest
{
    public static TheoryData<int[], int, IList<IList<int>>> Data => new()
    {
        { [2, 3, 6, 7], 7, [[7], [2, 2, 3]] },
        { [2], 1, [] },
        { [2, 3, 5], 8, [[3, 5], [2, 3, 3], [2, 2, 2, 2]] },
        { [1], 1, [[1]] },
        { [1], 2, [[1, 1]] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(CombinationSumUnitTest))]
    private void MultipleDataTest(int[] candidates, int target, IList<IList<int>> expected)
    {
        IList<IList<int>> actual = Solution.CombinationSum(candidates, target);
        Assert.Equal(expected, actual);
    }
}

public class ComplexNumberMultiplyUnitTest
{
    [Theory]
    [InlineData("1+1i", "1+1i", "0+2i")]
    [InlineData("1+-1i", "1+-1i", "0+-2i")]
    public void MultipleDataTest(string num1, string num2, string expected)
    {
        string actual = Solution.ComplexNumberMultiply(num1, num2);
        Assert.Equal(expected, actual);
    }
}

public class ConstructArrayUnitTest
{
    public static TheoryData<int, int, int[]> Data => new() { { 3, 1, [1, 2, 3] }, { 3, 2, [1, 3, 2] } };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int n, int k, int[] expected)
    {
        int[] actual = Solution.ConstructArray(n, k);
        Assert.Equal(expected, actual);
    }
}

public class ConstructMaximumBinaryTreeUnitTest
{
    public static TheoryData<int[], TreeNode> Data => new()
    {
        { [3, 2, 1, 6, 0, 5], Util.GenerateTreeNode([6, 3, 5, null, 2, 0, null, null, 1]) },
        { [3, 2, 1], Util.GenerateTreeNode([3, null, 2, null, 1]) }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(ConstructMaximumBinaryTreeUnitTest))]
    public void MultipleDataTest(int[] nums, TreeNode expected)
    {
        TreeNode actual = Solution.ConstructMaximumBinaryTree(nums);
        Assert.Equal(expected, actual, new TreeNodeComparer());
    }
}

public class ConvertToBase7UnitTest
{
    [Theory]
    [InlineData(100, "202")]
    [InlineData(-7, "-10")]
    public void MultipleDataTest(int input, string expected)
    {
        string actual = Solution.ConvertToBase7(input);
        Assert.Equal(expected, actual);
    }
}

public class ConvertToTitle
{
    [Theory]
    [InlineData(1, "A")]
    [InlineData(28, "AB")]
    [InlineData(701, "ZY")]
    public void MultipleDataTest(int columnNumber, string expected)
    {
        string actual = Solution.ConvertToTitle(columnNumber);
        Assert.Equal(expected, actual);
    }
}

public class CountKDifferenceUnitTest
{
    public static TheoryData<int[], int, int> Data => new() { { [1, 2, 2, 1], 1, 4 }, { [1, 3], 3, 0 }, { [3, 2, 1, 5, 4], 2, 3 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int k, int expected)
    {
        int actual = Solution.CountKDifference(nums, k);
        Assert.Equal(expected, actual);
    }
}

public class CountMaxOrSubsetsUniTest
{
    public static TheoryData<int[], int> Data => new() { { [3, 1], 2 }, { [2, 2, 2], 7 }, { [3, 2, 1, 5], 6 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] input, int expect)
    {
        int actual = Solution.CountMaxOrSubsets(input);
        Assert.Equal(expect, actual);
    }
}

public class CountEvenUnitTest
{
    [Theory]
    [InlineData(4, 2)]
    [InlineData(30, 14)]
    public void Test(int num, int expected)
    {
        int actual = Solution.CountEven(num);
        Assert.Equal(expected, actual);
    }
}

public class CountAndSayUnitTest
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(4, "1211")]
    public void Test(int n, string expected)
    {
        string actual = Solution.CountAndSay(n);
        Assert.Equal(expected, actual);
    }
}

public class CountNumbersWithUniqueDigitsUnitTest
{
    [Theory]
    [InlineData(2, 91)]
    [InlineData(0, 1)]
    public void MultipleDataTest(int n, int expected)
    {
        int actual = Solution.CountNumbersWithUniqueDigits(n);
        Assert.Equal(expected, actual);
    }
}

public class CountOddsUnitTest
{
    [Theory]
    [InlineData(3, 7, 3)]
    [InlineData(8, 10, 1)]
    public void MultipleDataTest(int low, int high, int expected)
    {
        int actual = Solution.CountOdds(low, high);
        Assert.Equal(expected, actual);
    }
}

public class CountSegmentUnitTest
{
    [Theory]
    [InlineData("Hello, my name is John", 5)]
    [InlineData("Hello", 1)]
    [InlineData("love live! mu'sic forever", 4)]
    [InlineData("", 0)]
    public void Test(string s, int expected)
    {
        int actual = Solution.CountSegments(s);
        Assert.Equal(expected, actual);
    }
}

public class CountStudentsUnitTest
{
    public static TheoryData<int[], int[], int> Data => new()
    {
        { [1, 1, 0, 0], [0, 1, 0, 1], 0 }, { [1, 1, 1, 0, 0, 1], [1, 0, 0, 0, 1, 1], 3 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] students, int[] sandwiches, int expected)
    {
        int actual = Solution.CountStudents(students, sandwiches);
        Assert.Equal(expected, actual);
    }
}

public class CountWaysUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { [[6, 10], [5, 15]], 2 }, { [[1, 3], [10, 20], [2, 5], [4, 8]], 4 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[][] ranges, int expected)
    {
        int actual = Solution.CountWays(ranges);
        Assert.Equal(expected, actual);
    }
}
