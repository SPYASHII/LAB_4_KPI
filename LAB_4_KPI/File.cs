using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB_4_KPI
{
    class File
    {
        public Directory directory;
        private protected string Name { get; set; }

        public File(string path, string name)
        {
            directory = new Directory(path);
            Create(name);
        }

        public virtual void Create (string name)
        {
            if (Name == null)
            {
                Delete(name);

                System.IO.File.Create(directory.Path + name).Close();
                Name = name;
            }
            Console.WriteLine("void Create();");
        }
        public virtual void Rename(string name)
        {
            Delete(name);

            System.IO.File.Move(directory.Path + Name, directory.Path + name);
            Name = name;

            Console.WriteLine("void Rename();");
        }
        public void Delete()
        {
            if (System.IO.File.Exists(directory.Path + Name))
                System.IO.File.Delete(directory.Path + Name);
            Name = null;

            Console.WriteLine("void Delete();");
        }
        private void Delete(string name)
        {
            if (System.IO.File.Exists(directory.Path + name))
                System.IO.File.Delete(directory.Path + name);

            Console.WriteLine("void Delete() in class;");
        }
        public override bool Equals(object obj)
        {
            if (obj is File)
            return GetHashCode() == obj.GetHashCode();
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + directory.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
