// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class MinStack
{
    private Stack<int> Min { get; }

    private Stack<int> X { get; }

    public MinStack()
    {
        Min = new Stack<int>();
        X = new Stack<int>();
        Min.Push(int.MaxValue);
    }

    public void Push(int val)
    {
        X.Push(val);
        Min.Push(Math.Min(Min.Peek(), val));
    }

    public void Pop()
    {
        X.Pop();
        Min.Pop();
    }

    public int Top()
    {
        return X.Peek();
    }

    public int GetMin()
    {
        return Min.Peek();
    }
}