
namespace AISDE1
{
    public class Element
    {
        private int key;
        private int streamSize;

        public Element()
        {
            // do nothing
        }

        //Konstruktor
        public Element(int myKey)
        {
            key = myKey;

        }
        public Element(int arrivalDate, int strSize)
        {
            key = arrivalDate;
            streamSize = strSize;
        }

        public int getKey()
        {
            return key;
        }
        public int getStreamSize()
        {
            return streamSize;
        }

    }
}
