// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class Codec
{
    /// <summary>
    /// Encode a tree to single string.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public string Serialize(TreeNode root)
    {
        List<int> list = [];
        PostOrder(root, list);
        return string.Join(",", list);
    }
    public TreeNode Deserialize(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }
        string[] numbers = data.Split(',');
        var stack = new Stack<int>();
        foreach (string number in numbers)
        {
            if (int.TryParse(number, out int num))
            {
                stack.Push(num);
            }
            else
            {
                throw new ArgumentException("Invalid serialized data format");
            }
        }
        return Build(int.MinValue, int.MaxValue, stack);
    }

    private void PostOrder(TreeNode root, List<int> list)
    {
        if (root is null)
        {
            return;
        }
        PostOrder(root.Left, list);
        PostOrder(root.Right, list);
        list.Add(root.Val);
    }

    private TreeNode Build(int lower, int upper, Stack<int> stack)
    {
        if (stack.Count == 0 || stack.Peek() < lower || stack.Peek() > upper)
        {
            return null;
        }
        int val = stack.Pop();
        var root = new TreeNode(val)
        {
            Right = Build(val, upper, stack),
            Left = Build(lower, val, stack)
        };
        return root;
    }
}
