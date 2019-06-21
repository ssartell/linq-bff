<Query Kind="Statements" />

// less code, but hard to understand
Enumerable.Range(2, 100).Where(i => Enumerable.Range(2, i / 4).All(e => i % e != 0)).Dump();


// more code, but easier to understand
bool IsDivisorOf(int x, int y) => x % y == 0;

bool IsPrime(int x) {
	return Enumerable.Range(2, x / 4)
		.All(y => !IsDivisorOf(x, y));
}

Enumerable.Range(2, 100)
	.Where(IsPrime)
	.Dump();