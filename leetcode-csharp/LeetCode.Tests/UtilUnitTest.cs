namespace LeetCode.Tests;

public class UtilUnitTest
{
    public static TheoryData<List<int?>, TreeNode> TreeNodeData => new()
    {
        { [1, 2, 3], new TreeNode(1, new TreeNode(2), new TreeNode(3)) },
        { [1, null, 3], new TreeNode(1, null, new TreeNode(3)) }
    };

    public static TheoryData<int[][], string> MatrixData => new()
    {
        {
            [
                [1, 2, 3],
                [4, 5, 6],
                [7, 8, 9]
            ],
            "[[1,2,3]\n [4,5,6]\n [7,8,9]]"
        },
        {
            [
                [1, 2],
                [4, 5],
                [7, 8]
            ],
            "[[1,2]\n [4,5]\n [7,8]]"
        },
        { [[1, 2, 3], [4, 5, 6]], "[[1,2,3]\n [4,5,6]]" },
        { [[1], [2], [3]], "[[1]\n [2]\n [3]]" },
        { [[1, 2, 3]], "[[1,2,3]]" }
    };

    [Theory]
    [MemberData(nameof(TreeNodeData), MemberType = typeof(UtilUnitTest))]
    public void Test_CreateTreeNode_Should_OK(List<int?> numbers, TreeNode expected)
    {
        TreeNode actual = Util.GenerateTreeNode(numbers);
        Assert.Equal(expected, actual, new TreeNodeComparer());
    }


    [Theory]
    [MemberData(nameof(MatrixData))]
    public void Test_ConvertMatrixToString_ShouldBe_OK(int[][] matrix, string expected)
    {
        string actual = Util.ConvertMatrixToString(matrix);
        Assert.Equal(expected, actual);
    }


    [Theory]
    [InlineData(1, 2, 2, 1)]
    [InlineData(-1, -2, -2, -1)]
    [InlineData(0, 1, 1, 0)]
    [InlineData(1, 0, 0, 1)]
    [InlineData(int.MaxValue, int.MinValue, int.MinValue, int.MaxValue)]
    public void Test_SwapByRef_Should_OK(int lhs, int rhs, int expectedLhs, int expectedRhs)
    {
        Util.Swap(ref lhs, ref rhs);
        Assert.Equal(expectedLhs, lhs);
        Assert.Equal(expectedRhs, rhs);
    }

    public static TheoryData<int[], int, int, int[]> SwapPassTestData => new()
    {
        { [1, 2], 0, 1, [2, 1] }, { [1, 2, 3, 4], 0, 3, [4, 2, 3, 1] }
    };

    [Theory]
    [MemberData(nameof(SwapPassTestData))]
    public void Test_SwapByArray_Should_OK(int[] input, int lhs, int rhs, int[] expected)
    {
        Util.Swap(input, lhs, rhs);
        Assert.Equal(expected, input);
    }

    public static TheoryData<int[], int, int> SwapFailedTestData => new() { { [1, 2], 1, 2 }, { [1, 2, 3, 4], -1, 3 } };

    [Theory]
    [MemberData(nameof(SwapFailedTestData))]
    public void Test_SwapByArray_Should_ThrowIndexOutOfRangeException(int[] input, int lhs, int rhs)
    {
        Assert.Throws<IndexOutOfRangeException>(() => Util.Swap(input, lhs, rhs));
    }
}
