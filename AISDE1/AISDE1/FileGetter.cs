using System;
using System.IO;

namespace AISDE1
{
    /*
    Plik wejściowy 'configuration' musi być w folderze bin/DEBUG
    */
    class FileGetter
    {
        public int readInt(String file)
        {
            file += ".txt";
            StreamReader sr = null;

            //filenotfoundxeception nie obsłużony
            sr = new StreamReader(file);
            int firstNumber = Int32.Parse(sr.ReadLine());
            sr.Close();
            return firstNumber;



        }


    }
}
