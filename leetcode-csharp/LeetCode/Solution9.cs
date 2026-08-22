// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 1608. Special Array With X Elements Greater Than or Equal X
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int SpecialArray(int[] nums)
    {
        Array.Sort(nums, (a, b) => b - a);
        int n = nums.Length;
        for (int i = 1; i <= n; i++)
        {
            if (nums[i - 1] >= i && (i == n || nums[i] < i))
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// 1619. Mean of Array After Removing Some Elements
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static double TrimMean(int[] arr)
    {
        int n = arr.Length;
        Array.Sort(arr);
        int sum = 0;
        for (int i = n / 20; i < 19 * n / 20; i++)
        {
            sum += arr[i];
        }

        return sum / (0.9 * n);
    }

    /// <summary>
    /// 1624. Largest Substring Between Two Equal Characters
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int MaxLengthBetweenEqualCharacters(string s)
    {
        int n = s.Length;
        var dic = new Dictionary<char, int>();
        int res = -1;
        for (int i = 0; i < n; i++)
        {
            if (!dic.TryGetValue(s[i], out int value))
            {
                dic.Add(s[i], i);
            }
            else
            {
                res = Math.Max(res, i - value - 1);
            }
        }

        return res;
    }

    /// <summary>
    /// 1636. Sort Array by Increasing Frequency
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int[] FrequencySort(int[] nums)
    {
        var count = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            count.TryAdd(num, 0);
            count[num]++;
        }

        Array.Sort(nums, (a, b) =>
        {
            int count1 = count[a], count2 = count[b];
            return count1 != count2 ? count1 - count2 : b - a;
        });
        return nums;
    }

    /// <summary>
    /// 1658. Minimum Operations to Reduce X to Zero
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int MinOperations(int[] nums, int x)
    {
        int n = nums.Length;
        int sum = nums.Sum();

        if (sum < x)
        {
            return -1;
        }

        int right = 0;
        int leftSum = 0, rightSum = sum;
        int res = n + 1;

        for (int left = -1; left < n; ++left)
        {
            if (left != -1)
            {
                leftSum += nums[left];
            }
            while (right < n && leftSum + rightSum > x)
            {
                rightSum -= nums[right];
                ++right;
            }
            if (leftSum + rightSum == x)
            {
                res = Math.Min(res, (left + 1) + (n - right));
            }
        }

        return res > n ? -1 : res;
    }

    /// <summary>
    /// 1672. Richest Customer Wealth
    /// </summary>
    /// <param name="accounts"></param>
    /// <returns></returns>
    public static int MaximumWealth(int[][] accounts) => accounts.Max(x => x.Sum());

    /// <summary>
    /// 1673. Find the Most Competitive Subsequence
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int[] MostCompetitive(int[] nums, int k)
    {
        int n = nums.Length;
        int[] res = new int[k];
        var stack = new Stack<int>();
        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && n - i + stack.Count > k && stack.Peek() > nums[i])
            {
                stack.Pop();
            }
            stack.Push(nums[i]);
        }
        while (stack.Count > k)
        {
            stack.Pop();
        }
        for (int i = k - 1; i >= 0; i--)
        {
            res[i] = stack.Pop();
        }
        return res;
    }

    /// <summary>
    /// 1694. Reformat Phone Number
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string ReformatNumber(string number)
    {
        var sb = new StringBuilder();
        foreach (char ch in number.Where(char.IsDigit))
        {
            sb.Append(ch);
        }

        string digits = sb.ToString();
        int n = digits.Length;
        int pt = 0;
        var res = new StringBuilder();
        while (n > 0)
        {
            if (n > 4)
            {
                res.Append(string.Concat(digits.AsSpan(pt, 3), "-"));
                pt += 3;
                n -= 3;
            }
            else
            {
                if (n == 4)
                {
                    res.Append(string.Concat(digits.AsSpan(pt, 2), "-", digits.AsSpan(pt + 2, 2)));
                }
                else
                {
                    res.Append(digits.AsSpan(pt, n));
                }

                break;
            }
        }

        return res.ToString();
    }

    /// <summary>
    /// 1700. Number of Students Unable to Eat Lunch
    /// </summary>
    /// <param name="students"></param>
    /// <param name="sandwiches"></param>
    /// <returns></returns>
    public static int CountStudents(int[] students, int[] sandwiches)
    {
        int square = students.Sum();
        int circular = students.Length - square;
        foreach (int t in sandwiches)
        {
            if (t == 0 && circular > 0)
            {
                circular--;
            }
            else if (t == 1 && square > 0)
            {
                square--;
            }
            else
            {
                break;
            }
        }
        return square + circular;
    }

    /// <summary>
    /// 1702. Maximum Binary String After Change
    /// </summary>
    /// <param name="binary"></param>
    /// <returns></returns>
    public static string MaximumBinaryString(string binary)
    {
        int n = binary.Length;
        int zeroIndex = n;
        int zeroCount = 0;
        char[] res = binary.ToCharArray();
        for (int i = 0; i < n; i++)
        {
            if (binary[i] == '0')
            {
                if (zeroIndex == n)
                {
                    zeroIndex = i;
                }
                zeroCount++;
            }
            res[i] = '1';
        }

        if (zeroCount == 0)
        {
            return binary;
        }
        res[zeroIndex + zeroCount - 1] = '0';
        return string.Join("", res);
    }

    /// <summary>
    /// 1750. Minimum Length of String After Deleting Similar Ends
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int MinimumLength(string s)
    {
        int n = s.Length;
        int left = 0, right = n - 1;
        while (left < right && s[left] == s[right])
        {
            char c = s[left];
            while (left <= right && s[left] == c)
            {
                left++;
            }
            while (left <= right && s[right] == c)
            {
                right--;
            }
        }
        return right - left + 1;
    }

    /// <summary>
    /// 1768. Merge Strings Alternately
    /// </summary>
    /// <param name="word1"></param>
    /// <param name="word2"></param>
    /// <returns></returns>
    public static string MergeAlternately(string word1, string word2)
    {
        int m = word1.Length, n = word2.Length;
        int i = 0, j = 0;
        var sb = new StringBuilder();
        while (i < m || j < n)
        {
            if (i < m)
            {
                sb.Append(word1[i++]);
            }

            if (j < n)
            {
                sb.Append(word2[j++]);
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// 1779. Find Nearest Point That Has the Same X or Y Coordinate
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="points"></param>
    /// <returns></returns>
    public static int NearestValidPoint(int x, int y, int[][] points)
    {
        int minDistance = int.MaxValue;
        int ans = -1;
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i][0] != x && points[i][1] != y) continue;
            int distance = Math.Abs(points[i][0] - x) + Math.Abs(points[i][1] - y);
            if (distance >= minDistance) continue;
            minDistance = distance;
            ans = i;
        }

        return ans;
    }

    /// <summary>
    /// 1784. Check if Binary String Has at Most One Segment of Ones
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool CheckOnesSegment(string s) => !s.Contains("01");

    /// <summary>
    /// 1790. Check if One String Swap Can Make Strings Equal
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static bool AreAlmostEqual(string s1, string s2)
    {
        int n = s1.Length;
        IList<int> diff = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (s1[i] == s2[i]) continue;
            if (diff.Count >= 2)
            {
                return false;
            }
            diff.Add(i);
        }

        if (diff.Count == 0)
        {
            return true;
        }

        if (diff.Count != 2)
        {
            return false;
        }

        return s1[diff[0]] == s2[diff[1]] && s1[diff[1]] == s2[diff[0]];
    }

    /// <summary>
    /// 1791. Find Center of Star Graph
    /// </summary>
    /// <param name="edges"></param>
    /// <returns></returns>
    public static int FindCenter(int[][] edges) => edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1] ? edges[0][0] : edges[0][1];
}
