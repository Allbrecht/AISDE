
using System;

namespace AISDE1
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueueTest qt = new QueueTest();
            RandExpGenerator regen = RandExpGenerator.getInstance(5);
            Console.WriteLine(regen.getExpRandom());
            Console.ReadKey();
        }        
    }
}

