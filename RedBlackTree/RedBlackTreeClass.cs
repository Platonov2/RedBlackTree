using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    public class RedBlackTreeClass
    {
        public RedBlackTreeNode root;

        public void Add(int value)
        {
            if (root == null)
            {
                RedBlackTreeNode newNode = new RedBlackTreeNode(value, true, null, null, null);
                root = newNode;
            }
        }

        public RedBlackTreeNode Get(int value)
        {
            RedBlackTreeNode currentNode = root;

            while (true)
            {
                if (currentNode.value == value)
                {
                    return currentNode;
                }

                if (currentNode.value < value && currentNode.leftChild != null)
                {
                    currentNode = currentNode.leftChild;
                }
                else if (currentNode.rightChild != null)
                {
                    currentNode = currentNode.rightChild;
                }
                else throw new ArgumentException("Искомое значение: " + value + " в дереве не найдено");
            }
        }
    }
}
