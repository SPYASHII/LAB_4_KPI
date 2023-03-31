using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4_KPI
{
    class Directory
    {
        public string Path { get; }

        public Directory(string path)
        {
            Path = path;
        }
        public override bool Equals(object obj)
        {
            if(obj is Directory)
            return GetHashCode() == obj.GetHashCode();
            return false;
        }
        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
