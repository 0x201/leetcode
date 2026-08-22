// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 401. Binary Watch
    /// </summary>
    public static IList<string> ReadBinaryWatch(int turnedOn)
    {
        IList<string> ans = new List<string>();
        for (int i = 0; i < 1024; ++i)
        {
            int h = i >> 6, m = i & 63;
            if (h < 12 && m < 60 && BitCount(i) == turnedOn)
            {
                ans.Add(h + ":" + (m < 10 ? "0" : "") + m);
            }
        }

        return ans;

        int BitCount(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (i + (i >> 4)) & 0x0f0f0f0f;
            i = i + (i >> 8);
            i = i + (i >> 16);
            return i & 0x3f;
        }
    }

    /// <summary>
    /// 412. Fizz Buzz
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IList<string> FizzBuzz(int n)
    {
        IList<string> answer = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            var sb = new StringBuilder();
            if (i % 3 == 0)
            {
                sb.Append("Fizz");
            }

            if (i % 5 == 0)
            {
                sb.Append("Buzz");
            }

            if (sb.Length == 0)
            {
                sb.Append(i);
            }

            answer.Add(sb.ToString());
        }

        return answer;
    }

    /// <summary>
    /// 415. Add Strings
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static string AddStrings(string num1, string num2)
    {
        int i = num1.Length - 1, j = num2.Length - 1, carry = 0;
        var ans = new StringBuilder();
        while (i >= 0 || j >= 0 || carry != 0)
        {
            int x = i >= 0 ? num1[i] - '0' : 0;
            int y = j >= 0 ? num2[j] - '0' : 0;
            int result = x + y + carry;
            ans.Append(result % 10);
            carry = result / 10;
            i--;
            j--;
        }

        return new string(ans.ToString().Reverse().ToArray());
    }

    /// <summary>
    /// 429. N-ary Tree Level Order Traversal
    /// </summary>
    public static IList<IList<int>> LevelOrder(Node root)
    {
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null)
        {
            return res;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Any())
        {
            int size = queue.Count;
            IList<int> tmp = new List<int>();
            for (int i = 0; i < size; i++)
            {
                Node curr = queue.Peek();
                tmp.Add(curr.Val);
                foreach (Node child in curr.Children)
                {
                    queue.Enqueue(child);
                }

                queue.Dequeue();
            }

            res.Add(tmp);
        }

        return res;
    }

    /// <summary>
    /// 434. Number of Segments in a String
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int CountSegments(string s)
    {
        return s.Where((t, i) => (i == 0 || s[i - 1] == ' ') && t != ' ').Count();
    }

    /// <summary>
    /// 450. Delete Node in a BST
    /// </summary>
    public static TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null)
        {
            return null;
        }

        if (root.Val > key)
        {
            root.Left = DeleteNode(root.Left, key);
        }
        else if (root.Val < key)
        {
            root.Right = DeleteNode(root.Right, key);
        }
        else
        {
            if (root.Left == null)
            {
                return root.Right;
            }

            if (root.Right == null)
            {
                return root.Left;
            }

            TreeNode minNode = FindMinHelper(root.Right);
            root.Val = minNode.Val;
            root.Right = DeleteNode(root.Right, root.Val);
        }

        return root;

        TreeNode FindMinHelper(TreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }

    /// <summary>
    /// 453. Minimum Moves to Equal Array Elements
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int MinMoves(int[] nums)
    {
        int min = nums.Min();
        int res = 0;
        foreach (int num in nums)
        {
            res += num - min;
        }
        return res;
    }

    /// <summary>
    /// 459. Repeated Substring Pattern
    /// </summary>
    /// <param name="s">input string</param>
    /// <returns></returns>
    public static bool RepeatedSubstring(string s)
    {
        int n = s.Length;
        var sb = new StringBuilder();
        for (int i = 1; i <= n / 2; i++)
        {
            if (n % i != 0)
            {
                continue;
            }

            sb.Clear();
            string sub = s[..i];
            while (sb.Length < n)
            {
                sb.Append(sub);
            }

            if (sb.ToString().Equals(s))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 462. Minimum Moves to Equal Array Elements II
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int MinMove2(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int mid = nums[n / 2];
        return nums.Sum(x => Math.Abs(x - mid));
    }

    /// <summary>
    /// 463. IsLand Perimeter
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int IsLandPerimeter(int[,] grid)
    {
        int island = 0;
        int neighbor = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid.GetLength(1) - 1; j++)
            {
                if (grid[i, j] != 1)
                {
                    continue;
                }

                island++;
                if (i < grid.Length - 1 && grid[i, j + 1] == 1)
                {
                    neighbor++;
                }

                if (j < grid.GetLength(1) - 1 && grid[i, j] == 1)
                {
                    neighbor++;
                }
            }
        }

        return island * 4 - neighbor * 2;
    }

    /// <summary>
    /// 467. Unique Substrings in Wraparound String
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static int FindSubstringInWraparoundString(string p)
    {
        int[] dp = new int[26];
        int k = 0;
        for (int i = 0; i < p.Length; ++i)
        {
            if (i > 0 && (p[i] - p[i - 1] + 26) % 26 == 1)
            {
                ++k;
            }
            else
            {
                k = 1;
            }

            dp[p[i] - 'a'] = Math.Max(dp[p[i] - 'a'], k);
        }

        return dp.Sum();
    }

    /// <summary>
    /// 468. Valid IP Address
    /// </summary>
    /// <param name="queryIp"></param>
    /// <returns></returns>
    public static string ValidIpAddress(string queryIp)
    {
        if (queryIp.Count(c => c == '.') == 3)
        {
            return ValidIPv4(queryIp);
        }

        return queryIp.Count(c => c == ':') == 7 ? ValidIPv6(queryIp) : "Neither";

        string ValidIPv4(string ip)
        {
            string[] chunks = ip.Split('.');
            foreach (string chunk in chunks)
            {
                if (chunk.Length is 0 or > 3)
                {
                    return "Neither";
                }

                if (chunk[0] == '0' && chunk.Length != 1)
                {
                    return "Neither";
                }

                if (chunk.Any(c => !char.IsNumber(c)))
                {
                    return "Neither";
                }

                if (Convert.ToInt32(chunk) > 255)
                {
                    return "Neither";
                }
            }

            return "IPv4";
        }

        string ValidIPv6(string ip)
        {
            string[] chunks = ip.Split(':');
            const string hexDigits = "0123456789abcdefABCDEF";
            foreach (string chunk in chunks)
            {
                if (chunk.Length is 0 or > 4)
                {
                    return "Neither";
                }

                if (chunk.Any(c => !hexDigits.Contains(c)))
                {
                    return "Neither";
                }
            }

            return "IPv6";
        }
    }

    /// <summary>
    /// 477.Total Hamming Distance
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int TotalHammingDistance(int[] nums)
    {
        int size = nums.Length;
        int res = 0;
        for (int i = 0; i < 30; i++)
        {
            int tmp = nums.Sum(num => (num >> i) & 1);
            res += tmp * (size - tmp);
        }

        return res;
    }

    /// <summary>
    /// 498. Diagonal Traverse
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public static int[] FindDiagonalOrder(int[][] matrix)
    {
        if (matrix == null || matrix.Length == 0)
        {
            return [];
        }

        int rowNumber = matrix.Length;
        int columnNumber = matrix[0].Length;
        int row = 0, col = 0;
        int direction = 1;
        int[] res = new int[rowNumber * columnNumber];
        int r = 0;
        while (row < rowNumber && col < columnNumber)
        {
            res[r++] = matrix[row][col];
            int newRow = row + (direction == 1 ? -1 : 1);
            int newCol = col + (direction == 1 ? 1 : -1);
            if (newRow < 0 || newRow == rowNumber || newCol < 0 || newCol == columnNumber)
            {
                if (direction == 1)
                {
                    row += (col == columnNumber - 1 ? 1 : 0);
                    col += (col < columnNumber - 1 ? 1 : 0);
                }
                else
                {
                    col += (row == rowNumber - 1 ? 1 : 0);
                    row += (row < rowNumber - 1 ? 1 : 0);
                }

                direction = 1 - direction;
            }
            else
            {
                row = newRow;
                col = newCol;
            }
        }

        return res;
    }

    /// <summary>
    /// 504. Base 7
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string ConvertToBase7(int num)
    {
        if (num == 0)
        {
            return "0";
        }

        bool negative = num < 0;
        num = Math.Abs(num);
        var digits = new StringBuilder();
        while (num > 0)
        {
            digits.Append(num % 7);
            num /= 7;
        }

        if (negative)
        {
            digits.Append('-');
        }

        string res = digits.ToString();
        return string.Create(res.Length, res, (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars.Reverse();
        });
    }

    /// <summary>
    /// 509. Fibonacci Number
    /// </summary>
    public static int Fib(int n)
    {
        if (n < 2)
        {
            return n;
        }

        int f0 = 0;
        int f1 = 1;
        int res = 0;
        for (int i = 1; i < n; i++)
        {
            res = f0 + f1;
            f0 = f1;
            f1 = res;
        }

        return res;
    }

    /// <summary>
    /// 521. Longest Uncommon Subsequence I
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int FindLusLength(string a, string b)
    {
        return a == b ? -1 : Math.Max(a.Length, b.Length);
    }

    /// <summary>
    /// 537. Complex Number Multiplication
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static string ComplexNumberMultiply(string num1, string num2)
    {
        string[] complex1 = num1.Split('+', 'i');
        string[] complex2 = num2.Split('+', 'i');
        int real1 = int.Parse(complex1[0]);
        int real2 = int.Parse(complex2[0]);
        int imag1 = int.Parse(complex1[1]);
        int imag2 = int.Parse(complex2[1]);
        return $"{real1 * real2 - imag1 * imag2}+{real1 * imag2 + imag1 * real2}i";
    }

    /// <summary>
    /// 540. Single Element in a Sorted Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int SingleNonDuplicate(int[] nums)
    {
        int low = 0, high = nums.Length - 1;
        while (low < high)
        {
            int mid = (high - low) / 2 + low;
            if (nums[mid] == nums[mid ^ 1])
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return nums[low];
    }

    /// <summary>
    /// 542. 01 Matrix
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public static int[][] UpdateMatrix(int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length;
        int[][] dist = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dist[i] = new int[n];
            Array.Fill(dist[i], int.MaxValue / 2);
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 0)
                {
                    dist[i][j] = 0;
                }
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i - 1 >= 0)
                {
                    dist[i][j] = Math.Min(dist[i][j], dist[i - 1][j] + 1);
                }

                if (j - 1 >= 0)
                {
                    dist[i][j] = Math.Min(dist[i][j], dist[i][j - 1] + 1);
                }
            }
        }

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (i + 1 < m)
                {
                    dist[i][j] = Math.Min(dist[i][j], dist[i + 1][j] + 1);
                }

                if (j + 1 < n)
                {
                    dist[i][j] = Math.Min(dist[i][j], dist[i][j + 1] + 1);
                }
            }
        }

        return dist;
    }

    /// <summary>
    /// 553. Optimal Division
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static string OptimalDivision(int[] nums)
    {
        int n = nums.Length;
        switch (n)
        {
            case 1:
                return nums[0].ToString();
            case 2:
                return $"{nums[0]}/{nums[1]}";
        }

        var res = new StringBuilder();
        res.Append(nums[0]);
        res.Append("/(");
        res.Append(nums[1]);
        for (int i = 2; i < n; i++)
        {
            res.Append('/');
            res.Append(nums[i]);
        }

        res.Append(')');
        return res.ToString();
    }

    /// <summary>
    /// 557. Reverse Words in a String III
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ReverseWords(string s)
    {
        var sb = new StringBuilder();
        int len = s.Length;
        int i = 0;
        while (i < len)
        {
            int start = i;
            while (i < len && s[i] != ' ')
            {
                i++;
            }

            for (int p = start; p < i; p++)
            {
                sb.Append(s[start + i - 1 - p]);
            }

            while (i < len && s[i] == ' ')
            {
                i++;
                sb.Append(' ');
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// 567. Permutation in String
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static bool CheckInclusion(string s1, string s2)
    {
        int n = s1.Length, m = s2.Length;
        if (n > m)
        {
            return false;
        }

        int[] cnt = new int[26];
        for (int i = 0; i < n; i++)
        {
            --cnt[s1[i] - 'a'];
            ++cnt[s2[i] - 'a'];
        }

        int diff = cnt.Count(item => item != 0);
        if (diff == 0)
        {
            return true;
        }

        for (int i = n; i < m; i++)
        {
            int x = s2[i] - 'a', y = s2[i - n] - 'a';
            if (x == y)
            {
                continue;
            }

            if (cnt[x] == 0)
            {
                ++diff;
            }

            ++cnt[x];
            if (cnt[x] == 0)
            {
                --diff;
            }

            if (cnt[y] == 0)
            {
                ++diff;
            }

            --cnt[y];
            if (cnt[y] == 0)
            {
                --diff;
            }

            if (diff == 0)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 575. Distribute Candies
    /// </summary>
    /// <param name="candyType"></param>
    /// <returns></returns>
    public static int DistributeCandies(int[] candyType) 
    {
        var set = candyType.ToHashSet();
        return Math.Min(set.Count, candyType.Length / 2);
    }

    /// <summary>
    /// 589. N-ary Tree Preorder Traversal
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IList<int> PreOrder(Node root)
    {
        IList<int> ans = new List<int>();
        Dfs(root);
        return ans;

        void Dfs(Node node)
        {
            if (node is null)
            {
                return;
            }

            ans.Add(node.Val);
            foreach (Node ch in node.Children)
            {
                Dfs(ch);
            }
        }
    }

    /// <summary>
    /// 590. N-ary Tree Postorder Traversal
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IList<int> PostOrder(Node root)
    {
        IList<int> ans = new List<int>();
        Dfs(root);
        return ans;

        void Dfs(Node node)
        {
            if (node is null)
            {
                return;
            }

            foreach (Node ch in node.Children)
            {
                Dfs(ch);
            }

            ans.Add(node.Val);
        }
    }

    /// <summary>
    /// 599. Minimum Index Sum of Two Lists
    /// </summary>
    /// <param name="list1"></param>
    /// <param name="list2"></param>
    /// <returns></returns>
    public static string[] FindRestaurant(string[] list1, string[] list2)
    {
        var index = new Dictionary<string, int>();
        for (int i = 0; i < list1.Length; i++)
        {
            index.Add(list1[i], i);
        }

        IList<string> ret = new List<string>();
        int indexSum = int.MaxValue;
        for (int i = 0; i < list2.Length; i++)
        {
            if (!index.ContainsKey(list2[i]))
            {
                continue;
            }

            int j = index[list2[i]];
            if (i + j < indexSum)
            {
                ret.Clear();
                ret.Add(list2[i]);
                indexSum = i + j;
            }
            else if (i + j == indexSum)
            {
                ret.Add(list2[i]);
            }
        }

        return ret.ToArray();
    }
}
