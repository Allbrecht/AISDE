using System;

namespace AISDE2
{
    public class RandGenerator 
    {

        private Random rnd;
        
        public RandGenerator() 
        {
            rnd = new Random();
            
        }

       
        public double getRandom()
        {
            return rnd.NextDouble();
        }
    }
}
