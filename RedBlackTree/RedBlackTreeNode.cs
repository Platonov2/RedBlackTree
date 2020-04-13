namespace RedBlackTree
{
    public class RedBlackTreeNode
    {
        public int value;
        public bool isBlack;

        public RedBlackTreeNode leftChild;
        public RedBlackTreeNode rightChild;

        public RedBlackTreeNode father;

        public RedBlackTreeNode(int value, bool isBlack, RedBlackTreeNode leftChild, RedBlackTreeNode rightChild, RedBlackTreeNode father)
        {
            this.value = value;
            this.isBlack = isBlack;
            this.leftChild = leftChild;
            this.father = father;
        }

        public RedBlackTreeNode getGrandFather()
        {
            if (father != null && father.father != null)
            {
                return father.father;
            }
            return null;
        }

        public RedBlackTreeNode getUncle()
        {
            RedBlackTreeNode grandFather = getGrandFather();

            if (grandFather == null)
                return null;

            if (grandFather.leftChild == father)
                return grandFather.rightChild;
            return grandFather.leftChild;
        }

        public override bool Equals(object obj)
        {
            RedBlackTreeNode tempObj = (RedBlackTreeNode) obj;

            if ((leftChild == null && tempObj.leftChild != null) || (rightChild == null && tempObj.rightChild != null)
             || (leftChild != null && tempObj.leftChild == null) || (rightChild != null && tempObj.rightChild == null)
             || (father == null && tempObj.father != null) || (father != null && tempObj.father == null))
                return false;

            return (value == tempObj.value && isBlack == tempObj.isBlack);
        }
    }
}