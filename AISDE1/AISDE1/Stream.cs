using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AISDE1
{
    class Stream
    {
        private int streamName;
        private int streamSize;
        private static int streamNumber = 0;
        private RandExpGenerator randExpGeneratorLength;
        private RandExpGenerator randExpGeneratorDistance;

        public Stream(int f_streamSize, double f_lambdaTelLength, double f_lambdaDistanceBetweenConnetions)
        {
            streamSize = f_streamSize;
            randExpGeneratorLength = new RandExpGenerator(f_lambdaTelLength);
            randExpGeneratorDistance = new RandExpGenerator(f_lambdaDistanceBetweenConnetions);
            Interlocked.Increment(ref streamNumber);
            streamName = streamNumber;
        }
        public double getRandLength()
        {
            return randExpGeneratorLength.getExpRandom();
        }
        public double getRandDistance()
        {
            return randExpGeneratorDistance.getExpRandom();
        }
        public int getStreamSize()
        {
            return streamSize;
        }

    }
}
