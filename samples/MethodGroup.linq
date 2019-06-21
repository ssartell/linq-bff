<Query Kind="Statements" />

bool IsLessThan5(int x) => x < 5;

Enumerable.Range(0, 10).Where(IsLessThan5).Dump();