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
                int lowestKey = myList[0].key;
                for (int tmp = 0; tmp < myList.Count(); tmp++) //sprawdza wszstkich po kolei
                {
                   if(lowestKey>myList[tmp].key)
                    {
                        lowestKey = myList[tmp].key;
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
