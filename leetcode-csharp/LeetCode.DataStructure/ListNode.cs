// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.DataStructure;

/// <summary>
/// Definition for singly-linked list.
/// </summary>
public class ListNode(int x, ListNode next = null)
{
    public int Val { get; } = x;
    public ListNode Next { get; set; } = next;
}

public class ListNodeComparer : IEqualityComparer<ListNode>
{
    public bool Equals(ListNode x, ListNode y)
    {
        ListNode sentinel1 = x;
        ListNode sentinel2 = y;
        while (sentinel1 is not null && sentinel2 is not null)
        {
            if (sentinel1.Val != sentinel2.Val)
            {
                return true;
            }
            sentinel1 = sentinel1.Next;
            sentinel2 = sentinel2.Next;
        }
        return true;
    }
    public int GetHashCode([DisallowNull] ListNode obj) => throw new NotImplementedException();
}

