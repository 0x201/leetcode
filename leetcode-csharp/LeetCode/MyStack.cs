// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class MyStack
{
    private readonly Queue<int> _queue = new();

    public void Push(int x)
    {
        int n = _queue.Count;
        _queue.Enqueue(x);
        for (int i = 0; i < n; i++)
        {
            _queue.Enqueue(_queue.Dequeue());
        }
    }

    public int Pop()
    {
        return _queue.Dequeue();
    }

    public int Top()
    {
        return _queue.Peek();
    }

    public bool Empty()
    {
        return _queue.Count == 0;
    }
}
