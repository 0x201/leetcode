namespace LeetCode.Tests.SolutionTests;

public class ScoreOfParenthesesUnitTest
{
    [Theory]
    [InlineData("()", 1)]
    [InlineData("(())", 2)]
    [InlineData("()()", 2)]
    public void Test(string s, int expected)
    {
        int actual = Solution.ScoreOfParentheses(s);
        Assert.Equal(expected, actual);
    }
}

public class SearchInRotatedSortedArrayUnitTest
{
    [Theory]
    [InlineData(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [InlineData(new[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
    [InlineData(new[] { 1 }, 0, -1)]
    public void MultipleDataTest(int[] nums, int target, int expected)
    {
        int actual = Solution.Search(nums, target);
        Assert.Equal(expected, actual);
    }
}

public class SearchInsertUnitTest
{
    public static TheoryData<int[], int, int> Data => new()
    {
        { [1, 3, 5, 6], 5, 2 }, { [1, 3, 5, 6], 2, 1 }, { [1, 3, 5, 6], 7, 4 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int target, int expected)
    {
        int actual = Solution.SearchInsert(nums, target);
        Assert.Equal(expected, actual);
    }
}

public class SearchMatrixUnitTest
{
    public static TheoryData<int[][], int, bool> Data => new()
    {
        { [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], 3, true },
        { [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], 13, false }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[][] matrix, int target, bool expected)
    {
        bool actual = Solution.SearchMatrix(matrix, target);
        Assert.Equal(expected, actual);
    }
}

public class SearchRangeUnitTest
{
    public static TheoryData<int[], int, int[]> Data => new()
    {
        { [5, 7, 7, 8, 8, 10], 8, [3, 4] }, { [5, 7, 7, 8, 8, 10], 6, [-1, -1] }, { [], 0, [-1, -1] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int target, int[] expected)
    {
        int[] actual = Solution.SearchRange(nums, target);
        Assert.Equal(expected, actual);
    }
}

public class SelfDividingNumberUnitTest
{
    public static TheoryData<int, int, int[]> Data => new()
    {
        { 1, 22, [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22] }, { 47, 85, [48, 55, 66, 77] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int left, int right, int[] expected)
    {
        IList<int> actual = Solution.SelfDividingNumbers(left, right);
        Assert.Equal(expected, actual.ToArray());
    }
}

public class SetZeroesUnitTest
{
    public static TheoryData<int[][], int[][]> Data => new()
    {
        { [[1, 1, 1], [1, 0, 1], [1, 1, 1]], [[1, 0, 1], [0, 0, 0], [1, 0, 1]] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] input, int[][] expected)
    {
        Solution.SetZeroes(input);
        Assert.Equal(input, expected);
    }
}

public class ShortestBridgeUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { [[0, 1], [1, 0]], 1 },
        { [[0, 1, 0], [0, 0, 0], [0, 0, 1]], 2 },
        { [[1, 1, 1, 1, 1], [1, 0, 0, 0, 1], [1, 0, 1, 0, 1], [1, 0, 0, 0, 1], [1, 1, 1, 1, 1],], 1 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] grid, int expected)
    {
        int actual = Solution.ShortestBridge(grid);
        Assert.Equal(expected, actual);
    }
}

public class ShortestPathBinaryMatrixUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { [[0, 1], [1, 0]], 2 }, { [[0, 0, 0], [1, 1, 0], [1, 1, 0]], 4 }, { [[1, 0, 0], [1, 1, 0], [1, 1, 0]], -1 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] grid, int expected)
    {
        int actual = Solution.ShortestPathBinaryMatrix(grid);
        Assert.Equal(expected, actual);
    }
}

public class ShuffleUnitTest
{
    public static TheoryData<int[], int, int[]> Data => new()
    {
        { [2, 5, 1, 3, 4, 7], 3, [2, 3, 5, 4, 1, 7] },
        { [1, 2, 3, 4, 4, 3, 2, 1], 4, [1, 4, 2, 3, 3, 2, 4, 1] },
        { [1, 1, 2, 2], 2, [1, 2, 1, 2] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int n, int[] expected)
    {
        int[] actual = Solution.Shuffle(nums, n);
        Assert.Equal(expected, actual);
    }
}

public class SimplifiedFractionsUnitTest
{
    public static TheoryData<int, string[]> Data => new() { { 2, ["1/2"] } };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int n, string[] expected)
    {
        IList<string> list = Solution.SimplifiedFractions(n);
        string[] actual = list.ToArray();
        Assert.Equal(expected, actual);
    }
}

public class SimplifyPathUnitTest
{
    [Theory]
    [InlineData("/home/", "/home")]
    [InlineData("/../", "/")]
    [InlineData("/home//foo/", "/home/foo")]
    [InlineData("/a/./b/../../c/", "/c")]
    public void Test(string path, string expected)
    {
        string actual = Solution.SimplifyPath(path);
        Assert.Equal(expected, actual);
    }
}

public class SingleNonDuplicateUnitTest
{
    public static TheoryData<int[], int> Data => new()
    {
        { [1, 1, 2, 3, 3, 4, 4, 8, 8], 2 }, { [3, 3, 7, 7, 10, 11, 11], 10 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int expected)
    {
        int actual = Solution.SingleNonDuplicate(nums);
        Assert.Equal(expected, actual);
    }
}

public class SingleNumberUnitTest
{
    public static TheoryData<int[], int> DataV1 = new() { { [2, 2, 1], 1 }, { [4, 1, 2, 1, 2], 4 }, { [1], 1 } };
    public static TheoryData<int[], int> DataV2 = new() { { [2, 2, 3, 2], 3 }, { [0, 1, 0, 1, 0, 1, 99], 99 } };

    public static TheoryData<int[], int[]> DataV3 = new()
    {
        { [1, 2, 1, 3, 2, 5], [3, 5] }, { [-1, 0], [-1, 0] }, { [0, 1], [1, 0] }
    };

    [Theory]
    [MemberData(nameof(DataV1))]
    public void Test_SingleNumber(int[] nums, int expected)
    {
        int actual = Solution.SingleNumber(nums);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(DataV2))]
    public void Test_SingleNumber_V2(int[] nums, int expected)
    {
        int actual = Solution.SingleNumberV2(nums);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(DataV3))]
    public void Test_SingleNumber_V3(int[] nums, int[] expected)
    {
        int[] actual = Solution.SingleNumberV3(nums);
        Assert.Equal(expected, actual);
    }
}

public class SmallestRangeIUnitTest
{
    public static TheoryData<int[], int, int> Data => new() { { [1], 0, 0 }, { [0, 10], 2, 6 }, { [1, 3, 6], 3, 0 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int k, int expected)
    {
        int actual = Solution.SmallestRangeI(nums, k);
        Assert.Equal(expected, actual);
    }
}

public class SolveSudokuUnitTest
{
    public static TheoryData<char[][], char[][]> Data => new()
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
            [
                ['5', '3', '4', '6', '7', '8', '9', '1', '2'],
                ['6', '7', '2', '1', '9', '5', '3', '4', '8'],
                ['1', '9', '8', '3', '4', '2', '5', '6', '7'],
                ['8', '5', '9', '7', '6', '1', '4', '2', '3'],
                ['4', '2', '6', '8', '5', '3', '7', '9', '1'],
                ['7', '1', '3', '9', '2', '4', '8', '5', '6'],
                ['9', '6', '1', '5', '3', '7', '2', '8', '4'],
                ['2', '8', '7', '4', '1', '9', '6', '3', '5'],
                ['3', '4', '5', '2', '8', '6', '1', '7', '9']
            ]
        }
    };


    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(char[][] board, char[][] expected)
    {
        Solution.SolveSudoku(board);
        Assert.Equal(expected, board);
    }
}

public class SortArrayByParityUnitTest
{
    public static TheoryData<int[], int[]> Data => new() { { [3, 1, 2, 4], [4, 2, 1, 3] }, { [0], [0] } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int[] expected)
    {
        int[] actual = Solution.SortArrayByParity(nums);
        Assert.Equal(expected, actual);
    }
}

public class SortedListToBstUnitTest
{
    public static TheoryData<int[], List<int?>> Data => new()
    {
        {[-10, -3, 0, 5, 9],[0, -10, 5, null, -3, null, 9]}
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(SortedListToBstUnitTest))]
    public void Test(int[] nums, List<int?> expectedNodes)
    {
        TreeNode actualNode = Solution.SortedArrayToBst(nums);
        TreeNode expectedNode = Util.GenerateTreeNode(expectedNodes);
        List<int> actual = Util.PreorderTraversal(actualNode);
        List<int> expected = Util.PreorderTraversal(expectedNode);
        Assert.Equal(expected, actual);
    }
}

public class SortedSquaresUnitTest
{
    public static TheoryData<int[], int[]> Data => new()
    {
        { [-4, -1, 0, 3, 10], [0, 1, 9, 16, 100] },
        { [0, 3, 4, 6, 10], [0, 9, 16, 36, 100] },
        { [-10, -6, -5, -4, -3], [9, 16, 25, 36, 100] },
        { [-7, -3, 2, 3, 11], [4, 9, 9, 49, 121] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test_Should_Ok(int[] nums, int[] expected)
    {
        int[] actual = Solution.SortedSquares(nums);
        Assert.Equal(expected, actual);
    }
}

public class SpecialArrayUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [3, 5], 2 }, { [0, 0], -1 }, { [0, 4, 3, 0, 4], 3 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.SpecialArray(nums);
        Assert.Equal(expected, actual);
    }
}

public class SpiralOrderUnitTest
{
    public static TheoryData<int[][], IList<int>> Data => new()
    {
        { [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]], [1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7] },
        { [[1, 2, 3], [4, 5, 6], [7, 8, 9]], [1, 2, 3, 6, 9, 8, 7, 4, 5] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(SpiralOrderUnitTest))]
    public void MultipleDataTest(int[][] matrix, IList<int> expected)
    {
        IList<int> actual = Solution.SpiralOrder(matrix);
        Assert.Equal(expected, actual);
    }
}

public class StockSpannerUnitTest
{
    [Fact]
    public void MultipleDataTest()
    {
        StockSpanner stockSpanner = new();
        Assert.Equal(1, stockSpanner.Next(100));
        Assert.Equal(1, stockSpanner.Next(80));
        Assert.Equal(1, stockSpanner.Next(60));
        Assert.Equal(2, stockSpanner.Next(70));
        Assert.Equal(1, stockSpanner.Next(60));
        Assert.Equal(4, stockSpanner.Next(75));
        Assert.Equal(6, stockSpanner.Next(85));
    }
}

public class StringMatchingUnitTest
{
    public static TheoryData<string[], IList<string>> Data => new()
    {
        { ["mass", "as", "hero", "superhero"], ["as", "hero"] },
        { ["leetcode", "et", "code"], ["et", "code"] },
        { ["blue", "green", "bu"], [] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(StringMatchingUnitTest))]
    public void MultipleDataTest(string[] words, IList<string> expected)
    {
        IList<string> actual = Solution.StringMatching(words);
        Assert.Equal(expected, actual);
    }
}

public class StrStrUnitTest
{
    [Theory]
    [InlineData("hello", "ll", 2)]
    [InlineData("aaaaa", "bba", -1)]
    public void MultipleDataTest(string haystack, string needle, int expected)
    {
        int actual = Solution.StrStr(haystack, needle);
        Assert.Equal(expected, actual);
    }
}

public class SubdomainVisitsUnitTest
{
    public static TheoryData<string[], IList<string>> Data => new()
    {
        { ["9001 discuss.leetcode.com"], ["9001 leetcode.com", "9001 discuss.leetcode.com", "9001 com"] },
        {
            ["900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"], [
                "901 mail.com", "50 yahoo.com", "900 google.mail.com", "5 wiki.org", "5 org", "1 intel.mail.com",
                "951 com"
            ]
        }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(SubdomainVisitsUnitTest))]
    public void Test(string[] cpdomains, IList<string> expected)
    {
        IList<string> actual = Solution.SubdomainVisit(cpdomains);
        actual = actual.OrderBy(x => x).ToList();
        expected = expected.OrderBy(x => x).ToList();
        Assert.Equal(expected, actual);
    }
}

public class SumRootToLeafUnitTest
{
    public static TheoryData<TreeNode, int> Data => new()
    {
        { Util.GenerateTreeNode([1, 0, 1, 0, 1, 0, 1]), 22 }, { Util.GenerateTreeNode([0]), 0 }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(SumRootToLeafUnitTest))]
    public void MultipleDataTest(TreeNode root, int expected)
    {
        int actual = Solution.SumRootToLeaf(root);
        Assert.Equal(expected, actual);
    }
}

public class SwapPairsUnitTest
{
    public static TheoryData<ListNode, ListNode> Data => new()
    {
        { Util.GenerateListNode([1, 2, 3, 4]), Util.GenerateListNode([2, 1, 4, 3]) },
        { Util.GenerateListNode(Array.Empty<int>()), Util.GenerateListNode(Array.Empty<int>()) },
        { Util.GenerateListNode([1]), Util.GenerateListNode([1]) }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(SwapPairsUnitTest))]
    public void MultipleDataTest(ListNode head, ListNode expected)
    {
        ListNode actual = Solution.SwapPairs(head);
        Assert.Equal(expected, actual, new ListNodeComparer());
    }
}
