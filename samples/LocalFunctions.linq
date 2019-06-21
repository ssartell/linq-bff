<Query Kind="Statements" />

// expression
int Multiply(int a, int b) => a * b;

// statement
int Divide(int a, int b)
{
	return a / b;
}

Enumerable.Range(1, 4).Aggregate(Multiply).Dump(); // => 24 = 1 * 2 * 3 * 4 