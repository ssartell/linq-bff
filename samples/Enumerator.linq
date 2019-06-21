<Query Kind="Statements" />

var ints = Enumerable.Range(1, 3);
ints.Dump();

var e = ints.GetEnumerator();
e.Current.Dump();
e.MoveNext().Dump();
e.Current.Dump();
e.MoveNext().Dump();
e.Current.Dump();
e.MoveNext().Dump();
e.Current.Dump();
e.MoveNext().Dump();
e.Current.Dump();
e.MoveNext().Dump();