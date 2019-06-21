<Query Kind="Program" />

public class Node<T>
{
	public T Value { get; set; }
	public Node<T> Left { get; set; }
	public Node<T> Right { get; set; }

	public Node(T value, Node<T> left = null, Node<T> right = null)
	{
		Value = value;
		Left = left;
		Right = right;
	}

	public IEnumerable<Node<T>> InOrder()
	{		
		if (Left != null)
		{
			foreach (var node in Left.InOrder())
				yield return node;
		}
		
		yield return this;

		if (Right != null)
		{
			foreach (var node in Right.InOrder())
				yield return node;
		}
	}
}

void Main()
{
	var tree = new Node<int>(4,		//       4
		new Node<int>(2,			//      / \
			new Node<int>(1),		//     2   5
			new Node<int>(3)),		//    / \
		new Node<int>(5));			//   1   3
		
	tree.InOrder().Select(x => x.Value).Dump();
}