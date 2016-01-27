using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt2Końcowy
{
    class Network
    {
        private const string NETWORK_CONFIG_FILENAME = "siec_input.txt"; 
        public List<Node> nodes = new List<Node>();
        public List<Need> needs = new List<Need>();
        Dictionary<Node, Dictionary<Node, Link>> links = new Dictionary<Node, Dictionary<Node, Link>>();

        public Node findNode(int id)
        {
            foreach (Node n in nodes)
                if (n.returnId() == id)
                    return n;
            return null;
        }
        public void addNeed(Need n)
        {
            needs.Add(n);
        }
        public void addNode(Node n)
        {
            nodes.Add(n);
            links.Add(n, new Dictionary<Node, Link>());
        }
        public void addLink(Link link1)
        {
            links[link1.returnInitialNode()][link1.returnTerminalNode()] = link1; //skierowane
            //Links[link1.returnTerminalNode()][link1.returnInitialNode()] = link1;
        }
        public Dictionary<Node, Dictionary<Node, Link>> returnLinks()
        {
            return links;
        }
        public List<Node> returnNodes()
        {
            return nodes;
        }
        public Network()
        {
            readNetworkConfiguration();
            setRandomCapacities();
        }
        public void readNetworkConfiguration(string filename = NETWORK_CONFIG_FILENAME)
        {
            StreamReader file = new StreamReader(filename);
            string line;
            string[] words;
            //odczytywanie i tworzenie węzłów
            line = file.ReadLine();
            words = line.Split(' ');
            int nodes_number = int.Parse(words[2]);
            for (int id1 = 1; id1 <= nodes_number; id1++)
                addNode(new Node(id1));
            //Console.WriteLine("Liczba wezlow = " + nodes_number);
            
            //odczytywanie i tworzenie łączy
            line = file.ReadLine();
            words = line.Split(' ');
            int links_number = int.Parse(words[2]);
            //Console.WriteLine("Liczba laczy = " + links_number);
            file.ReadLine();
            
            for (int i = 1; i <= links_number; i++)
            {
                line = file.ReadLine();
                words = line.Split(' ');
                int link_id = int.Parse(words[0]);
                int initial_node_id = int.Parse(words[1]);
                int terminal_node_id = int.Parse(words[2]);
                double capacity1 = double.Parse(words[3].Replace('.', ','));
                double unit_cost1 = double.Parse(words[4].Replace('.', ','));
                //Console.WriteLine(link_id + " " + initial_node_id + " " + terminal_node_id + " " + capacity1 + " " + unit_cost1);

                Link link = new Link(link_id);
                link.setInitialNode(findNode(initial_node_id));
                link.setTerminalNode(findNode(terminal_node_id));
                link.setCapacity(capacity1);
                link.setUnitCost(unit_cost1);
                addLink(link);
            }
            //odczytywanie i tworzenie zapotrzebowań
            line = file.ReadLine();
            words = line.Split(' ');
            int needs_nuber = int.Parse(words[2]);
            file.ReadLine();
            ///Console.WriteLine("Liczba zapotrzebowan = " + needs_nuber);
            
            for (int i = 1; i <= needs_nuber; i++)
            {
                line = file.ReadLine();
                words = line.Split(' ');
                int need_id = int.Parse(words[0]);
                int initial_node_id = int.Parse(words[1]);
                int terminal_node_id = int.Parse(words[2]);
                double size1 = double.Parse(words[3].Replace('.', ','));
                //Console.WriteLine(need_id + " " + initial_node_id + " " + terminal_node_id + " " + size1);
               
                Need need = new Need(need_id);
                need.setInitialNode(findNode(initial_node_id));
                need.setTerminalNode(findNode(terminal_node_id));
                need.setSize(size1);
                addNeed(need);
            }

            file.Close();
        }

        public void setRandomCapacities()
        {
            Random random = new Random();

            foreach(Node n1 in returnLinks().Keys)
            {
                foreach(Node n2 in returnLinks()[n1].Keys)
                {
                    //if(n1.returnId() <= n2.returnId())//dla skierowanych?
                    //{
                        double capacity1 = random.NextDouble();
                        returnLinks()[n1][n2].setCapacity(capacity1);
                        //returnLinks()[n2][n1].setCapacity(capacity1);//tu jak?
                    //}
                }
            }
        }
        class ExecutedNeed
        {
            public Need need;
            public Path path;
        }
        public string executeNeeds()
        {
            List<Need> needs_queue = new List<Need>();
            needs_queue.AddRange(needs);
            List<ExecutedNeed> executed_needs_queue = new List<ExecutedNeed>();
            double cost = 0;

            //int samples = 1000;
            while(needs_queue.Count > 0)
            {
                Need n = needs_queue[0];
                needs_queue.RemoveAt(0);
                
                List<Link> links_list = new List<Link>();
                foreach(Node n1 in links.Keys)
                    foreach(Node n2 in links[n1].Keys)
                    {
                        links_list.Add(links[n1][n2]);
                    }
                Dijikstra dij = new Dijikstra(nodes, links_list);
                //Floyd flo = new Floyd(nodes, links_list);
                Path best_path = new Path();
                //best_path = flo.returnShortestPathFromAtoB(n.returnInitialNode().returnId(), n.returnTerminalNode().returnId());
                best_path = dij.findShortestPathOneToOne(n.returnInitialNode(), n.returnTerminalNode());
                //capacities to path
                //for(int i = 0; i < best_path.returnLinksList().Count; i++)
                //{
                    
          
                //    int a = best_path.returnLinksList()[i].returnInitialNode().returnId();
                //    int b = best_path.returnLinksList()[i].returnTerminalNode().returnId();
                //    //Node A = best_path.returnLinksList()[i].returnInitialNode();
                //    //Node B = best_path.returnLinksList()[i].returnTerminalNode();
                //    //Link x;
                //    //x= links[A][B];
                //    Dictionary<Node, Link> x = links[findNode(a)];
                //    Link y = x[findNode(b)];
                //    best_path.returnLinksList()[i].setCapacity(y.returnCapacity());
                    
                //}

                foreach(Link l in best_path.links_list_in_path)
                {
                    while((l.returnCapacity()) < n.returnSize())
                    {
                        l.incrementNumberOfModules();
                        l.setCapacity(l.returnCapacity()*l.returnNuberOfModules());
                    }
                }
                foreach(Link l in best_path.links_list_in_path)
                {
                    cost += l.returnNuberOfModules()*l.returnUnitCost();
                    l.setCapacity(l.returnCapacity()-n.returnSize());
                }
                ExecutedNeed en1 = new ExecutedNeed();
                en1.need = n;
                en1.path = best_path;
                executed_needs_queue.Add(en1);

            }

            string results = "";
            results += "#koszt rozwiązania\n";
            results += ("KOSZT = " + cost + "\n");
            results += "#liczba zapotrzebowan\n";
            results += ("ZAPOTRZEBOWANIA = " + executed_needs_queue.Count()) + "\n";
            results += "# kazde zapotrzebowanie to id. zapotrzebowania oraz zbior uzytych krawedzi\n";
            foreach(ExecutedNeed en in executed_needs_queue)
            {
                results += (en.need.returnId() + " ");
                for(int i=0; i<en.path.links_list_in_path.Count;i++)
                {
                    results += (en.path.links_list_in_path[i].returnId() + " ");
                }
            }
            //ile łączy itd.
            int k=0;
            int []mod = new int[20];
            foreach(ExecutedNeed en in executed_needs_queue)
            {
                foreach(Link ln in en.path.links_list_in_path)
                {
                    if(k<ln.returnId())
                    k = ln.returnId();
                    mod[ln.returnId()] += ln.returnNuberOfModules();
                }
            }
            results += ("\n#liczba krawedzi\n");
            results += ("LACZA = " + k + "\n");
            results += "#kazde lacze to: id, liczba zainstalowanych modulow przepustowosci\n";
            for (int i = 1; i <= k;i++ )
            {
                results += (i + " ");
                results += (mod[i]+"\n");
            }
                results += "";


            return results;
        }
        public Network returnRemainingNetwork(double flow)
        {
            Network network = new Network();
            foreach (Node n in nodes)
                network.addNode(n);

            int id1 = 1;
            foreach(Node n1 in links.Keys)
                foreach(Node n2 in links[n1].Keys)
                {
                    if(links[n1][n2].returnCapacity() >= flow)
                    {
                        Link l1 = new Link(id1++);
                        l1.setInitialNode(n1);
                        l1.setTerminalNode(n2);
                        l1.setCapacity(links[n1][n2].returnCapacity() - flow);
                        l1.setUnitCost(links[n1][n2].returnUnitCost());

                        network.addLink(l1);
                    }
                }
            return network;
        }
    }
}
