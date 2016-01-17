
namespace AISDE2
{
    class Link
    {
        private double cost; 
        private Node A;
        private Node B; //od A do B

        
        public Link(int A, int B, double cost)
        {
            this.A = new Node(A);
            this.B = new Node(B);
            this.cost = cost;
        }
        public Link(Node A, Node B, double cost) //tego raczej nie będziemy używać
        {
            this.A = A;
            this.B = B;
            this.cost = cost;
        }
        public double getCost()
        {
            return cost;
        }
        public int getA()
        {
            return A.getName();
        }
        public int getB()
        {
            return B.getName();
        }

    }
}
