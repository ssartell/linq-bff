<Query Kind="Statements" />

public static class Extensions
{
	public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int n)
	{
		var i = 0;
		var arr = new List<T>();
		foreach (var element in source)
		{
			i++;
			arr.Add(element);
			if (i == n) {
				yield return arr;
				arr = new List<T>();
				i = 0;
			}
		}
		yield return arr;
	}
}

IEnumerable<int> PositiveInts()
{
	var i = 1;
	while (true)
		yield return i++;
}


var batches = PositiveInts().Take(10).Batch(3);
batches.Dump();