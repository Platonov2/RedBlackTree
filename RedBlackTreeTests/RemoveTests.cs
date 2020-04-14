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
    }
}