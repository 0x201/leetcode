namespace LeetCode.Tests.SolutionTests;

public class PalindromeNumberUnitTest
{
    [Theory]
    [InlineData(121, true)]
    [InlineData(-121, false)]
    [InlineData(10, false)]
    public void MultipleDataTest(int input, bool expected)
    {
        bool actual = Solution.IsPalindrome(input);
        Assert.Equal(expected, actual);
    }
}

public class PartitionDisjointUnitTest
{
    public static TheoryData<int[], int> Data => new() { { [5, 0, 3, 8, 6], 3 }, { [1, 1, 1, 0, 6, 12], 4 } };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expected)
    {
        int actual = Solution.PartitionDisjoint(nums);
        Assert.Equal(expected, actual);
    }
}

public class PathSumIiUnitTest
{
    public static TheoryData<TreeNode, int, IList<List<int>>> Data => new()
    {
        { Util.GenerateTreeNode([1, 2, 3]), 5, [] },
        {
            Util.GenerateTreeNode([5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1]), 22, [
                [5, 4, 11, 2],
                [5, 8, 4, 5],
            ]
        }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(TreeNode input, int targetNum, IList<List<int>> expected)
    {
        IList<IList<int>> actual = Solution.PathSum(input, targetNum);
        Assert.Equal(expected, actual);
    }
}

public class PeakIndexInMountainArrayUnitTest
{
    public static TheoryData<int[], int> Data => new()
    {
        { [18, 29, 38, 59, 98, 100, 99, 98, 90], 5 }, { [0, 1, 0], 1 }, { [1, 3, 5, 4, 2], 2 }, { [0, 10, 5, 2], 1 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] arr, int expected)
    {
        int actual = Solution.PeakIndexInMountainArray(arr);
        Assert.Equal(expected, actual);
    }
}

public class PermuteUnitTest
{
    public static TheoryData<int[], IList<IList<int>>> Data => new()
    {
        { [1, 2, 3], [[1, 2, 3], [1, 3, 2], [3, 1, 2], [2, 1, 3], [2, 3, 1], [3, 2, 1]] },
        { [0, 1], [[0, 1], [1, 0]] },
        { [1], [[1]] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, IList<IList<int>> expected)
    {
        IList<IList<int>> actual = Solution.Permute(nums);
        Assert.Equal(expected, actual);
    }
}

public class PivotIndexUnitTest
{
    public static TheoryData<int[], int> Data => new()
    {
        { [1, 7, 3, 6, 5, 6], 3 }, { [1, 2, 3], -1 }, { [2, 1, -1], 0 }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void MultipleDataTest(int[] nums, int expect)
    {
        int actual = Solution.PivotIndex(nums);
        Assert.Equal(expect, actual);
    }
}

public class PlatesBetweenCandlesUnitTest
{
    public static TheoryData<string, int[][], int[]> Data => new()
    {
        { "**|**|***|", new int[][] { [2, 5], [5, 9] }, [2, 3] },
        { "***|**|*****|**||**|*", [[1, 17], [4, 5], [14, 17], [5, 11], [15, 16],], [9, 0, 0, 0, 0] }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(string s, int[][] queries, int[] expected)
    {
        int[] actual = Solution.PlatesBetweenCandles(s, queries);
        Assert.Equal(expected, actual);
    }
}

public class PlusOneUnitTest
{
    public static TheoryData<int[], int[]> Data =>
        new() { { [1, 2, 3], [1, 2, 4] }, { [4, 3, 2, 1], [4, 3, 2, 2] }, { [9], [1, 0] } };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int[] digits, int[] expected)
    {
        int[] actual = Solution.PlusOne(digits);
        Assert.Equal(expected, actual);
    }
}

public class PossibleBipartitionUnitTest
{
    public static TheoryData<int, int[][], bool> Data => new()
    {
        { 4, [[1, 2], [1, 3], [2, 4]], true },
        { 3, [[1, 2], [1, 3], [2, 3]], false },
        { 5, [[1, 2], [2, 3], [3, 4], [4, 5], [1, 5],], false }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(int n, int[][] dislikes, bool expected)
    {
        bool actual = Solution.PossibleBipartition(n, dislikes);
        Assert.Equal(expected, actual);
    }
}

public class PostorderUnitTest
{
    [Fact]
    public void Test()
    {
        var root1 = new Node(1, new List<Node>());
        var root1ChildNode3 = new Node(3, new List<Node>());
        root1ChildNode3.Children.Add(new Node(5, new List<Node>()));
        root1ChildNode3.Children.Add(new Node(6, new List<Node>()));
        root1.Children.Add(root1ChildNode3);
        root1.Children.Add(new Node(2, new List<Node>()));
        root1.Children.Add(new Node(4, new List<Node>()));

        var root2 = new Node(1, new List<Node>());

        root2.Children.Add(new Node(2, new List<Node>()));

        var root2ChildNode3 = new Node(3, new List<Node>());
        var root2ChildNode7 = new Node(7, new List<Node>());
        var root2ChildNode11 = new Node(11, new List<Node>());
        root2ChildNode11.Children.Add(new Node(14, new List<Node>()));
        root2ChildNode7.Children.Add(root2ChildNode11);
        root2ChildNode3.Children.Add(new Node(6, new List<Node>()));
        root2ChildNode3.Children.Add(root2ChildNode7);

        var root2ChildNode8 = new Node(8, new List<Node>());
        root2ChildNode8.Children.Add(new Node(12, new List<Node>()));

        var root2ChildNode9 = new Node(9, new List<Node>());
        root2ChildNode9.Children.Add(new Node(13, new List<Node>()));

        var root2ChildNode4 = new Node(4, new List<Node>());
        root2ChildNode4.Children.Add(root2ChildNode8);

        var root2ChildNode5 = new Node(5, new List<Node>());
        root2ChildNode5.Children.Add(root2ChildNode9);
        root2ChildNode5.Children.Add(new Node(10, new List<Node>()));

        root2.Children.Add(root2ChildNode3);
        root2.Children.Add(root2ChildNode4);
        root2.Children.Add(root2ChildNode5);

        IList<int> actual1 = Solution.PostOrder(root1);
        IList<int> actual2 = Solution.PostOrder(root2);

        Assert.Equal(new[] { 5, 6, 3, 2, 4, 1 }, actual1);
        Assert.Equal(new[] { 2, 6, 14, 11, 7, 3, 12, 8, 4, 13, 9, 10, 5, 1 }, actual2);
    }
}

public class PowerOfTwoUnitTest
{
    [Theory]
    [InlineData(1, true)]
    [InlineData(16, true)]
    [InlineData(4, true)]
    [InlineData(3, false)]
    public void Test(int num, bool expected)
    {
        bool actual = Solution.IsPowerOfTwo(num);
        Assert.Equal(expected, actual);
    }
}

public class PrefixCountUnitTest
{
    [Theory]
    [InlineData(new[] { "pay", "attention", "practice", "attend" }, "at", 2)]
    [InlineData(new[] { "leetcode", "win", "loops", "success" }, "code", 0)]
    public void MultipleDataTest(string[] words, string pref, int expected)
    {
        int actual = Solution.PrefixCount(words, pref);
        Assert.Equal(expected, actual);
    }
}

public class PreimageSizeFzfUnitTest
{
    [Theory]
    [InlineData(0, 5)]
    [InlineData(5, 0)]
    [InlineData(3, 5)]
    public void MultipleDataTest(int k, int expected)
    {
        int actual = Solution.PreimageSizeFzf(k);
        Assert.Equal(expected, actual);
    }
}

public class PreorderUnitTest
{
    public static TheoryData<Node, IList<int>> Data => new()
    {
        { Util.GenerateNTree([1, null, 3, 2, 4, null, 5, 6]), [1, 3, 5, 6, 2, 4] },
        {
            Util.GenerateNTree([
                1, null, 2, 3, 4, 5, null, null, 6, 7, null, 8, null, 9, 10, null, null, 11, null, 12, null, 13,
                null, null, 14
            ]),
            [1, 2, 3, 6, 7, 11, 14, 4, 8, 12, 5, 9, 13, 10]
        }
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void Test(Node root, IList<int> expected)
    {
        IList<int> actual = Solution.PreOrder(root);

        Assert.Equal(expected, actual);
    }
}

public class PrintOrderUnitTest
{
    public static TheoryData<List<int>, string> Data => new()
    {
        { [1, 2, 3], "firstsecondthird" },
        { [1, 3, 2], "firstsecondthird" },
        { [2, 1, 3], "firstsecondthird" },
        { [2, 3, 1], "firstsecondthird" },
        { [3, 1, 2], "firstsecondthird" },
        { [3, 2, 1], "firstsecondthird" }
    };


    [Theory]
    [MemberData(nameof(Data), MemberType = typeof(PrintOrderUnitTest))]
    public async Task Test(List<int> sequences, string expected)
    {
        string actual = "";
        // Given
        var foo = new Foo();
        List<Task> tasks = [];
        tasks.AddRange(sequences.Select(sequence => Task.Run(() =>
        {
            switch (sequence)
            {
                case 1:
                    foo.First(PrintFirst);
                    break;
                case 2:
                    foo.Second(PrintSecond);
                    break;
                default:
                    foo.Third(PrintThird);
                    break;
            }
        })));

        await Task.WhenAll(tasks);
        // When
        Assert.Equal(expected, actual);
        return;
        // Then

        void PrintFirst()
        {
            actual += "first";
        }

        void PrintSecond()
        {
            actual += "second";
        }

        void PrintThird()
        {
            actual += "third";
        }
    }
}

public class PushDominoesUnitTest
{
    [Theory]
    [InlineData("RR.L", "RR.L")]
    [InlineData(".L.R...LR..L..", "LL.RR.LLRRLL..")]
    public void Test(string input, string expected)
    {
        string actual = Solution.PushDominoes(input);
        Assert.Equal(expected, actual);
    }
}
