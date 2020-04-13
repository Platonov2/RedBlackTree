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
                RedBlackTreeNode rootNode = new RedBlackTreeNode(value, Color.Black, null, null, null);
                root = rootNode;
                return;
            }

            RedBlackTreeNode father = FindPlace(value);

            RedBlackTreeNode newNode = new RedBlackTreeNode(value, Color.Red, null, null, father);

            if (father.value > value)
            {
                father.leftChild = newNode;
            }
            else father.rightChild = newNode;

            InsertCase2(value);
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

                if (currentNode.value > value && currentNode.leftChild != null)
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
                if (currentNode.value == value)
                {
                    throw new ArgumentException("Данное значение уже есть в дереве");
                }

                if (currentNode.value > value)
                {
                    if (currentNode.leftChild == null)
                        return currentNode;
                    else currentNode = currentNode.leftChild;
                }
                else if (currentNode.value < value)
                {
                    if (currentNode.rightChild == null)
                        return currentNode;
                    else currentNode = currentNode.rightChild;
                }
            }
        }
    }
}
