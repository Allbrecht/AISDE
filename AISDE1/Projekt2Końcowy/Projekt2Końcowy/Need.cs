using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2Końcowy
{
    class Need
    {
        Node A;
        Node B; //A -> B
        double size;

        int id;
        public Need(int id1)
        {
            id = id1;
        }
        public int returnId()
        {
            return id;
        }
        public void setInitialNode(Node initial)
        {
            A = initial;
        }
        public void setTerminalNode(Node terminal)
        {
            B = terminal;
        }
        public void setSize(double size1)
        {
            size = size1;
        }
        public Node returnInitialNode()
        {
            return A;
        }
        public Node returnTerminalNode()
        {
            return B;
        }
        public double returnSize()
        {
            return size;
        }

    }
}
