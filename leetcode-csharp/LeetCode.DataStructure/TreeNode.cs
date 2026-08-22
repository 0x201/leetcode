// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.DataStructure;

/// <summary>
/// Definition for a binary tree node.
/// </summary>
public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int Val { get; set; } = val;
    public TreeNode Left { get; set; } = left;
    public TreeNode Right { get; set; } = right;

    public TreeNode(int x) : this(x, null)
    {
    }
}


public class TreeNodeComparer : IEqualityComparer<TreeNode>
{
    public bool Equals(TreeNode x, TreeNode y)
    {
        if (x is null && y is null)
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        if (x.Val != y.Val)
        {
            return false;
        }

        return Equals(x.Left, y.Left) && Equals(x.Right, y.Right);

    }

    public int GetHashCode([DisallowNull] TreeNode obj)
    {
        throw new NotImplementedException();
    }
}
