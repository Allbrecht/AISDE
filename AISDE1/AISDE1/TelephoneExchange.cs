
using System.Collections.Generic;

namespace AISDE1
{
    class TelephoneExchange
    {
        private Heap heap;
        //UnorderedList unorderedList;

        private int numberOfChannels;
        private int queueSize;
        List<Element> channelsList;

        private int lostElements = 0;
        public TelephoneExchange(int qSize, int channels)
        {

            queueSize = qSize;
            heap = new Heap(queueSize);
            numberOfChannels = channels;

        }

        public void addEvent(Element element)
        {
            if (channelsList.Count < numberOfChannels)
            {
                //zajmij kanały
                int streamSize = element.getStreamSize();
                for (int tmp = 0; tmp < streamSize; tmp++)
                {
                    channelsList.Add(element);
                }

            }
            else if (heap.getNumberOfElements() < queueSize)
            {
                //dodaj do kolejki
                heap.insert(element);
            }
            else
            {
                lostElements++;
            }
        }
    }
}
