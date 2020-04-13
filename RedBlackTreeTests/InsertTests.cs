using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedBlackTree;
using System;

namespace RedBlackTreeTests
{
    [TestClass]
    public class InsertTests
    {
        [TestMethod]
        public void FirstInsert ()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass();

            redBlackTree.Add(1);

            RedBlackTreeNode tempNode = new RedBlackTreeNode(1, Color.Black, null, null, null);

            Assert.AreEqual(redBlackTree.root, tempNode);
        }

        [TestMethod]
        public void TwoSimplInserts() 
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass();

            redBlackTree.Add(2);
            redBlackTree.Add(1);
            redBlackTree.Add(3);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null, null, null);

            RedBlackTreeNode leftChild = new RedBlackTreeNode(1, Color.Red, null, null, rootNode);
            RedBlackTreeNode rightChild = new RedBlackTreeNode(3, Color.Red, null, null, rootNode);

            rootNode.leftChild = leftChild;
            rootNode.rightChild = rightChild;

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, leftChild);
            Assert.AreEqual(redBlackTree.root.rightChild, rightChild);
        }
    }
}
