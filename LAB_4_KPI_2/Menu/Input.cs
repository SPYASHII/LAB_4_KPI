using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4_KPI_2.Menu
{
    class Input
    {
        private ConsoleKeyInfo button;
        public void Key(ref Logic.Genre selectedGenre, ref Logic.Menu selected, ref bool enter, ref bool shutDown, ref bool _exit)
        {
            bool exit;
            do
            {
                button = Console.ReadKey(true);
                exit = false;
                switch (button.KeyChar)
                {
                    case 'W':
                    case 'w':
                        if (selected > 0)
                            selected -= 1;
                        if (selectedGenre > 0)
                            selectedGenre -= 1;
                        break;
                    case 'S':
                    case 's':
                        if (selected < Logic.Menu.ADD)
                            selected += 1;
                        if (selectedGenre < Logic.Genre.POP)
                            selectedGenre += 1;
                        break;
                    case '\u001b':
                        shutDown = true;
                        break;
                    case 'D':
                    case 'd':
                        enter = true;
                        break;
                    case 'A':
                    case 'a':
                        enter = false;
                        _exit = false;
                        break;
                    default:
                        exit = true;
                        break;
                }
            } while (exit);
        }
    }
}
