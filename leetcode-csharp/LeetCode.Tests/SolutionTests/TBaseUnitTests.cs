namespace LeetCode.Tests.SolutionTests;

public class ThreeEqualPartsUnitTest
{
    public static TheoryData<int[], int[]> Data => new()
    {
        { [1, 0, 1, 0, 1], [0, 3] }, { [1, 1, 0, 1, 1], [-1, -1] }, { [1, 1, 0, 0, 1], [0, 2] },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] arr, int[] expected)
    {
        int[] actual = Solution.ThreeEqualParts(arr);
        Assert.Equal(expected, actual);
    }
}

public class ThreeSumClosestUnitTest
{
    public static TheoryData<int[], int, int> Data => new() { { [-1, 2, 1, -4], 1, 2 }, { [0, 0, 0], 1, 0 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int target, int expected)
    {
        int actual = Solution.ThreeSumClosest(nums, target);
        Assert.Equal(expected, actual);
    }
}

public class ThreeSumUnitTest
{
    public static TheoryData<int[], IList<IList<int>>> Data => new()
    {
        { [-1, 0, 1, 2, -1, -4], [[-1, -1, 2], [-1, 0, 1]] }, { [], [] }, { [0], [] }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(ThreeSumUnitTest))]
    public void MultipleDataTest(int[] nums, IList<IList<int>> expected)
    {
        IList<IList<int>> actual = Solution.ThreeSum(nums);
        Assert.Equal(expected, actual);
    }
}

public class TitleToNumberUnitTest
{
    [Theory]
    [InlineData("A", 1)]
    [InlineData("AB", 28)]
    [InlineData("ZY", 701)]
    public void MultipleDataTest(string columnTitle, int expected)
    {
        int actual = Solution.TitleToNumber(columnTitle);
        Assert.Equal(expected, actual);
    }
}

public class ToGoatLatinUnitTest
{
    [Theory]
    [InlineData("I speak Goat Latin", "Imaa peaksmaaa oatGmaaaa atinLmaaaaa")]
    [InlineData("The quick brown fox jumped over the lazy dog",
        "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa")]
    public void MultipleDataTest(string sentence, string expected)
    {
        string actual = Solution.ToGoatLatin(sentence);
        Assert.Equal(expected, actual);
    }
}

public class TotalFruitUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [1, 2, 1], 3 }, { [0, 1, 2, 2], 3 }, { [1, 2, 3, 2, 2], 4 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] fruits, int expected)
    {
        int actual = Solution.TotalFruit(fruits);
        Assert.Equal(expected, actual);
    }
}

public class TotalHammingDistanceUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [4, 14, 2], 6 }, { [4, 14, 4], 4 }, };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int expected)
    {
        int actual = Solution.TotalHammingDistance(nums);
        Assert.Equal(expected, actual);
    }
}

public class TrapUnitTest
{
    public static TheoryData<int[], int> Data => new()
    {
        { [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1], 6 }, { [4, 2, 0, 3, 2, 5], 9 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.Trap(nums);
        Assert.Equal(expected, actual);
    }
}

public class TrimBstUnitTest
{
    public static TheoryData<TreeNode, int, int, TreeNode> Data => new()
    {
        { Util.GenerateTreeNode([1, 0, 2]), 1, 2, Util.GenerateTreeNode([1, null, 2]) },
        { Util.GenerateTreeNode([3, 0, 4, null, 2, null, null, 1]), 1, 3, Util.GenerateTreeNode([3, 2, null, 1]) }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(TrimBstUnitTest))]
    public void MultipleDataTest(TreeNode root, int low, int high, TreeNode expected)
    {
        TreeNode actual = Solution.TrimBst(root, low, high);
        Assert.Equal(expected, actual, new TreeNodeComparer());
    }
}

public class TrimMeanUnitTest
{
    public static TheoryData<int[], double, double> Data => new()
    {
        { [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3], 2.00000d, 2.00001d },
        { [6, 2, 7, 5, 1, 2, 0, 3, 10, 2, 5, 0, 5, 5, 0, 8, 7, 6, 8, 0], 4.00000d, 4.00001d },
        {
            [
                6, 0, 7, 0, 7, 5, 7, 8, 3, 4, 0, 7, 8, 1, 6, 8, 1, 1, 2, 4, 8, 1, 9, 5, 4, 3, 8, 5, 10, 8, 6, 6, 1, 0,
                6, 10, 8, 2, 3, 4
            ],
            4.77777d, 4.77778d
        }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] arr, double low, double high)
    {
        double actual = Solution.TrimMean(arr);
        Assert.InRange(actual, low, high);
    }
}

public class TwoOutOfThreeUnitTest
{
    public static TheoryData<int[], int[], int[], IList<int>> Data => new()
    {
        { [1, 1, 3, 2], [2, 3], [3], [3, 2] },
        { [3, 1], [2, 3], [1, 2], [2, 3, 1] },
        { [1, 2, 2], [4, 3, 3], [5], [] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(TwoOutOfThreeUnitTest))]
    public void Test(int[] nums1, int[] nums2, int[] nums3, IList<int> expected)
    {
        IList<int> actual = Solution.TwoOutOfThree(nums1, nums2, nums3);
        actual = actual.OrderBy(x => x).ToList();
        expected = expected.OrderBy(x => x).ToList();
        Assert.Equal(expected, actual);
    }
}

public class TwoSumIiUnitTest
{
    public static TheoryData<int[], int, int[]> Data => new()
    {
        { [2, 7, 11, 15], 9, [1, 2] }, { [2, 3, 4], 6, [1, 3] }, { [-1, 0], -1, [1, 2] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test1(int[] numbers, int target, int[] expected)
    {
        int[] actual = Solution.TwoSumIi(numbers, target);
        Assert.Equal(expected, actual);
    }
}

public class TwoSumUnitTest
{
    public static TheoryData<int[], int, int[]> Data => new()
    {
        { [2, 7, 11, 15], 9, [0, 1] }, { [3, 2, 4], 6, [1, 2] }, { [3, 3], 6, [0, 1] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void TwoSumTest(int[] nums, int target, int[] expected)
    {
        int[] actual = Solution.TwoSum(nums, target);
        Assert.Equal(expected, actual);
    }
}
