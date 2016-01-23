﻿
using System;
using System.Collections.Generic;

namespace AISDE2
{
    public class NetworkTest
    {
        public NetworkTest()
        {

            //wczytaj konfiguracje
            FileGetter fg = new FileGetter();
            int[] testVariables = new int[Variables.MAX_ARRAY_LENGTH];
            testVariables = fg.readTestConfig(Variables.CONFIG_TEST_FILE);
            //printConfig(testVariables);

            //zrób graf
            RandGenerator rnd = new RandGenerator();
            Network network = new Network();
            int numberOfLinks = testVariables[1];
            int nodeIndex = 1;
            //for(int tmp =0; tmp<Variables.A; tmp++){
            for (int tmp2 = 0; tmp2 < numberOfLinks; tmp2++)
            {
                network.addConnection(testVariables[++nodeIndex], testVariables[++nodeIndex], rnd.getRandom());
            }
            network.printNetwork();
            Dijikstra dij = new Dijikstra(network.getNode(), network.getLinks());
            List<Node> nodes = dij.findShortestPath(new Node(1));

            printPaths(nodes);
        }

        private void  printPaths (List<Node> paths)
        {
            for (int tmp = 0;tmp < paths.Count; tmp++)
            {

                Console.WriteLine(paths[tmp].getName() + " " + paths[tmp].getFlag() );
            }
            Console.ReadKey();
        }

        private void printConfig(int[] testVariables) //metoda pomocnicza
        {
            for (int tmp = 0; tmp< testVariables.Length ;tmp++)
            {
                Console.WriteLine(testVariables[tmp]);
            }
            
            Console.ReadKey();
        }
        
    }
}