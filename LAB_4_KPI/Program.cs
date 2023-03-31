using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4_KPI
{
    class Program
    {
        static void Main()
        {
            File file = new File("G:\\Programming\\LAB_4_KPI\\LAB_4_KPI\\File\\", "file");
            TextFile textFile = new TextFile("G:\\Programming\\LAB_4_KPI\\LAB_4_KPI\\File\\", "file");

            textFile.Write("Hello!");
            textFile.ReadFile();
            textFile.Write("\nMy name is Nikita.");
            textFile.ReadFile();
            textFile.Delete();
            textFile.ReadFile();
            textFile.Create("file");
            textFile.Write("BimBom");
            textFile.ReadFile();
            textFile.Rename("no file");
            textFile.ReadFile();

            Console.WriteLine("\n\n" + file.directory.Equals(textFile.directory));
            Console.WriteLine(file.directory.ToString());

            Console.WriteLine("\n\n" + file.Equals(textFile));
            Console.WriteLine(file.ToString());

            Console.WriteLine("\n\n" + textFile.Equals(file));
            Console.WriteLine(textFile.ToString());

            Console.WriteLine("\n\n" + textFile.Equals(textFile));
            Console.WriteLine(textFile.ToString());

            Console.ReadKey();
        }
    }
}
