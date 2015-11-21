using System;

namespace AISDE1
{
    public class RandExpGenerator //with singleton Pattern
    {
        //tą klase tworzy się przez getInstance(param) 

        private Random rnd;
        private double lambda;
        private static RandExpGenerator randExpGenerator = null;

        private RandExpGenerator() { } // koniecznie private
        private RandExpGenerator(double lmbd) // koniecznie private
        {
            rnd = new Random();
            lambda = lmbd;
        }

        public static RandExpGenerator getInstance(double lmbd)
        {
            if (null == randExpGenerator)
            {
                randExpGenerator = new RandExpGenerator(lmbd);
            }
            return randExpGenerator;

        }
        public double getExpRandom()
        {
            double y = rnd.NextDouble();
            double x = Math.Log(1 - y) / (-lambda);
            return x;
        }
    }
}
