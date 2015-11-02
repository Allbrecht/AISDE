using System.Collections.Generic;
using System.Linq;


namespace AISDE1
{
    public class UnorderedList : PriorityQueue
    {
        public  List<Element> myList;
        
        //konstruktor
        public UnorderedList()
        {
            initialise();
        }

        public void deleteMin()
        {
           if(myList.Count() == 0)
            {
                //do nothing
            }
            else
            {
                int lowestKeyIndex = 0;
                int lowestKey = myList[0].getKey();
                for (int tmp = 0; tmp < myList.Count(); tmp++) //sprawdza wszstkich po kolei
                {
                   if(lowestKey>myList[tmp].getKey())
                    {
                        lowestKey = myList[tmp].getKey();
                        lowestKeyIndex = tmp;
                    }
                }
                myList.RemoveAt(lowestKeyIndex);

            }
        }

        public void initialise()
        {
            myList = new List<Element>();
        }


        public void insert(Element element)
        {
            myList.Add(element);
        }
    }
}
