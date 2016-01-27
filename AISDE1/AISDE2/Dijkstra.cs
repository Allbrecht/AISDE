using System;
using System.Collections.Generic;

namespace AISDE2
{
    internal class Dijikstra
    {
        private List<Link> links;
        private List<Node> nodes;
        private List<Path> paths;

        public Dijikstra(List<Node> nodes, List<Link> links)
        {
            this.nodes = nodes;
            this.links = links;
            paths = new List<Path>(nodes.Count);
        }

        public List<Node> findShortestPathOneToAll(Node source)
        {
            paths.Clear(); // do czyszczenia zasobów

            List<Node> S = new List<Node>(); //znajdują się wierzchołki (węzły) grafu o już ustalonej najkrótszej ścieżce ze źródła, dalej nie będą już rozpatrywane w algorytmie
            List<Node> Q = new List<Node>(); //znajdują się wierzchołki, do których „dotarł” już algorytm, ale nie możemy jeszcze określić, czy znaleziono do nich najkrótszą ścieżkę ze źródła
            int[] P = new int[nodes.Count+1]; //indeks węzła, który poprzednikiem węzła i na najkrótszej ścieżce od źródła  do i  
            for (int tmp = 0; tmp < nodes.Count; tmp++)
            {
                nodes[tmp].setFlag(Double.MaxValue);
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
                            if (node.getFlag() + links[tmp].getCost()< nodeB.getFlag())
                            {
                                nodeB.setFlag(node.getFlag() + links[tmp].getCost());
                                P[links[tmp].getB().getName()] = node.getName();
                                Q.Add(nodeB);
                            }
                        }
                    }
                }
            }
            savePaths(P, nodes, source);
            return nodes;
        }

        private void savePaths(int[] P, List<Node> nodes, Node source)
        {
            for(int tmp = 0; tmp < nodes.Count; tmp++)
            {
                Node actualNode = nodes[tmp];
                if(actualNode.getName() == source.getName())
                {
                    paths.Add(new Path(actualNode.getName(), actualNode.getName()));
                }
                
                while ((actualNode.getName() != source.getName())&&(actualNode.getName() != 0))
                {
                    try
                    {
                        paths[tmp].addLink(actualNode.getName(), P[actualNode.getName()]);
                    }
                    catch (Exception ex) //tutaj słabo rozwiązany problem 
                    {
                        paths.Add(new Path(actualNode.getName(), P[actualNode.getName()]));
                    }  
                    actualNode = nodes.Find(x => x.getName() == P[actualNode.getName()]);
                    if (null == actualNode)
                    {
                        actualNode = new Node(0);
                    }
                }
            }
        }
        public void printPaths()
        {
            Console.WriteLine(" ");
            for (int tmp = 0; tmp < paths.Count; tmp++)
            {
               List<Link> links = paths[tmp].getLinks();
                for(int tmp2 =0; tmp2<links.Count;tmp2++)
                {
                    if (0 != links[tmp2].getBName())
                    { 
                        Console.Write(links[tmp2].getAName() + "<=" + links[tmp2].getBName() + " ");
                    }
                    else
                    {
                        Console.Write(links[tmp2].getAName() +" "+ Variables.NO_PATH_INFO);
                    }
                }
                Console.WriteLine(" ");
            }
           // Console.ReadKey();
        }

        public Path findShortestPathOneToOne(Node source, Node destination)
        {
            List<Node> listNodes = findShortestPathOneToAll(source);
            Path path = null;
            for (int tmp = 0; tmp < paths.Count; tmp++)
            {
                List<Link> links = paths[tmp].getLinks();
                if (links[0].getAName() == destination.getName())
                    path = paths[tmp];

            }
            List<Link> listLink = path.getLinks();
            for(int tmp = 0; tmp < listLink.Count; tmp++)
            {
                List<Link> linkA = new List<Link>();
                for(int tmpA = 0; tmpA < links.Count; tmpA++)
                {
                    if(links[tmpA].getAName() == listLink[tmp].getBName())
                    {
                        linkA.Add(links[tmpA]);
                    }
                }
                for (int tmpB = 0; tmpB < linkA.Count; tmpB++)
                {
                    if(linkA[tmpB].getBName()== listLink[tmp].getAName())
                    {
                        listLink[tmp].setCost(linkA[tmpB].getCost());
                    }
                }
            }
            path.setLinks(listLink);
            return path;

        }
    }

}