using System.Collections.Generic;

namespace AISDE2
{
    class Path
    {
        private List<Link> links;
        private Node A;
        private Node B;
        private double cost;

        public Path(Node A, Node B, double cost)
        {
            this.A = A;
            this.B = B;
            this.cost = cost;
        }
        public double getCost()
        {
            double counter = 0;
            for(int tmp = 0; tmp<links.Count;tmp++)
            {
                counter += links[tmp].getCost();
            }
            return counter;
        }


    }
}
