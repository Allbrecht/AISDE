using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE1
{
    class Program
    {
        static void Main(string[] args)
        {
            String configuration = "configuration";
            String destination;

            FileGetter fg = new FileGetter();
            int fileNumber = fg.readInt(configuration);
            Console.WriteLine("podaj nazwe pliku");
            destination = Console.ReadLine();
            int a = 0;

            FileMaker fm = new FileMaker(destination);
            while (a < fileNumber)
            {
                fm.writeString(Convert.ToString(a));
                a++;
            }
            fm.close();
            Console.WriteLine("oki"); 
            Console.ReadKey();
        }
    }
}
