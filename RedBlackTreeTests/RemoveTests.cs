using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using RedBlackTree;

namespace RedBlackTreeTests
{
    [TestClass]
    public class RemoveTests
    {
        [TestMethod]
        public void RootDelete()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(1);

            redBlackTree.Delete(1);

            Assert.IsNull(redBlackTree.root);
        }

        [TestMethod]
        public void TwoSimpleDelets()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(2);

            redBlackTree.Add(1);
            redBlackTree.Add(3);

            redBlackTree.Delete(1);
            redBlackTree.Delete(3);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null, null, null);

            Assert.AreEqual(redBlackTree.root, rootNode);
        }

        [TestMethod]
        public void RemoveOneLeafChild()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(2);

            redBlackTree.Add(1);
            redBlackTree.Add(3);
            redBlackTree.Add(4);

            redBlackTree.Delete(3);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null, null, null);
            RedBlackTreeNode l = new RedBlackTreeNode(1, Color.Black, null, null, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(4, Color.Red, null, null, rootNode);

            rootNode.leftChild = l;
            rootNode.rightChild = r;

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, l);
            Assert.AreEqual(redBlackTree.root.rightChild, r);
        }
    }
}