// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public static class InterviewSolution
{
    /// <summary>
    /// 面试题 01.05. One Away LCCI
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public static bool OneEditAway(string first, string second)
    {
        int m = first.Length, n = second.Length;
        if (n - m == 1)
        {
            return OneInsert(first, second);
        }

        if (m - n == 1)
        {
            return OneInsert(second, first);
        }

        if (m != n) return false;
        bool foundDifference = false;
        for (int i = 0; i < m; i++)
        {
            if (first[i] == second[i]) continue;
            if (!foundDifference)
            {
                foundDifference = true;
            }
            else
            {
                return false;
            }
        }
        return true;

        bool OneInsert(string shorter, string longer)
        {
            int len1 = shorter.Length, len2 = longer.Length;
            int index1 = 0, index2 = 0;
            while (index1 < len1 && index2 < len2)
            {
                if (shorter[index1] == longer[index2])
                {
                    index1++;
                }
                index2++;
                if (index2 - index1 > 1)
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// 面试题 01.02. Check Permutation LCCI
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static bool CheckPermutation(string s1, string s2)
    {
        int len1 = s1.Length, len2 = s2.Length;
        if (len1 != len2)
        {
            return false;
        }
        int[] map = new int[128];
        for (int i = 0; i < len1; i++)
        {
            map[s1[i]]++;
        }
        for (int i = 0; i < len2; i++)
        {
            map[s2[i]]--;
            if (map[s2[i]] < 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 面试题 01.07. Rotate Matrix LCCI
    /// </summary>
    /// <param name="matrix"></param>
    public static void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            matrix[i] = matrix[i].Reverse().ToArray();
        }
    }

    /// <summary>
    /// 面试题 01.09. String Rotation LCCI
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static bool IsFlippedString(string s1, string s2)
    {
        return s1.Length == s2.Length && (s1 + s1).Contains(s2);
    }

    /// <summary>
    /// 面试题 08.03. Magic Index LCCI
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int FindMagicIndex(int[] nums)
    {
        int right = nums.Length - 1;
        const int left = 0;
        return FindMagicIndexHelper(nums, left, right);

        int FindMagicIndexHelper(int[] data, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
            {
                return -1;
            }

            int mid = (rightIndex - leftIndex) / 2 + leftIndex;
            int leftAns = FindMagicIndexHelper(data, leftIndex, mid - 1);
            if (leftAns != -1)
            {
                return leftAns;
            }

            return data[mid] == mid ? mid : FindMagicIndexHelper(data, mid + 1, rightIndex);
        }
    }

    /// <summary>
    /// 面试题 17.09. Get Kth Magic Number LCCI
    /// </summary>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int GetKthMagicNumber(int k)
    {
        int[] dp = new int[k + 1];
        dp[1] = 1;
        int p3 = 1, p5 = 1, p7 = 1;
        for (int i = 2; i <= k; i++)
        {
            int num3 = dp[p3] * 3, num5 = dp[p5] * 5, num7 = dp[p7] * 7;
            dp[i] = Math.Min(Math.Min(num3, num5), num7);
            if (dp[i] == num3)
            {
                p3++;
            }
            if (dp[i] == num5)
            {
                p5++;
            }
            if (dp[i] == num7)
            {
                p7++;
            }
        }
        return dp[k];
    }

    /// <summary>
    /// 面试题 17.11. Find Closest LCCI
    /// </summary>
    /// <param name="words"></param>
    /// <param name="word1"></param>
    /// <param name="word2"></param>
    /// <returns></returns>
    public static int FindClosest(string[] words, string word1, string word2)
    {
        int ans = words.Length;
        int index1 = -1, index2 = -1;
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (word == word1)
            {
                index1 = i;
            }
            else if (word == word2)
            {
                index2 = i;
            }
            if (index1 >= 0 && index2 >= 0)
            {
                ans = Math.Min(ans, Math.Abs(index1 - index2));
            }
        }
        return ans;
    }
}
