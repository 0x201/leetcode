namespace LeetCode.Tests.SolutionTests;

public class GenerateMatrixUnitTest
{
    public static TheoryData<int, int[][]> Data => new() { { 3, [[1, 2, 3], [8, 9, 4], [7, 6, 5]] }, { 1, [[1]] } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int n, int[][] expected)
    {
        int[][] actual = Solution.GenerateMatrix(n);
        Assert.Equal(expected, actual);
    }
}

public class GenerateParenthesisUnitTest
{
    public static TheoryData<int, string[]> Data => new()
    {
        { 3, ["((()))", "(()())", "(())()", "()(())", "()()()"] }, { 1, ["()"] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int n, string[] expected)
    {
        string[] actual = Solution.GenerateParenthesis(n).ToArray();
        Assert.Equal(expected, actual);
    }
}

public class GenerateTheStringUnitTest
{
    [Theory]
    [InlineData(4, "aaab")]
    [InlineData(2, "ab")]
    [InlineData(3, "aaa")]
    public void MultipleDataTest(int input, string expected)
    {
        string actual = Solution.GenerateTheString(input);
        Assert.Equal(expected, actual);
    }
}

public class GetAllElementsUnitTest
{
    public static TheoryData<TreeNode, TreeNode, IList<int>> Data => new()
    {
        { Util.GenerateTreeNode([2, 1, 4]), Util.GenerateTreeNode([1, 0, 3]), [0, 1, 1, 2, 3, 4] },
        { Util.GenerateTreeNode([1, null, 8]), Util.GenerateTreeNode([8, 1]), [1, 1, 8, 8] }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(GetAllElementsUnitTest))]
    public void MultipleDataTest(TreeNode root1, TreeNode root2, IList<int> expected)
    {
        IList<int> actual = Solution.GetAllElements(root1, root2);
        Assert.Equal(expected, expected);
    }
}

public class GetSumUnitTest
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(7, 3, 10)]
    [InlineData(1, -2, -1)]
    public void Test_Should_OK(int a, int b, int expected)
    {
        int actual = Solution.GetSum(a, b);
        Assert.Equal(expected, actual);
    }
}

public class GraphUnitTest
{
    [Fact]
    public void Test()
    {
        var graph = new Graph(4, [[0, 2, 5], [0, 1, 2], [1, 2, 1], [3, 0, 3]]);
        Assert.Equal(6, graph.ShortestPath(3, 2));
        Assert.Equal(-1, graph.ShortestPath(0, 3));
        graph.AddEdge([1, 3, 4]);
        Assert.Equal(6, graph.ShortestPath(0, 3));
    }
}


public class GetFinalState
{
    [Theory]
    [InlineData(new int[] { 2, 1, 3, 5, 6 }, 5, 2, new int[] { 8, 4, 6, 5, 6 })]
    [InlineData(new int[] { 1, 2 }, 3, 4, new int[] { 16, 8 })]
    public void Test(int[] nums, int k, int multiplier, int[] expected)
    {
        var actual = Solution.GetFinalState(nums, k, multiplier);
        Assert.Equal(expected, actual);
    }
}
