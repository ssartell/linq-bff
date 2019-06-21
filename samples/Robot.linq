<Query Kind="Statements" />

var input = "R2 L4 L2 L4";
var moves = new [] { (x: 0, y: 1), (x: 1, y: 0), (x: 0, y: -1), (x: -1, y: 0) };

(string dir, int dist) ParseMove(string x) {
	return (x[0].ToString(), int.Parse(x.Substring(1)));
}

(int x, int y, int dir) ApplyMove((int x, int y, int dir) pos, (string turn, int dist) move) {
	var dir = (pos.dir + (move.turn == "R" ? 1 : -1) + 4) % 4;
	return (x: pos.x + moves[dir].x * move.dist, 
			y: pos.y + moves[dir].y * move.dist, 
			dir: dir);
}

var end = input
	.Split(' ')
	.Select(ParseMove)
	.Aggregate((x: 0, y: 0, dir: 3), ApplyMove)
	.Dump();