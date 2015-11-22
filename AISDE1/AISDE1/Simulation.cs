
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
        private double[] simulationOutputs = new double[numberOfOuts];
        private int queueSize;
        private int channelSize;
        private double lambdaTelLength; //długość rozmowy
        private double lambdaDistanceBetweenConnetions; //jak często przychodzą połączenia
        private int streamSize;




        public Simulation()
        {
            // ustawienie konfiguracji systemu

            FileGetter fg = new FileGetter();
            simVariables = fg.readDouble(simConfiguration);

            setConfiguration(simVariables);

            // symulacja właściwa

            simulationOutputs = doSimulation();

            //zapisanie wyników
            makeSimulationOutput(simulationOutputs);
        }

        private void setConfiguration(double[] config)
        {
            queueSize = Convert.ToInt32(simVariables[0]);
            channelSize = Convert.ToInt32(simVariables[1]);
            lambdaTelLength = simVariables[2];
            lambdaDistanceBetweenConnetions = simVariables[3];
            streamSize = Convert.ToInt32(simVariables[4]);

        }
        private void makeSimulationOutput(double[] simVariables)
        {
            FileMaker fm = new FileMaker(simOutput);
            fm.writeString("lostElements " + simVariables[0]);


            fm.close();
        }

        private double[] doSimulation() //same eventy
        {
            
            RandExpGenerator randExpGeneratorLength = new RandExpGenerator(lambdaTelLength);
            RandExpGenerator randExpGeneratorDistance = new RandExpGenerator(lambdaDistanceBetweenConnetions);
            EventQueue evQueue = new EventQueue();
            Heap heap = new Heap(queueSize);

            double currentTime = 0;
            double totalTime = 60;
            int busyChannels = 0;
            int inService = 0;
            int inQueue = 0;
            int lostElements = 0;
            int doubleToInt = 100000;

            evQueue.addEvent(EventType.Arrival, currentTime + randExpGeneratorDistance.getExpRandom());

            while (currentTime < totalTime)
            {
                Event ev = new Event();
                ev = evQueue.getEvent();
                currentTime = ev.eventTime;
                Element el = new Element(Convert.ToInt32((currentTime * doubleToInt)-0.5), streamSize);

                switch (ev.eventType)
                {
                    case EventType.Arrival:
                        if (busyChannels + el.getStreamSize() < channelSize)
                        {
                            //zajmij kanały
                            inService++;
                            busyChannels += el.getStreamSize();
                            evQueue.addEvent(EventType.Departure, currentTime + randExpGeneratorLength.getExpRandom());
                        }
                        else if (heap.getNumberOfElements() < queueSize)
                        {
                            //dodaj do kolejki
                            inQueue++;
                            heap.insert(el);
                        }
                        else
                        {
                            lostElements++;
                        }

                        evQueue.addEvent(EventType.Arrival, currentTime + randExpGeneratorDistance.getExpRandom());
                        break;
                    case EventType.Departure:
                        inService--;
                        if (inQueue > 0)
                        {
                            Element element = heap.getLowest();
                            if (busyChannels + element.getStreamSize() < channelSize)
                            {
                                //zajmij kanały
                                inQueue--;
                                heap.deleteMin();
                                inService++;
                                busyChannels += element.getStreamSize();
                                evQueue.addEvent(EventType.Departure, currentTime + randExpGeneratorLength.getExpRandom());
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
