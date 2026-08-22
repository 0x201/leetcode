// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;
public class MyCircularQueue
{
  private int _front;
  private int _rear;
  private readonly int _capacity;
  private readonly int[] _elements;

  public MyCircularQueue(int k)
  {
    _capacity = k + 1;
    _elements = new int[_capacity];
    _rear = _front = 0;
  }

  public bool EnQueue(int value)
  {
    if (IsFull())
    {
      return false;
    }
    _elements[_rear] = value;
    _rear = (_rear + 1) % _capacity;
    return true;
  }

  public bool DeQueue()
  {
    if (IsEmpty())
    {
      return false;
    }
    _front = (_front + 1) % _capacity;
    return true;
  }

  public int Front() => IsEmpty() ? -1 : _elements[_front];

  public int Rear() => IsEmpty() ? -1 : _elements[((_rear - 1) + _capacity) % _capacity];

  public bool IsFull() => ((_rear + 1) % _capacity) == _front;

  private bool IsEmpty() => _rear == _front;

}
