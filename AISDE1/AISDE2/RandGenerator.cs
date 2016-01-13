using System;

namespace AISDE2
{
    public class RandGenerator 
    {

        private Random rnd;
        private double lambda;
        
        public RandGenerator(double lmbd) 
        {
            rnd = new Random();
            lambda = lmbd;
        }

       
        public double getRandom()
        {
            return rnd.NextDouble();
        }
    }
}
