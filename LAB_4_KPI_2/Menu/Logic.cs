using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace LAB_4_KPI_2.Menu
{
    class Logic
    {
        private string path = "G:\\Programming\\LAB_4_KPI\\LAB_4_KPI_2\\DiskJson\\";
        private List<Music.Music> disk = new List<Music.Music>();
        private double DiskDurationMin { get; set; }

        Input input = new Input();
        Draw draw = new Draw();

        public enum Menu { CHECK, CHECKDURATION, SORT, FIND, ADD};
        private Menu selected;
        public enum Genre { ROCK, METAL, RAP, HIPHOP, POP};
        private Genre selectedGenre;

        private bool exit = true;
        private bool enter = false;
        private bool shutDown = false;

        public void Start()
        {
            LoadJsonDisk();
            CountDuration();
            while (!shutDown)
            {
                if (enter == false)
                    draw.MainMenu(selected);
                else
                {
                    switch (selected)
                    {
                        case Menu.CHECK:
                            draw.Tracks(disk);
                            break;
                        case Menu.CHECKDURATION:
                            draw.Duration(DiskDurationMin);
                            break;
                        case Menu.FIND:
                            draw.Tracks(FindByLength());
                            break;
                        case Menu.SORT:
                            SortByGenre();
                            draw.Sorted();
                            break;
                        case Menu.ADD:
                            enter = false;
                            exit = true;
                            while (exit)
                            {
                                if (enter == false)
                                    draw.SelectGenre(selectedGenre);
                                else
                                {
                                    AddTrack(selectedGenre);
                                    draw.TrackAdded();
                                    break;
                                }
                                input.Key(ref selectedGenre, ref selected, ref enter, ref shutDown, ref exit);
                            }
                            CountDuration();
                            break;
                    }
                    while(enter == true)
                    {
                        input.Key(ref selectedGenre,ref selected, ref enter, ref shutDown, ref exit);
                    }
                    continue;
                }
                input.Key(ref selectedGenre,ref selected, ref enter, ref shutDown, ref exit);
            }
            SerializeDisk();
        }
        private void SerializeDisk()
        {
            string rap = path + "Rap\\";
            string hipHop = rap + "HipHop\\";
            string pop = path + "Pop\\";
            string rock = path + "Rock\\";
            string metal = rock + "Metal\\";
            string _path;
            foreach (var track in disk)
            {
                switch (track.GetType().Name)
                {
                    case "Rap":
                        _path = rap;
                        break;
                    case "Rock":
                        _path = rock;
                        break;
                    case "HipHop":
                        _path = hipHop;
                        break;
                    case "Pop":
                        _path = pop;
                        break;
                    case "Metal":
                        _path = metal;
                        break;

                    default:
                        _path = path;
                        break;
                }
                File.WriteAllText($"{_path}{Regex.Replace(track.ToString(), @"[\/:*?<>|]+", "_")}.json", JsonSerializer.Serialize(track));
            }
        }
        private void LoadJsonDisk()
        {
            string rap = path + "Rap\\";
            string hipHop = rap + "HipHop\\";
            string pop = path + "Pop\\";
            string rock = path + "Rock\\";
            string metal = rock + "Metal\\";

            foreach (string file in Directory.EnumerateFiles(rap, "*.json"))
            {
                disk.Add(JsonSerializer.Deserialize<Music.Rap>(File.ReadAllText(file)));
            }
            foreach (string file in Directory.EnumerateFiles(hipHop, "*.json"))
            {
                disk.Add(JsonSerializer.Deserialize<Music.HipHop>(File.ReadAllText(file)));
            }
            foreach (string file in Directory.EnumerateFiles(pop, "*.json"))
            {
                disk.Add(JsonSerializer.Deserialize<Music.Pop>(File.ReadAllText(file)));
            }
            foreach (string file in Directory.EnumerateFiles(rock, "*.json"))
            {
                disk.Add(JsonSerializer.Deserialize<Music.Rock>(File.ReadAllText(file)));
            }
            foreach (string file in Directory.EnumerateFiles(metal, "*.json"))
            {
                disk.Add(JsonSerializer.Deserialize<Music.Metal>(File.ReadAllText(file)));
            }
        }
        private void CountDuration()
        {
            double duration = 0;
            foreach (Music.Music track in disk)
            {
                duration += track.DurationInSec;
            }
            DiskDurationMin = Math.Round(duration / 60, 1);
        }
        private List<Music.Music> FindByLength()
        {
            Console.Write("Enter max length => ");
            double Duration;
            while (true)
            {
                try
                {
                    Duration = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception exeption)
                {
                    Console.WriteLine(exeption.Message + "\nTRY AGAIN!");
                }
            }
            if (((Duration = Math.Round(Duration, 2)) * 100) % 100 >= 60)
            {
                Duration = Math.Round(Duration + 1 - 0.60, 2);
            }

            return disk.FindAll(a => a.DurationInSec < (int)((int)Duration * 60 + Duration * 100 % 100));
        }
        private void AddTrack (Genre selected)
        {
            Console.Clear();
            Console.Write("Enter Performer => ");
            string Performer = Console.ReadLine();
            Console.Write("\nEnter Track name => ");
            string Name = Console.ReadLine();
            Console.Write("\nEnter Duration =>");
            double Duration;
            while (true)
            {
                try
                {
                    Duration = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch(Exception exeption)
                {
                    Console.WriteLine(exeption.Message + "\nTRY AGAIN!");
                }
            }
            switch (selected)
            {
                case Genre.ROCK:
                    disk.Add(new Music.Rock(Performer, Name, Duration));
                    break;
                case Genre.RAP:
                    disk.Add(new Music.Rap(Performer, Name, Duration));
                    break;
                case Genre.POP:
                    disk.Add(new Music.Pop(Performer, Name, Duration));
                    break;
                case Genre.HIPHOP:
                    disk.Add(new Music.HipHop(Performer, Name, Duration));
                    break;
                case Genre.METAL:
                    disk.Add(new Music.Metal(Performer, Name, Duration));
                    break;
            }
        }
        private void SortByGenre()
        {
            disk = disk.OrderBy(k => k.GetHashCode()).ToList();
        }
    }
}
