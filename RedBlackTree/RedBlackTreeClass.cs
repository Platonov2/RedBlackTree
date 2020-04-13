using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    public class RedBlackTreeClass
    {
        public RedBlackTreeNode root;

        public RedBlackTreeClass(int rootValue)
        {
            RedBlackTreeNode rootNode = new RedBlackTreeNode(rootValue, Color.Black, null, null, null);
            root = rootNode;
        }

        public void Add(int value)
        {
            RedBlackTreeNode father = FindPlace(value);

            RedBlackTreeNode newNode = new RedBlackTreeNode(value, Color.Red, null, null, father);

            if (father.value > value)
            {
                father.leftChild = newNode;
            }
            else father.rightChild = newNode;

            InsertCase1(newNode);
        }

        public void InsertCase1(RedBlackTreeNode newNode)
        {
            if (newNode.father == null)
            {
                newNode.color = Color.Black;
            }

            InsertCase2(newNode);
        }

        public void InsertCase2(RedBlackTreeNode newNode)
        {
            if (newNode.father.color == Color.Black)
            {
                return;
            }

            InsertCase3(newNode);
        }

        public void InsertCase3(RedBlackTreeNode newNode)
        {
            RedBlackTreeNode uncle = newNode.getUncle();
            RedBlackTreeNode grandFather = newNode.getGrandFather();

            if (uncle != null && uncle.color == Color.Red)
            {
                newNode.father.color = Color.Black;
                uncle.color = Color.Black;
                grandFather.color = Color.Red;

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
