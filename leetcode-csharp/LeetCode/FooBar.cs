namespace LeetCode;

public class FooBar(int count)
{
    private int Count { get; } = count;
    private readonly AutoResetEvent _foo = new(true);
    private readonly AutoResetEvent _bar = new(false);

    public void Foo(Action printFoo)
    {
        for (int i = 0; i < Count; i++)
        {
            _foo.WaitOne();
            printFoo();
            _bar.Set();
        }
    }

    public void Bar(Action printBar)
    {
        for (int i = 0; i < Count; i++)
        {
            _bar.WaitOne();
            printBar();
            _foo.Set();
        }
    }
}
