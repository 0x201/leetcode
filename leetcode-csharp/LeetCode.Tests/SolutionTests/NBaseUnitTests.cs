namespace LeetCode.Tests.SolutionTests;

public class NearestValidPointUnitTest
{
    public static TheoryData<int, int, int[][], int> Data => new()
    {
        { 3, 4, [[1, 2], [3, 1], [2, 4], [2, 3], [4, 4]], 2 }, { 3, 4, [[3, 4]], 0 }, { 3, 4, [[2, 3]], -1 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int x, int y, int[][] points, int expected)
    {
        int actual = Solution.NearestValidPoint(x, y, points);
        Assert.Equal(expected, actual);
    }
}

public class NextPermutationUnitTest
{
    public static TheoryData<int[], int[]> Data => new()
    {
        { [1, 2, 3], [1, 3, 2] }, { [3, 2, 1], [1, 2, 3] }, { [1, 1, 5], [1, 5, 1] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int[] expected)
    {
        Solution.NextPermutation(nums);
        Assert.Equal(expected, nums);
    }
}

public class NumberOfLinesUnitTest
{
    public static TheoryData<int[], string, int[]> Data => new()
    {
        {
            [10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10],
            "abcdefghijklmnopqrstuvwxyz", [3, 60]
        },
        {
            [4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10],
            "bbbcccdddaaa", [2, 4]
        }
    };


    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] widths, string s, int[] expected)
    {
        int[] actual = Solution.NumberOfLines(widths, s);
        Assert.Equal(expected, actual);
    }
}

public class NumComponentsUnitTest
{
    public static TheoryData<ListNode, int[], int> Data => new()
    {
        { Util.GenerateListNode([0, 1, 2, 3]), [0, 1, 3], 2 },
        { Util.GenerateListNode([0, 1, 2, 3, 4]), [0, 3, 1, 4], 2 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(ListNode head, int[] nums, int expected)
    {
        int actual = Solution.NumComponents(head, nums);
        Assert.Equal(expected, actual);
    }
}

public class NumMatrixUnitTest
{
    private readonly int[][] _matrix =
    [
        [3, 0, 1, 4, 2],
        [5, 6, 3, 2, 1],
        [1, 2, 0, 1, 5],
        [4, 1, 0, 1, 7],
        [1, 0, 3, 0, 5]
    ];

    public static TheoryData<int[], int> Data => new()
    {
        { [2, 1, 4, 3], 8 }, { [1, 1, 2, 2], 11 }, { [1, 2, 2, 4], 12 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] points, int expected)
    {
        NumMatrix nm = new(_matrix);
        int actual = nm.SumRange(points[0], points[1], points[2], points[3]);
        Assert.Equal(expected, actual);
    }
}

public class NumSpecialUnitTest
{
    public static TheoryData<int[][], int> Data => new()
    {
        { [[1, 0, 0], [0, 0, 1], [1, 0, 0],], 1 }, { [[1, 0, 0], [0, 1, 0], [0, 0, 1],], 3 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[][] mat, int expected)
    {
        int actual = Solution.NumSpecial(mat);
        Assert.Equal(expected, actual);
    }
}
