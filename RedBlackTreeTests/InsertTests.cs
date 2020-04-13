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
    }
}
