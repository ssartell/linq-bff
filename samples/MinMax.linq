<Query Kind="Statements" />

(int, int) MinAndMax((int Min, int Max) a, int x)
{
	return (Math.Min(a.Min, x), Math.Max(a.Max, x));
}

Enumerable.Range(0, 100).Aggregate((int.MaxValue, int.MinValue), MinAndMax).Dump();