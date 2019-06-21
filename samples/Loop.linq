<Query Kind="Statements" />

public static class Extensions
{
	public static IEnumerable<T> Loop<T>(this IEnumerable<T> source)
	{
		while (true)
			foreach (var t in source)
				yield return t;
	}
}

Enumerable.Range(1, 3).Loop().Take(10).Dump();