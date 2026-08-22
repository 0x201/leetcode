// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 2006. Count Number of Pairs With Absolute Difference K
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int CountKDifference(int[] nums, int k)
    {
        int ans = 0, n = nums.Length;
        var cnt = new Dictionary<int, int>();
        for (int j = 0; j < n; j++)
        {
            ans += (cnt.ContainsKey(nums[j] - k) ? cnt[nums[j] - k] : 0)
                   + (cnt.ContainsKey(nums[j] + k) ? cnt[nums[j] + k] : 0);
            if (!cnt.TryGetValue(nums[j], out int value))
            {
                value = 0;
                cnt.Add(nums[j], value);
            }

            cnt[nums[j]] =
            ++value;
        }

        return ans;
    }

    /// <summary>
    /// 2011. Final Value of Variable After Performing Operations
    /// </summary>
    /// <param name="operations"></param>
    /// <returns></returns>
    public static int FinalValueAfterOperations(string[] operations) => operations.Select(op => op[1] == '+' ? 1 : -1).Sum();

    /// <summary>
    /// 2016. Maximum Difference Between Increasing Elements
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int MaximumDifference(int[] nums)
    {
        int n = nums.Length;
        int ans = -1, preMin = nums[0];
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > preMin)
            {
                ans = Math.Max(ans, nums[i] - preMin);
            }
            else
            {
                preMin = nums[i];
            }
        }

        return ans;
    }

    /// <summary>
    /// 2027. Minimum Moves to Convert String
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int MinimumMoves(string s)
    {
        int res = 0;
        int count = -1;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != 'X' || i <= count) continue;
            res++;
            count = i + 2;
        }
        return res;
    }

    /// <summary>
    /// 2032. Two Out of Three
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <param name="nums3"></param>
    /// <returns></returns>
    public static IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
    {
        Dictionary<int, int> dic = new();
        foreach (int num in nums1)
        {
            dic.TryAdd(num, 1);
        }

        foreach (int num in nums2)
        {
            dic.TryAdd(num, 0);
            dic[num] |= 2;
        }

        foreach (int num in nums3)
        {
            dic.TryAdd(num, 0);
            dic[num] |= 4;
        }

        IList<int> res = new List<int>();
        foreach ((int key, int value) in dic)
        {
            if ((value & (value - 1)) != 0)
            {
                res.Add(key);
            }
        }

        return res;
    }

    /// <summary>
    /// 2037. Minimum Number of Moves to Seat Everyone
    /// </summary>
    /// <param name="seats"></param>
    /// <param name="students"></param>
    /// <returns></returns>
    public static int MinMovesToSeat(int[] seats, int[] students)
    {
        Array.Sort(seats);
        Array.Sort(students);
        return seats.Select((t, i) => Math.Abs(t - students[i])).Sum();
    }

    /// <summary>
    /// 2042. Check if Numbers Are Ascending in a Sentence
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool AreNumberAscending(string s)
    {
        int prev = 0, pos = 0;
        while (pos < s.Length)
        {
            if (char.IsDigit(s[pos]))
            {
                int curr = 0;
                while (pos < s.Length && char.IsDigit(s[pos]))
                {
                    curr = curr * 10 + s[pos] - '0';
                    pos++;
                }
                if (curr <= prev)
                {
                    return false;
                }
                prev = curr;
            }
            else
            {
                pos++;
            }
        }
        return true;
    }

    /// <summary>
    /// 2044. Count Number of Maximum Bitwise-OR Subsets
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int CountMaxOrSubsets(int[] nums)
    {
        int maxOr = 0, cnt = 0;
        Dfs(0, 0);
        return cnt;

        void Dfs(int pos, int orVal)
        {
            if (pos == nums.Length)
            {
                if (orVal > maxOr)
                {
                    maxOr = orVal;
                    cnt = 1;
                }
                else if (orVal == maxOr)
                {
                    cnt++;
                }

                return;
            }

            Dfs(pos + 1, orVal | nums[pos]);
            Dfs(pos + 1, orVal);
        }
    }

    /// <summary>
    /// 2055. Plates Between Candles
    /// </summary>
    /// <param name="s"></param>
    /// <param name="queries"></param>
    /// <returns></returns>
    public static int[] PlatesBetweenCandles(string s, int[][] queries)
    {
        int n = s.Length;
        int[] preSum = new int[n];
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '*')
            {
                sum++;
            }

            preSum[i] = sum;
        }

        int[] left = new int[n];
        for (int i = 0, l = -1; i < n; i++)
        {
            if (s[i] == '|')
            {
                l = i;
            }

            left[i] = l;
        }

        int[] right = new int[n];
        for (int i = n - 1, r = -1; i >= 0; i--)
        {
            if (s[i] == '|')
            {
                r = i;
            }

            right[i] = r;
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int[] query = queries[i];
            int x = right[query[0]], y = left[query[1]];
            ans[i] = x == -1 || y == -1 || x >= y ? 0 : preSum[y] - preSum[x];
        }

        return ans;
    }

    /// <summary>
    /// 2180. Count Integers With Even Digit Sum
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static int CountEven(int num)
    {
        int y = num / 10, x = num % 10;
        int res = y * 5, ySum = 0;
        while (y > 0)
        {
            ySum += y % 10;
            y /= 10;
        }

        if (ySum % 2 == 0)
        {
            res += x / 2 + 1;
        }
        else
        {
            res += (x + 1) / 2;
        }

        return res - 1;
    }

    /// <summary>
    /// 2185.Counting Words With a Given Prefix
    /// </summary>
    /// <param name="words"></param>
    /// <param name="pref"></param>
    /// <returns></returns>
    public static int PrefixCount(string[] words, string pref) => words.Count(x => x.StartsWith(pref));

    class ElementIndexPair
    {
        public int Element { get; set; }
        public int Index { get; set; }

        public ElementIndexPair()
        {
            
        }

        public ElementIndexPair(int element, int index)
        {
            Element = element;
            Index = index;
        }
    }

    class ElementIndexPairComparer : IComparer<(int element, int index)>
    {
        public int Compare((int element, int index) x, (int element, int index) y)
        {
            if (x.element < y.element)
            {
                return -1;
            }

            if (x.element > y.element)
            {
                return 1;
            }

            return x.index < y.index ? -1 : 1;
        }

    }

    /// <summary>
    /// 3264. Final Array State After K Multiplication Operations I
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <param name="multiplier"></param>
    /// <returns></returns>
    public static int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        var n = nums.Length;
        var pq = new PriorityQueue<ElementIndexPair, (int element, int index)>(new ElementIndexPairComparer());
        for (int i = 0; i < n; i++)
        {
            pq.Enqueue(new ElementIndexPair(nums[i], i), (nums[i], i));
        }

        while (k > 0)
        {
            ElementIndexPair pair = pq.Dequeue();
            pair.Element *= multiplier;
            pq.Enqueue(pair, (pair.Element, pair.Index));
            k--;
        }

        int[] res = new int[n];
        for (int i = 0; i < n; i++)
        {
            ElementIndexPair pair = pq.Dequeue();
            res[pair.Index] = pair.Element;
        }
        return res;
    }
}
