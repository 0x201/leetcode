// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

/// <summary>
/// LeetCode Solution Class
/// </summary>
public partial class Solution
{
    /// <summary>
    /// 1. Two Sum
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int[] TwoSum(int[] nums, int target)
    {
        var dic = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (dic.TryGetValue(target - nums[i], out int value))
            {
                return [value, i];
            }
            _ = dic.TryAdd(nums[i], i);
        }

        return [];
    }

    /// <summary>
    /// 2. Add Two Numbers
    /// </summary>
    /// <param name="l1"></param>
    /// <param name="l2"></param>
    /// <returns></returns>
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {

        var dummyHead = new ListNode(0);
        if (l1 == null && l2 == null)
        {
            return dummyHead;
        }

        int carry = 0;
        ListNode curr = dummyHead;
        while (l1 != null || l2 != null)
        {
            int sum = carry;
            int num1 = l1?.Val ?? 0;
            l1 = l1?.Next;
            int num2 = l2?.Val ?? 0;
            l2 = l2?.Next;
            sum += (num1 + num2);
            curr.Next = new ListNode(sum % 10);
            curr = curr.Next;
            carry = sum / 10;
        }

        return dummyHead.Next;
    }

    /// <summary>
    /// 3. Longest Substring Without Repeating Characters
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int LengthOfLongestSubstring(string s)
    {
        // 96 ms int[]
        // int n = s.Length, ans = 0;
        // int[] index = new int[128];
        // for (int j = 0, i = 0; j < n; j++)
        // {
        //     i = Math.Max(index[s[j]], i);
        //     ans = Math.Max(ans, j - i + 1);
        //     index[s[j]] = j + 1;
        // }
        // return ans;

        // 100 ms HashSet<char>
        // int len = s.Length;
        // HashSet<char> set = new HashSet<char>();
        // int ans = 0, i = 0, j = 0;
        // while (i < len && j < len)
        // {
        //     if (!set.Contains(s[j]))
        //     {
        //         set.Add(s[j++]);
        //         ans = Math.Max(ans, j - i);
        //     }
        //     else set.Remove(s[i++]);
        // }
        // return ans;

        // 100ms Dictionary<char, int>
        int n = s.Length, ans = 0;
        var dic = new Dictionary<char, int>();
        for (int j = 0, i = 0; j < n; j++)
        {
            if (dic.TryGetValue(s[j], out int value))
            {
                i = Math.Max(value, i);
                dic[s[j]] = j + 1;
            }
            else
            {
                dic.Add(s[j], j + 1);
            }

            ans = Math.Max(ans, j - i + 1);
        }

        return ans;
    }

    /// <summary>
    /// 4. Median of Two Sorted Arrays
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        if (m > n)
        {
            (nums1, nums2) = (nums2, nums1);
            (m, n) = (n, m);
        }

        // use binary search
        int min = 0, max = m, halfLen = (m + n + 1) / 2;
        while (min <= max)
        {
            int i = min + (max - min) / 2;
            int j = halfLen - i;
            if (i < max && nums2[j - 1] > nums1[i])
            {
                min++;
            }
            else if (i > min && nums1[i - 1] > nums2[j])
            {
                max--;
            }
            else
            {
                int maxLeft;
                if (i == 0)
                {
                    maxLeft = nums2[j - 1];
                }
                else if (j == 0)
                {
                    maxLeft = nums1[i - 1];
                }
                else
                {
                    maxLeft = Math.Max(nums1[i - 1], nums2[j - 1]);
                }

                if ((m + n) % 2 == 1)
                {
                    return maxLeft;
                }

                int minRight;
                if (i == m)
                {
                    minRight = nums2[j];
                }
                else if (j == n)
                {
                    minRight = nums1[i];
                }
                else
                {
                    minRight = Math.Min(nums2[j], nums1[i]);
                }

                return (maxLeft + minRight) / 2.0;
            }
        }

        return 0.0;
    }

    /// <summary>
    /// 5. Longest Palindromic Substring
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string LongestPalindrome(string s)
    {
        string T = PreProcess(s);
        int n = T.Length;
        int[] p = new int[n];
        int c = 0, r = 0;
        for (int i = 1; i < n - 1; i++)
        {
            int mirror = 2 * c - i;
            p[i] = (r > 1) ? Math.Min(r - i, p[mirror]) : 0;
            while (T[i + 1 + p[i]] == T[i - 1 - p[i]])
            {
                p[i]++;
            }

            if (i + p[i] <= r)
            {
                continue;
            }

            c = i;
            r = i + p[i];
        }

        // Find the maximum element in P
        int maxLen = 0;
        int centerIndex = 0;
        for (int i = 1; i < n - 1; i++)
        {
            if (p[i] <= maxLen)
            {
                continue;
            }

            maxLen = p[i];
            centerIndex = i;
        }

        return s.Substring((centerIndex - 1 - maxLen) / 2, maxLen);

        string PreProcess(string input)
        {
            int len = input.Length;
            if (len == 0)
            {
                return "^$";
            }

            string ret = "^";
            for (int i = 0; i < len; i++)
            {
                ret += string.Concat("#", input.AsSpan(i, 1));
            }

            ret += "#$";
            return ret;
        }
    }

    /// <summary>
    /// 6. ZigZag Conversion
    /// </summary>
    /// <param name="s"></param>
    /// <param name="numRows"></param>
    /// <returns></returns>
    public static string ZipZagConvert(string s, int numRows)
    {
        if (numRows <= 1)
        {
            return s;
        }

        var res = new StringBuilder();
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < s.Length; j += 2 * numRows - 2)
            {
                int index = i + j;
                if (index < s.Length)
                {
                    res.Append(s[index]);
                }

                if (i == 0 || i == numRows - 1)
                {
                    continue;
                }

                index = j + 2 * numRows - 2 - i;
                if (index < s.Length)
                {
                    res.Append(s[index]);
                }
            }
        }

        return res.ToString();
    }

    /// <summary>
    /// 7. Reverse Integer
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int ReverseInteger(int x)
    {
        int rev = 0;
        while (x != 0)
        {
            int pop = x % 10;
            x /= 10;
            switch (rev)
            {
                case > int.MaxValue / 10:
                case int.MaxValue / 10 when pop > 7:
                case < int.MinValue / 10:
                case int.MinValue / 10 when pop < -8:
                    return 0;
                default:
                    rev = rev * 10 + pop;
                    break;
            }
        }

        return rev;
    }

    /// <summary>
    /// 8. String to Integer(atoi)
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int Atoi(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }

        int sign = 1;
        int bas = 0;
        int i = 0;
        while (str[i] == ' ')
        {
            i++;
        }

        if (str[i] == '-' || str[i] == '+')
        {
            sign = str[i++] == '-' ? -1 : 1;
        }

        while (i < str.Length && str[i] >= '0' && str[i] <= '9')
        {
            if (bas > int.MaxValue / 10 || (bas == int.MaxValue / 10 && str[i] - '0' > 7))
            {
                return (sign == 1) ? int.MaxValue : int.MinValue;
            }

            bas = 10 * bas + (str[i++] - '0');
        }

        return bas * sign;
    }

    /// <summary>
    /// 9. Palindrome Number
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static bool IsPalindrome(int x)
    {
        if (x < 0 || (x != 0 && x % 10 == 0))
        {
            return false;
        }

        int res = 0;
        while (res < x)
        {
            res = res * 10 + x % 10;
            x /= 10;
        }

        return (x == res || x == res / 10);
        // if (x < 10) return true;
        // int n = 0, temp = x;
        // while (temp / 10 != 0)
        // {
        //     n += temp % 10;
        //     n *= 10;
        //     temp /= 10;
        // }
        // n += temp % 10;
        // return (n == x);
    }

    /// <summary>
    /// 10. Regular Expression Matching
    /// </summary>
    /// <param name="text">string input</param>
    /// <param name="pattern">match pattern</param>
    /// <returns></returns>
    public static bool IsMatch(string text, string pattern)
    {
        bool[,] dp = new bool[text.Length + 1, pattern.Length + 1];
        dp[text.Length, pattern.Length] = true;
        for (int i = text.Length; i >= 0; i--)
        {
            for (int j = pattern.Length - 1; j >= 0; j--)
            {
                bool firstMatch = i < text.Length && (pattern[j] == text[i] || pattern[j] == '.');
                if (j + 1 < pattern.Length && pattern[j + 1] == '*')
                {
                    dp[i, j] = dp[i, j + 2] || firstMatch && dp[i + 1, j];
                }
                else
                {
                    dp[i, j] = firstMatch && dp[i + 1, j + 1];
                }
            }
        }

        return dp[0, 0];
    }

    /// <summary>
    /// 11. Container With Most Water
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public static int MaxArea(int[] height)
    {
        int maxArea = 0;
        int left = 0, right = height.Length - 1;
        while (left < right)
        {
            maxArea = Math.Max(maxArea, Math.Min(height[left], height[right]) * (right - left));
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }

    /// <summary>
    /// 12. Integer to Roman
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string IntToRoman(int num)
    {
        string[] m = ["", "M", "MM", "MMM"];
        string[] c = ["", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"];
        string[] x = ["", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"];
        string[] I = ["", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"];
        return m[num / 1000] + c[(num % 1000) / 100] + x[(num % 100) / 10] + I[num % 10];
    }

    /// <summary>
    /// 13. Roman to Integer
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int RomanToInt(string s)
    {
        var dic = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        int value = 0;
        char prev = s[0];
        foreach (char curr in s)
        {
            value += dic[curr];
            if (dic[prev] < dic[curr])
            {
                value -= dic[prev] * 2;
            }

            prev = curr;
        }

        return value;
    }

    /// <summary>
    /// 14. Longest Common Prefix
    /// </summary>
    /// <param name="strings"></param>
    /// <returns></returns>
    public static string LongestCommonPrefix(string[] strings)
    {
        if (strings.Length == 0)
        {
            return "";
        }

        string pre = strings[0];
        for (int i = 1; i < strings.Length; i++)
        {
            while (strings[i].IndexOf(pre, StringComparison.Ordinal) != 0)
            {
                pre = pre[..^1];
            }
        }

        return pre;
    }

    /// <summary>
    /// 15. Three Sum
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var res = new List<IList<int>>();
        //for (int i = 0; i < nums.Length - 2; i++)
        //{
        //    if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
        //    {
        //        int lo = i + 1, hi = nums.Length - 1, sum = 0 - nums[i];
        //        // two sum
        //        while (lo < hi)
        //        {
        //            if (nums[lo] + nums[hi] == sum)
        //            {
        //                res.Add(
        //                    new List<int>
        //                    {
        //                        nums[i],
        //                        nums[lo],
        //                        nums[hi]
        //                    });

        //                while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
        //                while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
        //                lo++;
        //                hi--;
        //            }
        //            else if (nums[lo] + nums[hi] < sum)
        //            {
        //                while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
        //                lo++;
        //            }
        //            else
        //            {
        //                while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
        //                hi--;
        //            }
        //        }
        //    }
        //}

        int len = nums.Length;
        for (int i = 0; i < len; i++)
        {
            int target = -nums[i];
            int left = i + 1;
            int right = len - 1;
            if (target < 0)
            {
                break;
            }

            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum < target)
                {
                    left++;
                }
                else if (sum > target)
                {
                    right--;
                }
                else
                {
                    var tmp = new List<int> { nums[i], nums[left], nums[right] };
                    res.Add(tmp);
                    while (left < right && nums[left] < tmp[1])
                    {
                        left++;
                    }

                    while (left < right && nums[right] == tmp[2])
                    {
                        right--;
                    }
                }
            }

            while (i + 1 < len && nums[i + 1] == nums[i])
            {
                i++;
            }
        }

        return res;
    }

    /// <summary>
    /// 16. Three Sum Closest
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int ThreeSumClosest(int[] nums, int target)
    {
        if (nums.Length < 3)
        {
            return 0;
        }

        int closest = nums[0] + nums[1] + nums[2];
        int len = nums.Length;
        Array.Sort(nums);
        for (int first = 0; first < len - 2; first++)
        {
            if (first > 0 && nums[first] == nums[first - 1])
            {
                continue;
            }

            int second = first + 1;
            int third = len - 1;
            while (second < third)
            {
                int currentSum = nums[first] + nums[second] + nums[third];
                if (currentSum == target)
                {
                    return currentSum;
                }

                if (Math.Abs(target - currentSum) < Math.Abs(target - closest))
                {
                    closest = currentSum;
                }

                if (currentSum > target)
                {
                    third--;
                }
                else
                {
                    second++;
                }
            }
        }

        return closest;
    }

    /// <summary>
    /// 17. Letter Combinations of a Phone Number
    /// </summary>
    /// <param name="digits">input digits</param>
    /// <returns></returns>
    public static IList<string> LetterCombinations(string digits)
    {
        string[] map = ["0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"];
        if (string.IsNullOrEmpty(digits))
        {
            return new List<string>();
        }

        var ans = new Queue<string>();
        ans.Enqueue("");
        for (int i = 0; i < digits.Length; i++)
        {
            int x = digits[i] - '0';
            while (ans.Peek().Length == i)
            {
                string t = ans.Dequeue();
                foreach (char c in map[x])
                {
                    ans.Enqueue(t + c);
                }
            }
        }

        return ans.ToList();
    }

    /// <summary>
    /// 18. 4Sum
    /// </summary>
    public static IList<IList<int>> FourSum(int[] nums, int target)
    {
        IList<IList<int>> res = new List<IList<int>>();
        int n = nums.Length;
        if (n < 4)
        {
            return res;
        }

        Array.Sort(nums);
        for (int i = 0; i < n - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target)
            {
                break;
            }

            if (nums[i] + nums[n - 3] + nums[n - 2] + nums[n - 1] < target)
            {
                continue;
            }

            for (int j = i + 1; j < n - 2; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1])
                {
                    continue;
                }

                if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target)
                {
                    break;
                }

                if (nums[i] + nums[j] + nums[n - 2] + nums[n - 1] < target)
                {
                    continue;
                }

                int left = j + 1, right = n - 1;
                while (left < right)
                {
                    int sum = nums[left] + nums[right] + nums[i] + nums[j];
                    if (sum < target)
                    {
                        left++;
                    }
                    else if (sum > target)
                    {
                        right--;
                    }
                    else
                    {
                        res.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                        do
                        {
                            left++;
                        } while (nums[left] == nums[left - 1] && left < right);

                        do
                        {
                            right--;
                        } while (nums[right] == nums[right + 1] && left < right);
                    }
                }
            }
        }

        return res;
    }

    /// <summary>
    /// 19. Remove Nth Node From End of List
    /// </summary>
    /// <param name="head"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var dummy = new ListNode(0, head);
        ListNode first = dummy;
        ListNode second = dummy;
        for (int i = 0; i <= n; i++)
        {
            first = first.Next;
        }

        while (first is not null)
        {
            first = first.Next;
            second = second.Next;
        }

        second.Next = second.Next.Next;
        return dummy.Next;
    }

    /// <summary>
    /// 20. Valid Parentheses
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsValid(string s)
    {
        var stack = new Stack<char>();
        foreach (char item in s)
        {
            switch (item)
            {
                case '(':
                    stack.Push(')');
                    break;
                case '{':
                    stack.Push('}');
                    break;
                case '[':
                    stack.Push(']');
                    break;
                default:
                    {
                        if (stack.Count == 0 || stack.Pop() != item)
                        {
                            return false;
                        }

                        break;
                    }
            }
        }

        return stack.Count == 0;
    }

    /// <summary>
    /// 21. Merge Two Sorted Lists
    /// </summary>
    /// <param name="l1">first list</param>
    /// <param name="l2">second list</param>
    /// <returns>merged list</returns>
    public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        var dummyHead = new ListNode(0);
        ListNode head = dummyHead;
        while (l1 != null && l2 != null)
        {
            if (l1.Val <= l2.Val)
            {
                head.Next = l1;
                l1 = l1.Next;
            }
            else
            {
                head.Next = l2;
                l2 = l2.Next;
            }

            head = head.Next;
        }

        head.Next = l1 ?? l2;
        return dummyHead.Next;

        //if (l1 == null) { return l2; }
        //if (l2 == null) { return l1; }
        //ListNode ans = null;
        //if (l1.val < l2.val)
        //{
        //    ans = l1;
        //    ans.next = MergeTwoLists(l1.next, l2);
        //}
        //else
        //{
        //    ans = l2;
        //    ans.next = MergeTwoLists(l1, l2.next);
        //}
        //return ans;
    }

    /// <summary>
    /// 22. Generate Parentheses
    /// </summary>
    public static IList<string> GenerateParenthesis(int n)
    {
        IList<string> ans = new List<string>();
        // if (n == 0)
        //     ans.Add("");
        // else
        // {
        //     for (int c = 0; c < n; c++)
        //         foreach (string left in GenerateParenthesis(c))
        //             foreach (string right in GenerateParenthesis(n - 1 - c))
        //                 ans.Add("(" + left + ")" + right);
        // }
        // return ans;
        Backtrack(ans, "", 0, 0, n);
        return ans;

        void Backtrack(IList<string> list, string str, int open, int close, int number)
        {
            if (str.Length == number * 2)
            {
                list.Add(str);
                return;
            }

            if (open < number)
            {
                Backtrack(list, str + "(", open + 1, close, number);
            }

            if (close < open)
            {
                Backtrack(list, str + ")", open, close + 1, number);
            }
        }
    }

    /// <summary>
    /// 23. Merge K Sorted Lists
    /// </summary>
    /// <param name="lists">the array of lists</param>
    /// <returns>merged list</returns>
    public static ListNode MergeKLists(ListNode[] lists)
    {
        int len = lists.Length;
        int interval = 1;
        while (interval < len)
        {
            for (int i = 0; i < len - interval; i += interval * 2)
            {
                lists[i] = MergeTwoLists(lists[i], lists[i + interval]);
            }

            interval *= 2;
        }

        return len > 0 ? lists[0] : null;
    }

    /// <summary>
    /// 24. Swap Node in Pairs
    /// </summary>
    public static ListNode SwapPairs(ListNode head)
    {
        var dummy = new ListNode(0)
        {
            Next = head
        };
        ListNode curr = dummy;
        while (curr.Next?.Next != null)
        {
            ListNode a = curr.Next;
            ListNode b = curr.Next.Next;
            a.Next = b.Next;
            curr.Next = b;
            curr.Next.Next = a;
            curr = curr.Next.Next;
        }

        return dummy.Next;
    }

    /// <summary>
    /// 25. Reverse Nodes in k-Group
    /// </summary>
    public static ListNode ReverseKGroup(ListNode head, int k)
    {
        // Non-recursive
        int n = 0;
        for (ListNode i = head; i != null;)
        {
            n++;
            i = i.Next;
        }

        var dummy = new ListNode(0)
        {
            Next = head
        };
        for (ListNode prev = dummy, tail = head; n >= k; n -= k)
        {
            for (int i = 1; i < k; i++)
            {
                ListNode next = tail.Next.Next;
                tail.Next.Next = prev.Next;
                prev.Next = tail.Next;
                tail.Next = next;
            }

            prev = tail;
            tail = tail.Next;
        }

        return dummy.Next;

        // Recursive
        // ListNode curr = head;
        // int count = 0;
        // while(curr!=null && count != k)
        // {
        //     curr = curr.next;
        //     count++;
        // }
        // if(count == k)
        // {
        //     curr = ReverseKGroup(curr, k);
        //     while(count-- > 0)
        //     {
        //         ListNode tmp = head.next;
        //         head.next = curr;
        //         curr = head;
        //         head = tmp;
        //     }
        //     head = curr;
        // }
        // return head;
    }

    /// <summary>
    /// 26. Remove Duplicates from Sorted Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int RemoveDuplicates(int[] nums)
    {
        int i = nums.Length > 0 ? 1 : 0;
        foreach (int n in nums)
        {
            if (n > nums[i - 1])
            {
                nums[i++] = n;
            }
        }

        return i;
    }

    /// <summary>
    /// 27. Remove Element
    /// </summary>
    public static int RemoveElement(int[] nums, int val)
    {
        int len = nums.Length;
        int found = 0;
        for (int i = 0; i < len; i++)
        {
            if (found > 0)
            {
                nums[i - found] = nums[i];
            }

            if (nums[i] == val)
            {
                found++;
            }
        }

        return len - found;
    }

    /// <summary>
    /// 28. Implement strStr()
    /// </summary>
    /// <param name="haystack"></param>
    /// <param name="needle"></param>
    /// <returns></returns>
    public static int StrStr(string haystack, string needle)
    {
        List<int> KmpProcess(string s)
        {
            int n = needle.Length;
            var lps = new List<int>();
            for (int i = 0; i < n; i++)
            {
                lps.Add(0);
            }

            for (int i = 1, len = 0; i < n;)
            {
                if (s[i] == s[len])
                {
                    lps[i] = ++len;
                    i++;
                }
                else if (len > 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i++] = 0;
                }
            }

            return lps;
        }

        int m = haystack.Length, n = needle.Length;
        if (n < 1)
        {
            return 0;
        }

        List<int> lps = KmpProcess(needle);
        for (int i = 0, j = 0; i < m;)
        {
            if (haystack[i] == needle[j])
            {
                i++;
                j++;
            }

            if (j == n)
            {
                return i - j;
            }

            if (i >= m || haystack[i] == needle[j])
            {
                continue;
            }

            if (j > 0)
            {
                j = lps[j - 1];
            }
            else
            {
                i++;
            }
        }

        return -1;
    }

    /// <summary>
    /// 29. Divide Two Integers
    /// </summary>
    /// <param name="dividend"></param>
    /// <param name="divisor"></param>
    /// <returns></returns>
    public static int Divide(int dividend, int divisor)
    {
        if (divisor == 0 || (dividend == int.MinValue && divisor == -1))
        {
            return int.MaxValue;
        }

        int sign = dividend < 0 ^ divisor < 0 ? -1 : 1;
        long dvd = Math.Abs((long)dividend);
        long dvs = Math.Abs((long)divisor);
        int res = 0;
        while (dvd >= dvs)
        {
            long tmp = dvs;
            int multiple = 1;
            while (dvd >= (tmp << 1))
            {
                tmp <<= 1;
                multiple <<= 1;
            }

            dvd -= tmp;
            res += multiple;
        }

        return sign * res;
    }

    /// <summary>
    /// 30. Substring with Concatenation of All Words
    /// </summary>
    public static IList<int> FindSubstring(string s, string[] words)
    {
        IList<int> ret = new List<int>();
        if (s.Length == 0 || words.Length == 0)
        {
            return ret;
        }

        int n = s.Length, size = words.Length, len = words[0].Length;
        var map = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (map.TryGetValue(word, out int value))
            {
                map[word] = ++value;
            }
            else
            {
                map.Add(word, 1);
            }
        }

        for (int i = 0; i < len; i++)
        {
            int left = i, count = 0;
            var window = new Dictionary<string, int>();
            for (int j = i; j + len - 1 < n; j += len)
            {
                string tmp = s.Substring(j, len);
                if (!map.TryGetValue(tmp, out int value))
                {
                    window.Clear();
                    count = 0;
                    left = j + len;
                }
                else
                {
                    if (window.TryGetValue(tmp, out int windowValue))
                    {
                        window[tmp] = ++windowValue;
                    }
                    else
                    {
                        window.Add(tmp, 1);
                    }

                    count++;
                    while (left + len - 1 < n && window[tmp] > value)
                    {
                        window[s.Substring(left, len)]--;
                        count--;
                        left += len;
                    }

                    if (count != size)
                    {
                        continue;
                    }

                    ret.Add(left);
                    window[s.Substring(left, len)]--;
                    count--;
                    left += len;
                }
            }
        }

        return ret;
    }

    /// <summary>
    /// 31. Next Permutation
    /// </summary>
    public static void NextPermutation(int[] nums)
    {
        int i = nums.Length - 2;
        while (i >= 0 && nums[i + 1] <= nums[i])
        {
            i--;
        }

        if (i >= 0)
        {
            int j = nums.Length - 1;
            while (j >= 0 && nums[j] <= nums[i])
            {
                j--;
            }

            Util.Swap(ref nums[i], ref nums[j]);
        }

        ReverseHelper(nums, i + 1);
        return;

        void ReverseHelper(int[] data, int start)
        {
            int startIndex = start, j = data.Length - 1;
            while (startIndex < j)
            {
                Util.Swap(ref data[startIndex], ref data[j]);
                startIndex++;
                j--;
            }
        }
    }

    /// <summary>
    /// 32. Longest Valid Parentheses
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int LongestValidParentheses(string s)
    {
        //int maxAns = 0;
        //int len = s.Length;
        //int[] dp = new int[len];
        //for (int i = 1; i < len; i++)
        //{
        //    if (s[i] == ')')
        //    {
        //        if (s[i - 1] == '(')
        //        {
        //            dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
        //        }
        //        else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
        //        {
        //            dp[i] = dp[i - 1] + ((i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
        //        }
        //        maxAns = Math.Max(maxAns, dp[i]);
        //    }
        //}
        //return maxAns;
        int len = s.Length;
        int left = 0, right = 0, maxLen = 0;
        for (int i = 0; i < len; i++)
        {
            if (s[i] == '(')
            {
                left++;
            }
            else
            {
                right++;
            }

            if (left == right)
            {
                maxLen = Math.Max(maxLen, 2 * right);
            }
            else if (right > left)
            {
                left = right = 0;
            }
        }

        left = right = 0;
        for (int i = len - 1; i >= 0; i--)
        {
            if (s[i] == '(')
            {
                left++;
            }
            else
            {
                right++;
            }

            if (left == right)
            {
                maxLen = Math.Max(maxLen, 2 * left);
            }
            else if (left > right)
            {
                left = right = 0;
            }
        }

        return maxLen;
    }

    /// <summary>
    /// 33. Search in Rotated Sorted Array
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int Search(int[] nums, int target)
    {
        int n = nums.Length;
        switch (n)
        {
            case 0:
                return -1;
            case 1:
                return nums[0] == target ? 0 : -1;
        }

        int l = 0, r = n - 1;
        while (l <= r)
        {
            int mid = (l + r) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[0] <= nums[mid])
            {
                if (nums[0] <= target && target < nums[mid])
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            else
            {
                if (nums[mid] < target && target <= nums[n - 1])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
        }

        return -1;
    }

    /// <summary>
    /// 34. Find First and Last Position of Element in Sorted Array
    /// </summary>
    public static int[] SearchRange(int[] nums, int target)
    {
        int[] missingResult = new[] { -1, -1 };
        //int[] res = new int[] { 0, 0 };
        //if (nums.Length < 1)
        //{
        //    return missingResult;
        //}
        //int lo = 0, hi = nums.Length - 1;
        //while (lo < hi)
        //{
        //    int mid = lo + (hi - lo) / 2;
        //    if (nums[mid] >= target)
        //    {
        //        hi = mid;
        //    }
        //    else
        //    {
        //        lo = mid + 1;
        //    }
        //}
        //int first = nums[lo] == target ? lo : -1;
        //if (first == -1)
        //{
        //    return missingResult;
        //}
        //lo = first;
        //hi = nums.Length - 1;
        //while (lo < hi)
        //{
        //    int mid = lo + (hi - lo + 1) / 2;
        //    if (nums[mid] <= target)
        //    {
        //        lo = mid;
        //    }
        //    else
        //    {
        //        hi = mid - 1;
        //    }
        //}
        //res[0] = first;
        //res[1] = lo;
        //return res;
        int leftIndex = BinarySearchHelper(nums, target, true);
        int rightIndex = BinarySearchHelper(nums, target, false) - 1;
        if (leftIndex <= rightIndex && rightIndex < nums.Length && nums[leftIndex] == nums[rightIndex])
        {
            return [leftIndex, rightIndex];
        }

        return missingResult;

        int BinarySearchHelper(int[] numbers, int targetNumber, bool lower)
        {
            int l = 0, r = numbers.Length - 1, ans = numbers.Length;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (numbers[mid] > targetNumber || (lower && numbers[mid] >= targetNumber))
                {
                    r = mid - 1;
                    ans = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return ans;
        }
    }

    /// <summary>
    /// 35. Search Insert Position
    /// </summary>
    public static int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return nums[left] < target ? left + 1 : left;
    }

    /// <summary>
    /// 36. Valid Sudoku
    /// </summary>
    public static bool IsValidSudoku(char[][] board)
    {
        // Dictionary<int, int>[] rows = new Dictionary<int, int>[9];
        // Dictionary<int, int>[] columns = new Dictionary<int, int>[9];
        // Dictionary<int, int>[] boxes = new Dictionary<int, int>[9];

        // for (int i = 0; i < 9; i++)
        // {
        //     rows[i] = new Dictionary<int, int>();
        //     columns[i] = new Dictionary<int, int>();
        //     boxes[i] = new Dictionary<int, int>();
        // }
        // for (int i = 0; i < 9; i++)
        // {
        //     for(int j = 0; j < 9; j++)
        //     {
        //         char num = board[i][j];
        //         if(num != '.')
        //         {
        //             int n = (int)num;
        //             int box_index = (i / 3) * 3 + j / 3;
        //             rows[i][n] = rows[i].GetValueOrDefault(n, 0) + 1;
        //             columns[j][n] = columns[j].GetValueOrDefault(n, 0) + 1;
        //             boxes[box_index][n] = boxes[box_index].GetValueOrDefault(n, 0) + 1;
        //             if (rows[i][n] > 1 || columns[j][n] > 1 || boxes[box_index][n] > 1)
        //                 return false;
        //         }
        //     }
        // }
        // return true;

        var seen = new HashSet<string>();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                char num = board[i][j];
                if (num == '.')
                {
                    continue;
                }

                if (!seen.Add(num + " in row " + i) ||
                    !seen.Add(num + " in column " + j) ||
                    !seen.Add(num + " in block " + i / 3 + "-" + j / 3))
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// 37. Sudoku Solver
    /// </summary>
    public static void SolveSudoku(char[][] board)
    {
        DoSolve(board, 0, 0);
        return;

        bool IsValidHelper(char[][] dataBoard, int row, int col, char num)
        {
            int blkRow = (row / 3) * 3, blkCol = (col / 3) * 3;
            for (int i = 0; i < 9; i++)
            {
                if (dataBoard[i][col] == num || dataBoard[row][i] == num ||
                    dataBoard[blkRow + i / 3][blkCol + i % 3] == num)
                {
                    return false;
                }
            }

            return true;
        }

        bool DoSolve(char[][] dataBoard, int row, int col)
        {
            for (int i = row; i < 9; i++, col = 0)
            {
                for (int j = col; j < 9; j++)
                {
                    if (dataBoard[i][j] != '.')
                    {
                        continue;
                    }

                    for (char num = '1'; num <= '9'; num++)
                    {
                        if (!IsValidHelper(dataBoard, i, j, num))
                        {
                            continue;
                        }

                        dataBoard[i][j] = num;
                        if (DoSolve(dataBoard, i, j + 1))
                        {
                            return true;
                        }

                        dataBoard[i][j] = '.';
                    }

                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// 38. Count and Say
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static string CountAndSay(int n)
    {
        if (n < 0)
        {
            return "-1";
        }

        string result = "1";
        for (int i = 1; i < n; ++i)
        {
            result = Build(result);
        }

        return result;

        string Build(string s)
        {
            var sb = new StringBuilder();
            int p = 0;
            while (p < s.Length)
            {
                char val = s[p];
                int count = 0;
                while (p < s.Length && s[p] == val)
                {
                    p++;
                    count++;
                }

                sb.Append(count);
                sb.Append(val);
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// 39. Combination Sum
    /// </summary>
    /// <param name="candidates"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> res = new List<IList<int>>();
        var combine = new List<int>();
        Dfs(candidates, target, res, combine, 0);
        return res;

        void Dfs(int[] data, int targetNumber, IList<IList<int>> result, List<int> combinations, int idx)
        {
            if (idx == data.Length)
            {
                return;
            }

            if (targetNumber == 0)
            {
                result.Add(new List<int>(combinations));
                return;
            }

            Dfs(data, targetNumber, result, combinations, idx + 1);
            if (targetNumber - data[idx] < 0)
            {
                return;
            }

            combinations.Add(data[idx]);
            Dfs(data, targetNumber - data[idx], result, combinations, idx);
            combinations.RemoveAt(combinations.Count - 1);
        }
    }

    /// <summary>
    /// 40. Combination Sum II
    /// </summary>
    /// <param name="candidates"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var freq = new List<int[]>();
        IList<IList<int>> ans = new List<IList<int>>();
        var sequence = new List<int>();

        Array.Sort(candidates);
        foreach (int num in candidates)
        {
            int size = freq.Count;
            if (freq.Count == 0 || num != freq[size - 1][0])
            {
                freq.Add([num, 1]);
            }
            else
            {
                ++freq[size - 1][1];
            }
        }

        Dfs(0, target);
        return ans;

        void Dfs(int pos, int rest)
        {
            if (rest == 0)
            {
                ans.Add(new List<int>(sequence));
                return;
            }

            if (pos == freq.Count || rest < freq[pos][0])
            {
                return;
            }

            Dfs(pos + 1, rest);
            int most = Math.Min(rest / freq[pos][0], freq[pos][1]);
            for (int i = 1; i <= most; i++)
            {
                sequence.Add(freq[pos][0]);
                Dfs(pos + 1, rest - i * freq[pos][0]);
            }

            for (int i = 1; i <= most; i++)
            {
                sequence.RemoveAt(sequence.Count - 1);
            }
        }
    }

    /// <summary>
    /// 41. First Missing Positive
    /// </summary>
    public static int FirstMissingPositive(int[] nums)
    {
        int len = nums.Length;
        for (int i = 0; i < len; i++)
        {
            while (nums[i] > 0 && nums[i] <= len && nums[nums[i] - 1] != nums[i])
            {
                Util.Swap(ref nums[i], ref nums[nums[i] - 1]);
            }
        }

        for (int i = 0; i < len; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }

        return len + 1;
    }

    /// <summary>
    /// 42. Trap Rain Water
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public static int Trap(int[] height)
    {
        if (height == null)
        {
            return 0;
        }

        int l = 0, r = height.Length - 1;
        int lMax = 0, rMax = 0;
        int ans = 0;
        while (l < r)
        {
            if (l >= r)
            {
                continue;
            }

            if (height[l] < height[r])
            {
                if (height[l] >= lMax)
                {
                    lMax = height[l];
                }
                else
                {
                    ans += (lMax - height[l]);
                }

                l++;
            }
            else
            {
                if (height[r] >= rMax)
                {
                    rMax = height[r];
                }
                else
                {
                    ans += (rMax - height[r]);
                }

                r--;
            }
        }

        return ans;
    }

    /// <summary>
    /// 43. Multiply String
    /// </summary>
    public static string Multiply(string num1, string num2)
    {
        int m = num1.Length, n = num2.Length;
        int[] pos = new int[m + n];
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                int mul = (num1[i] - '0') * (num2[j] - '0');
                int p1 = i + j, p2 = i + j + 1;
                int sum = mul + pos[p2];
                pos[p1] += sum / 10;
                pos[p2] = (sum) % 10;
            }
        }

        var sb = new StringBuilder();
        foreach (int item in pos)
        {
            if (!(sb.Length == 0 && item == 0))
            {
                sb.Append(item);
            }
        }

        return sb.Length == 0 ? "0" : sb.ToString();
    }

    /// <summary>
    /// 45. Jump Game II
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int Jump(int[] nums)
    {
        int n = nums.Length;
        if (n < 2)
        {
            return 0;
        }

        int level = 0;
        int currentMax = 0;
        int i = 0;
        int nextMax = 0;
        while (currentMax - i + 1 > 0)
        {
            level++;
            for (; i <= currentMax; i++)
            {
                nextMax = Math.Max(nextMax, nums[i] + i);
                if (nextMax >= n - 1)
                {
                    return level;
                }
            }

            currentMax = nextMax;
        }

        return 0;

        // with greedy
        //int jumps = 0, currEnd = 0, currFarthest = 0;
        //for (int i = 0; i < nums.Length - 1; i++)
        //{
        //    currFarthest = Math.Max(currFarthest, i + nums[i]); ;
        //    if (i == currEnd)
        //    {
        //        jumps++;
        //        currEnd = currFarthest;
        //        if (currEnd >= nums.Length - 1)
        //            break;
        //    }
        //}
        //return jumps;
    }

    /// <summary>
    /// 46. Permutations
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        var q = new Queue<IList<int>>();
        q.Enqueue(new List<int>());
        foreach (int t in nums)
        {
            int size = q.Count;
            while (size-- > 0)
            {
                IList<int> list = q.Dequeue();
                for (int j = 0; j <= list.Count; j++)
                {
                    var tmp = new List<int>(list);
                    tmp.Insert(j, t);
                    q.Enqueue(tmp);
                }
            }
        }

        while (q.Count > 0)
        {
            res.Add(q.Dequeue());
        }

        return res.Reverse().ToList();
    }

    /// <summary>
    /// 48. Rotate Image
    /// </summary>
    /// <param name="nums"></param>
    public static void Rotate(int[][] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n; j++)
            {
                (nums[i][j], nums[n - i - 1][j]) = (nums[n - i - 1][j], nums[i][j]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                (nums[i][j], nums[j][i]) = (nums[j][i], nums[i][j]);
            }
        }
    }

    /// <summary>
    /// 50. Power
    /// </summary>
    /// <param name="x">base</param>
    /// <param name="n">power</param>
    /// <returns></returns>
    public static double MyPow(double x, int n)
    {
        long longN = n;
        return longN >= 0 ? QuickMul(x, longN) : 1.0 / QuickMul(x, -longN);

        double QuickMul(double baseNumber, long power)
        {
            double ans = 1.0d;
            double xContribute = baseNumber;
            while (power > 0)
            {
                if (power % 2 == 1)
                {
                    ans *= xContribute;
                }

                xContribute *= xContribute;
                power /= 2;
            }

            return ans;
        }
    }

    /// <summary>
    /// 53. Maximum Subarray
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int MaxSubArray(int[] nums)
    {
        int pre = 0, maxAns = nums[0];
        foreach (int num in nums)
        {
            pre = Math.Max(pre + num, num);
            maxAns = Math.Max(maxAns, pre);
        }

        return maxAns;
    }

    /// <summary>
    /// 54. Spiral Matrix
    /// </summary>
    public static IList<int> SpiralOrder(int[][] matrix)
    {
        if (matrix.Length == 0)
        {
            return new List<int>() { 0 };
        }

        int startRow = 0, startColumn = 0;
        int height = matrix.Length, width = matrix[0].Length;
        IList<int> result = new List<int>();
        while (true)
        {
            if (height == 0 || width == 0) // can also use if(index == height * width)
            {
                break;
            }

            for (int col = startColumn; col < startColumn + width; col++)
            {
                result.Add(matrix[startRow][col]);
            }

            startRow++;
            height--;
            if (height == 0)
            {
                break;
            }

            for (int row = startRow; row < startRow + height; row++)
            {
                result.Add(matrix[row][startColumn + width - 1]);
            }

            width--;
            if (width == 0)
            {
                break;
            }

            for (int col = startColumn + width - 1; col >= startColumn; col--)
            {
                result.Add(matrix[startRow + height - 1][col]);
            }

            height--;
            if (height == 0)
            {
                break;
            }

            for (int row = startRow + height - 1; row >= startRow; row--)
            {
                result.Add(matrix[row][startColumn]);
            }

            startColumn++;
            width--;
        }

        return result;
    }

    /// <summary>
    /// 55. Jump Game
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static bool CanJump(int[] nums)
    {
        int lastPos = nums.Length - 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (i + nums[i] >= lastPos)
            {
                lastPos = i;
            }
        }

        return lastPos == 0;
    }

    /// <summary>
    /// 56. Merge Intervals
    /// </summary>
    /// <param name="intervals"></param>
    /// <returns></returns>
    public static int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return [];
        }

        Array.Sort(intervals, (l, r) => l[0] - r[0]);
        var merged = new List<int[]>();
        foreach (int[] t in intervals)
        {
            int n = merged.Count;
            int l = t[0], r = t[1];
            if (n == 0 || merged[n - 1][1] < l)
            {
                merged.Add([l, r]);
            }
            else
            {
                merged[n - 1][1] = Math.Max(merged[n - 1][1], r);
            }
        }

        return merged.ToArray();
    }

    /// <summary>
    /// 58. Length Of Last Word
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int LengthOfLastWord(string s)
    {
        // s = s.Trim();
        // int lastIndex = s.LastIndexOf(' ') + 1;
        // return s.Length - lastIndex;
        int len = 0, tail = s.Length - 1;
        while (tail >= 0 && s[tail] == ' ')
        {
            tail--;
        }

        while (tail >= 0 && s[tail] != ' ')
        {
            len++;
            tail--;
        }

        return len;
    }

    /// <summary>
    /// 59. Spiral Matrix II
    /// </summary>
    public static int[][] GenerateMatrix(int n)
    {
        if (n == 0)
        {
            return [[0]];
        }

        int startRow = 0, startColumn = 0;
        int index = 1, height = n, width = n;
        int[][] matrix = new int[n][];
        for (int r = 0; r < n; r++)
        {
            matrix[r] = new int[n];
        }

        while (true)
        {
            if (width == 0)
            {
                break;
            }

            for (int col = startColumn; col < startColumn + width; col++)
            {
                matrix[startRow][col] = index++;
            }

            startRow++;
            height--;
            if (height == 0)
            {
                break;
            }

            for (int row = startRow; row < startRow + height; row++)
            {
                matrix[row][startColumn + width - 1] = index++;
            }

            width--;
            if (width == 0)
            {
                break;
            }

            for (int col = startColumn + width - 1; col >= startColumn; col--)
            {
                matrix[startRow + height - 1][col] = index++;
            }

            height--;
            if (height == 0)
            {
                break;
            }

            for (int row = startRow + height - 1; row >= startRow; row--)
            {
                matrix[row][startColumn] = index++;
            }

            startColumn++;
            width--;
        }

        return matrix;
    }

    /// <summary>
    /// 61. Rotate List
    /// </summary>
    public static ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || k == 0 || head.Next == null)
        {
            return head;
        }

        ListNode oldTail = head;
        int n;
        for (n = 1; oldTail.Next != null; n++)
        {
            oldTail = oldTail.Next;
        }

        oldTail.Next = head;
        ListNode newTail = head;
        for (int i = 0; i < n - k % n - 1; i++)
        {
            newTail = newTail.Next;
        }

        ListNode newHead = newTail.Next;
        newTail.Next = null;
        return newHead;
    }

    /// <summary>
    /// 62. Unique Paths
    /// </summary>
    public static int UniquePaths(int m, int n)
    {
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[j] += dp[j - 1];
            }
        }

        return dp[n - 1];
    }

    /// <summary>
    /// 63. Unique Paths II
    /// </summary>
    public static int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        // if(obstacleGrid[0][0] == 1)
        //     return 0;
        // int height = obstacleGrid.Length;
        // int width = obstacleGrid[0].Length;
        // obstacleGrid[0][0] = 1;
        // for(int row = 1; row < height; row++)
        //     obstacleGrid[row][0] = (obstacleGrid[row][0] == 0 && obstacleGrid[row - 1][0] == 1) ? 1 : 0;
        // for(int col = 1; col < width; col++)
        //     obstacleGrid[0][col] = (obstacleGrid[0][col] == 0 && obstacleGrid[0][col - 1] == 1) ? 1 : 0;
        // for(int row = 1; row < height; row++)
        //     for(int col = 1; col < width; col++)
        //         if(obstacleGrid[row][col] == 0)
        //             obstacleGrid[row][col] = obstacleGrid[row - 1][col] + obstacleGrid[row][col - 1];
        //         else
        //             obstacleGrid[row][col] = 0;
        // return obstacleGrid[height - 1][width - 1];

        int width = obstacleGrid[0].Length;
        int[] dp = new int[width];
        dp[0] = 1;
        foreach (int[] row in obstacleGrid)
        {
            for (int j = 0; j < width; j++)
            {
                if (row[j] == 1)
                {
                    dp[j] = 0;
                }
                else if (j > 0)
                {
                    dp[j] += dp[j - 1];
                }
            }
        }

        return dp[width - 1];
    }

    /// <summary>
    /// 64. Minimum Path Sum
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int MinPathSum(int[][] grid)
    {
        int width = grid[0].Length;
        int height = grid.Length;
        int[][] dp = new int[height][];
        for (int i = 0; i < height; i++)
        {
            dp[i] = new int[width];
        }

        dp[0][0] = grid[0][0];
        for (int i = 1; i < width; i++)
        {
            dp[0][i] = dp[0][i - 1] + grid[0][i];
        }

        for (int i = 1; i < height; i++)
        {
            dp[i][0] = dp[i - 1][0] + grid[i][0];
        }

        for (int i = 1; i < height; i++)
        {
            for (int j = 1; j < width; j++)
            {
                dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + grid[i][j];
            }
        }

        return dp[height - 1][width - 1];
    }

    /// <summary>
    /// 66. Plus One
    /// </summary>
    /// <param name="digits"></param>
    /// <returns></returns>
    public static int[] PlusOne(int[] digits)
    {
        int n = digits.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            if (digits[i] != 9)
            {
                digits[i]++;
                for (int j = i + 1; j < n; j++)
                {
                    digits[j] = 0;
                }
                return digits;
            }
        }

        int[] newNumber = new int[n + 1];
        newNumber[0] = 1;
        return newNumber;
    }

    /// <summary>
    /// 67. Add Binary
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static string AddBinary(string a, string b)
    {
        string s = "";
        int c = 0, i = a.Length - 1, j = b.Length - 1;
        while (i >= 0 || j >= 0 || c == 1)
        {
            c += i >= 0 ? a[i--] - '0' : 0;
            c += j >= 0 ? b[j--] - '0' : 0;
            s = Convert.ToChar(c % 2 + '0') + s;
            c /= 2;
        }

        return s;
    }

    /// <summary>
    /// 68. Text Justification
    /// </summary>
    /// <param name="words"></param>
    /// <param name="maxWidth"></param>
    /// <returns></returns>
    public static IList<string> FullJustify(string[] words, int maxWidth)
    {
        IList<string> ans = new List<string>();
        int right = 0, n = words.Length;
        while (true)
        {
            int left = right;
            int sumLen = 0;
            while (right < n && sumLen + words[right].Length + right - left <= maxWidth)
            {
                sumLen += words[right++].Length;
            }

            if (right == n)
            {
                StringBuilder sb = Join(words, left, n, " ");
                sb.Append(Blank(maxWidth - sb.Length));
                ans.Add(sb.ToString());
                return ans;
            }

            int numWords = right - left;
            int numSpaces = maxWidth - sumLen;
            if (numWords == 1)
            {
                var sb = new StringBuilder(words[left]);
                sb.Append(Blank(numSpaces));
                ans.Add(sb.ToString());
                continue;
            }

            int avgSpaces = numSpaces / (numWords - 1);
            int extraSpaces = numSpaces % (numWords - 1);
            var curr = new StringBuilder();
            curr.Append(Join(words, left, left + extraSpaces + 1, Blank(avgSpaces + 1)));
            curr.Append(Blank(avgSpaces));
            curr.Append(Join(words, left + extraSpaces + 1, right, Blank(avgSpaces)));
            ans.Add(curr.ToString());
        }

        string Blank(int number)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                sb.Append(' ');
            }

            return sb.ToString();
        }

        StringBuilder Join(string[] inputWords, int leftIndex, int rightIndex, string separator)
        {
            var sb = new StringBuilder(inputWords[leftIndex]);
            for (int i = leftIndex + 1; i < rightIndex; i++)
            {
                sb.Append(separator + inputWords[i]);
            }

            return sb;
        }
    }

    /// <summary>
    /// 69. Sqrt(x)
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int Sqrt(int x)
    {
        if (x == 0)
        {
            return 0;
        }

        int left = 1, right = x;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (mid == x / mid)
            {
                return mid;
            }
            else if (mid < x / mid)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return right;
    }

    /// <summary>
    /// 70. Climb Stairs
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int ClimbStairs(int n)
    {
        // 44ms
        //if (n == 1) return 1;
        //int[] dp = new int[n + 1];
        //dp[1] = 1;
        //dp[2] = 2;
        //for (int i = 3; i <= n; i++)
        //  dp[i] = dp[i - 1] + dp[i - 2];
        //return dp[n];

        // 56ms
        int a = 1, b = 1;
        while (n-- > 0)
        {
            a = (b += a) - a;
        }

        return a;
    }

    /// <summary>
    /// 71. Simplify Path
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string SimplifyPath(string path)
    {
        var stack = new Stack<string>();
        var skip = new HashSet<string> { "", ".", ".." };
        foreach (string dir in path.Split('/'))
        {
            if (dir == ".." && stack.Count > 0)
            {
                stack.Pop();
            }
            else if (!skip.Contains(dir))
            {
                stack.Push(dir);
            }
        }

        if (stack.Count == 0)
        {
            return "/";
        }

        var sb = new StringBuilder();
        while (stack.Count > 0)
        {
            sb.Insert(0, "/" + stack.Pop());
        }

        return sb.ToString();
    }

    /// <summary>
    /// 73. Set Zeroes
    /// </summary>
    /// <param name="matrix"></param>
    public static void SetZeroes(int[][] matrix)
    {
        int col0 = 1, rows = matrix.Length, cols = matrix[0].Length;
        // top-down
        for (int i = 0; i < rows; i++)
        {
            // first column
            if (matrix[i][0] == 0)
            {
                col0 = 0;
            }

            for (int j = 1; j < cols; j++)
            {
                // if the current cell is "0" set i row and j col as "0"
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = matrix[0][j] = 0;
                }
            }
        }

        // bottom-up
        for (int i = rows - 1; i >= 0; i--)
        {
            for (int j = cols - 1; j >= 1; j--)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                {
                    matrix[i][j] = 0;
                }
            }

            if (col0 == 0)
            {
                matrix[i][0] = 0;
            }
        }
    }

    /// <summary>
    /// 74. Search a 2D Matrix
    /// </summary>
    public static bool SearchMatrix(int[][] matrix, int target)
    {
        int row = matrix.Length;
        if (row == 0)
        {
            return false;
        }

        int col = matrix[0].Length;
        int low = 0, high = row * col - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int r = mid / col;
            int c = mid % col;
            if (matrix[r][c] > target)
            {
                high = mid - 1;
            }
            else if (matrix[r][c] < target)
            {
                low = mid + 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 77. Combinations
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static IList<IList<int>> Combine(int n, int k)
    {
        var temp = new List<int>();
        IList<IList<int>> ans = new List<IList<int>>();
        for (int i = 1; i <= k; ++i)
        {
            temp.Add(i);
        }

        temp.Add(n + 1);
        int j = 0;
        while (j < k)
        {
            ans.Add(new List<int>(temp.GetRange(0, k)));
            j = 0;
            while (j < k && temp[j] + 1 == temp[j + 1])
            {
                temp[j] = j + 1;
                ++j;
            }

            ++temp[j];
        }

        return ans;
    }

    /// <summary>
    /// 80. Remove Duplicates from Sorted Array II
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int RemoveDuplicatesV2(int[] nums)
    {
        int len = nums.Length;
        if (len <= 2)
        {
            return len;
        }

        int slow = 2, fast = 2;
        while (fast < len)
        {
            if (nums[slow - 2] != nums[fast])
            {
                nums[slow] = nums[fast];
                ++slow;
            }

            ++fast;
        }

        return slow;
    }

    /// <summary>
    /// 83. Remove Duplicates from Sorted List
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static ListNode DeleteDuplicates(ListNode head)
    {
        ListNode current = head;
        while (current?.Next != null)
        {
            if (current.Val == current.Next.Val)
            {
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }

        return head;
    }

    /// <summary>
    /// 88. Merge Sorted Array
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="m"></param>
    /// <param name="num2"></param>
    /// <param name="n"></param>
    public static void Merge(int[] num1, int m, int[] num2, int n)
    {
        int p = m - 1, q = n - 1, i = m + n - 1;
        while (q >= 0)
        {
            if (p < 0 || num2[q] >= num1[p])
            {
                num1[i--] = num2[q--];
            }
            else
            {
                num1[i--] = num1[p--];
            }
        }
    }

    /// <summary>
    /// 94. Binary Tree Inorder Traversal
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> ret = new List<int>();
        if (root == null)
        {
            return ret;
        }
        // recursively
        // InorderHelper(ret, root);

        // iteratively
        var stack = new Stack<TreeNode>();
        TreeNode curr = root;
        while (curr != null || stack.Count > 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.Left;
            }

            curr = stack.Pop();
            ret.Add(curr.Val);
            curr = curr.Right;
        }

        return ret;

        // void InorderHelper(IList<int> data, TreeNode node)
        // {
        //     if (node == null)
        //     {
        //         return;
        //     }
        //     InorderHelper(data, node.left);
        //     data.Add(node.val);
        //     InorderHelper(data, node.right);
        // }
    }

    /// <summary>
    /// 98. Validate Binary Search Tree
    /// </summary>
    public static bool IsValidBst(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        double inorder = -double.MaxValue;
        while (stack.Count > 0 || root != null)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.Left;
            }

            root = stack.Pop();
            if (root.Val <= inorder)
            {
                return false;
            }

            inorder = root.Val;
            root = root.Right;
        }

        return true;
    }

    /// <summary>
    /// 100. Same Tree
    /// </summary>
    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null || q == null)
        {
            return p == q;
        }

        return p.Val == q.Val && IsSameTree(p.Left, q.Right) && IsSameTree(q.Left, q.Right);
    }

    /// <summary>
    /// 101. Symmetric Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool IsSymmetric(TreeNode root)
    {
        // 116ms by recursion
        // return IsMirror(root, root);

        // 104ms by iteration
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode t1 = queue.Dequeue();
            TreeNode t2 = queue.Dequeue();
            if (t1 == null & t2 == null)
            {
                continue;
            }

            if (t1 == null || t2 == null)
            {
                return false;
            }

            if (t1.Val != t2.Val)
            {
                return false;
            }

            queue.Enqueue(t1.Left);
            queue.Enqueue(t2.Right);
            queue.Enqueue(t1.Right);
            queue.Enqueue(t2.Left);
        }

        return true;

        // bool IsMirror(TreeNode l1, TreeNode l2)
        // {
        //     if (l1 == null && l2 == null)
        //     {
        //         return true;
        //     }
        //
        //     if (l1 == null || l2 == null)
        //     {
        //         return false;
        //     }
        //
        //     return (l1.val == l2.val)
        //            && IsMirror(l1.left, l2.right)
        //            && IsMirror(l1.right, l2.left);
        // }
    }

    /// <summary>
    /// 104. Maximum Depth of Binary Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static int MaxDepth(TreeNode root)
    {
        // DFS 112ms
        // return root == null ? 0 : 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        // BFS 112ms
        if (root == null)
        {
            return 0;
        }

        int res = 0;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            res++;
            for (int i = 0, n = queue.Count; i < n; i++)
            {
                TreeNode p = queue.Peek();
                queue.Dequeue();
                if (p.Left != null)
                {
                    queue.Enqueue(p.Left);
                }

                if (p.Right != null)
                {
                    queue.Enqueue(p.Right);
                }
            }
        }

        return res;
    }

    /// <summary>
    /// 107. Binary Tree Level Order Traversal II
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null)
        {
            return res;
        }

        var que = new Queue<TreeNode>();
        que.Enqueue(root);
        while (true)
        {
            int nodeCount = que.Count;
            if (nodeCount == 0)
            {
                break;
            }

            var subList = new List<int>();
            while (nodeCount > 0)
            {
                TreeNode dataNode = que.Dequeue();
                subList.Add(dataNode.Val);
                if (dataNode.Left != null)
                {
                    que.Enqueue(dataNode.Left);
                }

                if (dataNode.Right != null)
                {
                    que.Enqueue(dataNode.Right);
                }

                nodeCount--;
            }

            res.Insert(0, subList);
        }

        return res;
    }

    /// <summary>
    /// 108. Convert Sorted Array To Binary Search Tree
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static TreeNode SortedArrayToBst(int[] nums)
    {
        //if (nums == null || nums.Length == 0) return null;
        //int mid = nums.Length / 2;
        //TreeNode root = new TreeNode(nums[mid]);
        //root.left = SubProcess(nums.Where((num, index) => index < mid).ToArray());
        //root.right = SubProcess(nums.Where((num, index) => index > mid).ToArray());
        //return root;
        return SubProcess(nums, 0, nums.Length - 1);

        TreeNode SubProcess(int[] data, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = start + (end - start) / 2;
            var root = new TreeNode(data[mid])
            {
                Left = SubProcess(data, start, mid - 1),
                Right = SubProcess(data, mid + 1, end)
            };
            return root;
        }
    }

    /// <summary>
    /// 109. Convert Sorted List to Binary Search Tree
    /// </summary>
    public static TreeNode SortedListToBst(ListNode head)
    {
        int size = FindSize(head);
        return ConvertListToBst(0, size - 1);

        int FindSize(ListNode node)
        {
            ListNode ptr = node;
            int c = 0;
            while (ptr != null)
            {
                ptr = ptr.Next;
                c += 1;
            }

            return c;
        }

        TreeNode ConvertListToBst(int l, int r)
        {
            if (l > r)
            {
                return null;
            }

            int mid = (l + r) / 2;
            TreeNode left = ConvertListToBst(l, mid - 1);
            var node = new TreeNode(head.Val)
            {
                Left = left
            };
            head = head.Next;
            node.Right = ConvertListToBst(mid + 1, r);
            return node;
        }
    }

    /// <summary>
    /// 110. Balanced Binary Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static bool IsBalanced(TreeNode root)
    {
        return Dfs(root) != -1;

        int Dfs(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftHeight = Dfs(node.Left);
            if (leftHeight == -1)
            {
                return -1;
            }

            int rightHeight = Dfs(node.Right);
            if (rightHeight == -1)
            {
                return -1;
            }

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1;
            }

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }

    /// <summary>
    /// 111. Minimum Depth of Binary Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static int MinDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        int l = MinDepth(root.Left), r = MinDepth(root.Right);
        return 1 + (l < r && l > 0 || r < 1 ? l : r);
    }

    /// <summary>
    /// 112. Path Sum
    /// </summary>
    /// <param name="root"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    public static bool HasPathSum(TreeNode root, int sum)
    {
        if (root == null)
        {
            return false;
        }

        if (root.Val == sum && root.Left == null && root.Right == null)
        {
            return true;
        }

        return HasPathSum(root.Left, sum - root.Val) || HasPathSum(root.Right, sum - root.Val);
    }

    /// <summary>
    /// 113. Path Sum II
    /// </summary>
    /// <param name="root"></param>
    /// <param name="targetSum"></param>
    /// <returns></returns>
    public static IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> path = new List<int>();
        Dfs(root, targetSum);
        return res;

        void Dfs(TreeNode node, int sum)
        {
            if (node is null)
            {
                return;
            }

            path.Add(node.Val);
            sum -= node.Val;
            if (node.Left is null && node.Right is null && sum == 0)
            {
                res.Add(new List<int>(path));
            }

            Dfs(node.Left, sum);
            Dfs(node.Right, sum);
            path.RemoveAt(path.Count - 1);
        }
    }

    /// <summary>
    /// 116. Populating Next Right Pointers in Each Node
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static BinaryTreeNode Connect(BinaryTreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        BinaryTreeNode leftmost = root;
        while (leftmost.Left != null)
        {
            BinaryTreeNode head = leftmost;
            while (head != null)
            {
                head.Left.Next = head.Right;
                if (head.Next != null)
                {
                    head.Right.Next = head.Next.Left;
                }

                head = head.Next;
            }

            leftmost = leftmost.Left;
        }

        return root;
    }

    /// <summary>
    /// 118. Pascal's triangle
    /// </summary>
    /// <param name="numRows"></param>
    /// <returns></returns>
    public static IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> triangle = new List<IList<int>>();
        //if (numRows == 0) return triangle;
        //triangle.Add(new List<int>());
        //triangle[0].Add(1);
        //for(int rowNum = 1; rowNum < numRows; rowNum++)
        //{
        //    List<int> row = new List<int>();
        //    IList<int> prevRow = triangle[rowNum - 1];
        //    row.Add(1);
        //    for (int j = 1; j < rowNum; j++) row.Add(prevRow[j - 1] + prevRow[j]);
        //    row.Add(1);
        //    triangle.Add(row);
        //}
        for (int i = 0; i < numRows; ++i)
        {
            IList<int> row = new List<int>();
            for (int r = 1; r <= i + 1; r++)
            {
                row.Add(1);
            }

            triangle.Add(row);
            for (int j = 1; j < i; ++j)
            {
                triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }
        }

        return triangle;
    }

    /// <summary>
    /// 120. Triangle
    /// </summary>
    /// <param name="triangle"></param>
    /// <returns></returns>
    public static int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        int[] f = new int[n];
        f[0] = triangle[0][0];
        for (int i = 1; i < n; ++i)
        {
            f[i] = f[i - 1] + triangle[i][i];
            for (int j = i - 1; j > 0; --j)
            {
                f[j] = Math.Min(f[j - 1], f[j]) + triangle[i][j];
            }

            f[0] += triangle[i][0];
        }

        return f.Min();
    }

    /// <summary>
    /// 121. Best Time to Buy and Sell Stock
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public static int MaxProfit(int[] prices)
    {
        // 108 ms
        //int total = 0;
        //for (int i = 1; i < prices.Length; i++)
        //    if (prices[i] > prices[i - 1])
        //        total += prices[i] - prices[i - 1];
        //return total;
        int len = prices.Length;
        if (len < 1)
        {
            return 0;
        }

        int[] full = new int[len];
        int[] empty = new int[len];
        empty[0] = 0;
        full[0] = prices[0] * -1;
        for (int i = 1; i < len; i++)
        {
            empty[i] = Math.Max(empty[i - 1], full[i - 1] + prices[i]);
            full[i] = Math.Max(full[i - 1], empty[i - 1] - prices[i]);
        }

        return Math.Max(full[len - 1], empty[len - 1]);
    }

    /// <summary>
    /// 125. Valid Palindrome
    /// </summary>
    public static bool IsPalindrome(string s)
    {
        for (int i = 0, j = s.Length - 1; i < j;)
        {
            if (!char.IsLetterOrDigit(s[i])) // skip space from head
            {
                i++;
            }
            else if (!char.IsLetterOrDigit(s[j])) // skip space from tail
            {
                j--;
            }
            else if (char.ToLower(s[i++]) != char.ToLower(s[j--]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 136. Single Number
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int SingleNumber(int[] nums)
    {
        return nums.Aggregate(0, (current, item) => current ^ item);
    }

    /// <summary>
    /// 137. Single Number II
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int SingleNumberV2(int[] nums)
    {
        int ones = 0, twos = 0;
        foreach (int t in nums)
        {
            ones = (ones ^ t) & ~twos;
            twos = (twos ^ t) & ~ones;
        }

        return ones;
    }

    /// <summary>
    /// 141. Linked List Cycle
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static bool HasCycle(ListNode head)
    {
        if (head?.Next == null)
        {
            return false;
        }

        ListNode slow = head;
        ListNode fast = head.Next;
        while (slow != fast)
        {
            if (fast?.Next == null)
            {
                return false;
            }

            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return true;
    }

    /// <summary>
    /// 144. Binary Tree Preorder Traversal
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IList<int> PreorderTraversal(TreeNode root)
    {
        IList<int> res = new List<int>();
        var stack = new Stack<TreeNode>();
        while (root != null)
        {
            res.Add(root.Val);
            if (root.Right != null)
            {
                stack.Push(root.Right);
            }

            root = root.Left;
            if (root == null && stack.Count > 0)
            {
                root = stack.Pop();
            }
        }

        return res;
    }

    /// <summary>
    /// 148. Sort List
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static ListNode SortList(ListNode head)
    {
        if (head?.Next == null)
        {
            return head;
        }

        ListNode prev = null, left = head, right = head;
        while (right?.Next != null)
        {
            prev = left;
            left = left.Next;
            right = right.Next.Next;
        }

        prev!.Next = null;

        ListNode l1 = SortList(head);
        ListNode l2 = SortList(left);

        return MergeTwoLists(l1, l2);
    }

    /// <summary>
    /// 153. Find Minimum in Rotated Sorted Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int FindMin(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        int l = 0, r = nums.Length - 1;
        if (nums[r] > nums[0])
        {
            return nums[0];
        }

        while (r >= l)
        {
            int mid = l + (r - l) / 2;
            if (nums[mid] > nums[mid + 1])
            {
                return nums[mid + 1];
            }

            if (nums[mid - 1] > nums[mid])
            {
                return nums[mid];
            }

            if (nums[mid] > nums[0])
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }

        return -1;
    }

    /// <summary>
    /// 162. Find Peak Element
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int FindPeakElement(int[] nums)
    {
        int len = nums.Length;
        int l = 0, r = len - 1, ans = -1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            if (Compare(nums, mid - 1, mid) < 0 &&
                Compare(nums, mid, mid + 1) > 0)
            {
                ans = mid;
                break;
            }

            if (Compare(nums, mid, mid + 1) < 0)
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }

        return ans;

        int[] Get(int[] data, int index)
        {
            if (index == -1 || index == data.Length)
            {
                return [0, 0];
            }

            return [1, data[index]];
        }

        int Compare(int[] data, int index1, int index2)
        {
            int[] num1 = Get(data, index1);
            int[] num2 = Get(data, index2);
            if (num1[0] != data[0])
            {
                return num1[0] > num2[0] ? 1 : -1;
            }

            if (num1[1] == num2[1])
            {
                return 0;
            }

            return num1[1] > num2[1] ? 1 : -1;
        }
    }

    /// <summary>
    /// 167. Two Sum II - Input array is sorted
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int[] TwoSumIi(int[] numbers, int target)
    {
        int left = 0, right = numbers.Length - 1;
        while (left < right)
        {
            int sum = numbers[left] + numbers[right];
            if (sum == target)
            {
                return [left + 1, right + 1];
            }
            else if (sum > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return [-1, -1];
    }

    /// <summary>
    /// 168. Excel Sheet Column Title
    /// </summary>
    /// <param name="columnNumber"></param>
    /// <returns></returns>
    public static string ConvertToTitle(int columnNumber)
    {
        var sb = new StringBuilder();
        while (columnNumber != 0)
        {
            columnNumber--;
            sb.Append((char)(columnNumber % 26 + 'A'));
            columnNumber /= 26;
        }

        var columnTitle = new StringBuilder();
        for (int i = sb.Length - 1; i >= 0; i--)
        {
            columnTitle.Append(sb[i]);
        }

        return columnTitle.ToString();
    }

    /// <summary>
    /// 169. Majority Element
    /// </summary>
    public static int MajorityElement(int[] nums)
    {
        int count = 0;
        int candidate = 0;
        foreach (int num in nums)
        {
            if (count == 0)
            {
                candidate = num;
            }

            count += num == candidate ? 1 : -1;
        }

        return candidate;
    }

    /// <summary>
    /// 171. Excel Sheet Column Number
    /// </summary>
    /// <param name="columnTitle"></param>
    /// <returns></returns>
    public static int TitleToNumber(string columnTitle)
    {
        int number = 0;
        int multiple = 1;
        for (int i = columnTitle.Length - 1; i >= 0; --i)
        {
            int k = columnTitle[i] - 'A' + 1;
            number += k * multiple;
            multiple *= 26;
        }

        return number;
    }

    /// <summary>
    /// 172. Factorial Trailing Zeroes
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int TrailingZeroes(int n)
    {
        return n == 0 ? 0 : n / 5 + TrailingZeroes(n / 5);
    }

    /// <summary>
    /// 174. Dungeon Game
    /// </summary>
    /// <param name="dungeon">map</param>
    /// <returns></returns>
    public static int CalculateMinimumHp(int[][] dungeon)
    {
        int m = dungeon.Length;
        int n = dungeon[0].Length;
        if (m == 0 || n == 0)
        {
            return 0;
        }

        int[][] health = new int[m][];
        for (int i = 0; i < m; ++i)
        {
            health[i] = new int[n];
        }

        health[m - 1][n - 1] = Math.Max(1 - dungeon[m - 1][n - 1], 1);
        for (int i = m - 2; i >= 0; i--)
        {
            health[i][n - 1] = Math.Max(health[i + 1][n - 1] - dungeon[i][n - 1], 1);
        }

        for (int j = n - 2; j >= 0; j--)
        {
            health[m - 1][j] = Math.Max(health[m - 1][j + 1] - dungeon[m - 1][j], 1);
        }

        for (int i = m - 2; i >= 0; i--)
        {
            for (int j = n - 2; j >= 0; j--)
            {
                int down = Math.Max(health[i + 1][j] - dungeon[i][j], 1);
                int right = Math.Max(health[i][j + 1] - dungeon[i][j], 1);
                health[i][j] = Math.Min(right, down);
            }
        }

        return health[0][0];
    }

    /// <summary>
    /// 189. Rotate Array
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    public static void Rotate(int[] nums, int k)
    {
        k %= nums.Length;
        ReverseHelper(nums, 0, nums.Length - 1);
        ReverseHelper(nums, 0, k - 1);
        ReverseHelper(nums, k, nums.Length - 1);

        void ReverseHelper(int[] data, int start, int end)
        {
            while (start < end)
            {
                (data[start], data[end]) = (data[end], data[start]);
                start++;
                end--;
            }
        }
    }

    /// <summary>
    /// 190. Reverse Bits
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static uint ReverseBits(uint n)
    {
        n = (n >> 16) | (n << 16);
        n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
        n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
        n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
        n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
        return n;
        //if (n == 0) return 0;
        //uint res = 0;
        //for (int i = 0; i < 32; i++)
        //{
        //    res <<= 1;
        //    if ((n & 1) == 1) res++;
        //    n >>= 1;
        //}
        //return res;
    }

    /// <summary>
    /// 191. Number of 1 Bits
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int HammingWeight(uint n)
    {
        int res = 0;
        while (n != 0)
        {
            n &= (n - 1);
            res++;
        }

        return res;
    }

    /// <summary>
    /// 198. House Robber
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int Rob(int[] nums)
    {
        //int a = 0;
        //int b = 0;
        //for (int i = 0; i < nums.Length; i++)
        //{
        //    if (i % 2 == 0)
        //        a = Math.Max(a + nums[i], b);
        //    else
        //        b = Math.Max(a, b + nums[i]);
        //}
        //return Math.Max(a, b);

        int rob = 0;
        int notRob = 0;
        foreach (int item in nums)
        {
            int current = notRob + item;
            notRob = Math.Max(notRob, rob);
            rob = current;
        }

        return Math.Max(notRob, rob);
    }

    /// <summary>
    /// 2351. First Letter to Appear Twice
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static char RepeatedCharacter(string s)
    {
        int[] map = new int[26];
        foreach (char c in s)
        {
            int index = c - 'a';
            if (map[index] > 0)
            {
                return c;
            }
            map[index]++;
        }

        return ' ';
    }

    /// <summary>
    /// 2580. Count Ways to Group Overlapping Ranges
    /// </summary>
    /// <param name="ranges"></param>
    /// <returns></returns>
    public static int CountWays(int[][] ranges)
    {
        const int mod = 1_000_000_007;
        Array.Sort(ranges, (a, b) => a[0] - b[0]);
        int n = ranges.Length;
        int res = 1;
        for (int i = 0; i < n;)
        {
            int r = ranges[i][1];
            int j = i + 1;
            while (j < n && ranges[j][0] <= r)
            {
                r = Math.Max(r, ranges[j][1]);
                j++;
            }

            res = res * 2 % mod;
            i = j;
        }

        return res;
    }

    /// <summary>
    /// 2739. Total Distance Traveled
    /// </summary>
    /// <param name="mainTank"></param>
    /// <param name="additionalTank"></param>
    /// <returns></returns>
    public static int DistanceTraveled(int mainTank, int additionalTank)
    {
        return 10 * (mainTank + Math.Min((mainTank - 1) / 4, additionalTank));
    }

    /// <summary>
    /// 2810. Faulty Keyboard
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string FinalString(string s)
    {
        var q = new LinkedList<char>();
        bool head = false;
        foreach (char ch in s)
        {
            if (ch != 'i')
            {
                if (head)
                {
                    q.AddFirst(ch);
                }
                else
                {
                    q.AddLast(ch);
                }
            }
            else
            {
                head = !head;
            }
        }
        var sb = new StringBuilder();
        if (head)
        {
            while (q.Count > 0)
            {
                sb.Append(q.Last.Value);
                q.RemoveLast();
            }
        }
        else
        {
            while (q.Count > 0)
            {
                sb.Append(q.First.Value);
                q.RemoveFirst();
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// 2903. Find Indices With Index and Value Difference I
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="indexDifference"></param>
    /// <param name="valueDifference"></param>
    /// <returns></returns>
    public static int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
    {
        int minIndex = 0, maxIndex = 0;
        for (int j = indexDifference; j < nums.Length; j++)
        {
            int i = j - indexDifference;
            if (nums[i] < nums[minIndex])
            {
                minIndex = i;
            }

            if (nums[j] - nums[minIndex] >= valueDifference)
            {
                return [minIndex, j];
            }

            if (nums[i] > nums[maxIndex])
            {
                maxIndex = i;
            }
            if (nums[maxIndex] - nums[j] >= valueDifference)
            {
                return [maxIndex, j];
            }
        }
        return [-1, -1];
    }

    /// <summary>
    /// 2908. Minimum Sum of Mountain Triplets I
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int MinimumSum(int[] nums)
    {
        int n = nums.Length;
        int res = 1000;
        int mini = 1000;
        int[] left = new int[n];
        int right = nums[n - 1];

        for (int i = 1; i < n; i++)
        {
            mini = Math.Min(nums[i - 1], mini);
            left[i] = mini;
        }

        for (int i = n - 2; i > 0; i--)
        {
            if (left[i] < nums[i] && nums[i] > right)
            {
                res = Math.Min(res, left[i] + nums[i] + right);
            }
            right = Math.Min(right, nums[i]);
        }
        return res < 1000 ? res : -1;
    }

    /// <summary>
    /// 2952. Minimum Number of Coins to be Added
    /// </summary>
    /// <param name="coins"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int MinimumAddedCoins(int[] coins, int target)
    {
        int n = coins.Length;
        int index = 0;
        int res = 0;
        int x = 1;
        Array.Sort(coins);

        while (x <= target)
        {
            if (index < n && coins[index] <= x)
            {
                x += coins[index];
                index++;
            }
            else
            {
                x *= 2;
                res += 1;
            }
        }

        return res;
    }

    /// <summary>
    /// 6078. Rearrange Characters to Make Target String
    /// </summary>
    /// <param name="s"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int RearrangeCharacters(string s, string target)
    {
        var sDic = new Dictionary<char, int>();
        var targetDic = new Dictionary<char, int>();
        foreach (char ch in s)
        {
            if (sDic.TryGetValue(ch, out int value))
            {
                sDic[ch] = ++value;
            }
            else
            {
                sDic.Add(ch, 1);
            }
        }

        foreach (char ch in target)
        {
            if (targetDic.TryGetValue(ch, out int value))
            {
                targetDic[ch] = ++value;
            }
            else
            {
                targetDic.Add(ch, 1);
            }
        }

        int ans = int.MaxValue;
        foreach (char ch in target)
        {
            sDic.TryGetValue(ch, out int sValue);
            ans = Math.Min(ans, sValue / targetDic[ch]);
        }

        return ans;
    }
}
