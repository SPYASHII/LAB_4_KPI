using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4_KPI_2.Music
{
    public class Music
    {
        public string Name { get; }
        public string Performer { get; }
        public double Duration { get;}
        public int DurationInSec { get; }
        public Music(string Performer,string Name,double Duration)
        {
            if(((Duration = Math.Round(Duration,2))*100)%100 >= 60)
            {
                Duration = Math.Round(Duration + 1 - 0.60, 2);
            }
            this.Performer = Performer;
            this.Name = Name;
            this.Duration = Duration;
            DurationInSec = (int)((int)Duration * 60 + Duration * 100 % 100); 
        }
        public override string ToString()
        {
            string duration = Duration.ToString();
            if (duration.Length < 4)
                duration += "0";
            return $"{Performer} - {Name}   {duration.Replace(',',':')}";
        }
        public string Genre()
        {
            return GetType().Name;
        }
        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return GetType().Name.GetHashCode();
        }
    }
}
