using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB_4_KPI
{
    class TextFile : File
    {
        public TextFile(string path, string name) : base(path, name) { }

        public void Write(string text)
        {
            if (Name != null)
            {
                string oldtext = System.IO.File.ReadAllText(directory.Path + Name);
                System.IO.File.WriteAllText(directory.Path + Name, oldtext + text);
            }
            Console.WriteLine("void Write();");
        }
        public void ReadFile()
        {
            if(Name != null)
            System.Console.WriteLine(System.IO.File.ReadAllText(directory.Path + Name));

            Console.WriteLine("void ReadFile();");
        }
        public override void Create(string name)
        {
            base.Create(name + ".txt");
        }
        public override void Rename(string name)
        {
            base.Rename(name + ".txt");
        }
    }
}
