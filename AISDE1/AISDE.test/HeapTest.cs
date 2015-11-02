using AISDE1;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AISDE.test
{
    [TestClass]
    public class HeapTest
    {
        Heap heap = new Heap(7);
        Element element0 = new Element(0);
        Element element1 = new Element(1);
        Element element2 = new Element(2);
        Element element3 = new Element(3);
        Element element4 = new Element(4);
        Element element5 = new Element(5);

        [TestMethod]
        public void insertTest()
        {
            heap.insert(element4);
            Assert.AreEqual(4, heap.getKey(0));
            heap.insert(element1);
            Assert.AreEqual(1, heap.getKey(0));
            Assert.AreEqual(4, heap.getKey(1));
            heap.insert(element2);
            heap.insert(element3);
            heap.insert(element4);
            heap.insert(element3);
            heap.insert(element0);
            Assert.AreEqual(0, heap.getKey(0));


        }
        [TestMethod]
        public void deleteMinTest()
        {
            heap.insert(element4);
            heap.insert(element1);
            heap.insert(element2);
            heap.insert(element3);
            heap.insert(element4);
            heap.insert(element3);
            heap.insert(element0);
            heap.deleteMin();
            Assert.AreEqual(1, heap.getKey(0));
            //Assert.AreEqual(null, heap.getKey(7));
        }
    }
}
