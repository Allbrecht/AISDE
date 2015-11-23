
using System;

namespace AISDE1
{
    public class Simulation
    {

        //nazwy plików
        private string simConfiguration = "simulationConfiguration";
        private string simOutput = "simOutput";

        // konfiguracyjne
        private static int numberOfVariables = 15;
        private static int numberOfOuts = 15;
        private double[] simVariables = new double[numberOfVariables];
        private double[] simulationOutputsHeap = new double[numberOfOuts];
        private double[] simulationOutputsList = new double[numberOfOuts];
        private int queueSize;
        private int channelSize;
        private int numberOfStreams = 5;




        public Simulation()
        {
            // ustawienie konfiguracji systemu

            FileGetter fg = new FileGetter();
            simVariables = fg.readDouble(simConfiguration);

            setConfiguration(simVariables);

            // symulacja właściwa

            simulationOutputsHeap = doSimulation(1);
            simulationOutputsList = doSimulation(2);

            //zapisanie wyników
            makeSimulationOutput(simulationOutputsHeap, simulationOutputsList);
            //Console.WriteLine("wcisnij klawisz");
            //Console.ReadKey();
        }

        private void setConfiguration(double[] config)
        {
            queueSize = Convert.ToInt32(simVariables[0]);
            channelSize = Convert.ToInt32(simVariables[1]);

        }
        private void makeSimulationOutput(double[] simVariablesHeap, double[] simVariablesList)
        {
            FileMaker fm = new FileMaker(simOutput);
            fm.writeString("++++HEAP++++");

            fm.writeString("ilosc utraconych elementów: " + simVariablesHeap[0]);
            fm.writeString("srednia zajętość kanału: " + simVariablesHeap[1]);
            fm.writeString("srednia zajetosc kolejki: " + simVariablesHeap[2]);
            fm.writeString("stosunek utraconych pakietów do obsłużonych str1: " + simVariablesHeap[3]);
            fm.writeString("sredni czas przebywania w systemie str1: " + simVariablesHeap[4]);
            fm.writeString("stosunek utraconych pakietów do obsłużonych str2: " + simVariablesHeap[5]);
            fm.writeString("sredni czas przebywania w systemie str2: " + simVariablesHeap[6]);
            fm.writeString("utracone str1: " + simVariablesHeap[7]);
            fm.writeString("obsluzone str1: " + simVariablesHeap[8]);
            fm.writeString("utracone str2: " + simVariablesHeap[9]);
            fm.writeString("obsluzone str2: " + simVariablesHeap[10]);

            fm.writeString("++++LIST++++");
            fm.writeString("ilosc utraconych elementów: " + simVariablesList[0]);
            fm.writeString("srednia zajętość kanału: " + simVariablesList[1]);
            fm.writeString("srednia zajetosc kolejki: " + simVariablesList[2]);
            fm.writeString("stosunek utraconych pakietów do obsłużonych str1: " + simVariablesList[3]);
            fm.writeString("sredni czas przebywania w systemie str1: " + simVariablesList[4]);
            fm.writeString("stosunek utraconych pakietów do obsłużonych str2: " + simVariablesList[5]);
            fm.writeString("sredni czas przebywania w systemie str2: " + simVariablesList[6]);
            fm.writeString("utracone str1: " + simVariablesList[7]);
            fm.writeString("obsluzone str1: " + simVariablesList[8]);
            fm.writeString("utracone str2: " + simVariablesList[9]);
            fm.writeString("obsluzone str2: " + simVariablesList[10]);



            fm.close();
        }

        private double[] doSimulation(int whichQueue) //same eventy
        {
            Stream stream1 = new Stream(Convert.ToInt32(simVariables[4]), simVariables[2], simVariables[3]);
            Stream stream2 = new Stream(Convert.ToInt32(simVariables[7]), simVariables[5], simVariables[6]);
            Stream[] streams = new Stream[numberOfStreams];
            streams[0] = stream1;
            streams[1] = stream2;

            PriorityQueue priorityQueue;
            EventQueue evQueue = new EventQueue();
            if (1 == whichQueue)
            {
                priorityQueue = new Heap(queueSize);
            }
            else
            {
                priorityQueue = new UnorderedList(queueSize);
            }

            double currentTime = 0;
            double totalTime = 1600;
            int busyChannels = 0;
            int inService = 0;
            int inQueue = 0;
            int lostElements = 0;
            int doubleToInt = 100000;

            //Zajętość systemu:
            double averageChannelOccupancySum = 0;
            double averageQueueOccupancySum = 0;
            double inSystemTime = 0;

            for (int tmp = 0; tmp < 2; tmp++)
            {
                evQueue.addEvent(EventType.Arrival, currentTime + streams[tmp].getRandDistance(), streams[tmp].getStreamSize(), tmp, currentTime);
            }
            while (currentTime < totalTime)
            {
                Event ev = new Event();
                ev = evQueue.getEvent();
                //Console.WriteLine("zdarzenie: {0} o czasie {1}, Stream {2}",ev.eventType, currentTime , ev.numberOfStream);
                inSystemTime = ev.eventTime - currentTime;//czas od ostatniego zdarzenia

                currentTime = ev.eventTime;

                averageChannelOccupancySum += inSystemTime * busyChannels / channelSize;
                averageQueueOccupancySum += inSystemTime * inQueue / queueSize;

                Element el = new Element(Convert.ToInt32((currentTime * doubleToInt) - 0.5), ev.streamSize);

                switch (ev.eventType)
                {
                    case EventType.Arrival:
                        if (busyChannels + el.getStreamSize() < channelSize)
                        {
                            //zajmij kanały
                            inService++;
                            busyChannels += el.getStreamSize();
                            evQueue.addEvent(EventType.Departure, currentTime + streams[ev.numberOfStream].getRandLength(), el.getStreamSize(), ev.numberOfStream, currentTime);
                        }
                        else if (priorityQueue.getNumberOfElements() < queueSize - 1)
                        {
                            //dodaj do kolejki
                            inQueue++;
                            priorityQueue.insert(el);
                        }
                        else
                        {
                            lostElements++;
                            streams[ev.numberOfStream].lost++;
                        }

                        evQueue.addEvent(EventType.Arrival, currentTime + streams[ev.numberOfStream].getRandDistance(), ev.streamSize, ev.numberOfStream, currentTime);
                        break;
                    case EventType.Departure:
                        inService--;
                        busyChannels -= ev.streamSize;

                        //srednie
                        streams[ev.numberOfStream].served++;
                        streams[ev.numberOfStream].inSystemTime += currentTime - ev.arrivalTime;

                        if (inQueue > 0)
                        {
                            Element element = priorityQueue.getLowest();
                            if (busyChannels + element.getStreamSize() < channelSize)
                            {
                                //zajmij kanały
                                inQueue--;
                                priorityQueue.deleteMin();
                                inService++;
                                busyChannels += element.getStreamSize();
                                evQueue.addEvent(EventType.Departure, currentTime + streams[ev.numberOfStream].getRandLength(), el.getStreamSize(), ev.numberOfStream, currentTime);
                            }
                        }
                        break;
                }


            }

            //przygotuj dane wyjściowe
            double[] outs = new double[numberOfOuts];
            outs[0] = lostElements;
            outs[1] = averageChannelOccupancySum / totalTime; //srednia zajętość kanału
            outs[2] = averageQueueOccupancySum / totalTime;//srednia zajetosc kolejki
            outs[3] = streams[0].lost / streams[1].served;//prawdopodobieństwo utraty pakietu
            outs[4] = streams[0].inSystemTime / totalTime; // sredni czas przebywania w systemie
            outs[5] = streams[1].lost / streams[1].served;
            outs[6] = streams[1].inSystemTime / totalTime; // sredni czas przebywania w systemie
            outs[7] = streams[0].lost;
            outs[8] = streams[0].served;
            outs[9] = streams[1].lost;
            outs[10] = streams[1].served;


            return outs;
        }
    }
}
