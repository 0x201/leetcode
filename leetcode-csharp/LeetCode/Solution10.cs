// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 1800. Maximum Ascending Subarray Sum
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int MaxAscendingSum(int[] nums)
    {
        int res = 0;
        int i = 0;
        int n = nums.Length;
        while (i < n)
        {
            int currSum = nums[i++];
            while (i < n && nums[i] > nums[i - 1])
            {
                currSum += nums[i++];
            }

            res = Math.Max(res, currSum);
        }

        return res;
    }

    /// <summary>
    /// 1802. Maximum Value at a Given Index in a Bounded Array
    /// </summary>
    /// <param name="n"></param>
    /// <param name="index"></param>
    /// <param name="maxSum"></param>
    /// <returns></returns>
    public static int MaxValue(int n, int index, int maxSum)
    {
        double left = index;
        double right = n - index - 1;
        if (left > right)
        {
            (left, right) = (right, left);
        }

        double upper = ((left + 1) * (left + 1) - 3 * (left + 1)) / 2 + left + 1 + (left + 1) + ((left + 1) * (left + 1) - 3 * (left + 1)) / 2 + right + 1;
        if (upper >= maxSum)
        {
            double a = 1;
            double b = -2;
            double c = left + right + 2 - maxSum;
            return (int)Math.Floor((-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a));
        }

        upper = (2 * (right + 1) - left - 1) * left / 2 + (right + 1) + ((right + 1) * (right + 1) - 3 * (right + 1)) / 2 + right + 1;
        if (upper >= maxSum)
        {
            double a = 1.0 / 2;
            double b = left + 1 - 3.0 / 2;
            double c = right + 1 + (-left - 1) * left / 2 - maxSum;
            return (int)Math.Floor((-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a));
        }
        else
        {
            double a = left + right + 1;
            double b = (-left * left - left - right * right - right) / 2 - maxSum;
            return (int)Math.Floor(-b / a);
        }
    }

    /// <summary>
    /// 1823. Find the Winner of the Circular Game
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int FindTheWinner(int n, int k)
    {
        int winner = 1;
        for (int i = 2; i <= n; i++)
        {
            winner = (k + winner - 1) % i + 1;
        }

        return winner;
    }

    /// <summary>
    /// 1827. Minimum Operations to Make the Array Increasing
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int MinOperations(int[] nums)
    {
        int prev = nums[0] - 1;
        int res = 0;
        foreach (int num in nums)
        {
            prev = Math.Max(prev + 1, num);
            res += prev - num;
        }

        return res;
    }

    /// <summary>
    /// 1945. Sum of Digits of String After Convert
    /// </summary>
    /// <param name="s"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int GetLucky(string s, int k)
    {
        var sb = new StringBuilder();
        foreach (char ch in s)
        {
            sb.Append(ch - 'a' + 1);
        }

        string digits = sb.ToString();
        for (int i = 1; i <= k && digits.Length > 1; i++)
        {
            int sum = digits.Sum(ch => ch - '0');

            digits = sum.ToString();
        }

        return int.Parse(digits);
    }

    /// <summary>
    /// 1984. Minimum Difference Between Highest and Lowest of K Scores
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int MinimumDifference(int[] nums, int k)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int res = int.MaxValue;
        for (int i = 0; i + k - 1 < n; ++i)
        {
            res = Math.Min(res, nums[i + k - 1] - nums[i]);
        }

        return res;
    }

    /// <summary>
    /// 1991. Find the Middle Index in Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int FindMiddleIndex(int[] nums)
    {
        int total = nums.Sum();
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if ((2 * sum + nums[i]) == total)
            {
                return i;
            }

            sum += nums[i];
        }

        return -1;
    }

    /// <summary>
    /// 1995. Count Special Quadruplets
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int CountQuadruplets(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        var cnt = new Dictionary<int, int>();
        for (int b = n - 3; b >= 1; --b)
        {
            for (int d = b + 2; d < n; ++d)
            {
                int difference = nums[d] - nums[b + 1];
                if (!cnt.TryGetValue(difference, out int value))
                {
                    cnt.Add(difference, 1);
                }
                else
                {
                    cnt[difference] = ++value;
                }
            }

            for (int a = 0; a < b; ++a)
            {
                int sum = nums[a] + nums[b];
                if (cnt.TryGetValue(sum, out int value))
                {
                    ans += value;
                }
            }
        }

        return ans;
    }

    /// <summary>
    /// 1997. First Day Where You Have Been in All the Rooms
    /// </summary>
    /// <param name="nextVisit"></param>
    /// <returns></returns>
    public static int FirstDayBeenInAllRooms(int[] nextVisit)
    {
        const int mod = 1_000_000_007;
        int n = nextVisit.Length;
        int[] dp = new int[n];
        dp[0] = 2;
        for (int i = 1; i < n; i++)
        {
            int to = nextVisit[i];
            dp[i] = 2 + dp[i - 1];
            if (to != 0)
            {
                dp[i] = (dp[i] - dp[to - 1] + mod) % mod;
            }

            dp[i] = (dp[i] + dp[i - 1]) % mod;
        }
        return dp[n - 2];
    }
}
