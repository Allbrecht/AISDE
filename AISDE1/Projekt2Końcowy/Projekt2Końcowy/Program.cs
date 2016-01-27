using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2Końcowy
{
    class Program
    {
        static void Main(string[] args)
        {
            Network net = new Network();
            Console.Write(net.executeNeeds());
            Console.ReadKey();
        }
    }
}
