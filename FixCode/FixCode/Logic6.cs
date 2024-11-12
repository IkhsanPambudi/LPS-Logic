using System;
using System.Collections.Generic;

namespace MemoryLeakExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootNode = new TreeNode();
            int iterations = 0;

            while (iterations < 10)
            {
                var newNode = new TreeNode();
                for (int i = 0; i < 10000; i++)
                {
                    var childNode = new TreeNode();
                    newNode.AddChild(childNode);
                }

                rootNode.AddChild(newNode);
                Console.WriteLine($"Iteration {iterations + 1} - Tree size: {rootNode.GetChildrenCount()}");

                if (rootNode.GetChildrenCount() > 50000)
                {
                    rootNode.ClearChildren();
                }

                iterations++;
            }
        }
    }

    class TreeNode
    {
        private readonly List<TreeNode> _children = new List<TreeNode>();

        public void AddChild(TreeNode child)
        {
            _children.Add(child);
        }

        public int GetChildrenCount()
        {
            return _children.Count;
        }

        public void ClearChildren()
        {
            _children.Clear();
            Console.WriteLine("Cleared children nodes.");
        }
    }
}
alasan :
- batasi literasi
- membatasi ukuran pohon
- menghitung jumlah anak