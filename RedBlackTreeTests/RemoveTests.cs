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

        [TestMethod]
        public void Case1012572134_2()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(10);

            redBlackTree.Add(12);
            redBlackTree.Add(5);
            redBlackTree.Add(7);
            redBlackTree.Add(2);
            redBlackTree.Add(1);
            redBlackTree.Add(3);
            redBlackTree.Add(4);

            redBlackTree.Delete(2);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(5, Color.Black, null, null, null);
            RedBlackTreeNode l = new RedBlackTreeNode(3, Color.Red, null, null, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(10, Color.Red, null, null, rootNode);
            RedBlackTreeNode ll = new RedBlackTreeNode(1, Color.Black, null, null, l);
            RedBlackTreeNode lr = new RedBlackTreeNode(4, Color.Black, null, null, l);
            RedBlackTreeNode rl = new RedBlackTreeNode(7, Color.Black, null, null, r);
            RedBlackTreeNode rr = new RedBlackTreeNode(12, Color.Black, null, null, r);

            l.leftChild = ll;
            l.rightChild = lr;
            r.leftChild = rl;
            r.rightChild = rr;

            rootNode.leftChild = l;
            rootNode.rightChild = r;

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, l);
            Assert.AreEqual(redBlackTree.root.rightChild, r);
            Assert.AreEqual(redBlackTree.root.leftChild.leftChild, ll);
            Assert.AreEqual(redBlackTree.root.leftChild.rightChild, lr);
            Assert.AreEqual(redBlackTree.root.rightChild.leftChild, rl);
            Assert.AreEqual(redBlackTree.root.rightChild.rightChild, rr);
        }
    }
}