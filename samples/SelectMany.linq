<Query Kind="Statements" />

Enumerable.Range(0, 10)
	.Select(x => x * 10)
	.SelectMany(x => new[] { x + 3, x + 7 })
	.Dump();