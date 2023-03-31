using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LAB_4_KPI_2.Menu
{
    class Draw
    {
        public void MainMenu(Logic.Menu selected)
        {
            Console.Clear();
            if (selected == Logic.Menu.CHECK) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Check Disk\n");
            Console.ResetColor();
            if (selected == Logic.Menu.CHECKDURATION) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Check duration of Disk\n");
            Console.ResetColor();
            if (selected == Logic.Menu.SORT) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Sort tracks by genre\n");
            Console.ResetColor();
            if (selected == Logic.Menu.FIND) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Find tracks by length\n");
            Console.ResetColor();
            if (selected == Logic.Menu.ADD) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Add Track\n");
            Console.ResetColor();
        }
        public void Duration(double duration)
        {
            Console.Clear();
            Console.WriteLine($"Disk Duration : {duration}(minutes)");
        }
        public void Sorted ()
        {
            Console.Clear();
            Console.WriteLine("Tracks sorted! (get into CheckDisk to see result)");
        }
        public void Tracks(List<Music.Music> disk)
        {
            Console.Clear();
            if (disk.Count == 0)
            {
                Console.WriteLine("No tracks founded!");
                return;
            }

            var Genre = disk[0].GetHashCode();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{disk[0].Genre()}\n");
            Console.ResetColor();

            foreach (Music.Music track in disk)
            {
                if (Genre != track.GetHashCode())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{track.Genre()}\n");
                    Console.ResetColor();
                    Genre = track.GetHashCode();
                }
                Console.WriteLine(track.ToString() + "\n");
            }
        }
        public void SelectGenre(Logic.Genre selected)
        {
            Console.Clear();
            if (selected == Logic.Genre.ROCK) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Rock\n");
            Console.ResetColor();
            if (selected == Logic.Genre.METAL) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Metal\n");
            Console.ResetColor();
            if (selected == Logic.Genre.RAP) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Rap\n");
            Console.ResetColor();
            if (selected == Logic.Genre.HIPHOP) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Hip-Hop\n");
            Console.ResetColor();
            if (selected == Logic.Genre.POP) Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Pop\n");
            Console.ResetColor();
        }
        public void TrackAdded()
        {
            Console.Clear();
            Console.WriteLine("Track added!");
        }
    }
}
