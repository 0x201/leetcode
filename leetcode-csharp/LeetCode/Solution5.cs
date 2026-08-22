// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 1022. Sum of Root To Leaf Binary Numbers
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static int SumRootToLeaf(TreeNode root)
    {
        return Dfs(root, 0);

        int Dfs(TreeNode node, int val)
        {
            if (node is null)
            {
                return 0;
            }

            val = (val << 1) | node.Val;
            if (node.Left is null && node.Right is null)
            {
                return val;
            }

            return Dfs(node.Left, val) + Dfs(node.Right, val);
        }
    }

    /// <summary>
    /// 1025. Divisor Game
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static bool DivisorGame(int num)
    {
        return num % 2 == 0;
    }

    /// <summary>
    /// 1046. Last Stone Weight
    /// </summary>
    /// <param name="stones"></param>
    /// <returns></returns>
    public static int LastStoneWeight(List<int> stones)
    {
        var pq = new PriorityQueue<int>();
        foreach (int stone in stones)
        {
            pq.Push(stone);
        }

        while (pq.Count > 1)
        {
            int s1 = pq.Top();
            pq.Pop();
            int s2 = pq.Top();
            pq.Pop();
            if (s1 > s2)
            {
                pq.Push(s1 - s2);
            }
        }

        return pq.IsEmpty() ? 0 : pq.Top();
    }

    /// <summary>
    /// 1091. Shortest Path in Binary Matrix
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int ShortestPathBinaryMatrix(int[][] grid)
    {
        if (grid[0][0] == 1)
        {
            return -1;
        }

        int n = grid.Length;
        int[][] distance = new int[n][];
        for (int i = 0; i < n; i++)
        {
            distance[i] = new int[n];
            Array.Fill(distance[i], int.MaxValue);
        }

        var queue = new Queue<(int, int)>();
        queue.Enqueue((0, 0));
        distance[0][0] = 1;
        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();
            if (x == n - 1 && y == n - 1)
            {
                return distance[x][y];
            }

            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    if (x + dx < 0 || x + dx >= n || y + dy < 0 || y + dy >= n)
                    {
                        continue;
                    }

                    if (grid[x + dx][y + dy] == 1 || distance[x + dx][y + dy] <= distance[x][y] + 1)
                    {
                        continue;
                    }

                    distance[x + dx][y + dy] = distance[x][y] + 1;
                    queue.Enqueue((x + dx, y + dy));
                }
            }
        }

        return -1;
    }
}
