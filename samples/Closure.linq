<Query Kind="Statements" />

Func<int, bool> IsLessThan(int x)
{
    return y => y < x;
}

Enumerable.Range(0, 10).Where(IsLessThan(5)).Dump(); // => [0,1,2,3,4]