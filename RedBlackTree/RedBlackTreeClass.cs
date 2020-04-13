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
            InsertCase1(value);
        }

        public void InsertCase1(int value)
        {
            if (root == null)
            {
                RedBlackTreeNode newNode = new RedBlackTreeNode(value, true, null, null, null);
                root = newNode;
            }
            else InsertCase2(value);
        }

        public void InsertCase2(int value)
        {

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
                else return null;
            }
        }

        public RedBlackTreeNode FindPlace(int value)
        {
            RedBlackTreeNode currentNode = root;

            while (true)
            {
                if (currentNode == null)
                {
                    return currentNode;
                }

                if (currentNode.value < value)
                {
                    currentNode = currentNode.leftChild;
                }
                else if (currentNode.value > value)
                {
                    currentNode = currentNode.rightChild;
                }
            }
        }
    }
}
