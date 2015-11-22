using System;

namespace AISDE1
{
    public class RandExpGenerator //jednak bez singletona
    {

        private Random rnd;
        private double lambda;
        //private static RandExpGenerator randExpGenerator = null;

        //private RandExpGenerator() { } 
        public RandExpGenerator(double lmbd) 
        {
            rnd = new Random();
            lambda = lmbd;
        }

       /* public static RandExpGenerator getInstance(double lmbd)
        {
            if (null == randExpGenerator) //yoda 
            {
                randExpGenerator = new RandExpGenerator(lmbd);
            }
            return randExpGenerator;

        }*/
        public double getExpRandom()
        {
            double y = rnd.NextDouble();
            double x = Math.Log(1 - y) / (-lambda);
            return x;
        }
    }
}
