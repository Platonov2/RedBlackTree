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

            rootNode.leftChild = leftChild;
            rootNode.rightChild = rightChild;

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

            RedBlackTreeNode rootNode = new RedBlackTreeNode(5, Color.Black, null, null, null);
            RedBlackTreeNode ll = new RedBlackTreeNode(3, Color.Red, null, null, rootNode);
            RedBlackTreeNode l = new RedBlackTreeNode(4, Color.Black, ll, null, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(6, Color.Black, null, null, rootNode);

            rootNode.leftChild = l;
            rootNode.rightChild = r;

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

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null, null, null);
            RedBlackTreeNode l = new RedBlackTreeNode(1, Color.Red, null, null, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(3, Color.Red, null, null, rootNode);

            rootNode.leftChild = l;
            rootNode.rightChild = r;

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

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null, null, null);
            RedBlackTreeNode l = new RedBlackTreeNode(1, Color.Black, null, null, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(3, Color.Black, null, null, rootNode);
            RedBlackTreeNode rr = new RedBlackTreeNode(4, Color.Red, null, null, rootNode);    

            rootNode.leftChild = l;
            rootNode.rightChild = r;
            r.rightChild = rr;

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

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null, null, null);
            RedBlackTreeNode l = new RedBlackTreeNode(1, Color.Black, null, null, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(4, Color.Black, null, null, rootNode);
            RedBlackTreeNode rl = new RedBlackTreeNode(3, Color.Red, null, null, r);
            RedBlackTreeNode rr = new RedBlackTreeNode(5, Color.Red, null, null, r);

            rootNode.leftChild = l;
            rootNode.rightChild = r;
            r.leftChild = rl;
            r.rightChild = rr;

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

            RedBlackTreeNode rootNode = new RedBlackTreeNode(2, Color.Black, null, null, null);
            RedBlackTreeNode l = new RedBlackTreeNode(1, Color.Black, null, null, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(4, Color.Red, null, null, rootNode);
            RedBlackTreeNode rl = new RedBlackTreeNode(3, Color.Black, null, null, r);
            RedBlackTreeNode rr = new RedBlackTreeNode(5, Color.Black, null, null, r);
            RedBlackTreeNode rrr = new RedBlackTreeNode(6, Color.Red, null, null, rr);

            rootNode.leftChild = l;
            rootNode.rightChild = r;
            r.leftChild = rl;
            r.rightChild = rr;
            rr.rightChild = rrr;

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

            RedBlackTreeNode rootNode = new RedBlackTreeNode(5, Color.Black, null, null, null);
            RedBlackTreeNode l = new RedBlackTreeNode(2, Color.Red, null, null, rootNode);
            RedBlackTreeNode r = new RedBlackTreeNode(10, Color.Red, null, null, rootNode);
            RedBlackTreeNode ll = new RedBlackTreeNode(1, Color.Black, null, null, l);
            RedBlackTreeNode lr = new RedBlackTreeNode(3, Color.Black, null, null, l);
            RedBlackTreeNode rl = new RedBlackTreeNode(7, Color.Black, null, null, r);
            RedBlackTreeNode rr = new RedBlackTreeNode(12, Color.Black, null, null, r);
            RedBlackTreeNode lrr = new RedBlackTreeNode(4, Color.Red, null, null, lr);

            l.leftChild = ll;
            l.rightChild = lr;
            r.leftChild = rl;
            r.rightChild = rr;
            lr.rightChild = lrr;

            rootNode.leftChild = l;
            rootNode.rightChild = r;

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
