
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AISDE2
{
    public class NetworkTest
    {
        public NetworkTest()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine(Variables.START_INFO);
            //wczytaj konfiguracje
            FileGetter fg = new FileGetter();
            int[] testVariables = new int[Variables.MAX_ARRAY_LENGTH];
            testVariables = fg.readTestConfig(Variables.CONFIG_TEST_FILE);
            //printConfig(testVariables);

            //zrób graf
            RandGenerator rnd = new RandGenerator();

            for (int tmp = 0; tmp < Variables.A; tmp++)
            {
                Network network = null;
                int numberOfLinks = testVariables[1];
                int nodeIndex = 1;

                network = new Network();
                for (int tmp2 = 0; tmp2 < numberOfLinks; tmp2++)
                {
                    network.addConnection(testVariables[++nodeIndex], testVariables[++nodeIndex], rnd.getRandom());//
                }
                //network.printNetwork();

                //Dijkstra
                Dijikstra dij = new Dijikstra(network.getNode(), network.getLinks());
                List<Node> nodes = dij.findShortestPathOneToAll(new Node(Variables.nodeSource));

                //printNodes(nodes);
                // dij.printPaths();
                Console.ReadKey();
                Path path = dij.findShortestPathOneToOne(new Node(Variables.nodeSource), new Node(Variables.nodeDestination));
                List<Link> links = path.getLinks();
                path.writePath();
                for (int tmp3 = 0; tmp3 < links.Count; tmp3++)
                {
                    Console.WriteLine(links[tmp3].getCost());
                }
                Console.ReadKey();
                //Kruskal
                
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed.ToString());
            Console.ReadKey();
            
            //zapisanie wyników
            FileMaker fm = new FileMaker(Variables.TEST_FILE_OUT);
            fm.writeString("całkowity czas: ");
            fm.writeString(watch.Elapsed.ToString());
            fm.close();
            
        }

        

        private void  printNodes (List<Node> nodes)
        {
            for (int tmp = 0;tmp < nodes.Count; tmp++)
            {
                if (Double.MaxValue != nodes[tmp].getFlag())
                {
                    Console.WriteLine(nodes[tmp].getName() + " " + nodes[tmp].getFlag());
                }
                else
                {
                    Console.WriteLine(nodes[tmp].getName() + " "+ Variables.NO_PATH_INFO); 
                }
            }
           // Console.ReadKey();
        }

        private void printConfig(int[] testVariables) //metoda pomocnicza
        {
            for (int tmp = 0; tmp< testVariables.Length ;tmp++)
            {
                Console.WriteLine(testVariables[tmp]);
            }
            
           // Console.ReadKey();
        }
        
    }
}