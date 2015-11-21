
namespace AISDE1
{
    public class Simulation
    {
        
        public Simulation()
        {
            // ustawienie konfiguracji systemu
            string simConfiguration = "simulationConfiguration";
            string simOutput = "simOutput";

            FileGetter fg = new FileGetter();
            double[] simVariables = new double[15];
            simVariables = fg.readDouble(simConfiguration);

            FileMaker fm = new FileMaker(simOutput);

            // simulacja właściwa

            RandExpGenerator regen = RandExpGenerator.getInstance(simVariables[0]);
            fm.writeString(regen.getExpRandom().ToString());
            fm.close();
        }
    }
}
