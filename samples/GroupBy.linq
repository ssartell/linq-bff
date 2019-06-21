<Query Kind="Statements" />

var Books = new [] {
	new { Author = "N. K. Jemison", Title = "The Fifth Season", Pages = 512 },
	new { Author = "Orson Scott Card", Title = "Speaker of the Dead", Pages = 415 },
	new { Author = "N. K. Jemison", Title = "The Obelisk Gate", Pages = 433 },
	new { Author = "Orson Scott Card", Title = "Ender's Game", Pages = 324 },
	new { Author = "N. K. Jemison", Title = "The Stone Sky", Pages = 464 },
};

var authorWithMostBooks = Books
	.GroupBy(book => book.Author)
	.OrderByDescending(x => x.Count())
	.First()
	.Key
	.Dump();