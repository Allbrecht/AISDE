

using System;

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


        }

        private void printConfig(int[] testVariables)
        {
            for (int tmp = 0; tmp< testVariables.Length ;tmp++)
            {
                Console.WriteLine(testVariables[tmp]);
            }
            
            Console.ReadKey();
        }
        
    }
}