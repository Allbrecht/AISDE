using System;
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



            //filenotfoundxeception nie obsłużony
            string dir = Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location);
            dir = Directory.GetParent(dir).FullName;
            dir = Directory.GetParent(dir).FullName; // dwa razy bo cofamy się o dwa foldery do tyłu
            file = dir + @"\config\" + file;
            StreamReader sr = new StreamReader(file);
            String line = "";
            int index = 0;
            int tmp = 0;
            int[] testConfiguration = new int[5]; // Tutaj iczba argumentów z pliku (TRZa to będzie zmienić?
            while ((line = sr.ReadLine()) != null)
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
