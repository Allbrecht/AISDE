
namespace AISDE2
{
    class Node
    {
        private int name { get; set; }
        private double flag { get; set; }

        public Node(int name)
        {
            this.name = name;
        }
        public Node(int name, double flag)
        {
            this.flag = flag;
            this.name = name;
        }
    }
}
