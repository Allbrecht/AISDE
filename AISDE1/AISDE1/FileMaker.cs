using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE1
{
    /*
    Plik wyjściowy ląduje w folderze bin
    */
    class FileMaker
    {
       
        private StreamWriter sw;



        public FileMaker(String file)
        {
            file += ".txt";
            sw = new StreamWriter(@file);
        }
        public void writeString(string number)
        { 
                sw.WriteLine(number);

        }
        public void close()
        {
            sw.Close();
      
        }
    }
}
