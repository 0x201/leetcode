// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public class ATM
{
    private readonly long[] _count;
    private readonly long[] _value;

    public ATM()
    {
        _count = [0, 0, 0, 0, 0];
        _value = [20, 50, 100, 200, 500];
    }

    public void Deposit(int[] banknotesCount)
    {
        for (int i = 0; i < 5; i++)
        {
            _count[i] += banknotesCount[i];
        }
    }

    public int[] Withdraw(int amount)
    {
        int[] res = new int[5];
        for (int i = 4; i >= 0; --i)
        {
            res[i] = (int)Math.Min(_count[i], amount / _value[i]);
            amount -= res[i] * (int)_value[i];
        }

        if (amount > 0)
        {
            return [-1];
        }
        else
        {
            for (int i = 0; i < 5; ++i)
            {
                _count[i] -= res[i];
            }
            return res;
        }
    }
}
