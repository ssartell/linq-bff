<Query Kind="Statements" />

IEnumerable<bool> True()
{
	yield return true;
}

public static class EnumerableExtentions {
	public static IEnumerable<T> Debug<T>(this IEnumerable<T> source) {
		return source;
	}

	public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, IEnumerable<IEnumerable<T>> seconds)
	{
		foreach(var t in source)
			yield return t;
			
		foreach(var second in seconds)
			foreach(var t in second)
				yield return t;
	}
	
	public static IEnumerable<T2> SelectWithLast<T1, T2>(this IEnumerable<T1> source, T2 seed, Func<T2, T1, T2> predicate) 
	{
		T2 t2 = seed;
		foreach(var t1 in source)
		{
			t2 = predicate(t2, t1);
			yield return t2;
		}
	}
}