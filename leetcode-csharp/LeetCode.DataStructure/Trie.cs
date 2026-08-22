// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.DataStructure;

/// <summary>
/// Dictionary Tree class
/// </summary>
public class Trie
{
    TrieNode Root { get; } = new();

    public void Insert(string word)
    {
        TrieNode node = Root;
        foreach (char currentChar in word)
        {
            if (!node.ContainsKey(currentChar))
            {
                node.Put(currentChar, new TrieNode());
            }

            node = node.Get(currentChar);
        }

        node.IsEnd = true;
    }


    public bool Search(string word)
    {
        TrieNode node = SearchPrefix(word);
        return node is { IsEnd: true };
    }

    private TrieNode SearchPrefix(string word)
    {
        TrieNode node = Root;
        foreach (char currLetter in word)
        {
            if (node.ContainsKey(currLetter))
                node = node.Get(currLetter);
            else
                return null;
        }

        return node;
    }

    public bool StartWith(string prefix)
    {
        TrieNode node = SearchPrefix(prefix);
        return node != null;
    }
}

/// <summary>
/// Trie Node
/// </summary>
public class TrieNode
{
    public string Word { get; set; }
    public TrieNode[] Links { get; } = new TrieNode[R];

    // a-z lowercase
    private static readonly int R = 26;

    public bool IsEnd { get; set; }

    public bool ContainsKey(char ch)
    {
        return Links[ch - 'a'] != null;
    }

    public TrieNode Get(char ch)
    {
        return Links[ch - 'a'];
    }

    public void Put(char ch, TrieNode node)
    {
        Links[ch - 'a'] = node;
    }
}