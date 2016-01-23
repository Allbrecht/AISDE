using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE2
{
    class Floyd
    {
        private List<Link> links;
        private List<Node> nodes;
        private double[,] graph;
        private double[,] shortest_paths;
        private double infinity = Double.PositiveInfinity;
        public Floyd(Network net)
        {
            links = net.returnLinkList();
            nodes = net.returnNodeList();
            graph = new double[nodes.Count+1, nodes.Count+1];
            for(int i=0; i< nodes.Count;i++)
            {
                for(int j=0; j<nodes.Count;j++)
                {
                    graph[i+1,j+1] = infinity;
                }
            }
            for(int i=0; i < links.Count; i++)
            {
                graph[links[i].getAName(), links[i].getBName()] = links[i].getCost();
            }
            shortest_paths = graph;
           // findShortestPath();
        }

       /* public void floydTest()
        {
            Console.Write("\n");
            Floyd floyd = new Floyd(network);
            floyd.writeGraph();
            Console.Write("\n");
            Console.ReadKey();
            floyd.findShortestPaths();
            floyd.writeShortestPaths();
            Console.ReadKey();

        }*/

        public void findShortestPaths()
        {
            for (int k = 1; k <= nodes.Count; k++)
            {
                for (int i = 1; i <= nodes.Count; i++)
                {
                    for (int j = 1; j <= nodes.Count; j++)
                    {
                        if (shortest_paths[i, j] > (shortest_paths[i, k] + shortest_paths[k, j]))
                        {
                            shortest_paths[i, j] = (shortest_paths[i, k] + shortest_paths[k, j]);
                        }
                    }
                }
            }
        }
        

        public void writeShortestPaths()
        {
            for(int i =0; i<= nodes.Count;i++)
            {
                for(int j=0;j<= nodes.Count;j++)
                {
                    Console.Write(Math.Round(shortest_paths[i, j], 2) + " ");
                    //Console.Write(Math.Round(graph[i, j], 2) + " ");
                }
                Console.Write("\n");
            }

        }
        public void writeGraph()
        {
            for (int i = 0; i <= nodes.Count; i++)
            {
                for (int j = 0; j <= nodes.Count; j++)
                {
                    //Console.Write(Math.Round(shortest_paths[i, j], 2) + " ");
                    Console.Write(Math.Round(graph[i, j], 2) + " ");
                }
                Console.Write("\n");
            }

        }

    }
}
