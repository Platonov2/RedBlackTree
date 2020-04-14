using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedBlackTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTreeTests
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void Get()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(1);

            RedBlackTreeNode tempNode = new RedBlackTreeNode(1, Color.Black, null, null, null);

            RedBlackTreeNode getNode1 = redBlackTree.Get(1);
            RedBlackTreeNode getNodeNull = redBlackTree.Get(2);

            Assert.AreEqual(getNode1, tempNode);
            Assert.IsNull(getNodeNull);
        }

        [TestMethod]
        public void FindPlace()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(1);

            RedBlackTreeNode tempNode = new RedBlackTreeNode(1, Color.Black, null, null, null);

            RedBlackTreeNode findNewPlace = redBlackTree.FindPlace(2);

            Assert.AreEqual(findNewPlace, tempNode);
            Assert.ThrowsException<ArgumentException>(() => redBlackTree.FindPlace(1));
        }

        [TestMethod]
        public void FindNext()
        {
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass(10);

            redBlackTree.Add(12);
            redBlackTree.Add(5);
            redBlackTree.Add(2);
            redBlackTree.Add(7);
            redBlackTree.Add(1);

            RedBlackTreeNode findNext2Before = redBlackTree.FindNext(2);

            redBlackTree.Add(3);

            RedBlackTreeNode findNext2After = redBlackTree.FindNext(2);
            RedBlackTreeNode findNext12 = redBlackTree.FindNext(12);

            Assert.AreEqual(findNext2Before.value, 5);
            Assert.AreEqual(findNext2After.value, 3);
            Assert.IsNull(findNext12);

        }
    }
}
