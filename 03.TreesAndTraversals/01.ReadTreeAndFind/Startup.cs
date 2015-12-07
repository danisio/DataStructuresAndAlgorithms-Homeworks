/*You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1).Write a program to read the tree and find:
-the root node
-all leaf nodes
-all middle nodes
-the longest path in the tree*/

namespace ReadTreeAndFind
{
    using System;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
#endif
            var nodes = ReadInput();

            PrintRoot(nodes);

            PrintAllLeafs(nodes);

            PrintAllMiddleNodes(nodes);

            Console.WriteLine("Longest path is: {0}", FindLongestPath(FindRoot(nodes)));
        }

        private static int FindLongestPath(Node<int> node)
        {
            if (node.Children.Count == 0)
            {
                return 0;
            }

            int result = 0;
            foreach (var child in node.Children)
            {
                int maxPath = FindLongestPath(child);
                if (maxPath > result)
                {
                    result = maxPath;
                }
            }

            return result + 1;
        }

        private static void PrintAllMiddleNodes(Node<int>[] nodes)
        {
            var middleNodes = nodes
                .Where(n => n.Children.Count > 0 && n.Parent != null)
                .Select(n => n.Value)
                .ToList();

            Console.WriteLine("The middle nodes are: {0}", string.Join(", ", middleNodes));
        }

        private static void PrintAllLeafs(Node<int>[] nodes)
        {
            var leafs = nodes
             .Where(n => n.Children.Count == 0)
             .Select(l => l.Value)
             .ToList();

            Console.WriteLine("The leafs are: {0}", string.Join(", ", leafs));
        }

        private static void PrintRoot(Node<int>[] nodes)
        {
            var root = FindRoot(nodes);

            Console.WriteLine("The root is: {0}", root.Value);
        }

        private static Node<int> FindRoot(Node<int>[] nodes)
        {
            return nodes
               .Where(n => n.Parent == null)
               .FirstOrDefault();
        }

        private static Node<int>[] ReadInput()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= nodesCount - 1; i++)
            {
                var currentLine = Console.ReadLine().Split(' ');
                int parentId = int.Parse(currentLine[0]);
                int childId = int.Parse(currentLine[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].Parent = nodes[parentId];
            }

            return nodes;
        }
    }
}
