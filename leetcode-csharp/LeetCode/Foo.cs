// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class Foo
{
    private readonly SemaphoreSlim _firstSemaphore = new(0, 1);
    private readonly SemaphoreSlim _secondSemaphore = new(0, 1);
    
    public void First(Action printFirst)
    {
        printFirst();
        _firstSemaphore.Release();
    }

    public void Second(Action printSecond)
    {
        _firstSemaphore.Wait();
        printSecond();
        _secondSemaphore.Release();
    }

    public void Third(Action printThird)
    {
        _secondSemaphore.Wait();
        printThird();
    }
}