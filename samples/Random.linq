<Query Kind="Statements" />

IEnumerable<int> Random(int min, int max) 
{
	var rand = new Random();
	
	while(true)
		yield return rand.Next(min, max);
}

Random(0, 10).Take(5).Dump();