using System;
using System.Collections.Generic;

namespace AISDE2
{
    class Network : IFindPath //==Graph
    {
        private List<Node> node;
        private List<Link> link;

        public Network()
        {
            node = new List<Node>();
            link = new List<Link>();
        }

        public void addConnection(int nodeA, int nodeB, double link)
        {
            checkNewNode(nodeA);
            checkNewNode(nodeB);
            this.link.Add(new Link(nodeA, nodeB, link));
        }

        private void checkNewNode(int node)// jeśli jest nowy wierzchołek (node) to dodaj go do listy nodów
        {
            bool newNode = true;
            
            for (int tmp = 0; tmp<this.node.Count;tmp++)
            {
                if (this.node[tmp].getName() == node)
                {
                    newNode = false; 
                }
            }
            if (newNode)
            {
                this.node.Add(new Node(node));
            }
        }
        public void printNetwork()
        {
            Console.WriteLine("nody:");
            for (int tmp = 0; tmp < node.Count; tmp++)
            {
                Console.WriteLine(node[tmp].getName());
            }
            Console.WriteLine("Links:");
            for (int tmp = 0; tmp < link.Count; tmp++)
            {
                Console.WriteLine(link[tmp].getAName() + " " + link[tmp].getBName()+" " + this.link[tmp].getCost());
            }
            //Console.ReadKey();
        }

        public void findPathOneToOne(int algorithm, Node A, Node B)
        {
            throw new NotImplementedException();
        }

        public void findPathOneToAll(int algorithm, Node A)
        {
            throw new NotImplementedException();
        }

        public void findPathAllToAll(int algorithm)
        {
            throw new NotImplementedException();
        }

        public List<Link> returnLinkList()
        {
            return link;
        }

        public List<Node> returnNodeList()
        {
            return node;
        }
        public List<Node> getNode()
        {
            return node;
        }
        public List<Link> getLinks()
        {
            return link;
        }

    }
}
