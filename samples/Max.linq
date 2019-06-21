<Query Kind="Statements" />

var values = Enumerable.Range(0, 100);

// with a foreach
var max = int.MinValue;
foreach (var x in values)
{
	max = Math.Max(max, x);
}
max.Dump();



// (prevAccumulator, element) => nextAccumulator
values.Aggregate(int.MinValue, (a, x) => Math.Max(a, x)).Dump();



// without a seed, with method group
Enumerable.Range(0, 100).Aggregate(Math.Max).Dump();