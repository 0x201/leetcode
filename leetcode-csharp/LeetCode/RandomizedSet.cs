// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class RandomizedSet
{
    private List<int> Nums { get; } = [];

    private Dictionary<int, int> Indices { get; } = new();

    private Random Random { get; } = new();

    public bool Insert(int val)
    {
        if (Indices.ContainsKey(val))
        {
            return false;
        }
        Indices.Add(val, Nums.Count);
        Nums.Add(val);
        return true;
    }

    public bool Remove(int val)
    {
        if (!Indices.TryGetValue(val, out int index))
        {
            return false;
        }

        int last = Nums.Last();
        Nums[index] = last;
        Indices[last] = index;
        Nums.RemoveAt(Nums.Count - 1);
        Indices.Remove(val);
        return true;
    }

    public int GetRandom()
    {
        return Nums[Random.Next(Nums.Count)];
    }

}
