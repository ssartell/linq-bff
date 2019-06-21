<Query Kind="Statements" />

// C# aggregate === JS reduce

// (state, action) => state
(int, int) Reducer((int Min, int Max) prevState, int action)
{
	return (Math.Min(prevState.Min, action), Math.Max(prevState.Max, action));
}

var actions = Enumerable.Range(0, 100);
var initState = (Min: int.MaxValue, Max: int.MinValue);

var state = actions.Aggregate(initState, Reducer);
state.Dump();