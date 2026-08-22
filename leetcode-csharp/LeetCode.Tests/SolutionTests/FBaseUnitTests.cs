namespace LeetCode.Tests.SolutionTests;

public class FibonacciNumberUnitTest
{
    [Theory]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    public void Test(int n, int expected)
    {
        int actual = Solution.Fib(n);
        Assert.Equal(expected, actual);
    }
}

public class FinalPricesUnitTest
{
    public static TheoryData<int[], int[]> Data => new()
    {
        { [8, 4, 6, 2, 3], [4, 2, 4, 2, 3] }, { [1, 2, 3, 4, 5], [1, 2, 3, 4, 5] }, { [10, 1, 1, 6], [9, 0, 1, 6] },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] prices, int[] expected)
    {
        int[] actual = Solution.FinalPrices(prices);
        Assert.Equal(expected, actual);
    }
}

public class FinalStringUnitTest
{
    [Theory]
    [InlineData("string", "rtsng")]
    [InlineData("poiinter", "ponter")]
    public void Test(string input, string expected)
    {
        string actual = Solution.FinalString(input);
        Assert.Equal(expected, actual);
    }
}

public class FinalValueAfterOperationsUnitTest
{
    public static TheoryData<string[], int> Data => new()
    {
        { ["--X", "X++", "X++"], 1 }, { ["++X", "++X", "X++"], 3 }, { ["X++", "++X", "--X", "X--"], 0 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string[] operations, int expected)
    {
        int actual = Solution.FinalValueAfterOperations(operations);
        Assert.Equal(expected, actual);
    }
}

public class FindCenterUnitTest
{
    public static TheoryData<int[][], int> Edges => new()
    {
        { [[1, 2], [2, 3], [4, 2]], 2 }, { [[1, 2], [5, 1], [1, 3], [1, 4]], 1 }
    };


    [Theory]
    [MemberData(nameof(Edges))]
    public void Test(int[][] edges, int expected)
    {
        int actual = Solution.FindCenter(edges);
        Assert.Equal(expected, actual);
    }
}

public class FindIndicesUnitTest
{
    public static TheoryData<int[], int, int, int[]> Data => new()
    {
        { [5,1,4,1], 2, 4, [0, 3] }, { [2, 1], 0, 0, [0, 0] }, { [1, 2, 3], 2, 4, [-1, -1] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(FindIndicesUnitTest))]
    public void MultipleDataTest(int[] nums, int indexDifference, int valueDifference, int[] expected)
    {
        int[] actual = Solution.FindIndices(nums, indexDifference, valueDifference);
        Assert.Equal(expected, actual);
    }
}

public class FindClosestElementsUnitTest
{
    public static TheoryData<int[], int, int, IList<int>> Data => new()
    {
        { [1, 2, 3, 4, 5], 4, 3, [1, 2, 3, 4] }, { [1, 2, 3, 4, 5], 4, -1, [1, 2, 3, 4] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(FindClosestElementsUnitTest))]
    public void MultipleDataTest(int[] arr, int k, int x, IList<int> expected)
    {
        IList<int> actual = Solution.FindClosestElements(arr, k, x);
        Assert.Equal(expected, actual);
    }
}

public class FindDiagonalOrderUnitTest
{
    public static TheoryData<int[][], int[]> Data => new()
    {
        { [[1, 2, 3], [4, 5, 6], [7, 8, 9]], [1, 2, 4, 7, 5, 3, 6, 8, 9] }, { [[1, 2], [3, 4]], [1, 2, 3, 4] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] matrix, int[] expected)
    {
        int[] actual = Solution.FindDiagonalOrder(matrix);
        Assert.Equal(expected, actual);
    }
}

public class FindDuplicateSubtreesUnitTest
{
    public static TheoryData<TreeNode, IList<TreeNode>> Data => new()
    {
        {
            Util.GenerateTreeNode([1, 2, 3, 4, null, 2, 4, null, null, 4]),
            new List<TreeNode> { Util.GenerateTreeNode([4]), Util.GenerateTreeNode([2, 4]), }
        },
        { Util.GenerateTreeNode([2, 1, 1]), new List<TreeNode> { Util.GenerateTreeNode([1]) } },
        {
            Util.GenerateTreeNode([2, 2, 2, 3, null, 3, null]),
            new List<TreeNode> { Util.GenerateTreeNode([3]), Util.GenerateTreeNode([2, 3]), }
        }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(FindDuplicateSubtreesUnitTest))]
    public void MultipleDataTest(TreeNode root, IList<TreeNode> expected)
    {
        IList<TreeNode> actual = Solution.FindDuplicateSubtrees(root);
        Assert.Equal(expected, actual, new TreeNodeComparer());
    }
}

public class FindLongestChainUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { [[1, 2], [2, 3], [3, 4]], 2 }, { [[1, 2], [7, 8], [4, 5]], 3 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] pairs, int expected)
    {
        int actual = Solution.FindLongestChain(pairs);
        Assert.Equal(expected, actual);
    }
}

public class FindLusLengthUnitTest
{
    [Theory]
    [InlineData("aba", "cdc", 3)]
    [InlineData("aaa", "bbb", 3)]
    [InlineData("aaa", "aaa", -1)]
    public void MultipleDataTest(string a, string b, int expected)
    {
        int actual = Solution.FindLusLength(a, b);
        Assert.Equal(expected, actual);
    }
}

public class FindMedianSortedArraysUnitTest
{
    public static TheoryData<int[], int[], double> Data => new()
    {
        { [1, 3], [2], 2.00000 }, { [1, 2], [3, 4], 2.50000 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] numbers1, int[] numbers2, double expected)
    {
        double actual = Solution.FindMedianSortedArrays(numbers1, numbers2);
        Assert.Equal(expected, actual);
    }
}

public class FindMiddleIndexUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [2, 3, -1, 8, 4], 3 }, { [1, -1, 4], 2 }, { [2, 5], -1 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.FindMiddleIndex(nums);
        Assert.Equal(expected, actual);
    }
}

public class FindPeakElementUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [1, 2, 3, 1], 2 }, { [1, 2, 1, 3, 5, 6, 4], 5 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] arr, int expected)
    {
        int actual = Solution.FindPeakElement(arr);
        Assert.Equal(expected, actual);
    }
}

public class FindRestaurantUnitTest
{
    public static TheoryData<string[], string[], string[]> Data => new()
    {
        {
            ["Shogun", "Tapioca Express", "Burger King", "KFC"],
            ["Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun"], ["Shogun"]
        },
        { ["Shogun", "Tapioca Express", "Burger King", "KFC"], ["KFC", "Shogun", "Burger King"], ["Shogun"] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string[] list1, string[] list2, string[] expect)
    {
        string[] actual = Solution.FindRestaurant(list1, list2);
        Assert.Equal(expect, actual);
    }
}

public class FindSubstringInWraparoundStringUnitTest
{
    [Theory]
    [InlineData("a", 1)]
    [InlineData("cac", 2)]
    [InlineData("zab", 6)]
    public void Test(string p, int expected)
    {
        int actual = Solution.FindSubstringInWraparoundString(p);
        Assert.Equal(expected, actual);
    }
}

public class FindSubstringUnitTest
{
    public static TheoryData<string, string[], IList<int>> Data => new()
    {
        { "barfoothefoobarman", ["foo", "bar"], [0, 9] },
        { "wordgoodgoodgoodbestword", ["word", "good", "best", "word"], [] },
        { "barfoofoobarthefoobarman", ["bar", "foo", "the"], [6, 9, 12] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(FindSubstringUnitTest))]
    public void MultipleDataTest(string s, string[] words, IList<int> expected)
    {
        IList<int> actual = Solution.FindSubstring(s, words);
        Assert.Equal(expected, actual);
    }
}

public class FindTargetUnitTest
{
    public static TheoryData<TreeNode, int, bool> Data => new()
    {
        { Util.GenerateTreeNode([5, 3, 6, 2, 4, null, 7]), 9, true },
        { Util.GenerateTreeNode([5, 3, 6, 2, 4, null, 7]), 28, false }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(FindTargetUnitTest))]
    public void Test(TreeNode root, int target, bool expected)
    {
        bool actual = Solution.FindTarget(root, target);
        Assert.Equal(expected, actual);
    }
}

public class FindTheWinnerUnitTest
{
    [Theory]
    [InlineData(5, 2, 3)]
    [InlineData(6, 5, 1)]
    public void MultipleDataTest(int n, int k, int expected)
    {
        int actual = Solution.FindTheWinner(n, k);
        Assert.Equal(expected, actual);
    }
}

public class FindWordsIiUnitTest
{
    public static TheoryData<char[][], string[], IList<string>> Data => new()
    {
        {
            [
                ['o', 'a', 'a', 'n'],
                ['e', 't', 'a', 'e'],
                ['i', 'h', 'k', 'r'],
                ['i', 'f', 'l', 'v']
            ],
            ["oath", "pea", "eat", "rain"], ["oath", "eat"]
        },
        {
            [
                ['a', 'b'],
                ['c', 'd']
            ],
            ["abcb"], []
        }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(FindWordsIiUnitTest))]
    public void MultipleDataTest(char[][] board, string[] words, IList<string> expected)
    {
        IList<string> actual = Solution.FindWords(board, words);
        Assert.Equal(expected, actual);
    }
}

public class FirstDayBeenInAllRoomsUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [0, 0], 2 }, { [0, 0, 2], 6 }, { [0, 1, 2, 0], 6 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nextVisit, int expected)
    {
        int actual = Solution.FirstDayBeenInAllRooms(nextVisit);
        Assert.Equal(expected, actual);
    }
}

public class FirstMissingPositiveUnitTest
{
    public static TheoryData<int[], int> Data =>
        new() { { [1, 2, 0], 3 }, { [3, 4, -1, 1], 2 }, { [7, 8, 9, 11, 12], 1 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.FirstMissingPositive(nums);
        Assert.Equal(expected, actual);
    }
}

public class FizzBuzzUnitTest
{
    public static TheoryData<int, IList<string>> Data => new()
    {
        { 3, ["1", "2", "Fizz"] },
        { 5, ["1", "2", "Fizz", "4", "Buzz"] },
        {
            15,
            ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"]
        }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(FizzBuzzUnitTest))]
    public void Test(int n, IList<string> expected)
    {
        IList<string> actual = Solution.FizzBuzz(n);
        Assert.Equal(expected, actual);
    }
}

public class FlipLightsUnitTest
{
    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 1, 3)]
    [InlineData(3, 1, 4)]
    public void Test(int n, int presses, int expected)
    {
        int actual = Solution.FlipLights(n, presses);
        Assert.Equal(expected, actual);
    }
}

public class FloodFillUnitTest
{
    public static TheoryData<int[][], int, int, int, int[][]> Data => new()
    {
        { [[1, 1, 1], [1, 1, 0], [1, 0, 1],], 1, 1, 2, [[2, 2, 2], [2, 2, 0], [2, 0, 1]] },
        { [[0, 0, 0], [0, 0, 0]], 0, 0, 2, [[2, 2, 2], [2, 2, 2]] }
    };


    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[][] input, int sr, int sc, int newColor, int[][] expected)
    {
        int[][] actual = Solution.FloodFill(input, sr, sc, newColor);
        Assert.Equal(expected, actual);
    }
}

public class FooBarUnitTest
{
    public static TheoryData<int, string> Data =>
        new() { { 1, "foobar" }, { 2, "foobarfoobar" }, { 4, "foobarfoobarfoobarfoobar" }, };


    [Theory]
    [MemberData(nameof(Data))]
    public async Task Test(int n, string expected)
    {
        var foobar = new FooBar(n);
        string actual = "";

        var fooTask = Task.Run(() => foobar.Foo(() => actual += "foo"), TestContext.Current.CancellationToken);
        var barTask = Task.Run(() => foobar.Bar(() => actual += "bar"), TestContext.Current.CancellationToken);
        await Task.WhenAll(fooTask, barTask);

        Assert.Equal(expected, actual);
    }
}

public class FourSumUnitTest
{
    public static TheoryData<int[], int, IList<IList<int>>> Data => new()
    {
        { [1, 0, -1, 0, -2, 2], 0, [[-2, -1, 1, 2], [-2, 0, 0, 2], [-1, 0, 0, 1]] },
        { [2, 2, 2, 2, 2], 8, [[2, 2, 2, 2],] }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(FourSumUnitTest))]
    public void MultipleDataTest(int[] nums, int target, IList<IList<int>> expected)
    {
        IList<IList<int>> actual = Solution.FourSum(nums, target);
        Assert.Equal(expected, actual);
    }
}

public class FrequencySortUnitTest
{
    public static TheoryData<int[], int[]> Data => new()
    {
        { [1, 1, 2, 2, 2, 3], [3, 1, 1, 2, 2, 2] },
        { [2, 3, 1, 3, 2], [1, 3, 3, 2, 2] },
        { [-1, 1, -6, 4, 5, -6, 1, 4, 1], [5, -1, 4, 4, -6, -6, 1, 1, 1] }
    };


    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int[] expected)
    {
        int[] actual = Solution.FrequencySort(nums);
        Assert.Equal(expected, actual);
    }
}

public class FullJustifyUnitTest
{
    public static TheoryData<string[], int, IList<string>> Data => new()
    {
        {
            [
                "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.",
                "Art", "is", "everything", "else", "we", "do"
            ],
            20,
            [
                "Science  is  what we",
                "understand      well",
                "enough to explain to",
                "a  computer.  Art is",
                "everything  else  we",
                "do                  "
            ]
        }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(FullJustifyUnitTest))]
    public void Test(string[] words, int maxWidth, IList<string> expected)
    {
        IList<string> actual = Solution.FullJustify(words, maxWidth);
        Assert.Equal(expected, actual);
    }
}
