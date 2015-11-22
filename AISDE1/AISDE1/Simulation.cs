
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
        private double[] simVariables = new double[numberOfVariables];

        private int queueLength;
        private int channelSize;
        private double lambdaTelLength; //długość rozmowy
        private double lambdaDistanceBetweenConnetions; //jak często przychodzą połączenia
        private int streamSize;

        //symulacyjne
        private int currentTime = 0;
        private int totalTime = 60;
        private int inService= 0;
        private int inQueue= 0;

        public Simulation()
        {
            // ustawienie konfiguracji systemu

            FileGetter fg = new FileGetter();
            simVariables = fg.readDouble(simConfiguration);

            setConfiguration(simVariables);

            // symulacja właściwa
            
            doSimulation();

            //zapisanie wyników
            makeSimulationOutput(simVariables);
        }

        private void setConfiguration(double[] config)
        {
            queueLength = Convert.ToInt32(simVariables[0]);
            channelSize = Convert.ToInt32(simVariables[1]);
            lambdaTelLength = simVariables[2];
            lambdaDistanceBetweenConnetions = simVariables[3];
            streamSize = Convert.ToInt32(simVariables[4]);

        }
        private void makeSimulationOutput(double[] simVariables/*, int[] heapOuts, int[] listOuts*/)
        {
            FileMaker fm = new FileMaker(simOutput);
            fm.writeString("lambdaTelLength " + simVariables[0]);


            fm.close();
        }

        private void doSimulation()
        {
            TelephoneExchange telExchange = new TelephoneExchange(queueLength, channelSize);
            RandExpGenerator randExpGeneratorLength = new RandExpGenerator(lambdaTelLength);
            RandExpGenerator randExpGeneratorDistance = new RandExpGenerator(lambdaDistanceBetweenConnetions);

            //while (currentTime < totalTime)
            //{




               
            //}
        }
    }
}
