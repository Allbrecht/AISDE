



namespace AISDE1
{
    public class UnorderedList : PriorityQueue
    {
        private Element[] myArray;
        private int index;

        //konstruktor
        public UnorderedList(int size)
        {
            initialise(size);
        }

        public void deleteMin()
        {
           if(index == -1)
            {
                //do nothing
            }
            else
            {
                int lowestKeyIndex = 0;
                int lowestKey = myArray[0].getKey();
                for (int tmp = 1; tmp <= index; tmp++) //sprawdza wszstkich po kolei
                {
                   if(lowestKey> myArray[tmp].getKey())
                    {
                        lowestKey = myArray[tmp].getKey();
                        lowestKeyIndex = tmp;
                    }
                }
                myArray[lowestKeyIndex] = myArray[index];
                myArray[index] = null;
                index--;
            }
        }

        public void initialise(int size)
        {
            myArray = new Element[size];
            index = -1;
        }


        public void insert(Element element)
        {
            myArray[++index]=element;
        }
        public int getKey(int index)
        {
            return myArray[index].getKey();
        }
    }
}
