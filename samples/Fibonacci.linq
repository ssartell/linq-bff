<Query Kind="Statements" />

IEnumerable<int> Fibonacci()
{
	var (a, b) = (0, 1);
	yield return a;

	while (true)
	{
		yield return b;
		(a, b) = (b, a + b);
	}
}

Fibonacci().First(x => x > 100).Dump();