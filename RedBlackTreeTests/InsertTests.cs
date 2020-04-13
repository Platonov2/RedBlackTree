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

            redBlackTree.InsertCase1(1);

            RedBlackTreeNode tempNode = new RedBlackTreeNode(1, true, null, null, null);

            Assert.AreEqual(redBlackTree.root, tempNode);
        }
    }
}
