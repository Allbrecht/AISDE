
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
        }

        private void setConfiguration(double[] config)
        {
            queueSize = Convert.ToInt32(simVariables[0]);
            channelSize = Convert.ToInt32(simVariables[1]);

        }
        private void makeSimulationOutput(double[] simVariablesHeap, double[] simVariablesList)
        {
            FileMaker fm = new FileMaker(simOutput);
            fm.writeString("lostElementsHeap " + simVariablesHeap[0]);
            fm.writeString("lostElementsList " + simVariablesList[0]);

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
            double totalTime = 160;
            int busyChannels = 0;
            int inService = 0;
            int inQueue = 0;
            int lostElements = 0;
            int doubleToInt = 100000;

            for (int tmp = 0; tmp < 2; tmp++)
            {
                evQueue.addEvent(EventType.Arrival, currentTime + streams[tmp].getRandDistance(), streams[tmp].getStreamSize(), tmp);
            }
            while (currentTime < totalTime)
            {
                Event ev = new Event();
                ev = evQueue.getEvent();
                currentTime = ev.eventTime;
                Element el = new Element(Convert.ToInt32((currentTime * doubleToInt) - 0.5), ev.streamSize);

                switch (ev.eventType)
                {
                    case EventType.Arrival:
                        if (busyChannels + el.getStreamSize() < channelSize)
                        {
                            //zajmij kanały
                            inService++;
                            busyChannels += el.getStreamSize();
                            evQueue.addEvent(EventType.Departure, currentTime + streams[ev.numberofStream].getRandLength(), el.getStreamSize(), ev.numberofStream);
                        }
                        else if (priorityQueue.getNumberOfElements() < queueSize)
                        {
                            //dodaj do kolejki
                            inQueue++;
                            priorityQueue.insert(el);
                        }
                        else
                        {
                            lostElements++;
                        }

                        evQueue.addEvent(EventType.Arrival, currentTime + streams[ev.numberofStream].getRandDistance(),ev.streamSize, ev.numberofStream);
                        break;
                    case EventType.Departure:
                        inService--;
                        busyChannels -= ev.streamSize;
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
                                evQueue.addEvent(EventType.Departure, currentTime + streams[ev.numberofStream].getRandLength(), el.getStreamSize(), ev.numberofStream);
                            }
                        }
                        break;
                }


            }
            //przygotuj dane wyjściowe
            double[] outs = new double[numberOfOuts];
            outs[0] = lostElements;

            return outs;
        }
    }
}
