using System;
using System.Collections.Generic;

namespace AISDE2
{
    internal class Dijikstra
    {
        private List<Link> links;
        private List<Node> nodes;

        public Dijikstra(List<Node> nodes, List<Link> links)
        {
            this.nodes = nodes;
            this.links = links;
        }

        public List<Node> findShortestPath(Node source)
        {
            List<Node> S = new List<Node>(); //znajdują się wierzchołki (węzły) grafu o już ustalonej najkrótszej ścieżce ze źródła, dalej nie będą już rozpatrywane w algorytmie
            List<Node> Q = new List<Node>(); //znajdują się wierzchołki, do których „dotarł” już algorytm, ale nie możemy jeszcze określić, czy znaleziono do nich najkrótszą ścieżkę ze źródła
            int[] P = new int[nodes.Count+1]; //indeks węzła, który poprzednikiem węzła i na najkrótszej ścieżce od źródła  do i  
            for (int tmp = 0; tmp < nodes.Count; tmp++)
            {
                nodes[tmp].setFlag(Int32.MaxValue);
                P[tmp] = 0;
            }
            Q.Add(source);
            for (int tmp = 0; tmp < nodes.Count; tmp++)
            {
                if (nodes[tmp].getName() == source.getName())
                {
                    nodes[tmp].setFlag(0);
                }
            }
            
            
            while (Q.Count != 0)
            {
                //wybierz ze zbioru Q wierzchołek o indeksie i, dla którego wartość D[i] będzie najmiejsza.  
                double minValue = Double.MaxValue;
                int minIndex = -1;
                for (int tmp = 0; tmp < Q.Count; tmp++)
                {
                    if (Q[tmp].getFlag() < minValue)
                    {
                        minValue = Q[tmp].getFlag();
                        minIndex = tmp;
                    }
                }
                S.Add(Q[minIndex]);
                Node node = Q[minIndex];
                Q.RemoveAt(minIndex);
                

                for( int tmp = 0; tmp < links.Count; tmp++)
                {
                    if(links[tmp].getAName() == node.getName())
                    {
                        if (!S.Contains(links[tmp].getB()))
                        {

                            Node nodeB = nodes.Find(x => x.getName() == links[tmp].getB().getName());
                            if (node.getFlag() + links[tmp].getCost()< nodeB.getFlag())//parts.Find(x => x.PartName.Contains("seat")));
                            {
                                nodeB.setFlag(node.getFlag() + links[tmp].getCost());
                                P[links[tmp].getB().getName()] = node.getName();
                                Q.Add(nodeB);
                            }
                        }
                    }
                }
            }
            return nodes;
        }

        internal Path findBigestPath()
        {
            throw new NotImplementedException();
        }
    }
}