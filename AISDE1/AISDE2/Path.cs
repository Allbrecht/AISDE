using System;
using System.Collections.Generic;

namespace AISDE2
{
    class Path
    {
        private List<Link> links;

        public Path()
        {
            links = new List<Link>();
        }

        public Path(int v1, int v2)
        {
            links = new List<Link>();
            addLink(v1, v2);
        }


        /*public double getCost()
        {
            double counter = 0;
            for(int tmp = 0; tmp<links.Count;tmp++)
            {
                counter += links[tmp].getCost();
            }
            return counter;
        }*/
        public void addLink(int A, int B)
        {
            links.Add(new Link(A, B));  
        }
        public List<Link> getLinks()
        {
            return links;
        }
       
        public void writePath()
        {
            for(int tmp = 0; tmp < links.Count; tmp++)
            {
                Console.Write(links[tmp].getAName()+" " + links[tmp].getBName() );
            }
        }


    }
}
