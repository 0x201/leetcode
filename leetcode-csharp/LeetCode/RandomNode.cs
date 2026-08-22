// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class RandomNode(ListNode head)
{
    private readonly Random _random = new();

    public int GetRandom()
    {
        int i = 1, ans = 0;
        for (ListNode curr = head; curr != null; curr = curr.Next)
        {
            if (_random.Next(i) == 0)
            {
                ans = curr.Val;
            }

            ++i;
        }

        return ans;
    }
}