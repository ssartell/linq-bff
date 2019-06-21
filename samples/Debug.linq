<Query Kind="Statements" />

public static class Extensions
{
    public static T Debug<T>(this T value)
    {
        // set a breakpoint here or console write
        return value;
    }
}

Enumerable.Range(0, 10).Debug().Select(x => x.Debug()).Dump();