﻿using System;
using System.IO;

namespace AISDE1
{
    /*
    Plik wejściowy 'configuration' musi być w folderze bin/DEBUG
    */
    class FileGetter
    {
        public int[] readInt(String file)
        {
            file += ".txt";
            StreamReader sr = null;

            //filenotfoundxeception nie obsłużony
            sr = new StreamReader(file);
            String line = "";
            int index = 0;
            int tmp = 0;
            int[] testConfiguration = new int[4]; // Tutaj iczba argumentów z pliku (TRZa to będzie zmienić?
            while ((line = sr.ReadLine())!= null)
            {
                index = line.IndexOf(' '); // wyszukuje index pierwszej spacji w stringu
                line = line.Substring(index);
                
                testConfiguration[tmp] = Int32.Parse(line);
                tmp++;
                line = "";
            }
            
            sr.Close();
            return testConfiguration;



        }


    }
}
