using AISDE1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AISDE.test
{
    [TestClass]
    public class ExpGeneratorTest
    {
        [TestMethod]
        public void expTest()
        {
            RandExpGenerator regen = RandExpGenerator.getInstance(0.5);
            int[] licznik = new int[10];
            foreach (int el in licznik)
            {
                licznik[el] = 0;
            }
            for (int tmp = 0; tmp < 10000; tmp++)
            {
                int x = Convert.ToInt32(regen.getExpRandom() - 0.5);


                switch (x)
                {
                    case 0:
                        licznik[0]++;
                        break;
                    case 1:
                        licznik[1]++;
                        break;
                    case 2:
                        licznik[2]++;
                        break;
                    case 3:
                        licznik[3]++;
                        break;
                    case 4:
                        licznik[4]++;
                        break;
                    case 5:
                        licznik[5]++;
                        break;
                    case 6:
                        licznik[6]++;
                        break;
                    case 7:
                        licznik[7]++;
                        break;
                    default:
                        licznik[8]++;
                        break;

                }
            }
            Assert.AreEqual(true, licznik[0]>licznik[1]);
            Assert.AreEqual(true, licznik[1] > licznik[2]);
            Assert.AreEqual(true, licznik[2] > licznik[3]);
            Assert.AreEqual(true, licznik[3] > licznik[4]);
            Assert.AreEqual(true, licznik[4] > licznik[5]);
            Assert.AreEqual(true, licznik[5] > licznik[6]);

        }
    }
}
