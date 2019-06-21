<Query Kind="Statements" />

public static class Extensions
{
	public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int n)
	{
		var remainder = source;
		while (remainder.Any()) {
			yield return remainder.Take(n);
			remainder = remainder.Skip(n);
		}
	}
}


Enumerable.Range(0, 7).Batch(3).Dump();