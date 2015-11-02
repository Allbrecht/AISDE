using System;
using System.Diagnostics;

namespace AISDE1
{
    class Program
    {
        static void Main(string[] args)
        {
            String testConfiguration = "testConfiguration";
            String testOutput = "testOutput";
            int[] testVariables = new int[4];

            FileGetter fg = new FileGetter();
            testVariables = fg.readInt(testConfiguration);

            FileMaker fm = new FileMaker(testOutput);
            fm.writeString("List time: " + testList(testVariables[0], testVariables[1], testVariables[2], testVariables[3], testVariables[4]));
            fm.writeString("Heap time: " + testHeap(testVariables[0], testVariables[1], testVariables[2], testVariables[3], testVariables[4]));

            fm.close();

        }

        public static String testList(int lengthA, int lenghtB, int rangeA, int rangeB, int size)
        {
            int insertArrayLength = lengthA;
            int removeAndInsertArrayLength = lenghtB;
            int insertRange = rangeA;
            int removeAndInsertRange = rangeB;

            Element[] elementM = new Element[insertArrayLength];
            Element[] elementN = new Element[removeAndInsertArrayLength];
            Random rnd = new Random();
            int tmp = 0;
            while (tmp < insertArrayLength)
            {
                elementM[tmp] = new Element(rnd.Next(1, insertRange + 1));
                tmp++;
            }

            tmp = 0;
            while (tmp < removeAndInsertArrayLength)
            {
                elementN[tmp] = new Element(rnd.Next(1, removeAndInsertRange + 1));
                tmp++;
            }

            Stopwatch watch = new Stopwatch();
            watch.Start(); //czy tutaj włączyć czy przy inicjalizacji randomów?
            UnorderedList list = new UnorderedList(size);

            for (tmp = 0; tmp < insertArrayLength; tmp++)
            {
                list.insert(elementM[tmp]);
            }
            tmp = 0;
            while (tmp < removeAndInsertArrayLength)
            {

                list.deleteMin();
                list.insert(elementN[tmp]);
                tmp++;
            }
            watch.Stop();
            Console.WriteLine("List " + watch.Elapsed);
            //Console.ReadKey();
            return watch.Elapsed.ToString();
        }
        public static String testHeap(int lengthA, int lenghtB, int rangeA, int rangeB,int size)
        {
            int insertArrayLength = lengthA;
            int removeAndInsertArrayLength = lenghtB;
            int insertRange = rangeA;
            int removeAndInsertRange = rangeB;

            Element[] elementM = new Element[insertArrayLength];
            Element[] elementN = new Element[removeAndInsertArrayLength];
            Random rnd = new Random();
            int tmp = 0;
            while (tmp < insertArrayLength)
            {
                elementM[tmp] = new Element(rnd.Next(1, insertRange + 1));
                tmp++;
            }

            tmp = 0;
            while (tmp < removeAndInsertArrayLength)
            {
                elementN[tmp] = new Element(rnd.Next(1, removeAndInsertRange + 1));
                tmp++;
            }

            Stopwatch watch = new Stopwatch();
            watch.Start(); //czy tutaj włączyć czy przy inicjalizacji randomów?
            Heap heap = new Heap(size);

            for (tmp = 0; tmp < insertArrayLength; tmp++)
            {
                heap.insert(elementM[tmp]);
            }
            tmp = 0;
            while (tmp < removeAndInsertArrayLength)
            {

                heap.deleteMin();
                heap.insert(elementN[tmp]);
                tmp++;
            }
            watch.Stop();
            Console.WriteLine("Heap " + watch.Elapsed);
            Console.ReadKey();
            return watch.Elapsed.ToString();
        }
    }
}

