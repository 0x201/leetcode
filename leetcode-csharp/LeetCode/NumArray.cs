// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;
/// <summary>
/// LeetCode 303 Number Array
/// </summary>
public class NumArray
{
    private List<int> Sum { get; }
    public NumArray(int[] nums)
    {
        int len = nums.Length;
        Sum = [len + 1];
        for (int i = 0; i < len; i++)
        {
            Sum[i + 1] = Sum[i] + nums[i];
        }
    }

    public int SumRange(int i, int j) => Sum[j + 1] - Sum[i];
}
