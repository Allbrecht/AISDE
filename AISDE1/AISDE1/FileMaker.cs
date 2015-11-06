using System;
using System.IO;


namespace AISDE1
{
    /*
    Plik wyjściowy ląduje w folderze bin/DEBUG
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
