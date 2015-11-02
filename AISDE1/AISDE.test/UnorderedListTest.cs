using AISDE1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AISDE.test
{
    [TestClass]
    public class UnorderedListTest
    {
        UnorderedList list = new UnorderedList();
        Element element0 = new Element(5);
        Element element1 = new Element(1);
        Element element2 = new Element(2);
        Element element3 = new Element(3);

        [TestMethod]
        public void TestMethod1()
        {

            list.insert(element0);
            list.insert(element1);
            list.insert(element2);
            list.insert(element3);
            list.deleteMin();
            //Assert.Equals(null, list.myList[3]); 
            Assert.AreEqual(3, list.myList[2].getKey());
        }
    }
}
