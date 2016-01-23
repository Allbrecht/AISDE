
namespace AISDE2
{
    class Node
    {
        private int name;
        private double flag; 

        public Node(int name)
        {
            this.name = name;
        }
        public Node(int name, double flag)
        {
            this.flag = flag;
            this.name = name;
        }

        public int getName()
        {
            return name;
        }
        public void setName(int name)
        {
            this.name = name;
        }

        public double getFlag()
        {
            return flag;
        }
        public void setFlag(double flag)
        {
            this.flag = flag;
        }
    }
}
