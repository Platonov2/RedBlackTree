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
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(1);

            RedBlackTreeNode tempNode = new RedBlackTreeNode(1, Color.Black, null, null, null);

            Assert.AreEqual(redBlackTree.root, tempNode);
        }

        [TestMethod]
        public void TwoSimplInserts() 
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(2);

            redBlackTree.Add(1);
            redBlackTree.Add(3);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null, null, null);

            RedBlackTreeNode leftChild = new RedBlackTreeNode(1, Color.Red, null, null, rootNode);
            RedBlackTreeNode rightChild = new RedBlackTreeNode(3, Color.Red, null, null, rootNode);

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, leftChild);
            Assert.AreEqual(redBlackTree.root.rightChild, rightChild);
        }

        [TestMethod]
        public void RedFatherCase()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(5);

            redBlackTree.Add(6);
            redBlackTree.Add(4);
            redBlackTree.Add(3);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(5, Color.Black, null);
            RedBlackTreeNode ll = new RedBlackTreeNode(3, Color.Red, rootNode);
            RedBlackTreeNode l = new RedBlackTreeNode(4, Color.Black, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(6, Color.Black, rootNode);

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, l);
            Assert.AreEqual(redBlackTree.root.leftChild.leftChild, ll);
            Assert.AreEqual(redBlackTree.root.rightChild, r);
        }

        [TestMethod]
        public void Insert123()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(1);

            redBlackTree.Add(2);
            redBlackTree.Add(3);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null);
            RedBlackTreeNode l = new RedBlackTreeNode(1, Color.Red, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(3, Color.Red, rootNode);

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, l);
            Assert.AreEqual(redBlackTree.root.rightChild, r);
        }

        [TestMethod]
        public void Insert1234()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(1);

            redBlackTree.Add(2);
            redBlackTree.Add(3);
            redBlackTree.Add(4);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null);
            RedBlackTreeNode l = new RedBlackTreeNode(1, Color.Black, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(3, Color.Black, rootNode);
            RedBlackTreeNode rr = new RedBlackTreeNode(4, Color.Red, rootNode);    

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, l);
            Assert.AreEqual(redBlackTree.root.rightChild, r);
            Assert.AreEqual(redBlackTree.root.rightChild.rightChild, rr);
        }

        [TestMethod]
        public void Insert12345()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(1);

            redBlackTree.Add(2);
            redBlackTree.Add(3);
            redBlackTree.Add(4);
            redBlackTree.Add(5);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null);
            RedBlackTreeNode l = new RedBlackTreeNode(1, Color.Black, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(4, Color.Black, rootNode);
            RedBlackTreeNode rl = new RedBlackTreeNode(3, Color.Red, r);
            RedBlackTreeNode rr = new RedBlackTreeNode(5, Color.Red, r);

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, l);
            Assert.AreEqual(redBlackTree.root.rightChild, r);
            Assert.AreEqual(redBlackTree.root.rightChild.leftChild, rl);
            Assert.AreEqual(redBlackTree.root.rightChild.rightChild, rr);
        }

        [TestMethod]
        public void Insert123456()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(1);

            redBlackTree.Add(2);
            redBlackTree.Add(3);
            redBlackTree.Add(4);
            redBlackTree.Add(5);
            redBlackTree.Add(6);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null);
            RedBlackTreeNode l = new RedBlackTreeNode(1, Color.Black, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(4, Color.Red, rootNode);
            RedBlackTreeNode rl = new RedBlackTreeNode(3, Color.Black, r);
            RedBlackTreeNode rr = new RedBlackTreeNode(5, Color.Black, r);
            RedBlackTreeNode rrr = new RedBlackTreeNode(6, Color.Red, rr);

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, l);
            Assert.AreEqual(redBlackTree.root.rightChild, r);
            Assert.AreEqual(redBlackTree.root.rightChild.leftChild, rl);
            Assert.AreEqual(redBlackTree.root.rightChild.rightChild, rr);
            Assert.AreEqual(redBlackTree.root.rightChild.rightChild.rightChild, rrr);
        }

        [TestMethod]
        public void Case1012572134()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(10);

            redBlackTree.Add(12);
            redBlackTree.Add(5);
            redBlackTree.Add(7);
            redBlackTree.Add(2);
            redBlackTree.Add(1);
            redBlackTree.Add(3);
            redBlackTree.Add(4);

            RedBlackTreeNode rootNode = new RedBlackTreeNode(5, Color.Black, null);
            RedBlackTreeNode l = new RedBlackTreeNode(2, Color.Red, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(10, Color.Red, rootNode);
            RedBlackTreeNode ll = new RedBlackTreeNode(1, Color.Black, l);
            RedBlackTreeNode lr = new RedBlackTreeNode(3, Color.Black, l);
            RedBlackTreeNode rl = new RedBlackTreeNode(7, Color.Black, r);
            RedBlackTreeNode rr = new RedBlackTreeNode(12, Color.Black, r);
            RedBlackTreeNode lrr = new RedBlackTreeNode(4, Color.Red, lr);

            Assert.AreEqual(redBlackTree.root, rootNode);
            Assert.AreEqual(redBlackTree.root.leftChild, l);
            Assert.AreEqual(redBlackTree.root.rightChild, r);
            Assert.AreEqual(redBlackTree.root.leftChild.leftChild, ll);
            Assert.AreEqual(redBlackTree.root.leftChild.rightChild, lr);
            Assert.AreEqual(redBlackTree.root.rightChild.leftChild, rl);
            Assert.AreEqual(redBlackTree.root.rightChild.rightChild, rr);
            Assert.AreEqual(redBlackTree.root.leftChild.rightChild.rightChild, lrr);
        }
    }
}
