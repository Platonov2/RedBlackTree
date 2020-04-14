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
    }
}