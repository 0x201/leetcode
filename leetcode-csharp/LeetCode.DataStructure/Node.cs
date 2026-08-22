// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.DataStructure;

/// <summary>
/// Definition for a Node.
/// </summary>
public class Node
{
    public int Val { get; }
    public IList<Node> Children { get; } = new List<Node>();

    public Node()
    {
    }

    public Node(int val)
    {
        Val = val;
    }

    public Node(int val, IList<Node> children)
    {
        Val = val;
        Children = children;
    }
}