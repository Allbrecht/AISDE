namespace AISDE1
{
    interface PriorityQueue
    {
        void initialise(int size);
        void insert(Element element); 
        void deleteMin();

        int getNumberOfElements();
        Element getLowest();

    }
}
