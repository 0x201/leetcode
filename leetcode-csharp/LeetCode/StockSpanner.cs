// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class StockSpanner
{
    private int Index { get; set; }

    private Stack<(int day, int price)> Stack { get; }

    public StockSpanner()
    {
        Stack = new Stack<(int day, int price)>();
        Stack.Push((-1, int.MaxValue));
        Index = -1;
    }

    public int Next(int price)
    {
        Index++;
        while (price >= Stack.Peek().price)
        {
            Stack.Pop();
        }

        int res = Index - Stack.Peek().day;
        Stack.Push((Index, price));
        return res;
    }
}