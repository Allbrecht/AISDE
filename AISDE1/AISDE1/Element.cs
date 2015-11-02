using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE1
{
    public class Element
    {
        private int key;

        public Element()
        {
            // do nothing
        }

        //Konstruktor
        public Element(int myKey)
        {
           key = myKey;
        }

        public int getKey()
        {
            return key;
        }
        
    }
}
