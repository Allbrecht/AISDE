using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2Końcowy
{
    class Node
    {
        private int id;
        private double flag;
        public Node(int id1)
        {
            id = id1;
        }
        public int returnId()
        {
            return id;
        }
        public int getName()
        {
            return id;
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
