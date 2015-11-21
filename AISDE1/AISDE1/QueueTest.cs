using System;
using System.Diagnostics;


namespace AISDE1
{


    public class QueueTest
    {
        public  QueueTest()
        {
            Console.WriteLine("Czekaj na wynik");
            string testConfiguration = "testConfiguration";
            string testOutput = "testOutput";
            int[] testVariables = new int[4];

            FileGetter fg = new FileGetter();
            testVariables = fg.readInt(testConfiguration);

            FileMaker fm = new FileMaker(testOutput);

            string list= testList(testVariables[0], testVariables[1], testVariables[2], testVariables[3], testVariables[4]);
            string heap = testHeap(testVariables[0], testVariables[1], testVariables[2], testVariables[3], testVariables[4]);

            fm.writeString("List time: " + list);
            fm.writeString("Heap time: " + heap);
            fm.close();

            Console.WriteLine("List " + list);
            Console.WriteLine("Heap " + heap);
            Console.ReadKey();
        }
        
    
    private String testList(int lengthA, int lenghtB, int rangeA, int rangeB, int size)
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
            
            return watch.Elapsed.ToString();
        }
        private String testHeap(int lengthA, int lenghtB, int rangeA, int rangeB, int size)
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
            
            return watch.Elapsed.ToString();
        }
    }
}
