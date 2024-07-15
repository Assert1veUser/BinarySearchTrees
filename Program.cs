using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class Program
    {
        public static Node node = new Node(6);
        public static void Main(string[] args)
        {
            Random random = new Random();
            for(int i = 1; i < 7; i++)
            {
                node.insert(node, i, random);
            }
            
        }
    }    
}
