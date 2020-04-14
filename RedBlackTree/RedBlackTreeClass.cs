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
            RedBlackTreeNode rootNode = new RedBlackTreeNode(rootValue, Color.Black, null);
            root = rootNode;
        }

        public void Add(int value)
        {
            RedBlackTreeNode father = FindPlace(value);

            RedBlackTreeNode newNode = new RedBlackTreeNode(value, Color.Red, father);

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
                return;

            InsertCase3(node);
        }

        private void InsertCase3(RedBlackTreeNode node)
        {
            RedBlackTreeNode uncle = node.GetUncle();
            RedBlackTreeNode grandFather = node.GetGrandFather();

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
            RedBlackTreeNode grandFather = node.GetGrandFather();

            if (node == node.father.rightChild && node.father == grandFather.leftChild)
            {
                RotateLeft(node.father);
            }
            else if (node == node.father.leftChild && node.father == grandFather.rightChild)
            {
                RotateRight(node.father);
            }

            InsertCase5(node);
        }

        private void InsertCase5(RedBlackTreeNode node)
        {
            RedBlackTreeNode grandFather = node.GetGrandFather();

            node.father.color = Color.Black;
            grandFather.color = Color.Red;

            if (node == node.father.leftChild && node.father == grandFather.leftChild)
            {
                RotateRight(grandFather);
            }
            else RotateLeft(grandFather);

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
            
            RedBlackTreeNode replacedNode = Get(value);
            RedBlackTreeNode deletedNodeNext = FindNext(replacedNode.value);
            RedBlackTreeNode deletedNodePrev = FindPrev(replacedNode.value);

            if (deletedNodePrev == null && deletedNodeNext == null)
            {
                DeleteCase1(replacedNode);
                return;
            }

            if (deletedNodePrev == null && deletedNodeNext != null)
            {
                replacedNode.value = deletedNodeNext.value;
            }

            /*if (!RedBlackTreeNode.IsLeaf(deletedNode))
                ReplaceNode(deletedNode);


            if (node.color == Color.Black)
                if (child.color == Color.Red)
                    child.color = Color.Black;
                else DeleteCase1(child);*/
        }


        private void DeleteCase1(RedBlackTreeNode node)
        {
            if (node.father != null)
                DeleteCase2(node);
        }

        private void DeleteCase2(RedBlackTreeNode node)
        {
            RedBlackTreeNode brother = node.GetBrother();

            if (brother.color == Color.Red)
            {
                node.father.color = Color.Red;
                brother.color = Color.Black;

                if (node == node.father.leftChild)
                    RotateLeft(node.father);
                else RotateRight(node.father);
            }
            DeleteCase3(node);
        }

        private void DeleteCase3(RedBlackTreeNode node)
        {
            RedBlackTreeNode brother = node.GetBrother();

            if ((node.father.color == Color.Black) && (brother.color == Color.Black) &&
                (brother.leftChild.color == Color.Black) && (brother.rightChild.color == Color.Black))
            {
                brother.color = Color.Red;
                DeleteCase1(node.father);
            }
            else DeleteCase4(node);
        }

        private void DeleteCase4(RedBlackTreeNode node)
        {
            RedBlackTreeNode brother = node.GetBrother();

            if ((node.father.color == Color.Red) && (brother.color == Color.Black) &&
                (brother.leftChild.color == Color.Black) && (brother.rightChild.color == Color.Black))
            {
                brother.color = Color.Red;
                node.father.color = Color.Black;
            }
            else DeleteCase5(node);
        }

        private void DeleteCase5(RedBlackTreeNode node)
        {
            RedBlackTreeNode brother = node.GetBrother();

            if (brother.color == Color.Black)
            {
                if ((node == node.father.leftChild) && (brother.rightChild.color == Color.Black) &&
                    (brother.leftChild.color == Color.Red))
                {
                    brother.color = Color.Red;
                    brother.leftChild.color = Color.Black;
                    RotateRight(brother);
                }
                else if ((node == node.father.rightChild) && (brother.leftChild.color == Color.Black) &&
                    (brother.rightChild.color == Color.Red))
                {
                    brother.color = Color.Red;
                    brother.rightChild.color = Color.Black;
                }
            }
            DeleteCase6(node);
        }

        private void DeleteCase6(RedBlackTreeNode node)
        {
            RedBlackTreeNode brother = node.GetBrother();

            brother.color = node.father.color;
            node.father.color = Color.Black;

            if (node == node.father.leftChild)
            {
                brother.rightChild.color = Color.Black;
                RotateLeft(node.father);
            }
            else
            {
                brother.leftChild.color = Color.Black;
                RotateRight(node.father);
            }
        }

        private void ReplaceNode(RedBlackTreeNode node)
        {
            /*if (node.leftChild != null)

            child.father = node.father;

            if (node == node.father.leftChild)
                node.father.leftChild = child;
            else node.father.rightChild = child;*/
        }

        public RedBlackTreeNode Get(int value)
        {
            RedBlackTreeNode currentNode = root;

            while (currentNode.value != 0)
            {
                if (currentNode.value == value)
                {
                    return currentNode;
                }

                if (currentNode.value > value)
                    currentNode = currentNode.leftChild;
                else currentNode = currentNode.rightChild;
            }
            return null;
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
                    if (currentNode.leftChild.value == 0)
                        return currentNode;
                    else currentNode = currentNode.leftChild;
                }
                else if (currentNode.value < value)
                {
                    if (currentNode.rightChild.value == 0)
                        return currentNode;
                    else currentNode = currentNode.rightChild;
                }
            }
        }

        public RedBlackTreeNode FindNext(int value)
        {
            RedBlackTreeNode currentNode = Get(value);

            currentNode = currentNode.rightChild;

            while (currentNode.value != 0)
            {
                currentNode = currentNode.leftChild;
            }
            return currentNode.father;
        }

        public RedBlackTreeNode FindPrev(int value)
        {
            RedBlackTreeNode currentNode = Get(value);

            if (currentNode.leftChild == null)
            {
                return null;
            }

            currentNode = currentNode.leftChild;

            while (currentNode.rightChild != null)
            {
                currentNode = currentNode.rightChild;
            }
            return currentNode;
        }

        public void RotateRight(RedBlackTreeNode node)
        {
            RedBlackTreeNode pivot = node.leftChild;

            pivot.father = node.father;

            if (node.father != null)
            {
                if (node.father.leftChild == node)
                    node.father.leftChild = pivot;
                else
                    node.father.rightChild = pivot;
            }

            node.leftChild = pivot.rightChild;

            if (pivot.rightChild != null)
                pivot.rightChild.father = node;

            node.father = pivot;
            pivot.rightChild = node;
        }

        public void RotateLeft(RedBlackTreeNode node)
        {
            RedBlackTreeNode pivot = node.rightChild;

            pivot.father = node.father;

            if (node.father != null)
            {
                if (node.father.leftChild == node)
                    node.father.leftChild = pivot;
                else
                    node.father.rightChild = pivot;
            }

            node.rightChild = pivot.leftChild;

            if (pivot.leftChild != null)
                pivot.leftChild.father = node;

            node.father = pivot;
            pivot.leftChild = node;
        }
    }
}
