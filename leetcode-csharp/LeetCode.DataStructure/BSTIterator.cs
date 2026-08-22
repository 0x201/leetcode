// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.DataStructure;

public class BSTIterator
{
    private Stack<TreeNode> Stack { get; }

    public BSTIterator(TreeNode root)
    {
        Stack = new Stack<TreeNode>();
        while (root != null)
        {
            Stack.Push(root);
            root = root.Left;
        }
    }

    public int Next()
    {
        TreeNode tmp = Stack.Pop();
        TreeNode right = tmp.Right;
        while (right != null)
        {
            Stack.Push(right);
            right = right.Left;
        }
        return tmp.Val;
    }

    public bool HasNext()
    {
        return Stack.Count > 0;
    }
}

