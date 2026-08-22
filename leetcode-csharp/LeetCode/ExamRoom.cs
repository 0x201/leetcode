// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class ExamRoomComparer : IComparer<(int first, int second)>
{
    public int Compare((int first, int second) x, (int first, int second) y)
    {
        int d1 = x.second - x.first, d2 = y.second - y.first;
        return d1 / 2 < d2 / 2 || (d1 / 2 == d2 / 2 && x.first > y.first) ? 1 : -1;
    }
}

public class ExamRoom(int n)
{
    private PriorityQueue<(int first, int second), (int first, int second)> Queue { get; } = new(new ExamRoomComparer());

    private SortedSet<int> Seats { get; } = [];

    private int N { get; } = n;

    public int Seat()
    {
        if (Seats.Count == 0)
        {
            Seats.Add(0);
            return 0;
        }

        int left = Seats.Min, right = N - 1 - Seats.Max;
        while (Seats.Count >= 2)
        {
            (int first, int second) = Queue.Peek();
            if (Seats.Contains(first) && Seats.Contains(second)
                                        && Seats.GetViewBetween(first + 1, Seats.Max).Min == second)
            {
                int distance = second - first;
                int mid = first + distance / 2;
                if (distance / 2 < right || distance / 2 <= left)
                {
                    break;
                }

                Queue.Dequeue();
                Queue.Enqueue((first, mid), (first, mid));
                Queue.Enqueue((mid, second), (mid, second));
                Seats.Add(mid);
                return mid;
            }

            Queue.Dequeue();
        }

        if (right > left)
        {
            Queue.Enqueue((Seats.Max, N - 1), (Seats.Max, N - 1));
            Seats.Add(N - 1);
            return N - 1;
        }

        Queue.Enqueue((0, Seats.Min), (0, Seats.Min));
        Seats.Add(0);
        return 0;
    }

    public void Leave(int p)
    {
        if (p != Seats.Max && p != Seats.Min)
        {
            int prev = Seats.GetViewBetween(Seats.Min, p - 1).Max;
            int next = Seats.GetViewBetween(p + 1, Seats.Max).Min;
            Queue.Enqueue((prev, next), (prev, next));
        }

        Seats.Remove(p);
    }
}
