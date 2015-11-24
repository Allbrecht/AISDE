using System;

namespace AISDE1
{
    public class Heap : PriorityQueue
    {
        private Element[] myArray;
        private int index;

        //konstruktor
        public Heap(int size)
        {
            initialise(size);
        }

        public void deleteMin()
        {
            // co zrobić coś z elementem minimalnym, czy go gdzieś przekazać, czy coś innego?
            if (index > 0)
            {
                myArray[0] = myArray[index];
                myArray[index] = null;
                index--;
                pushDown(0);
            }
            else if (index == 0)
            {
                myArray[0] = null;
                index--;
            }
            else
            {
                // nie ma nic w heapie
            }
        }

        private void pushDown(int i)
        {
            int pusher = myArray[i].getKey(); //wartość element  który zsuwamy w dół
            int childIndex = 2 * i + 1;
            while (childIndex <= index)
            {
                if (myArray[childIndex + 1] != null)
                {
                    if (myArray[childIndex].getKey() > myArray[childIndex + 1].getKey())//porównaj dzieci
                    {
                        childIndex++; //index mniejszego dziecka
                    }
                }
                if (pusher > myArray[childIndex].getKey())//zamień jeśli diecko mniejsze
                {
                    Element tmp = myArray[i];
                    myArray[i] = myArray[childIndex];
                    myArray[childIndex] = tmp;
                    i = childIndex;
                    childIndex = 2 * i + 1;
                }
                else
                {
                    childIndex = index + 1;

                }
            }
        }

        public void insert(Element element)//czy tutaj obsłużyć out of array exception, żeby liczyło niezmieszczone/odrzucone elementy?
        {
            myArray[++index] = element;
            pushUp(index);
        }

        private void pushUp(int i)
        {
            while (i > 0 && myArray[i].getKey() < myArray[(i-1) / 2].getKey())
            {
                Element tmp = myArray[i];
                myArray[i] = myArray[((i-1) / 2)];
                myArray[(i-1) / 2] = tmp;
                i = (i - 1) / 2;
            }
        }

        public void initialise(int size)
        {
            myArray = new Element[size];
            index = -1; // żeby zaczynać wypełnianie array od zerowego miejsca 
 
        }

       
        public int getKey(int index)
        {
            return myArray[index].getKey();
        }
        public int getNumberOfElements()
        {
            return index+1; 
        }
        public Element getLowest()
        {
            return myArray[0];
        }

    }
}
