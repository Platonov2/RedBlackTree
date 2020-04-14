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
            this.rightChild = rightChild;
            this.father = father;
        }

        public RedBlackTreeNode(int value, Color color, RedBlackTreeNode father)
        {
            this.value = value;
            this.color = color;
            this.leftChild = new RedBlackTreeNode(0, Color.Black, null, null, this);
            this.rightChild = new RedBlackTreeNode(0, Color.Black, null, null, this);
            this.father = father;
        }

        public RedBlackTreeNode GetGrandFather()
        {
            if (father != null && father.father != null)
            {
                return father.father;
            }
            return null;
        }

        public RedBlackTreeNode GetUncle()
        {
            RedBlackTreeNode grandFather = GetGrandFather();

            if (grandFather == null)
                return null;

            if (grandFather.leftChild == father)
                return grandFather.rightChild;
            return grandFather.leftChild;
        }

        public RedBlackTreeNode GetBrother()
        {
            if (father == null) return null;

            if (father.leftChild == this && father.rightChild.value != 0)
                return father.rightChild;
            if (father.rightChild == this && father.leftChild.value != 0)
                return father.leftChild;
            return null;
        }

        public static bool IsLeaf(RedBlackTreeNode node)
        {
            return node != null && node.leftChild == null && node.rightChild == null;
        }

        public override bool Equals(object obj)
        {
            RedBlackTreeNode tempObj = (RedBlackTreeNode) obj;

            return (value == tempObj.value && color == tempObj.color);
        }
    }
}