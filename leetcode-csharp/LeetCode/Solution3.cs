// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 617. Merge Two Binary Trees
    /// </summary>
    public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
    {
        // Recursive
        // if(t1 == null)
        //     return t2;
        // if(t2 == null)
        //     return t1;
        // t1.val += t2.val;
        // t1.left = MergeTrees(t1.left, t2.left);
        // t1.right = MergeTrees(t1.right, t2.right);
        // return t1;
        // Iterative
        if (t1 == null)
        {
            return t2;
        }

        var stack = new Stack<TreeNode[]>();
        stack.Push([t1, t2]);
        while (stack.Count > 0)
        {
            TreeNode[] t = stack.Pop();
            if (t[0] == null || t[1] == null)
            {
                continue;
            }

            t[0].Val += t[1].Val;
            if (t[0].Left == null)
            {
                t[0].Left = t[1].Left;
            }
            else
            {
                stack.Push([t[0].Left, t[1].Left]);
            }

            if (t[0].Right == null)
            {
                t[0].Right = t[1].Right;
            }
            else
            {
                stack.Push([t[0].Right, t[1].Right]);
            }
        }

        return t1;
    }

    /// <summary>
    /// 623. Add One Row to Tree
    /// </summary>
    /// <param name="root"></param>
    /// <param name="val"></param>
    /// <param name="depth"></param>
    /// <returns></returns>
    public static TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        if (root is null)
        {
            return null;
        }

        if (depth == 1)
        {
            return new TreeNode(val, root);
        }

        if (depth == 2)
        {
            root.Left = new TreeNode(val, root.Left);
            root.Right = new TreeNode(val, null, root.Right);
        }
        else
        {
            root.Left = AddOneRow(root.Left, val, depth - 1);
            root.Right = AddOneRow(root.Right, val, depth - 1);
        }

        return root;
    }

    /// <summary>
    /// 636. Exclusive Time of Functions
    /// </summary>
    /// <param name="n"></param>
    /// <param name="logs"></param>
    /// <returns></returns>
    public static int[] ExclusiveTime(int n, IList<string> logs)
    {
        var stack = new Stack<int[]>();
        int[] res = new int[n];
        const string startCommand = "start";
        foreach (string log in logs)
        {
            string[] data = log.Split(':');
            int index = int.Parse(data[0]);
            int timestamp = int.Parse(data[2]);
            if (data[1] == startCommand)
            {
                if (stack.Count > 0)
                {
                    res[stack.Peek()[0]] += timestamp - stack.Peek()[1];
                }

                stack.Push([index, timestamp]);
            }
            else
            {
                int[] pair = stack.Pop();
                res[pair[0]] += timestamp - pair[1] + 1;
                if (stack.Count > 0)
                {
                    stack.Peek()[1] = timestamp + 1;
                }
            }
        }

        return res;
    }

    /// <summary>
    /// 646. Maximum Length of Pair Chain
    /// </summary>
    /// <param name="pairs"></param>
    /// <returns></returns>
    public static int FindLongestChain(int[][] pairs)
    {
        Array.Sort(pairs, (a, b) => a[1] - b[1]);
        int curr = int.MinValue, res = 0;
        foreach (int[] pair in pairs)
        {
            if (curr < pair[0])
            {
                curr = pair[1];
                res++;
            }
        }

        return res;
    }

    /// <summary>
    /// 652. Find Duplicate Subtrees
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        Dictionary<string, (TreeNode, int)> seen = new();
        var repeat = new HashSet<TreeNode>();
        int index = 0;
        Dfs(root);
        return new List<TreeNode>(repeat);

        int Dfs(TreeNode node)
        {
            if (node is null)
            {
                return 0;
            }

            (int, int, int) triple = (node.Val, Dfs(node.Left), Dfs(node.Right));
            string key = triple.ToString();
            if (seen.TryGetValue(key, out (TreeNode, int) pair))
            {
                repeat.Add(pair.Item1);
                return pair.Item2;
            }

            seen.Add(key, (node, ++index));
            return index;
        }
    }

    /// <summary>
    /// 653. Two Sum IV
    /// </summary>
    /// <param name="root"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static bool FindTarget(TreeNode root, int k)
    {
        TreeNode left = root, right = root;
        var leftStack = new Stack<TreeNode>();
        var rightStack = new Stack<TreeNode>();
        leftStack.Push(left);
        while (left.Left != null)
        {
            leftStack.Push(left.Left);
            left = left.Left;
        }

        rightStack.Push(right);
        while (right.Right != null)
        {
            rightStack.Push(right.Right);
            right = right.Right;
        }

        while (left != right)
        {
            if (left.Val + right.Val == k)
            {
                return true;
            }

            if (left.Val + right.Val < k)
            {
                left = GetLeft(leftStack);
            }
            else
            {
                right = GetRight(rightStack);
            }
        }

        return false;

        TreeNode GetRight(Stack<TreeNode> stack)
        {
            TreeNode currentNode = stack.Pop();
            TreeNode node = currentNode.Left;
            while (node != null)
            {
                stack.Push(node);
                node = node.Right;
            }

            return currentNode;
        }

        TreeNode GetLeft(Stack<TreeNode> stack)
        {
            TreeNode currentNode = stack.Pop();
            TreeNode node = currentNode.Right;
            while (node != null)
            {
                stack.Push(node);
                node = node.Left;
            }

            return currentNode;
        }
    }

    /// <summary>
    /// 654. Maximum Binary Tree
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        int n = nums.Length;
        var stack = new List<int>();
        var trees = new TreeNode[n];
        for (int i = 0; i < n; i++)
        {
            trees[i] = new TreeNode(nums[i]);
            while (stack.Count > 0 && nums[i] > nums[stack[^1]])
            {
                trees[i].Left = trees[stack[^1]];
                stack.RemoveAt(stack.Count - 1);
            }

            if (stack.Count > 0)
            {
                trees[stack[^1]].Right = trees[i];
            }

            stack.Add(i);
        }

        return trees[stack[0]];
    }

    /// <summary>
    /// 658. Find K Closest Elements
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="k"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public static IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        int right = BinarySearchHelper(arr, x);
        int left = right - 1;
        int n = arr.Length;
        while (k-- > 0)
        {
            if (left < 0)
            {
                right++;
            }
            else if (right >= n || x - arr[left] <= arr[right] - x)
            {
                left--;
            }
            else
            {
                right++;
            }
        }

        return arr[(left + 1)..right];

        int BinarySearchHelper(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] >= target)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }
    }

    /// <summary>
    /// 662. Maximum Width of Binary Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static int WidthOfBinaryTree(TreeNode root)
    {
        var levelMin = new Dictionary<int, int>();

        int Dfs(TreeNode node, int depth, int index)
        {
            if (node is null)
            {
                return 0;
            }

            levelMin.TryAdd(depth, index);
            return Math.Max(index - levelMin[depth] + 1,
                Math.Max(
                    Dfs(node.Left, depth + 1, index * 2),
                    Dfs(node.Right, depth + 1, index * 2 + 1)));
        }

        return Dfs(root, 1, 1);
    }

    /// <summary>
    /// 665. Non-decreasing Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static bool CheckPossibility(int[] nums)
    {
        int n = nums.Length, count = 0;
        for (int i = 0; i < n - 1; i++)
        {
            int x = nums[i], y = nums[i + 1];
            if (x > y)
            {
                count++;
                if (count > 1)
                {
                    return false;
                }

                if (i > 0 && y < nums[i - 1])
                {
                    nums[i + 1] = x;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// 667. Beautiful Arrangement II
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int[] ConstructArray(int n, int k)
    {
        int[] res = new int[n];
        int index = 0;
        for (int i = 1; i < n - k; ++i)
        {
            res[index++] = i;
        }

        for (int i = n - k, j = n; i <= j; ++i, --j)
        {
            res[index++] = i;
            if (i != j)
            {
                res[index++] = j;
            }
        }

        return res;
    }

    /// <summary>
    /// 669. Trim a Binary Search Tree
    /// </summary>
    public static TreeNode TrimBst(TreeNode root, int low, int high)
    {
        // recursively
        //if (root == null)
        //{
        //    return null;
        //}

        //if (root.val > high)
        //{
        //    return TrimBST(root.left, low, high);
        //}

        //if (root.val < low)
        //{
        //    return TrimBST(root.right, low, high);
        //}

        //root.left = TrimBST(root.left, low, high);
        //root.right = TrimBST(root.right, low, high);
        //return root;

        // iteratively
        while (root is not null && (root.Val < low || root.Val > high))
        {
            root = root.Val < low ? root.Right : root.Left;
        }

        if (root is null)
        {
            return null;
        }

        for (TreeNode node = root; node.Left is not null;)
        {
            if (node.Left.Val < low)
            {
                node.Left = node.Left.Right;
            }
            else
            {
                node = node.Left;
            }
        }

        for (TreeNode node = root; node.Right is not null;)
        {
            if (node.Right.Val > high)
            {
                node.Right = node.Right.Left;
            }
            else
            {
                node = node.Right;
            }
        }

        return root;
    }

    /// <summary>
    /// 670. Maximum Swap
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static int MaximumSwap(int num)
    {
        char[] chars = num.ToString().ToCharArray();
        int n = chars.Length;
        int maxIndex = n - 1, index1 = -1, index2 = -1;
        for (int i = n - 1; i >= 0; i--)
        {
            if (chars[i] > chars[maxIndex])
            {
                maxIndex = i;
            }
            else if (chars[i] < chars[maxIndex])
            {
                index1 = i;
                index2 = maxIndex;
            }
        }

        if (index1 >= 0)
        {
            (chars[index1], chars[index2]) = (chars[index2], chars[index1]);
            return int.Parse(new string(chars));
        }

        return num;
    }

    /// <summary>
    /// 672. Bulb Switcher II
    /// </summary>
    /// <param name="n"></param>
    /// <param name="presses"></param>
    /// <returns></returns>
    public static int FlipLights(int n, int presses)
    {
        var seen = new HashSet<int>();
        for (int i = 0; i < 1 << 4; i++)
        {
            int[] pressArray = new int[4];
            for (int j = 0; j < 4; j++)
            {
                pressArray[j] = i >> j & 1;
            }

            int sum = pressArray.Sum();
            if (sum % 2 == presses % 2 && sum <= presses)
            {
                int status = pressArray[0] ^ pressArray[1] ^ pressArray[3];
                if (n >= 2)
                {
                    status |= (pressArray[0] ^ pressArray[1]) << 1;
                }

                if (n >= 3)
                {
                    status |= (pressArray[0] ^ pressArray[2]) << 2;
                }

                if (n >= 4)
                {
                    status |= status << 3;
                }

                seen.Add(status);
            }
        }

        return seen.Count;
    }

    /// <summary>
    /// 679. 24 Game
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static bool JudgePoint24(int[] nums)
    {
        var doubleNumbers = nums
            .Select(Convert.ToDouble)
            .ToList();
        return Solve(doubleNumbers);

        bool Solve(List<double> data)
        {
            switch (data.Count)
            {
                case 0:
                    return false;
                case 1:
                    return Math.Abs(data[0] - 24) < 1e-6;
            }

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var nums2 = data.Where((_, k) => k != i && k != j).ToList();
                    for (int k = 0; k < 4; k++)
                    {
                        switch (k)
                        {
                            case < 2 when j > i:
                                continue;
                            case 0:
                                nums2.Add(data[i] + data[j]);
                                break;
                            case 1:
                                nums2.Add(data[i] * data[j]);
                                break;
                            case 2:
                                nums2.Add(data[i] - data[j]);
                                break;
                            case 3 when data[j] != 0:
                                nums2.Add(data[i] / data[j]);
                                break;
                            case 3:
                                continue;
                        }

                        if (Solve(nums2))
                        {
                            return true;
                        }

                        nums2.Remove(nums2.Count - 1);
                    }
                }
            }

            return false;
        }
    }

    /// <summary>
    /// 682. Baseball Game
    /// </summary>
    /// <param name="ops"></param>
    /// <returns></returns>
    public static int CalPoints(string[] ops)
    {
        int ret = 0;
        var points = new List<int>();
        foreach (string op in ops)
        {
            int n = points.Count;
            switch (op[0])
            {
                case '+':
                    ret += points[n - 1] + points[n - 2];
                    points.Add(points[n - 1] + points[n - 2]);
                    break;
                case 'D':
                    ret += 2 * points[n - 1];
                    points.Add(2 * points[n - 1]);
                    break;
                case 'C':
                    ret -= points[n - 1];
                    points.RemoveAt(n - 1);
                    break;
                default:
                    ret += int.Parse(op);
                    points.Add(int.Parse(op));
                    break;
            }
        }

        return ret;
    }

    /// <summary>
    /// 687. Longest Univalue Path
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static int LongestUnivaluePath(TreeNode root)
    {
        int res = 0;

        Dfs(root);
        return res;

        int Dfs(TreeNode node)
        {
            if (node is null)
            {
                return 0;
            }

            int left = Dfs(node.Left), right = Dfs(node.Right);
            int left1 = 0, right1 = 0;
            if (node.Left is not null && node.Left.Val == node.Val)
            {
                left1 = left + 1;
            }

            if (node.Right is not null && node.Right.Val == node.Val)
            {
                right1 = right + 1;
            }

            res = Math.Max(res, left1 + right1);
            return Math.Max(left1, right1);
        }
    }

    /// <summary>
    /// 695. Max Area of Island
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int MaxAreaOfIsland(int[][] grid)
    {
        int ans = 0;
        int rowLength = grid.Length;
        int colLength = grid[0].Length;
        int[] di = new[] { 0, 0, 1, -1 };
        int[] dj = new[] { 1, -1, 0, 0 };
        for (int row = 0; row < rowLength; row++)
        {
            for (int col = 0; col < colLength; col++)
            {
                int curr = 0;
                var queueRow = new Queue<int>();
                var queueCol = new Queue<int>();
                queueRow.Enqueue(row);
                queueCol.Enqueue(col);
                while (queueRow.Count != 0)
                {
                    int currRow = queueRow.Dequeue(), currCol = queueCol.Dequeue();
                    if (currRow < 0 || currCol < 0 || currRow == rowLength || currCol == colLength ||
                        grid[currRow][currCol] != 1)
                    {
                        continue;
                    }

                    ++curr;
                    grid[currRow][currCol] = 0;
                    for (int index = 0; index != 4; ++index)
                    {
                        int nextRow = currRow + di[index], nextCol = currCol + dj[index];
                        queueRow.Enqueue(nextRow);
                        queueCol.Enqueue(nextCol);
                    }
                }

                ans = Math.Max(ans, curr);
            }
        }

        return ans;
    }

    /// <summary>
    /// 698. Partition to K Equal Sum Subsets
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static bool CanPartitionKSubsets(int[] nums, int k)
    {
        int sum = nums.Sum();
        if (sum % k != 0)
        {
            return false;
        }

        int average = sum / k;
        Array.Sort(nums);
        int len = nums.Length;
        if (nums[len - 1] > average)
        {
            return false;
        }

        bool[] dp = new bool[1 << len];
        int[] currSum = new int[1 << len];
        dp[0] = true;
        for (int i = 0; i < 1 << len; i++)
        {
            if (!dp[i])
            {
                continue;
            }

            for (int j = 0; j < len; j++)
            {
                if (currSum[i] + nums[j] > average)
                {
                    break;
                }

                if (((i >> j) & 1) == 0)
                {
                    int next = i | (1 << j);
                    if (!dp[next])
                    {
                        currSum[next] = (currSum[i] + nums[j]) % average;
                        dp[next] = true;
                    }
                }
            }
        }

        return dp[(1 << len) - 1];
    }

    /// <summary>
    /// 700. Search in a Binary Search Tree
    /// </summary>
    public static TreeNode SearchBst(TreeNode root, int val)
    {
        while (root != null && root.Val != val)
        {
            root = val < root.Val ? root.Left : root.Right;
        }

        return root;
    }

    /// <summary>
    /// 701. Insert into a Binary Search Tree
    /// </summary>
    public static TreeNode InsertIntoBst(TreeNode root, int val)
    {
        // recursive
        // if(root == null)
        //     return new TreeNode(val);
        // if(val > root.val)
        //     root.right = InsertIntoBST(root.right, val);
        // else
        //     root.left = InsertIntoBST(root.left, val);
        // return root;
        // iterative
        if (root == null)
        {
            return new TreeNode(val);
        }

        TreeNode currentNode = root;
        while (true)
        {
            if (currentNode.Val >= val)
            {
                if (currentNode.Left != null)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode.Left = new TreeNode(val);
                    break;
                }
            }
            else
            {
                if (currentNode.Right != null)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode.Right = new TreeNode(val);
                    break;
                }
            }
        }

        return root;
    }

    /// <summary>
    /// 704. Binary Search
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int BinarySearch(int[] nums, int target)
    {
        // version 1
        //int left = 0;
        //int right = nums.Length - 1;
        //while (left <= right)
        //{
        //    int mid = left + (right - left) / 2;
        //    if (nums[mid] > target)
        //    {
        //        right = mid - 1;
        //    }
        //    else if (nums[mid] < target)
        //    {
        //        left = mid + 1;
        //    }
        //    else
        //    {
        //        return mid;
        //    }
        //}
        //return -1;

        int left = 0;
        int right = nums.Length;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] > target)
            {
                right = mid;
            }
            else if (nums[mid] < target)
            {
                left = mid;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }

    /// <summary>
    /// 709. To Lower Case
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToLowerCase(string str)
    {
        var sb = new StringBuilder();
        foreach (char r in str.Select(c => (char)(c | 32)))
        {
            sb.Append(r);
        }

        return sb.ToString();

        // LINQ
        // return string.Concat(str.Select(c => c >= 'A' && c <= 'Z' ? (char)(c + 32) : c));
    }

    /// <summary>
    /// 720. Longest Word in Dictionary
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public static string LongestWord(string[] words)
    {
        var trie = new Trie();
        foreach (string word in words)
        {
            trie.Insert(word);
        }

        string longest = string.Empty;
        foreach (string word in words)
        {
            if (!trie.Search(word)) continue;
            if (word.Length > longest.Length || (word.Length == longest.Length && string.Compare(word, longest, StringComparison.Ordinal) < 0))
            {
                longest = word;
            }
        }

        return longest;
    }

    /// <summary>
    /// 724. Find Pivot Index
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int PivotIndex(int[] nums)
    {
        int total = nums.Sum();
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (2 * sum + nums[i] == total)
            {
                return i;
            }

            sum += nums[i];
        }

        return -1;
    }

    /// <summary>
    /// 728. Self Dividing Numbers
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IList<int> SelfDividingNumbers(int left, int right)
    {
        bool IsSelfDividing(int num)
        {
            int tmp = num;
            while (tmp > 0)
            {
                int digit = tmp % 10;
                if (digit == 0 || num % digit != 0)
                {
                    return false;
                }

                tmp /= 10;
            }

            return true;
        }

        IList<int> ans = new List<int>();
        for (int i = left; i <= right; i++)
        {
            if (IsSelfDividing(i))
            {
                ans.Add(i);
            }
        }

        return ans;
    }

    /// <summary>
    /// 733. Flood Fill
    /// </summary>
    /// <param name="image"></param>
    /// <param name="sr"></param>
    /// <param name="sc"></param>
    /// <param name="newColor"></param>
    /// <returns></returns>
    public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        int[] dx = [1, 0, 0, -1];
        int[] dy = [0, 1, -1, 0];
        int currentColor = image[sr][sc];
        if (currentColor == newColor)
        {
            return image;
        }

        int n = image.Length, m = image[0].Length;
        var queue = new Queue<int[]>();
        queue.Enqueue([sr, sc]);
        image[sr][sc] = newColor;
        while (queue.Any())
        {
            int[] pair = queue.Dequeue();
            int x = pair[0], y = pair[1];
            for (int i = 0; i < 4; i++)
            {
                int mx = x + dx[i], my = y + dy[i];
                if (mx < 0 || mx >= n || my < 0 || my >= m || image[mx][my] != currentColor)
                {
                    continue;
                }

                queue.Enqueue([mx, my]);
                image[mx][my] = newColor;
            }
        }

        return image;
    }

    /// <summary>
    /// 739. Daily Temperatures
    /// </summary>
    public static int[] DailyTemperatures(int[] T)
    {
        var stack = new Stack<int>();
        int len = T.Length;
        int[] ans = new int[len];
        for (int i = 0; i < len; i++)
        {
            while (stack.Count != 0 && T[i] > T[stack.Peek()])
            {
                int t = stack.Peek();
                stack.Pop();
                ans[t] = i - t;
            }

            stack.Push(i);
        }

        return ans;
    }

    /// <summary>
    /// 769. Max Chunks To Make Sorted
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int MaxChunksToSorted(int[] arr)
    {
        int m = 0, res = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            m = Math.Max(m, arr[i]);
            if (m == i)
            {
                res++;
            }
        }

        return res;
    }

    /// <summary>
    /// 777. Swap Adjacent in LR String
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static bool CanTransform(string start, string end)
    {
        int n = start.Length;
        int i = 0, j = 0;
        while (i < n && j < n)
        {
            while (i < n && start[i] == 'X')
            {
                i++;
            }

            while (j < n && end[j] == 'X')
            {
                j++;
            }

            if (i < n && j < n)
            {
                char c = start[i];
                if (c != end[j])
                {
                    return false;
                }

                if ((c == 'L' && i < j) || (c == 'R' && i > j))
                {
                    return false;
                }

                i++;
                j++;
            }
        }

        while (i < n)
        {
            if (start[i] != 'X')
            {
                return false;
            }

            i++;
        }

        while (j < n)
        {
            if (end[j] != 'X')
            {
                return false;
            }

            j++;
        }

        return true;
    }

    /// <summary>
    /// 779. K-th Symbol in Grammar
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int KthGrammar(int n, int k)
    {
        k--;
        int res = 0;
        while (k > 0)
        {
            k &= k - 1;
            res ^= 1;
        }
        return res;
    }

    /// <summary>
    /// 784. Letter Case Permutation
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static List<string> LetterCasePermutation(string s)
    {
        var ans = new List<StringBuilder> { new StringBuilder() };
        foreach (char c in s)
        {
            int n = ans.Count;
            if (char.IsLetter(c))
            {
                for (int i = 0; i < n; ++i)
                {
                    ans.Add(new StringBuilder(ans[i].ToString()));
                    ans[i].Append(char.ToLower(c));
                    ans[n + i].Append(char.ToUpper(c));
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    ans[i].Append(c);
                }
            }
        }

        return ans.Select(sb => sb.ToString()).ToList();
    }

    /// <summary>
    /// 793. Preimage Size of Factorial Zeroes Function
    /// </summary>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int PreimageSizeFzf(int k)
    {
        return (int)(Nx(k + 1) - Nx(k));

        long Nx(int n)
        {
            long left = 0, right = 5L * n;
            while (left <= right)
            {
                long mid = (left + right) / 2;
                if (Zeta(mid) < n)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return right + 1;
        }

        long Zeta(long x)
        {
            long res = 0;
            while (x != 0)
            {
                res += x / 5;
                x /= 5;
            }

            return res;
        }
    }

    /// <summary>
    /// 796. Rotate String
    /// </summary>
    /// <param name="strA"></param>
    /// <param name="strB"></param>
    /// <returns></returns>
    public static bool RotateString(string strA, string strB) => strA.Length == strB.Length && (strA + strA).Contains(strB);
}
