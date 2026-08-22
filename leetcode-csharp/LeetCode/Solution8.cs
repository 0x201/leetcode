// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace LeetCode;

public partial class Solution
{
    /// <summary>
    /// 1403. Minimum Subsequence in Non-Increasing Order
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static IList<int> MinSubsequence(int[] nums)
    {
        Array.Sort(nums);
        int total = nums.Sum();
        IList<int> ans = new List<int>();
        int curr = 0;
        for (int i = nums.Length - 1; i >= 0; --i)
        {
            curr += nums[i];
            ans.Add(nums[i]);
            if (total - curr < curr)
            {
                break;
            }
        }

        return ans;
    }

    /// <summary>
    /// 1408. String Matching in an Array
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public static IList<string> StringMatching(string[] words)
    {
        return words
            .Where((t1, i) => words
                .Where((t, j) => i != j && t.Contains(t1)).Any())
            .ToList();
    }

    /// <summary>
    /// 1417. Reformat The String
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string Reformat(string s)
    {
        int sumDigit = s.Count(char.IsDigit);

        int sumAlpha = s.Length - sumDigit;
        if (Math.Abs(sumDigit - sumAlpha) > 1)
        {
            return string.Empty;
        }

        bool flag = sumDigit > sumAlpha;
        char[] arr = s.ToCharArray();
        for (int i = 0, j = 1; i < arr.Length; i += 2)
        {
            if (char.IsDigit(arr[i]) == flag) continue;
            while (char.IsDigit(arr[j]) != flag)
            {
                j += 2;
            }

            (arr[i], arr[j]) = (arr[j], arr[i]);
        }

        return new string(arr);
    }

    /// <summary>
    /// 1441. Build an Array With Stack Operations
    /// </summary>
    /// <param name="target"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IList<string> BuildArray(int[] target, int n)
    {
        IList<string> res = new List<string>();
        int prev = 0;
        foreach (int number in target)
        {
            for (int i = 0; i < number - prev - 1; i++)
            {
                res.Add("Push");
                res.Add("Pop");
            }
            res.Add("Push");
            prev = number;
        }

        return res;
    }

    /// <summary>
    /// 1447. Simplified Fractions
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IList<string> SimplifiedFractions(int n)
    {
        IList<string> res = new List<string>();
        for (int denominator = 2; denominator <= n; ++denominator)
        {
            for (int numerator = 1; numerator < denominator; ++numerator)
            {
                if (Gcd(numerator, denominator) == 1)
                {
                    res.Add(numerator + "/" + denominator);
                }
            }
        }

        return res;

        int Gcd(int a, int b)
        {
            return b != 0 ? Gcd(b, a % b) : a;
        }
    }

    /// <summary>
    /// 1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence
    /// </summary>
    /// <param name="sentence"></param>
    /// <param name="searchWord"></param>
    /// <returns></returns>
    public static int IsPrefixOfWord(string sentence, string searchWord)
    {
        int n = sentence.Length, index = 1, start = 0, end = 0;
        while (start < n)
        {
            while (end < n && sentence[end] != ' ')
            {
                end++;
            }

            if (IsPrefix(sentence, start, end, searchWord))
            {
                return index;
            }

            index++;
            end++;
            start = end;
        }

        return -1;

        bool IsPrefix(string input, int startIndex, int endIndex, string target)
        {
            return !target
                .Where((t, i) => startIndex + i >= endIndex || input[startIndex + i] != t)
                .Any();
        }
    }

    /// <summary>
    /// 1470. Shuffle the Array
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int[] Shuffle(int[] nums, int n)
    {
        int[] res = new int[n * 2];
        for (int i = 0; i < n; ++i)
        {
            res[2 * i] = nums[i];
            res[2 * i + 1] = nums[i + n];
        }

        return res;
    }

    /// <summary>
    /// 1475. Final Prices With a Special Discount in a Shop
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public static int[] FinalPrices(int[] prices)
    {
        int n = prices.Length;
        int[] res = new int[n];
        var stack = new Stack<int>();
        for (int i = n - 1; i >= 0; --i)
        {
            while (stack.Count > 0 && stack.Peek() > prices[i])
            {
                stack.Pop();
            }

            res[i] = stack.Count == 0 ? prices[i] : prices[i] - stack.Peek();
            stack.Push(prices[i]);
        }

        return res;
    }

    /// <summary>
    /// 1486. XOR Operation in an Array.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="start"></param>
    /// <returns></returns>
    public static int XorOperation(int n, int start)
    {
        // (sumXor(s - 1) ^ sumXor(s + n - 1)) * 2 + e; s = start/2, e = (0 || 1)
        int s = start >> 1;
        int e = n & start & 1;
        int res = SumXor(s - 1) ^ SumXor(s + n - 1);
        return res << 1 | e;

        int SumXor(int num)
        {
            return (num % 4) switch
            {
                0 => num,
                1 => 1,
                2 => num + 1,
                _ => 0
            };
        }
    }

    /// <summary>
    /// 1491. Average Salary Excluding the Minimum and Maximum Salary
    /// </summary>
    /// <param name="salary"></param>
    /// <returns></returns>
    public static double Average(int[] salary)
    {
        int min = int.MaxValue, max = int.MinValue;
        int sum = 0;
        foreach (int item in salary)
        {
            sum += item;
            max = Math.Max(max, item);
            min = Math.Min(min, item);
        }

        return (sum - max - min) / (salary.Length - 2);
    }

    /// <summary>
    /// 1523. Count Odd Numbers in an Interval Range
    /// </summary>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <returns></returns>
    public static int CountOdds(int low, int high)
    {
        return PreSum(high) - PreSum(low - 1);

        int PreSum(int num)
        {
            return (num + 1) >> 1;
        }
    }

    /// <summary>
    /// 1582. Special Positions in a Binary Matrix
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public static int NumSpecial(int[][] mat)
    {
        int row = mat.Length, col = mat[0].Length;
        for (int i = 0; i < row; i++)
        {
            int count = 0;
            for (int j = 0; j < col; j++)
            {
                if (mat[i][j] == 1)
                {
                    count++;
                }
            }

            if (i == 0)
            {
                count--;
            }

            if (count <= 0) continue;

            for (int j = 0; j < col; j++)
            {
                if (mat[i][j] == 1)
                {
                    mat[0][j] += count;
                }
            }
        }

        return mat[0].Count(item => item == 1);
    }

    /// <summary>
    /// 1592. Rearrange Spaces Between Words
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ReorderSpaces(string text)
    {
        int n = text.Length;
        int whitespaceCount = n;
        string[] words = text.Trim().Split(" ");
        int wordCount = 0;
        foreach (string word in words)
        {
            if (word.Length <= 0) continue;
            whitespaceCount -= word.Length;
            wordCount++;
        }

        var sb = new StringBuilder();
        if (words.Length == 1)
        {
            sb.Append(words[0]);
            for (int i = 0; i < whitespaceCount; ++i)
            {
                sb.Append(' ');
            }

            return sb.ToString();
        }

        int spacePerCount = whitespaceCount / (wordCount - 1);
        int restSpaceCount = whitespaceCount % (wordCount - 1);
        foreach (string t in words)
        {
            if (t.Length == 0)
            {
                continue;
            }

            if (sb.Length > 0)
            {
                for (int j = 0; j < spacePerCount; ++j)
                {
                    sb.Append(' ');
                }
            }

            sb.Append(t);
        }

        for (int i = 0; i < restSpaceCount; ++i)
        {
            sb.Append(' ');
        }

        return sb.ToString();
    }

    /// <summary>
    /// 1598. Crawler Log Folder
    /// </summary>
    /// <param name="logs"></param>
    /// <returns></returns>
    public static int MinOperations(string[] logs)
    {
        int depth = 0;
        foreach (string log in logs)
        {
            switch (log)
            {
                case "./":
                    continue;
                case "../":
                    {
                        if (depth > 0)
                        {
                            depth--;
                        }

                        break;
                    }
                default:
                    depth++;
                    break;
            }
        }

        return depth;
    }
}
