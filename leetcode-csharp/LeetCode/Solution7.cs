// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 1235. Maximum Profit in Job Scheduling
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="profit"></param>
    /// <returns></returns>
    public static int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        int n = startTime.Length;
        int[][] jobs = new int[n][];
        for (int i = 0; i < n; i++)
        {
            jobs[i] = [startTime[i], endTime[i], profit[i]];
        }

        Array.Sort(jobs, (a, b) => a[1] - b[1]);
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            int k = BinarySearchCore(jobs, i - 1, jobs[i - 1][0]);
            dp[i] = Math.Max(dp[i - 1], dp[k] + jobs[i - 1][2]);
        }

        return dp[n];

        int BinarySearchCore(int[][] data, int right, int target)
        {
            int left = 0;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (data[mid][1] > target)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }
    }

    /// <summary>
    /// 1249
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string MinRemoveToMakeValid(string s)
    {
        var sb = new StringBuilder();
        int openSeen = 0;
        int balance = 0;
        foreach (char c in s)
        {
            switch (c)
            {
                case '(':
                    openSeen++;
                    balance++;
                    break;
                case ')' when balance == 0:
                    continue;
                case ')':
                    balance--;
                    break;
            }

            sb.Append(c);
        }

        var res = new StringBuilder();
        int openToKeep = openSeen - balance;
        for (int i = 0; i < sb.Length; i++)
        {
            char c = sb[i];
            if (c == '(')
            {
                openToKeep--;
                if (openToKeep < 0)
                {
                    continue;
                }
            }

            res.Append(c);
        }

        return res.ToString();
    }

    /// <summary>
    /// 1260. Shift 2D Grid
    /// </summary>
    public static IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        int n = grid.Length, m = grid[0].Length;
        // use array
        IList<IList<int>> res = new List<IList<int>>();
        if (n == 0)
        {
            return res;
        }
        for (int r = 0; r < n; r++)
        {
            res[r] = new int[m];
        }

        // use list
        // IList<IList<int>> res = new IList<List<int>>();
        // for (int i = 0; i < n; i++)
        // {
        //     List<int> tmp = new List<int>();
        //     for (int j = 0; j < m; j++)
        //         tmp.Add(0);
        //     res.Add(tmp);
        // }

        k %= (m * n);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int index = (i * m + j + k) % (m * n);
                int x = index / m, y = index % m;
                res[x][y] = grid[i][j];
            }
        }

        return res;
    }

    /// <summary>
    /// 1305. All Elements in Two Binary Search Trees
    /// </summary>
    /// <param name="root1"></param>
    /// <param name="root2"></param>
    /// <returns></returns>
    public static IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        IList<int> nums1 = new List<int>();
        IList<int> nums2 = new List<int>();
        Inorder(root1, nums1);
        Inorder(root2, nums2);
        IList<int> merged = new List<int>();
        int p1 = 0, p2 = 0;
        while (true)
        {
            if (p1 == nums1.Count)
            {
                while (p2 < nums2.Count)
                {
                    merged.Add(nums2[p2++]);
                }

                break;
            }

            if (p2 == nums1.Count)
            {
                while (p1 < nums1.Count)
                {
                    merged.Add(nums1[p1++]);
                }

                break;
            }

            merged.Add(nums1[p1] < nums2[p2] ? nums1[p1++] : nums2[p2++]);
        }

        return merged;

        void Inorder(TreeNode node, IList<int> res)
        {
            while (true)
            {
                if (node != null)
                {
                    Inorder(node.Left, res);
                    res.Add((node.Val));
                    node = node.Right;
                    continue;
                }

                break;
            }
        }
    }

    /// <summary>
    /// 1374. Generate a String With Characters That Have Odd Counts
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static string GenerateTheString(int n)
    {
        if (n % 2 == 0)
        {
            return new string('a', n - 1) + "b";
        }

        return new string('a', n);
    }

    /// <summary>
    /// 1380. Lucky Numbers in a Matrix
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public static IList<int> LuckyNumbers(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int[] minRow = new int[m];
        Array.Fill(minRow, int.MaxValue);
        int[] maxCol = new int[n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                minRow[i] = Math.Min(minRow[i], matrix[i][j]);
                maxCol[j] = Math.Max(maxCol[j], matrix[i][j]);
            }
        }

        IList<int> res = new List<int>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == minRow[i] && matrix[i][j] == maxCol[j])
                {
                    res.Add(matrix[i][j]);
                }
            }
        }

        return res;
    }
}
