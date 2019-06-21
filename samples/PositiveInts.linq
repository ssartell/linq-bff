<Query Kind="Statements" />

IEnumerable<int> PositiveInts()
{
	var i = 1;
	while(true)
		yield return i++;
}

var numbers = PositiveInts();
var fiveNumbers = numbers.Take(5);
fiveNumbers.Dump(); // => [1, 2, 3, 4, 5]