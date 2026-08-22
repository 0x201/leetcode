namespace LeetCode;

public class ZeroEvenOdd(int count)
{
    private int Count { get; } = count;
    private readonly SemaphoreSlim _zeroSemaphore = new(1, 1);
    private readonly SemaphoreSlim _evenSemaphore = new(0, 1);
    private readonly SemaphoreSlim _oddSemaphore = new(0, 1);

    public void Zero(Action<int> printNumber)
    {
        for (int i = 1; i <= Count; i++)
        {
            _zeroSemaphore.Wait();
            printNumber(0);
            if (i % 2 == 0)
            {
                _evenSemaphore.Release();
            }
            else
            {
                _oddSemaphore.Release();
            }
        }
    }

    public void Even(Action<int> printNumber)
    {
        for (int i = 2; i <= Count; i += 2)
        {
            _evenSemaphore.Wait();
            printNumber(i);
            _zeroSemaphore.Release();
        }
    }

    public void Odd(Action<int> printNumber)
    {
        for (int i = 1; i <= Count; i += 2)
        {
            _oddSemaphore.Wait();
            printNumber(i);
            _zeroSemaphore.Release();
        }
    }
}
