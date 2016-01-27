using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2Końcowy
{
    class Link
    {
        Node A;
        Node B;
        double capacity;
        double unit_cost;
        int id;
        int modules;
        public Link(int id1)
        {
            id = id1;
            modules = 0;
        }
        public Link(int A, int B, double capacity)
        {
            this.A = new Node(A);
            this.B = new Node(B);
            this.capacity = capacity;
        }
        public Link(int A, int B)
        {
            this.A = new Node(A);
            this.B = new Node(B);
        }
        public void setId(int id1)
        {
            id = id1;
        }
        public int returnNuberOfModules()
        {
            return modules;
        }
        public void setNumberOfModules(int mod)
        {
            modules = mod;
        }
        public void incrementNumberOfModules()
        {
            modules++;
        }
        public int returnId()
        {
            return id;
        }
        public void setCapacity(double capacity1)
        {
            capacity = capacity1;
        }
        public double returnCapacity()
        {
            return capacity;
        }
        public void setInitialNode(Node initial)
        {
            A = initial;
        }
        public void setTerminalNode(Node terminal)
        {
            B = terminal;
        }
        public Node returnInitialNode()
        {
            return A;
        }
        public Node returnTerminalNode()
        {
            return B;
        }
        public void setUnitCost(double unit_cost1)
        {
            unit_cost = unit_cost1;
        }
        public double returnUnitCost()
        {
            return unit_cost;
        }
        public int getAName()
        {
            return A.getName();
        }
        public int getBName()
        {
            return B.getName();
        }
        public Node getB()
        {
            return B;
        }
        public void setCost(double cap)
        {
            this.capacity = cap;
        }
        public double getCost()
        {
            return capacity;
        }
    }
    
}
