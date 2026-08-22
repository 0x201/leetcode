// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class KthLargest
{
    private PriorityQueue<int, int> Queue { get; }

    private int K { get; }

    public KthLargest(int k, int[] nums)
    {
        Queue = new PriorityQueue<int, int>();
        K = k;
        foreach (int num in nums)
        {
            Add(num);
        }
    }

    public int Add(int val)
    {
        Queue.Enqueue(val, val);
        if (Queue.Count > K)
        {
            Queue.Dequeue();
        }

        return Queue.Peek();
    }
}
