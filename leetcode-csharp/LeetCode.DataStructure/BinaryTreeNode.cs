// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.DataStructure;

public class BinaryTreeNode
{
    public int Val { get; set; }
    public BinaryTreeNode Left { get; set; }
    public BinaryTreeNode Right { get; set; }
    public BinaryTreeNode Next { get; set; }

    public BinaryTreeNode()
    {
    }

    public BinaryTreeNode(int val)
    {
        Val = val;
    }

    public BinaryTreeNode(int val, BinaryTreeNode left, BinaryTreeNode right, BinaryTreeNode next)
    {
        Val = val;
        Left = left;
        Right = right;
        Next = next;
    }
}

public class BinaryTreeNodeComparer : IEqualityComparer<BinaryTreeNode>
{
    public bool Equals(BinaryTreeNode x, BinaryTreeNode y)
    {
        if (x is null && y is null)
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        if (x.Next != y.Next)
        {
            return false;
        }

        return Equals(x.Left, y.Left) && Equals(x.Right, y.Right);

    }

    public int GetHashCode([DisallowNull] BinaryTreeNode obj)
    {
        throw new NotImplementedException();
    }
}