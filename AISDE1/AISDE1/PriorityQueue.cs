namespace AISDE1
{
    interface PriorityQueue
    {
        void initialise();
        void insert(Element element); // na razie arg to int , ale później zmieni się na naszą klasę
        void deleteMin();
    }
}
