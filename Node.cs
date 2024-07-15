using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class Node
    {
        public int key;
        public int size;
        public Node left_son;
        public Node right_brother;

        public Node(int k)
        {
            key = k;
            size = 1;
            left_son = left_son.right_brother = null;
        }
        public Node find(Node p, int k) // поиск ключа k  в дереве p
        {
            if (p == null)
            {
                return null;
            }
            if (k == p.key)
            {
                return find(p.left_son, k);
            }
            else
            {
                return find(p.left_son.right_brother, k);
            }
        }
        public int getsize(Node p)
        {
            if (p == null)
            {
                return 0;
            }
            return p.size;
        }
        public void fixsize(Node p)
        {
            p.size = getsize(p.left_son) + getsize(p.left_son.right_brother) + 1;
        }
        public Node rotateright(Node p)
        {
            Node q = p.left_son;
            if(q == null)
            {
                return p;
            }
            p.left_son = q.left_son.right_brother;
            q.left_son.right_brother = p;
            q.size = p.size;
            fixsize(p);
            return q;
        }
        public Node rotateleft(Node q)
        {
            Node p = q.left_son.right_brother;
            if(p == null)
            {
                return q;
            }
            q.left_son.right_brother = p.left_son;
            p.left_son = q;
            p.size = q.size;
            fixsize(q);
            return p;
        }
        public Node insertroot(Node p, int k)
        {
            if(p == null)
            {
                return new Node(k);
            }
            if (k < p.key)
            {
                p.left_son = insertroot(p.left_son, k);
                return rotateright(p);
            }
            else
            {
                p.left_son.right_brother = insertroot(p.left_son.right_brother, k);
                return rotateleft(p);
            }
        }
        public Node insert(Node p, int k, Random random)
        {
            if(p == null)
            {
                return new Node(k);
            }
            if(random.Next(0, p.size + 1) == 0)
            {
                return insertroot(p, k);
            }
            if(p.key > k)
            {
                p.left_son = insert(p.left_son, k, random);
            }
            else
            {
                p.left_son.right_brother = insert(p.left_son.right_brother, k, random);
            }
            fixsize(p);
            return p;
        }
    }
}
