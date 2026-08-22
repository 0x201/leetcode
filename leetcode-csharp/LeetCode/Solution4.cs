// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 801. Minimum Swaps To Make Sequences Increasing
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public static int MinSwap(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int a = 0, b = 1;
        for (int i = 1; i < n; i++)
        {
            int at = a, bt = b;
            a = b = n;
            if (nums1[i] > nums1[i - 1] && nums2[i] > nums2[i - 1])
            {
                a = Math.Min(a, at);
                b = Math.Min(b, bt + 1);
            }
            if (nums1[i] > nums2[i - 1] && nums2[i] > nums1[i - 1])
            {
                a = Math.Min(a, bt);
                b = Math.Min(b, at + 1);
            }
        }

        return Math.Min(a, b);
    }

    /// <summary>
    /// 804. Unique Morse Code Words
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public static int UniqueMorseRepresentations(string[] words)
    {
        string[] morse = new[]
        {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---",
            ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
        };
        var seen = new HashSet<string>();
        foreach (string word in words)
        {
            var code = new StringBuilder();
            foreach (char c in word)
            {
                code.Append(morse[c - 'a']);
            }

            seen.Add(code.ToString());
        }

        return seen.Count;
    }

    /// <summary>
    /// 806. Number of Lines To Write String
    /// </summary>
    /// <param name="widths"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int[] NumberOfLines(int[] widths, string s)
    {
        const int maxWidth = 100;
        int lines = 1, width = 0;
        foreach (int need in s.Select(t => widths[t - 'a']))
        {
            width += need;
            if (width <= maxWidth) continue;
            lines++;
            width = need;
        }

        return [lines, width];
    }

    /// <summary>
    /// 807. Max Increase to Keep City Skyline
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int MaxIncreaseKeepingSkyline(int[][] grid)
    {
        int n = grid.Length;
        int[] rowMax = new int[n];
        int[] colMax = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                rowMax[i] = Math.Max(rowMax[i], grid[i][j]);
                colMax[j] = Math.Max(colMax[j], grid[i][j]);
            }
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                ans += Math.Min(rowMax[i], colMax[j]) - grid[i][j];
            }
        }

        return ans;
    }

    /// <summary>
    /// 811. Subdomain Visit Count
    /// </summary>
    /// <param name="cpDomains"></param>
    /// <returns></returns>
    public static IList<string> SubdomainVisit(string[] cpDomains)
    {
        var counts = new Dictionary<string, int>();
        foreach (string cpDomain in cpDomains)
        {
            int space = cpDomain.IndexOf(' ');
            int count = int.Parse(cpDomain.Substring(0, space));
            string domain = cpDomain.Substring(space + 1);
            counts.TryAdd(domain, 0);

            counts[domain] += count;
            for (int i = 0; i < domain.Length; i++)
            {
                if (domain[i] != '.') continue;
                string subdomain = domain[(i + 1)..];
                counts.TryAdd(subdomain, 0);

                counts[subdomain] += count;
            }
        }

        return counts.Select(pair => pair.Value + " " + pair.Key).ToList();
    }

    /// <summary>
    /// 817. Linked List Components
    /// </summary>
    /// <param name="head"></param>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int NumComponents(ListNode head, int[] nums)
    {
        ISet<int> numsSet = new HashSet<int>();
        foreach (int num in nums)
        {
            numsSet.Add(num);
        }

        bool inSet = false;
        int res = 0;
        while (head is not null)
        {
            if (numsSet.Contains(head.Val))
            {
                if (!inSet)
                {
                    inSet = true;
                    res++;
                }
            }
            else
            {
                inSet = false;
            }

            head = head.Next;
        }

        return res;
    }

    /// <summary>
    /// 819. Most Common Word
    /// </summary>
    /// <param name="paragraph"></param>
    /// <param name="banned"></param>
    /// <returns></returns>
    public static string MostCommonWord(string paragraph, string[] banned)
    {
        var bannedSet = new HashSet<string>();
        foreach (string word in banned)
        {
            bannedSet.Add(word);
        }

        int maxFrequency = 0;
        var frequencies = new Dictionary<string, int>();
        var sb = new StringBuilder();
        int len = paragraph.Length;
        for (int i = 0; i <= len; i++)
        {
            if (i < len && char.IsLetter(paragraph[i]))
            {
                sb.Append(char.ToLower(paragraph[i]));
            }
            else if (sb.Length > 0)
            {
                string word = sb.ToString();
                if (!bannedSet.Contains(word))
                {
                    if (!frequencies.TryGetValue(word, out int value))
                    {
                        frequencies.Add(word, 1);
                    }
                    else
                    {
                        frequencies[word] = ++value;
                    }

                    maxFrequency = Math.Max(maxFrequency, frequencies[word]);
                }

                sb.Clear();
            }
        }

        string mostCommon = "";
        foreach ((string word, int frequency) in frequencies)
        {
            if (frequency != maxFrequency) continue;
            mostCommon = word;
            break;
        }

        return mostCommon;
    }

    /// <summary>
    /// 821. Shortest Distance to a Character
    /// </summary>
    /// <param name="s"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static int[] ShortestToChar(string s, char c)
    {
        int n = s.Length;
        int[] ans = new int[n];
        int prev = int.MinValue / 2;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == c)
            {
                prev = i;
            }

            ans[i] = i - prev;
        }

        prev = int.MaxValue / 2;
        for (int i = n - 1; i >= 0; i--)
        {
            if (s[i] == c)
            {
                prev = i;
            }

            ans[i] = Math.Min(ans[i], prev - i);
        }

        return ans;
    }

    /// <summary>
    /// 824. Goat Latin
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    public static string ToGoatLatin(string sentence)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        if (sentence.Length == 0)
        {
            return string.Empty;
        }

        var sb = new StringBuilder("a");
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (vowels.Contains(words[i][0]))
            {
                words[i] = words[i] + "ma" + sb;
            }
            else
            {
                words[i] = words[i][1..^0] + words[i][0] + "ma" + sb;
            }

            sb.Append('a');
        }

        return string.Join(" ", words);
    }

    /// <summary>
    /// 828. Count Unique Characters of All Substrings of a Given String
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int UniqueLetterString(string s)
    {
        var index = new Dictionary<char, IList<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (!index.TryGetValue(c, out IList<int> value))
            {
                value = new List<int> { -1 };
                index.Add(c, value);
            }

            value.Add(i);
        }

        int res = 0;
        foreach (IList<int> list in index.Select(pair => pair.Value))
        {
            list.Add(s.Length);
            for (int i = 1; i < list.Count - 1; i++)
            {
                res += (list[i] - list[i - 1]) * (list[i + 1] - list[i]);
            }
        }

        return res;
    }

    /// <summary>
    /// 838. Push Dominoes
    /// </summary>
    /// <param name="dominoes"></param>
    /// <returns></returns>
    public static string PushDominoes(string dominoes)
    {
        char[] s = dominoes.ToCharArray();
        int n = s.Length, i = 0;
        char left = 'L';
        while (i < n)
        {
            int j = i;
            while (j < n && s[j] == '.')
            {
                j++;
            }

            char right = j < n ? s[j] : 'R';
            if (left == right)
            {
                while (i < j)
                {
                    s[i++] = right;
                }
            }
            else if (left == 'R' && right == 'L')
            {
                int k = j - 1;
                while (i < k)
                {
                    s[i++] = 'R';
                    s[k--] = 'L';
                }
            }

            left = right;
            i = j + 1;
        }

        return new string(s);
    }

    /// <summary>
    /// 844. Backspace String Compare
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool BackspaceCompare(string s, string t)
    {
        int i = s.Length - 1, j = t.Length - 1;
        int skipS = 0, skipT = 0;
        while (i >= 0 || j >= 0)
        {
            while (i >= 0)
            {
                if (s[i] == '#')
                {
                    skipS++;
                    i--;
                }
                else if (skipS > 0)
                {
                    skipS--;
                    i--;
                }
                else
                {
                    break;
                }
            }

            while (j >= 0)
            {
                if (t[j] == '#')
                {
                    skipT++;
                    j--;
                }
                else if (skipT > 0)
                {
                    skipT--;
                    j--;
                }
                else
                {
                    break;
                }
            }

            if (i >= 0 && j >= 0)
            {
                if (s[i] != t[j])
                {
                    return false;
                }
            }
            else
            {
                if (i >= 0 || j >= 0)
                {
                    return false;
                }
            }

            i--;
            j--;
        }

        return true;
    }

    /// <summary>
    /// 846. Hand of Straights
    /// </summary>
    /// <param name="hand"></param>
    /// <param name="groupSize"></param>
    /// <returns></returns>
    public static bool IsNStraightHand(int[] hand, int groupSize)
    {
        int n = hand.Length;
        if (n % groupSize != 0)
        {
            return false;
        }

        Array.Sort(hand);
        var count = new Dictionary<int, int>();
        foreach (int x in hand)
        {
            count.TryAdd(x, 0);
            count[x]++;
        }

        foreach (int x in hand)
        {
            if (!count.ContainsKey(x))
            {
                continue;
            }

            for (int j = 0; j < groupSize; j++)
            {
                int num = x + j;
                if (!count.TryGetValue(num, out int value))
                {
                    return false;
                }

                count[num] = --value;
                if (value == 0)
                {
                    count.Remove(num);
                }
            }
        }

        return true;
    }

    /// <summary>
    /// 852. Peak Index in a Mountain Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int PeakIndexInMountainArray(int[] nums)
    {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            int mid = (l + r) / 2;
            if (nums[mid] < nums[mid + 1])
            {
                l = mid + 1;
            }
            else
            {
                r = mid;
            }
        }

        return l;
    }

    /// <summary>
    /// 856. Score of Parentheses
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int ScoreOfParentheses(string s)
    {
        int bal = 0, n = s.Length, res = 0;
        for (int i = 0; i < n; i++)
        {
            bal += (s[i] == '(' ? 1 : -1);
            if (s[i] == ')' && s[i - 1] == '(')
            {
                res += 1 << bal;
            }
        }

        return res;
    }

    /// <summary>
    /// 857. Minimum Cost to Hire K Workers
    /// </summary>
    /// <param name="quality"></param>
    /// <param name="wage"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static double MinCostToHireWorkers(int[] quality, int[] wage, int k)
    {
        int n = quality.Length;
        int[] hire = new int[n];
        for (int i = 0; i < n; i++)
        {
            hire[i] = i;
        }

        Array.Sort(hire, (a, b) => quality[b] * wage[a] - quality[a] * wage[b]);
        double res = 1e9;
        double totalQuality = 0.0d;
        var queue = new PriorityQueue<int, int>();
        for (int i = 0; i < k - 1; i++)
        {
            totalQuality += quality[hire[i]];
            queue.Enqueue(quality[hire[i]], -quality[hire[i]]);
        }

        for (int i = k - 1; i < n; i++)
        {
            int index = hire[i];
            totalQuality += quality[index];
            queue.Enqueue(quality[index], -quality[index]);
            double totalCost = ((double)wage[index] / quality[index]) * totalQuality;
            res = Math.Min(res, totalCost);
            totalQuality -= queue.Dequeue();
        }

        return res;
    }

    /// <summary>
    /// 870. Advantage Shuffle
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public static int[] AdvantageCount(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int[] index1 = new int[n];
        int[] index2 = new int[n];
        for (int i = 0; i < n; i++)
        {
            index1[i] = i;
            index2[i] = i;
        }
        Array.Sort(index1, (i, j) => nums1[i] - nums1[j]);
        Array.Sort(index2, (i, j) => nums2[i] - nums2[j]);

        int[] res = new int[n];
        int left = 0, right = n - 1;
        for (int i = 0; i < n; i++)
        {
            if (nums1[index1[i]] > nums2[index2[left]])
            {
                res[index2[left]] = nums1[index1[i]];
                left++;
            }
            else
            {
                res[index2[right]] = nums1[index1[i]];
                right--;
            }
        }

        return res;
    }

    /// <summary>
    /// 876. Middle of the Linked List
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static ListNode MiddleNode(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        while (fast?.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }

    /// <summary>
    /// 883. Projection Area of 3D Shapes
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int ProjectionArea(int[][] grid)
    {
        int ans = 0;
        for (int x = 0; x < grid.Length; x++)
        {
            int row = 0;
            int column = 0;
            for (int y = 0; y < grid[x].Length; y++)
            {
                if (grid[x][y] != 0)
                {
                    ans++;
                }

                row = Math.Max(row, grid[x][y]);
                column = Math.Max(column, grid[y][x]);
            }

            ans += row + column;
        }

        return ans;
    }

    /// <summary>
    /// 884. Uncommon Words from Two Sentences.
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static string[] UncommonFromSentences(string s1, string s2)
    {
        var dic = new Dictionary<string, int>();
        foreach (string word in s1.Split(' '))
        {
            if (dic.TryGetValue(word, out int value))
            {
                dic[word] = ++value;
            }
            else
            {
                dic[word] = 1;
            }
        }

        foreach (string word in s2.Split(' '))
        {
            if (dic.TryGetValue(word, out int value))
            {
                dic[word] = ++value;
            }
            else
            {
                dic[word] = 1;
            }
        }

        return (from word in dic where word.Value == 1 select word.Key).ToArray();
    }

    /// <summary>
    /// 886. Possible Bipartition
    /// </summary>
    /// <param name="n"></param>
    /// <param name="dislikes"></param>
    /// <returns></returns>
    public static bool PossibleBipartition(int n, int[][] dislikes)
    {
        int[] color = new int[n + 1];
        var group = new IList<int>[n + 1];
        for (int i = 0; i <= n; i++)
        {
            group[i] = new List<int>();
        }

        foreach (int[] p in dislikes)
        {
            group[p[0]].Add(p[1]);
            group[p[1]].Add(p[0]);
        }

        for (int i = 1; i <= n; i++)
        {
            if (color[i] == 0 && !Dfs(i, 1, color, group))
            {
                return false;
            }
        }

        return true;

        bool Dfs(int curr, int nowColor, int[] colors, IList<int>[] groups)
        {
            colors[curr] = nowColor;
            foreach (int next in groups[curr])
            {
                if (colors[next] != 0 && colors[next] == colors[curr])
                {
                    return false;
                }
                if (colors[next] == 0 && !Dfs(next, 3 ^ nowColor, colors, groups))
                {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// 892. Surface Area of 3D Shapes
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int SurfaceArea(int[][] grid)
    {
        int res = 0, n = grid.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] > 0)
                {
                    res += grid[i][j] * 4 + 2;
                }

                if (i > 0)
                {
                    res -= Math.Min(grid[i][j], grid[i - 1][j]) * 2;
                }

                if (j > 0)
                {
                    res -= Math.Min(grid[i][j], grid[i][j - 1]) * 2;
                }
            }
        }

        return res;
    }

    /// <summary>
    /// 893. Groups of Special-Equivalent Strings
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static int NumSpecialEquivGroups(string[] a)
    {
        var seen = new HashSet<string>();
        foreach (string s in a)
        {
            int[] count = new int[52];
            for (int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a' + 26 * (i % 2)]++;
            }

            seen.Add(string.Join(",", count));
        }

        return seen.Count;
    }

    /// <summary>
    /// 896. Monotonic Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns><c>true</c> if and only if the given array A is monotonic; otherwise, <c>false</c></returns>
    public static bool IsMonotonic(int[] nums)
    {
        int store = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            int c = nums[i].CompareTo(nums[i + 1]);
            if (c == 0)
            {
                continue;
            }

            if (c != store && store != 0)
            {
                return false;
            }

            store = c;
        }

        return true;
    }

    /// <summary>
    /// 904. Fruit Into Baskets
    /// </summary>
    /// <param name="fruits"></param>
    /// <returns></returns>
    public static int TotalFruit(int[] fruits)
    {
        int n = fruits.Length;
        var counter = new Dictionary<int, int>();
        int left = 0, res = 0;
        for (int right = 0; right < n; ++right)
        {
            counter.TryAdd(fruits[right], 0);
            ++counter[fruits[right]];
            while (counter.Count > 2)
            {
                --counter[fruits[left]];
                if (counter[fruits[left]] == 0)
                {
                    counter.Remove(fruits[left]);
                }
                ++left;
            }
            res = Math.Max(res, right - left + 1);
        }
        return res;
    }

    /// <summary>
    /// 905. Sort Array By Parity
    /// </summary>
    public static int[] SortArrayByParity(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            while (left < right && nums[left] % 2 == 0)
            {
                left++;
            }

            while (left < right && nums[right] % 2 == 1)
            {
                right--;
            }

            if (left < right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
        }

        return nums;
    }

    /// <summary>
    /// 908. Smallest Range I
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int SmallestRangeI(int[] nums, int k)
    {
        int min = nums.Min();
        int max = nums.Max();
        return max - min <= 2 * k ? 0 : max - min - 2 * k;
    }

    /// <summary>
    /// 915. Partition Array into Disjoint Intervals
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int PartitionDisjoint(int[] nums)
    {
        int n = nums.Length;
        int leftMax = nums[0], leftPos = 0, curr = nums[0];
        for (int i = 1; i < n - 1; i++)
        {
            curr = Math.Max(curr, nums[i]);
            if (nums[i] < leftMax)
            {
                leftMax = curr;
                leftPos = i;
            }
        }
        return leftPos + 1;
    }

    /// <summary>
    /// 917. Reverse Only Letters
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ReverseOnlyLetters(string s)
    {
        char[] letters = s.ToCharArray();
        int l = 0, r = s.Length - 1;
        while (true)
        {
            while (l < r && !char.IsLetter(s[l]))
            {
                l++;
            }

            while (r > l && !char.IsLetter(s[r]))
            {
                r--;
            }

            if (l >= r)
            {
                break;
            }

            //char tmp = letters[l];
            //letters[l] = letters[r];
            //letters[r] = tmp;
            Util.Swap(letters, l, r);
            l++;
            r--;
        }

        return new string(letters);
    }

    /// <summary>
    /// 921. Minimum Add to Make Parentheses Valid
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int MinAddToMakeValid(string s)
    {
        int res = 0, leftCount = 0;
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            if (c == '(')
            {
                leftCount++;
            }
            else
            {
                if (leftCount > 0)
                {
                    leftCount--;
                }
                else
                {
                    res++;
                }
            }
        }

        res += leftCount;
        return res;
    }

    /// <summary>
    /// 927. Three Equal Parts
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int[] ThreeEqualParts(int[] arr)
    {
        int sum = arr.Sum();
        if (sum % 3 != 0)
        {
            return [-1, -1];
        }

        if (sum == 0)
        {
            return [0, 2];
        }

        int partial = sum / 3;
        int first = 0, second = 0, third = 0, curr = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 1)
            {
                if (curr == 0)
                {
                    first = i;
                }
                else if (curr == partial)
                {
                    second = i;
                }
                else if (curr == 2 * partial)
                {
                    third = i;
                }

                curr++;
            }
        }

        int len = arr.Length - third;
        if (first + len <= second && second + len <= third)
        {
            int i = 0;
            while (third + i < arr.Length)
            {
                if (arr[first + i] != arr[second + i] || arr[first + i] != arr[third + i])
                {
                    return [-1, -1];
                }

                i++;
            }

            return [first + len - 1, second + len];
        }

        return [-1, -1];
    }

    /// <summary>
    /// 934. Shortest Bridge
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int ShortestBridge(int[][] grid)
    {
        int n = grid.Length;
        int[][] dirs = [[-1, 0], [1, 0], [0, 1], [0, -1]];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] != 1) continue;
                var queue = new Queue<(int, int)>();
                Dfs(i, j, grid, queue);
                int step = 0;
                while (queue.Count > 0)
                {
                    int size = queue.Count;
                    for (int k = 0; k < size; k++)
                    {
                        (int x, int y) = queue.Dequeue();
                        for (int d = 0; d < 4; d++)
                        {
                            int nx = x + dirs[d][0];
                            int ny = y + dirs[d][1];
                            if (nx >= 0 && ny >= 0 && nx < n && ny < n)
                            {
                                switch (grid[nx][ny])
                                {
                                    case 0:
                                        queue.Enqueue((nx, ny));
                                        grid[nx][ny] = -1;
                                        break;
                                    case 1:
                                        return step;
                                }
                            }
                        }
                    }
                    step++;
                }
            }
        }
        return 0;

        void Dfs(int x, int y, int[][] inputGrid, Queue<(int, int)> queue)
        {
            if (x < 0 || y < 0 || x >= inputGrid.Length || y >= inputGrid[0].Length || inputGrid[x][y] != 1)
            {
                return;
            }
            queue.Enqueue((x, y));
            inputGrid[x][y] = -1;
            Dfs(x - 1, y, inputGrid, queue);
            Dfs(x + 1, y, inputGrid, queue);
            Dfs(x, y - 1, inputGrid, queue);
            Dfs(x, y + 1, inputGrid, queue);
        }
    }

    /// <summary>
    /// 938. Range Sum of BST
    /// </summary>
    /// <param name="root"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static int RangeSumBst(TreeNode root, int left, int right)
    {
        // Recursive
        //int sum = 0;
        //if (root == null) return sum;
        //if (root.val > L)
        //    sum += RangeSumBST(root.left, L, R);
        //if (root.val < R)
        //    sum += RangeSumBST(root.right, L, R);
        //if (root.val >= L && root.val <= R)
        //    sum += root.val;
        //return sum;

        // Iterative
        int sum = 0;
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            TreeNode currentNode = stack.Pop();
            if (currentNode == null)
            {
                continue;
            }

            if (left <= currentNode.Val && currentNode.Val <= right)
            {
                sum += currentNode.Val;
            }

            if (left < currentNode.Val)
            {
                stack.Push(currentNode.Left);
            }

            if (currentNode.Val < right)
            {
                stack.Push(currentNode.Right);
            }
        }

        return sum;
    }

    public static int DistinctSubseqIi(string s)
    {
        const int mod = 1000000007;
        int[] alphas = new int[26];
        int n = s.Length, res = 0;
        for (int i = 0; i < n; i++)
        {
            int index = s[i] - 'a';
            int prev = alphas[index];
            alphas[index] = (res + 1) % mod;
            res = ((res + alphas[index] - prev) % mod + mod) % mod;
        }

        return res;
    }

    /// <summary>
    /// 942. DI String Match
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int[] DiStringMatch(string s)
    {
        int n = s.Length, lo = 0, hi = n;
        int[] perm = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            perm[i] = s[i] == 'I' ? lo++ : hi--;
        }

        perm[n] = lo;
        return perm;
    }

    /// <summary>
    /// 944. Delete Columns to Make Sorted
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public static int MinDeletionSize(string[] strs)
    {
        int row = strs.Length;
        int col = strs[0].Length;
        int ans = 0;
        for (int j = 0; j < col; j++)
        {
            for (int i = 1; i < row; i++)
            {
                if (strs[i - 1][j] <= strs[i][j]) continue;
                ans++;
                break;
            }
        }

        return ans;
    }

    /// <summary>
    /// 946. Validate Stack Sequences
    /// </summary>
    /// <param name="pushed"></param>
    /// <param name="popped"></param>
    /// <returns></returns>
    public static bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        var stack = new Stack<int>();
        int n = pushed.Length;
        for (int i = 0, j = 0; i < n; ++i)
        {
            stack.Push(pushed[i]);
            while (stack.Count > 0 && stack.Peek() == popped[j])
            {
                stack.Pop();
                ++j;
            }
        }

        return stack.Count == 0;
    }

    /// <summary>
    /// 953. Verifying an Alien Dictionary
    /// </summary>
    /// <param name="words"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    public static bool IsAlienSorted(string[] words, string order)
    {
        int[] index = new int[26];
        for (int i = 0; i < order.Length; ++i)
        {
            index[order[i] - 'a'] = i;
        }

        for (int i = 1; i < words.Length; ++i)
        {
            bool valid = false;
            for (int j = 0; j < words[i - 1].Length && j < words[i].Length; ++j)
            {
                int prev = index[words[i - 1][j] - 'a'];
                int curr = index[words[i][j] - 'a'];
                if (prev < curr)
                {
                    valid = true;
                    break;
                }
                else if (prev > curr)
                {
                    return false;
                }
            }

            if (valid) continue;
            if (words[i - 1].Length > words[i].Length)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 961. N-Repeated Element in Size 2N Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int RepeatedNTimes(int[] nums)
    {
        var found = new HashSet<int>();
        foreach (int num in nums)
        {
            if (!found.Add(num))
            {
                return num;
            }
        }

        return -1;
    }

    /// <summary>
    /// 976. Largest Perimeter Triangle
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);
        for (int i = nums.Length - 1; i >= 2; --i)
        {
            if (nums[i - 2] + nums[i - 1] > nums[i])
            {
                return nums[i - 2] + nums[i - 1] + nums[i];
            }
        }

        return 0;
    }

    /// <summary>
    /// 977. Squares of a Sorted Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int[] SortedSquares(int[] nums)
    {
        int len = nums.Length;
        int[] ans = new int[len];
        for (int i = 0, j = len - 1, pos = len - 1; i <= j;)
        {
            if (nums[i] * nums[i] > nums[j] * nums[j])
            {
                ans[pos] = nums[i] * nums[i];
                ++i;
            }
            else
            {
                ans[pos] = nums[j] * nums[j];
                --j;
            }

            --pos;
        }

        return ans;
    }

    /// <summary>
    /// 994. Rotting Oranges
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static int OrangeRotting(int[][] grid)
    {
        int[] dr = new[] { -1, 0, 1, 0 };
        int[] dc = new[] { 0, -1, 0, 1 };
        int rowLength = grid.Length, colLength = grid[0].Length;
        var queue = new Queue<int>();
        var depth = new Dictionary<int, int>();
        for (int row = 0; row < rowLength; ++row)
        {
            for (int col = 0; col < colLength; ++col)
            {
                if (grid[row][col] != 2)
                {
                    continue;
                }

                int code = row * colLength + col;
                queue.Enqueue(code);
                depth.Add(code, 0);
            }
        }

        int ans = 0;
        while (queue.Count != 0)
        {
            int code = queue.Dequeue();
            int row = code / colLength, col = code % colLength;
            for (int k = 0; k < 4; k++)
            {
                int nr = row + dr[k];
                int nc = col + dc[k];
                if (0 > nr || nr >= rowLength || 0 > nc || nc >= colLength || grid[nr][nc] != 1)
                {
                    continue;
                }

                grid[nr][nc] = 2;
                int nCode = nr * colLength + nc;
                queue.Enqueue(nCode);
                depth.Add(nCode, depth[code] + 1);
                ans = depth[nCode];
            }
        }

        if (grid.SelectMany(row => row).Any(v => v == 1))
        {
            return -1;
        }

        return ans;
    }

    /// <summary>
    /// 998. Maximum Binary Tree II
    /// </summary>
    /// <param name="root"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public static TreeNode InsertIntoMaxTree(TreeNode root, int val)
    {
        TreeNode parent = null;
        TreeNode curr = root;
        while (curr != null)
        {
            if (val > curr.Val)
            {
                if (parent is null)
                {
                    return new TreeNode(val, root);
                }

                var node = new TreeNode(val, curr);
                parent.Right = node;
                return root;
            }

            parent = curr;
            curr = curr.Right;
        }

        parent!.Right = new TreeNode(val);
        return root;
    }
}
