namespace RedBlackTree
{
    public class RedBlackTreeNode
    {
        public int value;
        public Color color;

        public RedBlackTreeNode leftChild;
        public RedBlackTreeNode rightChild;

        public RedBlackTreeNode father;

        public RedBlackTreeNode(int value, Color color, RedBlackTreeNode leftChild, RedBlackTreeNode rightChild, RedBlackTreeNode father)
        {
            this.value = value;
            this.color = color;
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

        public static void RotateRight(RedBlackTreeNode node)
        {
            RedBlackTreeNode pivot = node.leftChild;

            pivot.father = node.father;

            if (node.father != null)
            {
                if (node.father.leftChild == node)
                    node.father.leftChild = pivot;
                else
                    node.father.rightChild = pivot;
            }

            node.leftChild = pivot.rightChild;

            if (pivot.rightChild != null)
                pivot.rightChild.father = node;

            node.father = pivot;
            pivot.rightChild = node;
        }

        public static void RotateLeft(RedBlackTreeNode node)
        {
            RedBlackTreeNode pivot = node.rightChild;

            pivot.father = node.father;

            if (node.father != null)
            {
                if (node.father.leftChild == node)
                    node.father.leftChild = pivot;
                else
                    node.father.rightChild = pivot;
            }

            node.rightChild = pivot.leftChild;

            if (pivot.leftChild != null)
                pivot.leftChild.father = node;

            node.father = pivot;
            pivot.leftChild = node;
        }

        public override bool Equals(object obj)
        {
            RedBlackTreeNode tempObj = (RedBlackTreeNode) obj;

            if ((leftChild == null && tempObj.leftChild != null) || (rightChild == null && tempObj.rightChild != null)
             || (leftChild != null && tempObj.leftChild == null) || (rightChild != null && tempObj.rightChild == null)
             || (father == null && tempObj.father != null) || (father != null && tempObj.father == null))
                return false;

            return (value == tempObj.value && color == tempObj.color);
        }
    }
}