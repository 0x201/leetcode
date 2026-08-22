namespace LeetCode.Tests.SolutionTests;

public class MajorityElementUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [3, 2, 3], 3 }, { [2, 2, 1, 1, 1, 2, 2], 2 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.MajorityElement(nums);
        Assert.Equal(expected, actual);
    }
}

public class MatrixUnitTest
{
    public static TheoryData<int[][], int[][]> Matrix => new()
    {
        { [[0, 0, 0], [0, 1, 0], [0, 0, 0]], [[0, 0, 0], [0, 1, 0], [0, 0, 0]] },
        { [[0, 0, 0], [0, 1, 0], [1, 1, 1]], [[0, 0, 0], [0, 1, 0], [1, 2, 1]] }
    };

    [Theory]
    [MemberData(nameof(Matrix))]
    public void Test(int[][] matrix, int[][] expected)
    {
        int[][] actual = Solution.UpdateMatrix(matrix);
        Assert.Equal(expected, actual);
    }
}

public class MaxAreaUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [1, 8, 6, 2, 5, 4, 8, 3, 7], 49 }, { [1, 1], 1 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] height, int expected)
    {
        int actual = Solution.MaxArea(height);
        Assert.Equal(expected, actual);
    }
}

public class MaxAscendingSumUnitTest
{
    public static TheoryData<int[], int> Data => new()
    {
        { [10, 20, 30, 5, 10, 50], 65 }, { [10, 20, 30, 40, 50], 150 }, { [12, 17, 15, 13, 10, 11, 12], 33 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] arr, int expected)
    {
        int actual = Solution.MaxAscendingSum(arr);
        Assert.Equal(expected, actual);
    }
}

public class MaxChunksToSortedUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [4, 3, 2, 1, 0], 1 }, { [1, 0, 2, 3, 4], 4 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] arr, int expected)
    {
        int actual = Solution.MaxChunksToSorted(arr);
        Assert.Equal(expected, actual);
    }
}

public class MaxDifferenceUnitTest
{
    public static TheoryData<int[], int> Data => new()
    {
        { [7, 1, 5, 4], 4 }, { [9, 4, 3, 2], -1 }, { [1, 5, 2, 10], 9 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] input, int expected)
    {
        int actual = Solution.MaximumDifference(input);
        Assert.Equal(expected, actual);
    }
}

public class MaximumBinaryStringUnitTest
{
    public static TheoryData<string, string> Data => new()
    {
        { "000110", "111011" }, { "01", "01" }, { "11", "11" }, { "1000", "1110" },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string binary, string expected)
    {
        string actual = Solution.MaximumBinaryString(binary);
        Assert.Equal(expected, actual);
    }
}

public class MaximumSwapUnitTest
{
    [Theory]
    [InlineData(2736, 7236)]
    [InlineData(9973, 9973)]
    public void Test(int num, int expected)
    {
        int actual = Solution.MaximumSwap(num);
        Assert.Equal(expected, actual);
    }
}

public class MaximumWealthUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { [[1, 2, 3], [3, 2, 1]], 6 }, { [[1, 5], [7, 3], [3, 5]], 10 }, { [[2, 8, 7], [7, 1, 3], [1, 9, 5],], 17 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] accounts, int expected)
    {
        int actual = Solution.MaximumWealth(accounts);
        Assert.Equal(expected, actual);
    }
}

public class MaxIncreaseKeepingSkylineUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { [[3, 0, 8, 4], [2, 4, 5, 7], [9, 2, 6, 3], [0, 3, 1, 0],], 35 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[][] grid, int expected)
    {
        int actual = Solution.MaxIncreaseKeepingSkyline(grid);
        Assert.Equal(expected, actual);
    }
}

public class MaxLengthBetweenEqualCharactersUnitTest
{
    [Theory]
    [InlineData("aa", 0)]
    [InlineData("abca", 2)]
    [InlineData("cbzyx", -1)]
    public void Test(string s, int expected)
    {
        int actual = Solution.MaxLengthBetweenEqualCharacters(s);
        Assert.Equal(expected, actual);
    }
}

public class MaxSubArrayUnitTest
{
    public static TheoryData<int[], int> Data => new()
    {
        { [-2, 1, -3, 4, -1, 2, 1, -5, 4], 6 }, { [1], 1 }, { [5, 4, -1, 7, 8], 23 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.MaxSubArray(nums);
        Assert.Equal(expected, actual);
    }
}

public class MaxValueUnitTest
{
    [Theory]
    [InlineData(4, 2, 6, 2)]
    [InlineData(6, 1, 10, 3)]
    public void Test(int n, int index, int maxSum, int expected)
    {
        int actual = Solution.MaxValue(n, index, maxSum);
        Assert.Equal(expected, actual);
    }
}

public class MergeAlternatelyUnitTest
{
    [Theory]
    [InlineData("abc", "pqr", "apbqcr")]
    [InlineData("ab", "pqrs", "apbqrs")]
    [InlineData("abcd", "pq", "apbqcd")]
    public void Test(string word1, string word2, string expected)
    {
        string actual = Solution.MergeAlternately(word1, word2);
        Assert.Equal(expected, actual);
    }
}

public class MergeKListsUnitTest
{
    public static TheoryData<ListNode[], ListNode> Data => new()
    {
        {
            [Util.GenerateListNode([1, 4, 5]), Util.GenerateListNode([1, 3, 4]), Util.GenerateListNode([2, 6])],
            Util.GenerateListNode([1, 1, 2, 3, 4, 4, 5, 6])
        },
        { [], null },
        { [null], null }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(MergeKListsUnitTest))]
    public void MultipleDataTest(ListNode[] lists, ListNode expected)
    {
        ListNode actual = Solution.MergeKLists(lists);
        Assert.Equal(expected, actual, new ListNodeComparer());
    }
}

public class MergeTwoListsUnitTest
{
    public static TheoryData<ListNode, ListNode, List<int>> Data => new()
    {
        {
            Util.GenerateListNode(new List<int> { 1, 2, 4 }), Util.GenerateListNode(new List<int> { 1, 3, 4 }),
            [1, 1, 2, 3, 4, 4]
        },
        { null, null, [] },
        { null, Util.GenerateListNode(new List<int> { 0 }), [0] }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(MergeTwoListsUnitTest))]
    public void Test(ListNode l1, ListNode l2, List<int> expected)
    {
        ListNode actualNode = Solution.MergeTwoLists(l1, l2);
        List<int> actual = Util.ConvertListNodeToList(actualNode);
        Assert.Equal(expected, actual);
    }
}

public class MergeUnitTest
{
    public static TheoryData<int[][], int[][]> Data => new()
    {
        { new int[][] { [1, 3], [2, 6], [8, 10], [15, 18] }, new int[][] { [1, 6], [8, 10], [15, 18] } },
        { new int[][] { [1, 4], [4, 5], }, new int[][] { [1, 5] } }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] input, int[][] expected)
    {
        int[][] actual = Solution.Merge(input);
        Assert.Equal(expected, actual);
    }
}

public class MiddleNodeUnitTest
{
    public static TheoryData<ListNode, ListNode> Data => new()
    {
        { Util.GenerateListNode([1, 2, 3, 4, 5, 6]), Util.GenerateListNode([4, 5, 6]) },
        { Util.GenerateListNode([1, 2, 3, 4, 5,]), Util.GenerateListNode([3, 4, 5]) }
    };

    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(MiddleNodeUnitTest))]
    public void Test_Input_Even_Data_Should_OK(ListNode input, ListNode expected)
    {
        ListNode actual = Solution.MiddleNode(input);
        Assert.Equal(expected, actual, new ListNodeComparer());
    }
}

public class MinAddToMakeValidUnitTest
{
    [Theory]
    [InlineData("())", 1)]
    [InlineData("(((", 3)]
    public void MultipleDataTest(string s, int expected)
    {
        int actual = Solution.MinAddToMakeValid(s);
        Assert.Equal(expected, actual);
    }
}

public class MinCostToHireWorkersUnitTest
{
    public static TheoryData<int[], int[], int, double, double> Data => new()
    {
        { [10, 20, 5], [70, 50, 30], 2, 105.00000, 105.000001 },
        { [3, 1, 10, 10, 1], [4, 8, 2, 2, 7], 3, 30.66666, 30.6666667 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] quality, int[] wage, int k, double low, double high)
    {
        double actual = Solution.MinCostToHireWorkers(quality, wage, k);
        Assert.InRange(actual, low, high);
    }
}

public class MinDeletionSizeUnitTest
{
    public static TheoryData<string[], int> Data => new()
    {
        { ["cba", "daf", "ghi"], 1 }, { ["a", "b"], 0 }, { ["zyx", "wvu", "tsr"], 3 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(string[] strs, int expected)
    {
        int actual = Solution.MinDeletionSize(strs);
        Assert.Equal(expected, actual);
    }
}

public class MinimumAddedCoinsUnitTest
{
    public static TheoryData<int[], int, int> Data => new() { { [1, 4, 10], 19, 2 }, { [1, 4, 10, 5, 7, 19], 19, 1 }, { [1, 1, 1], 20, 3 }, };


    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] coins, int target, int expected)
    {
        int actual = Solution.MinimumAddedCoins(coins, target);
        Assert.Equal(expected, actual);
    }
}

public class MinimumDifferenceUnitTest
{
    public static TheoryData<int[], int, int> Data => new() { { [90], 1, 0 }, { [9, 4, 1, 7], 2, 2 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int k, int expected)
    {
        int actual = Solution.MinimumDifference(nums, k);
        Assert.Equal(expected, actual);
    }
}

public class MinimumLengthUnitTest
{
    [Theory]
    [InlineData("ca", 2)]
    [InlineData("cabaabac", 0)]
    [InlineData("aabccabba", 3)]
    public void MultipleDataTest(string s, int expected)
    {
        int actual = Solution.MinimumLength(s);
        Assert.Equal(expected, actual);
    }
}

public class MinimumMovesUnitTest
{
    [Theory]
    [InlineData("XXX", 1)]
    [InlineData("XXOX", 2)]
    [InlineData("OOOO", 0)]
    public void MultipleDataTest(string s, int expected)
    {
        int actual = Solution.MinimumMoves(s);
        Assert.Equal(expected, actual);
    }
}

public class MinimumSumUnitTest
{
    public static TheoryData<int[], int> Data => new()
    {
        { [8, 6, 1, 5, 3], 9 }, { [5, 4, 8, 7, 10, 2], 13 }, { [6, 5, 4, 3, 4, 5], -1 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int expected)
    {
        int actual = Solution.MinimumSum(nums);
        Assert.Equal(expected, actual);
    }
}

public class MinimumTotalUnitTest
{
    [Fact]
    public void Test()
    {
        IList<IList<int>> data = [[2], [3, 4], [6, 5, 7], [4, 1, 8, 3]];
        int actual = Solution.MinimumTotal(data);
        const int expected = 11;
        Assert.Equal(expected, actual);
    }
}

public class MinMove2UnitTest
{
    public static TheoryData<int[], int> Data => new() { { [1, 2, 3], 2 }, { [1, 10, 2, 9], 16 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.MinMove2(nums);
        Assert.Equal(expected, actual);
    }
}

public class MinMovesToSeatUnitTest
{
    public static TheoryData<int[], int[], int> Data => new()
    {
        { [3, 1, 5], [2, 7, 4], 4 }, { [4, 1, 5, 9], [1, 3, 2, 6], 7 }, { [2, 2, 6, 6], [1, 3, 2, 6], 4 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] seats, int[] students, int expected)
    {
        int actual = Solution.MinMovesToSeat(seats, students);
        Assert.Equal(expected, actual);
    }
}

public class MinMovesUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [1, 2, 3], 3 }, { [1, 1, 1], 0 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.MinMoves(nums);
        Assert.Equal(expected, actual);
    }
}

public class MinOperations2UnitTest
{
    public static TheoryData<int[], int, int> Data => new()
    {
        { [1, 1, 4, 2, 3], 5, 2 }, { [5, 6, 7, 8, 9], 4, -1 }, { [3, 2, 20, 1, 1, 3], 10, 5 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int x, int expected)
    {
        int actual = Solution.MinOperations(nums, x);
        Assert.Equal(expected, actual);
    }
}

public class MinOperationsUnitTest
{
    public static TheoryData<string[], int> Data => new()
    {
        { ["d1/", "d2/", "../", "d21/", "./"], 2 },
        { ["d1/", "d2/", "./", "d3/", "../", "d31/"], 3 },
        { ["d1/", "../", "../", "../"], 0 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string[] logs, int expected)
    {
        int actual = Solution.MinOperations(logs);
        Assert.Equal(expected, actual);
    }
}

public class MinPathSumUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { new int[][] { [1, 2, 3, 1], [4, 5, 6, 1], [7, 8, 9, 1] }, 9 },
        { new int[][] { [1, 2, 3, 1], [4, 2, 6, 1], [7, 1, 1, 1] }, 8 },
        { new int[][] { [1, 1, 1, 1], [1, 1, 1, 1], [1, 1, 1, 1] }, 6 },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[][] grid, int expected)
    {
        int actual = Solution.MinPathSum(grid);
        Assert.Equal(expected, actual);
    }
}

public class MinRemoveToMakeValidUnitTest
{
    [Theory]
    [InlineData("lee(t(c)o)de)", "lee(t(c)o)de")]
    [InlineData("a)b(c)d", "ab(c)d")]
    [InlineData("))((", "")]
    public void MultipleDataTest(string testInput, string expected)
    {
        string actual = Solution.MinRemoveToMakeValid(testInput);
        Assert.Equal(expected, actual);
    }
}

public class MinStackUnitTest
{
    [Fact]
    public void Test()
    {
        var min = new MinStack();
        min.Push(-2);
        min.Push(0);
        min.Push(-3);
        Assert.Equal(-3, min.GetMin());
        min.Pop();
        Assert.Equal(0, min.Top());
        Assert.Equal(-2, min.GetMin());
    }
}

public class MinSubsequenceUnitTest
{
    public static TheoryData<int[], IList<int>> Data => new()
    {
        { [4, 3, 10, 9, 8], [10, 9] }, { [4, 4, 7, 6, 7], [7, 7, 6] }, { [6], [6] }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(MinSubsequenceUnitTest))]
    public void MultipleDataTest(int[] input, IList<int> expected)
    {
        IList<int> actual = Solution.MinSubsequence(input);
        Assert.Equal(expected, actual);
    }
}

public class MinSwapUnitTest
{
    public static TheoryData<int[], int[], int> Data => new()
    {
        { [1, 3, 5, 4], [1, 2, 3, 7], 1 }, { [0, 3, 5, 8, 9], [2, 1, 4, 6, 9], 1 },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums1, int[] nums2, int expected)
    {
        int actual = Solution.MinSwap(nums1, nums2);
        Assert.Equal(expected, actual);
    }
}

public class MostCommonWordUnitTest
{
    public static TheoryData<string, string[], string> Data => new()
    {
        { "Bob hit a ball, the hit BALL flew far after it was hit.", ["hit"], "ball" }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string paragraph, string[] banned, string expected)
    {
        string actual = Solution.MostCommonWord(paragraph, banned);
        Assert.Equal(expected, actual);
    }
}

public class MoveZeroUnitTest
{
    public static TheoryData<int[], int[]> Data => new()
    {
        {[0, 1, 0, 3, 12],[1, 3, 12, 0, 0]},
        {[0],[0]}
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] nums, int[] expected)
    {
        Solution.MoveZeroes(nums);
        Assert.Equal(expected, nums);
    }
}

public class MultiplyUnitTest
{
    [Theory]
    [InlineData("2", "3", "6")]
    [InlineData("123", "456", "56088")]
    public void MultipleDataTest(string num1, string num2, string expected)
    {
        string actual = Solution.Multiply(num1, num2);
        Assert.Equal(expected, actual);
    }
}

public class MyCircularQueueUnitTest
{
    [Fact]
    public void Test()
    {
        var myCircularQueue = new MyCircularQueue(3);
        Assert.True(myCircularQueue.EnQueue(1)); // return True
        Assert.True(myCircularQueue.EnQueue(2)); // return True
        Assert.True(myCircularQueue.EnQueue(3)); // return True
        Assert.False(myCircularQueue.EnQueue(4)); // return False
        Assert.Equal(3, myCircularQueue.Rear()); // return 3
        Assert.True(myCircularQueue.IsFull()); // return True
        Assert.True(myCircularQueue.DeQueue()); // return True
        Assert.True(myCircularQueue.EnQueue(4)); // return True
        Assert.Equal(4, myCircularQueue.Rear()); // return 4
    }
}

public class MyPowUnitTest
{
    [Theory]
    [InlineData(2.00000d, 10, 1024.00000d)]
    [InlineData(2.10000d, 3, 9.26100d)]
    [InlineData(2.00000d, -2, 0.25000d)]
    public void MultipleDataTest(double x, int n, double expected)
    {
        double actual = Solution.MyPow(x, n);
        Assert.Equal((decimal)expected, (decimal)actual);
    }
}

public class MyQueueUnitTest
{
    [Fact]
    public void OnlyPushAndPop()
    {
        var queue = new MyQueue();
        queue.Push(1);
        int actual = queue.Pop();
        bool actualResult = queue.Empty();

        Assert.Equal(1, actual);
        Assert.True(actualResult);
    }
}
