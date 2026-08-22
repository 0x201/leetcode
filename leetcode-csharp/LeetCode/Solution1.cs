// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 202. Happy Number
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsHappy(int n)
    {
        int slow = n, fast = n;
        while (slow != 1)
        {
            slow = DigitSquareSum(slow);
            fast = DigitSquareSum(DigitSquareSum(fast));
            if (slow != 1 && slow == fast)
            {
                return false;
            }
        }

        return true;

        int DigitSquareSum(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                int tmp = num % 10;
                sum += tmp * tmp;
                num /= 10;
            }

            return sum;
        }
    }

    /// <summary>
    /// 204. Count Primes
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int CountPrimes(int n)
    {
        if (n < 3)
        {
            return 0;
        }

        bool[] f = new bool[n];
        int count = n / 2;
        for (int i = 3; i * i < n; i += 2)
        {
            if (f[i])
            {
                continue;
            }

            for (int j = i * i; j < n; j += 2 * i)
            {
                if (f[j])
                {
                    continue;
                }

                --count;
                f[j] = true;
            }
        }

        return count;
    }

    /// <summary>
    /// 205. Isomorphic Strings
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool IsIsomorphic(string s, string t)
    {
        int[] m1 = new int[256];
        int[] m2 = new int[256];
        int n = s.Length;
        for (int i = 0; i < 256; i++)
        {
            m1[i] = m2[i] = -1;
        }

        for (int i = 0; i < n; i++)
        {
            if (m1[s[i]] != m2[t[i]])
            {
                return false;
            }

            m1[s[i]] = m2[t[i]] = i;
        }

        return true;
    }

    /// <summary>
    /// 206. Reverse Linked List
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static ListNode ReverseList(ListNode head)
    {
        // Iteratively Time: O(n) Space O(1)
        ListNode prev = null;
        ListNode curr = head;
        while (curr is not null)
        {
            ListNode next = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = next;
        }

        return prev;

        // Recursively Time: O(n) Space O(n)
        //if (head is null || head.next is null)
        //{
        //    return head;
        //}
        //ListNode newHead = ReverseList(head.next);
        //head.next.next = head;
        //head.next = null;
        //return newHead;
    }

    /// <summary>
    /// 212. Word Search II
    /// </summary>
    /// <param name="board"></param>
    /// <param name="words"></param>
    /// <returns></returns>
    public static IList<string> FindWords(char[][] board, string[] words)
    {
        IList<string> res = new List<string>();
        TrieNode root = BuildTrie(words);
        int m = board.Length, n = board[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Dfs(board, i, j, root, res);
            }
        }

        return res;

        TrieNode BuildTrie(string[] wordData)
        {
            var node = new TrieNode();
            foreach (string item in wordData)
            {
                TrieNode p = node;
                foreach (char ch in item)
                {
                    if (p.Get(ch) == null)
                    {
                        p.Links[ch - 'a'] = new TrieNode();
                    }

                    p = p.Get(ch);
                }

                p.Word = item;
            }

            return node;
        }

        void Dfs(char[][] dataBoard, int i, int j, TrieNode p, IList<string> list)
        {
            char cell = dataBoard[i][j];
            int rowNumber = dataBoard.Length;
            int columnNumber = dataBoard[0].Length;
            if (cell == '#' || p.Get(cell) == null)
            {
                return;
            }

            p = p.Get(cell);
            if (p.Word != null)
            {
                list.Add(p.Word);
                p.Word = null;
            }

            dataBoard[i][j] = '#';
            if (i > 0)
            {
                Dfs(dataBoard, i - 1, j, p, list);
            }

            if (j > 0)
            {
                Dfs(dataBoard, i, j - 1, p, list);
            }

            if (i < rowNumber - 1)
            {
                Dfs(dataBoard, i + 1, j, p, list);
            }

            if (j < columnNumber - 1)
            {
                Dfs(dataBoard, i, j + 1, p, list);
            }

            dataBoard[i][j] = cell;
        }
    }

    /// <summary>
    /// 213. House Robber II
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int RobIi(int[] nums)
    {
        int n = nums.Length;
        if (n < 2)
        {
            return n == 1 ? nums[0] : 0;
        }

        return Math.Max(Robber(nums, 0, n - 2), Robber(nums, 1, n - 1));

        int Robber(int[] data, int l, int r)
        {
            int pre = 0, cur = 0;
            for (int i = l; i <= r; i++)
            {
                int temp = Math.Max(pre + data[i], cur);
                pre = cur;
                cur = temp;
            }

            return cur;
        }
    }

    /// <summary>
    /// 217. Contains Duplicate
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static bool ContainsDuplicate(int[] nums)
    {
        ISet<int> set = new HashSet<int>();
        return nums.Any(item => !set.Add(item));
    }

    /// <summary>
    /// 231. Power of Two
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsPowerOfTwo(int n) => n > 0 && (n & (n - 1)) == 0;

    /// <summary>
    /// 234.Palindrome Linked List
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static bool IsPalindrome(ListNode head)
    {
        if (head == null)
        {
            return true;
        }

        ListNode firstHalfEnd = EndOfFirstHalf(head);
        ListNode secondHalfStart = ReverseListHelper(firstHalfEnd.Next);
        ListNode p1 = head;
        ListNode p2 = secondHalfStart;
        while (p2 != null)
        {
            if (p1.Val != p2.Val)
            {
                return false;
            }

            p1 = p1.Next;
            p2 = p2.Next;
        }

        firstHalfEnd.Next = ReverseListHelper(secondHalfStart);
        return true;

        ListNode ReverseListHelper(ListNode node)
        {
            ListNode prev = null;
            ListNode curr = node;
            while (curr != null)
            {
                ListNode tmp = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = tmp;
            }

            return prev;
        }

        ListNode EndOfFirstHalf(ListNode node)
        {
            ListNode fast = node;
            ListNode slow = node;
            while (fast.Next?.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            return slow;
        }
    }

    /// <summary>
    /// 242. Valid Anagram
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        int[] tables = new int[26];
        foreach (char c in s)
        {
            tables[c - 'a']++;
        }

        foreach (char c in t)
        {
            tables[c - 'a']--;
        }

        return tables.All(e => e == 0);
    }

    /// <summary>
    /// 258. Add Digits
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static int AddDigits(int num)
    {
        return (num - 1) % 9 + 1;
    }

    /// <summary>
    /// 260. Single Number III
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int[] SingleNumberV3(int[] nums)
    {
        int xorSum = nums.Aggregate(0, (current, num) => current ^ num);
        int lsb = (xorSum == int.MinValue ? xorSum : xorSum & (-xorSum));
        int type1 = 0, type2 = 0;
        foreach (int num in nums)
        {
            if ((num & lsb) != 0)
            {
                type1 ^= num;
            }
            else
            {
                type2 ^= num;
            }
        }

        return [type1, type2];
    }

    /// <summary>
    /// 268. Missing Number
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int MissingNumber(int[] nums)
    {
        int len = nums.Length;
        int sum = len * (len + 1) / 2;
        int actual = nums.Sum();
        return sum - actual;
    }

    /// <summary>
    /// 283. Move Zeroes
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static void MoveZeroes(int[] nums)
    {
        //int j = 0, len = nums.Length;
        //for (int i = 0; i < len; i++)
        //    if (nums[i] != 0)
        //        nums[j++] = nums[i];
        //for (; j < len; j++)
        //    nums[j] = 0;

        int len = nums.Length, left = 0, right = 0;
        while (right < len)
        {
            if (nums[right] != 0)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
            }

            right++;
        }
    }

    /// <summary>
    /// 287. Find the Duplicate Number
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int FindDuplicate(int[] nums)
    {
        int slow = 0, fast = 0;
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        slow = 0;
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }

    /// <summary>
    /// 331. Verify Preorder Serialization of a Binary Tree
    /// </summary>
    /// <param name="preorder"></param>
    /// <returns></returns>
    public static bool IsValidSerialization(string preorder)
    {
        int n = preorder.Length, i = 0, slots = 1;
        while (i < n)
        {
            if (slots == 0)
            {
                return false;
            }

            if (preorder[i] == ',')
            {
                i++;
            }
            else if (preorder[i] == '#')
            {
                slots--;
                i++;
            }
            else
            {
                while (i < n && preorder[i] != ',')
                {
                    i++;
                }

                slots++;
            }
        }

        return slots == 0;
    }

    /// <summary>
    /// 337. House Robber III
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static int RobIii(TreeNode root)
    {
        int[] res = SubRob(root);
        return Math.Max(res[0], res[1]);

        int[] SubRob(TreeNode node)
        {
            if (node == null)
            {
                return new int[2];
            }

            int[] left = SubRob(node.Left);
            int[] right = SubRob(node.Right);
            int[] ret = new int[2];
            ret[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
            ret[1] = node.Val + left[0] + right[0];
            return ret;
        }
    }

    /// <summary>
    /// 342. Power of Four
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static bool IsPowerOfFour(int num) => num > 0 && (num & (num - 1)) == 0 && (num - 1) % 3 == 0;

    /// <summary>
    /// 344. Reverse String
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static void ReverseString(char[] s)
    {
        int len = s.Length;
        for (int left = 0, right = len - 1; left < right; ++left, --right)
        {
            Util.Swap(s, left, right);
        }
    }

    /// <summary>
    /// 357. Count Numbers with Unique Digits
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int CountNumbersWithUniqueDigits(int n)
    {
        switch (n)
        {
            case 0:
                return 1;
            case 1:
                return 10;
        }

        int res = 10, cur = 9;
        for (int i = 0; i < n - 1; i++)
        {
            cur *= 9 - i;
            res += cur;
        }

        return res;
    }

    /// <summary>
    /// 371. Sum of Two Integers
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int GetSum(int a, int b)
    {
        while (b != 0)
        {
            int carry = (a & b) << 1;
            a ^= b;
            b = carry;
        }

        return a;
    }

    /// <summary>
    /// 374. Guess Number Higher or Lower
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int GuessNumber(int n)
    {
        int left = 1, right = n;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int res = Guess(mid);
            switch (res)
            {
                case 0:
                    return mid;
                case < 0:
                    right = mid - 1;
                    break;
                default:
                    left = mid + 1;
                    break;
            }
        }

        return -1;

        int Guess(int num)
        {
            var random = new Random();
            int target = random.Next(1, int.MaxValue);
            if (num > target)
            {
                return 1;
            }
            else if (num < target)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    /// <summary>
    /// 383. Ransom Note
    /// </summary>
    /// <param name="ransomNote"></param>
    /// <param name="magazine"></param>
    /// <returns></returns>
    public static bool CanConstruct(string ransomNote, string magazine)
    {
        if (ransomNote.Length > magazine.Length)
        {
            return false;
        }
        int[] counter = new int[26];
        foreach (char ch in magazine)
        {
            counter[ch - 'a']++;
        }
        foreach (char ch in ransomNote)
        {
            counter[ch - 'a']--;
            if (counter[ch - 'a'] < 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 386. Lexicographical Numbers
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IList<int> LexicalOrder(int n)
    {
        IList<int> list = new List<int>(n);
        int num = 1;
        for (int i = 0; i < n; i++)
        {
            list.Add(num);
            if (num * 10 <= n)
            {
                num *= 10;
            }
            else
            {
                while (num % 10 == 9 || num + 1 > n)
                {
                    num /= 10;
                }

                num++;
            }
        }

        return list;
    }

    /// <summary>
    /// 393. UTF-8 Validation
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool ValidUtf8(int[] data)
    {
        const int mask1 = 1 << 7;
        const int mask2 = (1 << 7) + (1 << 6);
        int m = data.Length;
        int index = 0;
        while (index < m)
        {
            int num = data[index];
            int n = GetBytes(num);
            if (n < 0 || index + n > m)
            {
                return false;
            }

            for (int i = 1; i < n; i++)
            {
                if (!IsValidHelper((data[index + i])))
                {
                    return false;
                }
            }

            index += n;
        }

        return true;

        int GetBytes(int num)
        {
            if ((num & mask1) == 0)
            {
                return 1;
            }

            int n = 0;
            int mask = mask1;
            while ((num & mask) != 0)
            {
                n++;
                if (n > 4)
                {
                    return -1;
                }

                mask >>= 1;
            }

            return n >= 2 ? n : -1;
        }

        bool IsValidHelper(int num) => (num & mask2) == mask1;
    }

    /// <summary>
    /// 396. Rotate Function
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int MaxRotateFunction(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1)
        {
            return 0;
        }

        int f = 0, numSum = nums.Sum();
        for (int i = 0; i < n; i++)
        {
            f += i * nums[i];
        }

        int ans = f;
        for (int i = n - 1; i > 0; i--)
        {
            f += numSum - n * nums[i];
            ans = Math.Max(ans, f);
        }

        return ans;
    }
}
