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
            RedBlackTreeClass redBlackTree = new RedBlackTreeClass();

            redBlackTree.Add(1);

            RedBlackTreeNode tempNode = new RedBlackTreeNode(1, true, null, null, null);

            RedBlackTreeNode getNode1 = redBlackTree.Get(1);
            RedBlackTreeNode getNodeNull = redBlackTree.Get(2);

            Assert.AreEqual(getNode1, tempNode);
            Assert.IsNull(getNodeNull);
        }
    }
}
