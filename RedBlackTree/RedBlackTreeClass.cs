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
            InsertCase1(root);
        }

        private void InsertCase1(RedBlackTreeNode node)
        {
            if (node.father == null)
            {
                node.color = Color.Black;
                return;
            }

            InsertCase2(node);
        }

        private void InsertCase2(RedBlackTreeNode node)
        {
            if (node.father.color == Color.Black)
            {
                return;
            }

            InsertCase3(node);
        }

        private void InsertCase3(RedBlackTreeNode node)
        {
            RedBlackTreeNode uncle = node.getUncle();
            RedBlackTreeNode grandFather = node.getGrandFather();

            if (uncle != null && uncle.color == Color.Red)
            {
                node.father.color = Color.Black;
                uncle.color = Color.Black;
                grandFather.color = Color.Red;
                InsertCase1(grandFather);
            }
            else InsertCase4(node);
        }

        private void InsertCase4(RedBlackTreeNode node)
        {
            RedBlackTreeNode grandFather = node.getGrandFather();

            if (node == node.father.rightChild && node.father == grandFather.leftChild)
            {
                RedBlackTreeNode.RotateLeft(node.father);
            }
            else if (node == node.father.leftChild && node.father == grandFather.rightChild)
            {
                RedBlackTreeNode.RotateRight(node.father);
            }

            InsertCase5(node);
        }

        private void InsertCase5(RedBlackTreeNode node)
        {
            RedBlackTreeNode grandFather = node.getGrandFather();

            node.father.color = Color.Black;
            grandFather.color = Color.Red;

            if (node == node.father.leftChild && node.father == grandFather.leftChild)
            {
                RedBlackTreeNode.RotateRight(grandFather);
            }
            else RedBlackTreeNode.RotateLeft(grandFather);

            UpdateRoot(node);
        }

        public void UpdateRoot(RedBlackTreeNode node)
        {
            while (node.father != null)
            {
                node = node.father;
            }

            root = node;
        }




        public void Delete(int value)
        {
            RedBlackTreeNode node = Get(value);
            RedBlackTreeNode father = node.father;

            if (node.leftChild == null && node.rightChild == null)
            {
                if (father == null)
                    root = null;
                else if (father.leftChild == node)
                    father.leftChild = null;
                else father.rightChild = null;

                return;
            }

            // Один левый потомок
            if (node.leftChild != null && node.rightChild == null)
            {
                father.leftChild = node.leftChild;
                node.leftChild.father = father;
            }
            // Один правый потомок
            else if (node.leftChild == null && node.rightChild != null)
            {
                father.rightChild = node.rightChild;
                node.rightChild.father = father;
            }
            // Имеется оба потомка
            else
            {
                RedBlackTreeNode nextNode = FindNext(node.value);

                if (nextNode.rightChild != null)
                {
                    nextNode.rightChild.father = nextNode.father;
                }
                if (nextNode == root)
                    root = nextNode.rightChild;
                else nextNode.father.rightChild = nextNode.rightChild;

                if (nextNode != node)
                {
                    node.color = nextNode.color;
                    node.value = nextNode.value;
                }
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

        public RedBlackTreeNode FindNext(int value)
        {
            RedBlackTreeNode currentNode = Get(value);

            if (currentNode.rightChild == null)
            {
                if (currentNode.value > currentNode.father.value)
                    return null;
                return currentNode.father;
            }

            currentNode = currentNode.rightChild;

            while (currentNode.leftChild != null)
            {
                currentNode = currentNode.leftChild;
            }
            return currentNode;
        }
    }
}
