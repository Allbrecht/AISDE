using System;
using System.IO;

namespace AISDE2
{
    /*
    Plik wejściowy 'configuration' musi być w folderze bin/DEBUG
    */
    class FileGetter
    {
        public int[] readTestConfig(String file)
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
 
            int[] testConfiguration = new int[Variables.MAX_ARRAY_LENGTH]; //dwójkami: pierwsze dwa na ilosc wezłow i łączy kolejne dwa to węzły. 

            line = sr.ReadLine();
            line = line.Substring(line.IndexOf(' '));
            testConfiguration[0] = Int32.Parse(line); //ilosc wezłow
            line = sr.ReadLine();
            line = line.Substring(line.IndexOf(' '));
            testConfiguration[1] = Int32.Parse(line); //ilosc laczy

            
            int tmp = 1;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lines = line.Split(' ');
                testConfiguration[++tmp] = Int32.Parse(lines[1]);
                testConfiguration[++tmp] = Int32.Parse(lines[2]);
            }

                sr.Close();
            return testConfiguration;

        }


    }
}
