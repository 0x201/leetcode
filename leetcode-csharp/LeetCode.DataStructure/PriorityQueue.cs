// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode.DataStructure;

public class PriorityQueue<T> where T : IComparable, IComparable<T>
{
    private SortedSet<T> Values { get; }

    /// <summary>
    /// Default constructor
    /// </summary>
    public PriorityQueue()
    {
        Values = [];
    }

    public PriorityQueue(IComparer<T> comparer)
    {
        Values = new SortedSet<T>(comparer);
    }

    /// <summary>
    /// Constructor with an IEnumerable parameter
    /// </summary>
    /// <param name="elements"></param>
    public PriorityQueue(IEnumerable<T> elements)
    {
        Values = [..elements];
    }

    /// <summary>
    /// Constructor with a custom comparer and IEnumerable parameters
    /// </summary>
    /// <param name="comparer"></param>
    /// <param name="elements"></param>
    public PriorityQueue(IEnumerable<T> elements, IComparer<T> comparer)
    {
        Values = new SortedSet<T>(elements, comparer);
    }

    /// <summary>
    /// Gets the number of elements in the PriorityQueue.
    /// </summary>
    public int Count => Values.Count;

    /// <summary>
    /// Returns the top element in the PriorityQueue.
    /// </summary>
    /// <returns></returns>
    public T Top()
    {
        return Values.Max;
    }

    /// <summary>
    /// Remove the element on top of the PriorityQueue.
    /// </summary>
    public bool Pop() => Values.Remove(Values.Max);

    /// <summary>
    /// Inserts a new element to the PriorityQueue.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>true if successfully, false otherwise</returns>
    public bool Push(T value) => Values.Add(value);

    /// <summary>
    /// Returns whether the queue is empty.
    /// </summary>
    /// <returns>true if the queue's size is 0, false otherwise</returns>
    public bool IsEmpty() => Values.Count == 0;

    /// <summary>
    /// Returns a List from a priority queue.
    /// </summary>
    /// <returns></returns>
    public List<T> ToList() => [..Values];
}