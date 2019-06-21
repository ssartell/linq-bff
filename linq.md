# LINQ

---

## `IEnumerable<T>`
Exposes an enumerator via `.GetEnumerator()`, which supports a simple iteration over a collection of a specified type.
- Can be iterated through with a `foreach`
- Examples include arrays, lists, dictionaries, sets, queues, stacks, etc.
- No defined length, can be finite or infinite 
- Elements may or may not be in memory

---

## What is LINQ?
A set of methods and syntax that enable the traversal, filtering, and projection of enumerables.

```cs
// basic example
var authorsFromThisYear = Books
    .Where(x => x.PublishedYear >= 2019)
    .Select(x => x.Author)
    .Distinct();
```

- Initial release in 2007 (12 years old)
- Cuts down on boilerplate code
- Helps express intent
- Chainable because many methods return IEnumerable
- Immutable
- Lazy

---

### Flavors of LINQ
- **LINQ to objects**
- Entity Framework
- Other LINQ providers

---

## LINQPad
Playground application for tinkering with C#.
![image](https://www.linqpad.net/images/maincodescratchpad.png)
- Instead of console apps to test snippets of code
- Can run any C#, not just LINQ
- `.Dump()` console writes value (and returns value)

---

## Syntax: Method vs. Query
> **[Microsoft](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)**: "As a rule when you write LINQ queries, we recommend that you use query syntax whenever possible and method syntax whenever necessary. There is no semantic or performance difference between the two different forms. Query expressions are often more readable than equivalent expressions written in method syntax."

> **Sean**: Uh, no.

---

### Method Syntax

```cs
var normalPeopleNames = people
    .Where(p => p.UsesMethodSyntax)
    .Select(p => p.Name);
```

- Built as extension methods on `IEnumerable<T>`
- Naturally chainable
- Easy to extend

---

### Query Syntax

```cs
var weirdPeopleNames = from p in people
                       where p.UsesQuerySyntax
                       select p.Name;
```

- Unique syntax just for LINQ
- Not extensible

---

## Lambdas
Anonymous function that are treated as objects.

```cs
// expression lambda
Func<int, int, int> add = (a, b) => a + b;

// statement lambda
Func<int, int, int> subtract = (a, b) => {
    return a - b;
};

// example usage
Enumerable.Range(0, 10).Where(x => x < 5).Dump(); // => [0,1,2,3,4]
```

- Can be defined inline
- Passed around the same as any other object
- Expression lambdas are better when short
- Statement lambdas are easier to debug

---

## Local Functions

```cs
// expression
int Multiply(int a, int b) => a * b;

// statement
int Divide(int a, int b)
{
    return a / b;
}

// example usage
Enumerable.Range(1, 4).Aggregate(Multiply).Dump(); // => 24 = 1 * 2 * 3 * 4 
```

- Must be named
- Cannot be defined inline
- Clearer parameter and return types
- Easier recursion

---

## LINQ Methods

---

## Where
`IEnumerable<T> Where<T>(Func<T, bool> predicate)`

Filters an enumerable using some conditional applied to each element.

```cs
// I like large fantasy books
IEnumerable<Book> booksToRead = Books
    .Where(book => book.PageCount >= 1000 && book.Genre == "Fantasy");
```

---

## Select
`IEnumerable<TResult> Where<T, TResult>(Func<T, TResult> selector)`

Transforms each item in an enumberable using the selector provided.

```cs
IEnumerable<int> publishedYears = Books
    .Select(book => book.PublishedYear);
```

---

## Finding an Element
- First / FirstOrDefault
- Single / SingleOrDefault
- Last / LastOrDefault

`T First([Func<T, bool> predicate])`

Returns a single element from the enumerable, using an optional filter.

*OrDefault* versions return the default value of the type if the enumerable is empty or no elements match the predicate.

```cs
// errors if none match
Book firstBookOf2019 = Books.First(book => book.PublishedDate >= 2019);

// null if none match, errors if multiple books match
Book fifthSeasonBook = Books
    .SingleOrDefault(book => book.Title == "The Fifth Season");
```

---

## Count
`int Count<T>([Func<T, bool> predicate])`

Returns the number of elements in the enumerable that optionally matches the predicate.

```cs
int booksCount = Books.Count();
int newBooksCount = Books.Count(book => book.PublishedYear >= 2019);
```

---

## Reordering
- OrderBy
- OrderByDescending
- Reverse
- ThenBy

---

## Truncating
- Skip
- Take

```cs
var pageResults = searchResults
    .Skip(page * pageCount)
    .Take(pageCount);
```

---

## Adding elements
- Concat
- Append
- Prepend

---

## Checking condition of enumerable
- Any
- All

```cs
var anyBooksToRead = Books.Any(book => book.IsUnread);
```

---

## Advanced Methods
- GroupBy
- SelectMany
- Zip
- Aggregate

---

## Static Enumerable Methods
- Empty
    - Good for early returns or with ?? operator
- Range
- Repeat

```cs
var neverNull = possiblyNull ?? Enumerable.Empty<int>();
var ints = Enumerable.Range(0, 5); // => [0, 1, 2, 3, 4]
var fives = Enumerable.Repeat(5, 3); // => [5, 5, 5]
```

---

## GroupBy
Groups the elements of a sequence according to a specified key selector function.

`IEnumerable<IGrouping<TKey, T>> GroupBy<T, TKey>(Func<T, TKey> keySelector)`

```cs
var authorWithMostBooks = Books
    .GroupBy(book => book.Author);      // a list of lists of books
    .OrderByDescending(books => books.Count())
    .First()
    .Key;
```

- `IGrouping` implements `IEnumerable<T>`

---

## SelectMany
Projects each element of a sequence to an `IEnumerable<T>`, and flattens the resulting sequences into one sequence.

`IEnumerable<TResult> SelectMany<T, TResult>(Func<T, IEnumerable<TResult>> selector)`

```cs
// numbers between 0 - 100 that end in 3 or 7
Enumerable.Range(0, 10)
    .Select(x => x * 10)
    .SelectMany(x => new[] { x + 3, x + 7 })
    .Dump(); // => [3, 7, 13, 17, 23, ...]
```

---

## Aggregate

`T Aggregate<T>(Func<T, T, T> func)`

`TResult Aggregate<T, TResult>(TResult seed, Func<TResult, T, TResult> func)`

Applies an accumulator function over a sequence. Returns final accumulator. *Essentially a for loop with some state.*

Examples:
- Max
- Min & Max
- Redux

---

## Deferred Execution

"Deferred execution" means the expression won't be evaluated until the materialized value is needed. C# allows this through `yield return`.

```cs
IEnumerable<int> PositiveInts()
{
    var i = 1;
    while(true)
        yield return i++;
}

var numbers = PositiveInts();
numbers.Take(5).Dump(); // => [1, 2, 3, 4, 5]
```

- Must have return type of `IEnumerable<T>`
- Function doesn't execute until enumerated
- **Execution halts** at each yield until next value needed
- All LINQ methods that return `IEnumerable<T>` use yield

---

## Interesting Examples
- Random
- Fibonacci
- Binary Tree Traversal

---

## Caution: Multiple Enumerations

While some enumerators are based on materialized data, others other may have major side effects (expensive code, queries to a database, etc.). Enumerating multiple times can be very expensive!

Consider enumerating once and saving the values. i.e. `.ToList()`

---

## Extension Methods
```cs
public static class Extensions
{
    public static IEnumerable<T> Loop<T>(this IEnumerable<T> source)
    {
        while (true)
            foreach (var t in source)
                yield return t;
    }
}

Enumerable.Range(1, 3).Loop().Take(10).Dump(); // => [1,2,3,1,2,3,1,2,3,1]
```

---

## More Extension Methods
```cs
public static class Extensions
{
    public static IEnumerable<IEnumerable<T>> Batch<T>(
        this IEnumerable<T> source, 
        int n)
    {
        var remainder = source;
        while (remainder.Any()) {
            yield return remainder.Take(n);
            remainder = remainder.Skip(n);
        }
    }
}

Enumerable.Range(0, 7)
    .Batch(3)
    .Dump(); // [[0, 1, 2], [3, 4, 5], [6]]
```

---

## Debugging LINQ
- If you need to set a breakpoint, use statement lambda!
- Use the helpful extension method below:

```cs
public static class Extensions
{
    public static T Debug<T>(this T value)
    {
        // set a breakpoint here or console write
        return value;
    }
}

Enumerable.Range(0, 10)
    .Debug()
    .Select(x => x.Debug())
    .Dump();
```

---

## Readability & Reusability
```cs
bool IsOdd(int x) => x % 2 == 1;
int Doubled(int x) => x * 2;

Enumerable.Range(0, 10)
    .Where(IsOdd)
    .Select(Doubled)
    .Dump(); // => [2, 6, 10, 14, 18]
```

- Use line-breaks in LINQ chains help comprehension
- Breakup long chains into logical groups with named variables
- Use named local functions, lambdas, or static methods improve readability
- Use inline lambdas for simple logic only

---

## Reusability++

Closures can be used to parameterize lambdas.
> "A closure is the combination of a function and the lexical environment within which that function was declared" ~**MDN**

```cs
Func<int, bool> IsLessThan(int x)
{
    return y => y < x;
}

Enumerable.Range(0, 10)
    .Where(IsLessThan(5))
    .Dump(); // => [0, 1, 2, 3, 4]
```

---

## LINQ Puzzles
- http://ssartell.github.io/linq-puzzles/
- Solved with LINQ one-liner (no semicolons)

### Examples
- Randomize List
- Prime Numbers
- Generate Permutations
- Subset Sum [*NP-Complete*]

---

# Thank you!