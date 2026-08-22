// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;
public class MyQueue
{
    private readonly Stack<int> _inStack = new();
    private readonly Stack<int> _outStack = new();

    private void In2Out()
    {
        while (_inStack.Count != 0)
        {
            _outStack.Push(_inStack.Pop());
        }
    }

    public void Push(int x)
    {
        _inStack.Push(x);
    }

    public int Pop()
    {
        if (_outStack.Count == 0)
        {
            In2Out();
        }
        return _outStack.Pop();
    }

    public int Peek()
    {
        if (_outStack.Count == 0)
        {
            In2Out();
        }
        return _outStack.Peek();
    }

    public bool Empty()
    {
        return _inStack.Count == 0 && _outStack.Count == 0;
    }
}
