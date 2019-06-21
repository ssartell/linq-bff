<Query Kind="Statements" />

public static class FuncExtensions
{
	public static Func<T1, T3> Then<T1, T2, T3>(this Func<T1, T2> f1, Func<T2, T3> f2)
	{
		return x => f2(f1(x));
	}

	public static Func<T1, T2, T4> Then<T1, T2, T3, T4>(this Func<T1, T2, T3> f1, Func<T3, T4> f2)
	{
		return (x, y) => f2(f1(x, y));
	}
}

Func<int, int, int> Add = (a, b) => a + b;
Func<int, bool> IsEven = x => x % 2 == 0;
Func<bool, bool> Not = x => !x;

var sumIsOdd = Add
	.Then(IsEven)
	.Then(Not);

sumIsOdd(1, 0).Dump();