using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Xtron
{
    public class Start
    {

        //första versionen

        //A för att bryta combat (combat är inte kodat ännu).

            public enum BaseClass
        {
            SELECT, Warrior, Archer, Mage, Summoner, Ninja
        }

        public List<string> HeaderText = new List<string>();
        public int HeaderLength = 0;
        public int GameMode = 0;
        public string dumbSpace = "     ";
        public string dumbMini = "   ";
        public bool nameset = false;

        public Player player = new Player();

        public bool SetClass = false;
        public bool LoadedStart = false;

        public void GenerateHeader()
        {
            HeaderText.Add("____  ___ __");
            HeaderText.Add("\\   \\/  //  |________  ____   ____");
            HeaderText.Add(" \\     /\\   __\\_  __ \\/  _ \\ /    \\");
            HeaderText.Add(" /     \\ |  |  |  | \\(  <_> )   |  \\");
            HeaderText.Add("/___/\\  \\|__|  |__|   \\____/|___|  /");
            HeaderText.Add("      \\_/                        \\/");

            for (int i = 0; i < HeaderText.Count; i++)
            {
                if (HeaderText[i].Length > HeaderLength) HeaderLength = HeaderText[i].Length;
            }

            for (int i = 0; i < HeaderText.Count; i++)
            {
                if (HeaderText[i].Length < HeaderLength)
                {
                    for (int j = HeaderText[i].Length; j < HeaderLength; j++)
                    {
                        HeaderText[i] += " ";
                    }
                }
            }

            Tuple<int, int> xy = new Tuple<int, int>(HeaderText.Count + 4, 70);
            Tuple<int, int> xyDiff = new Tuple<int, int>((xy.Item1 - HeaderText.Count) / 2, (xy.Item2 - HeaderLength) / 2);
            var tDiff = (xy.Item2 - HeaderLength) / 2; // skillnaden mellan headerns bredd och titeltextens bredd
            var SolidBlock = "█";
            var Space = " ";
            var SmallTab = "     ";

            string[] ProgramHeader = new string[xy.Item1];

            for (int i = 0; i < xy.Item1; i++)
            {
                var k = 0;

                for (int j = 0; j < xy.Item2; j++)
                {
                    if (i == 0 || i == xy.Item1 - 1) ProgramHeader[i] += SolidBlock;
                    else
                    {
                        if (j == 0 || j == xy.Item2 - 1)
                        {
                            ProgramHeader[i] += SolidBlock;
                        }
                        else if ((i >= xyDiff.Item1 && i <= xy.Item1 - xyDiff.Item1 - 1) && j > xyDiff.Item2 && j <= xy.Item2 - xyDiff.Item2)
                        {
                            ProgramHeader[i] += HeaderText[i - xyDiff.Item1].Substring(k, 1);
                            k++;
                        }
                        else ProgramHeader[i] += Space;

                        if (j == xy.Item2 - 1) k = 0;
                    }
                }
            }

            for (int i = 0; i < ProgramHeader.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("\n");
                }
                if (i <= 1 || i >= ProgramHeader.Length - 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{SmallTab}{ProgramHeader[i]}");
                }
                else
                {
                    Console.Write($"{ SmallTab}{ProgramHeader[i].Substring(0, 1)}");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(ProgramHeader[i].Substring(1, ProgramHeader[i].Length - 2));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(ProgramHeader[i].Substring(ProgramHeader[i].Length - 1, 1));
                }
            }
        }

        public void DrawLine()
        {
            if (Console.ForegroundColor != ConsoleColor.DarkGreen) Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        public void ClearLine(int Times)
        {
            for (int i = 0; i < Times; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
            }
        }

        public void ClearCurrentLine()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
        }

        public void StartMenu()
        {
            Console.WriteLine($"{dumbSpace}1. NEW GAME");
            if (!File.Exists(@"gamesave.txt")) Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{dumbSpace}2. CONTINUE");
            if (Console.ForegroundColor == ConsoleColor.DarkRed) Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{dumbSpace}3. EXIT");
        }

        public void GameStarter()
        {
            var testo = "123";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                ClearCurrentLine();
                Console.Write(":>");
            } while (!testo.Contains(keyInfo.KeyChar));

            GameMode = Convert.ToInt32(keyInfo.KeyChar)-48;
        }

        public void NewGame() //1#
        {
            if (SetClass == false) ClearLine(6);
            DrawLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\n{dumbMini}CLASS: {player.cLs}\n");
            Console.WriteLine($"{dumbMini}BASE STATS");
            var pStats = new string[]
            {
                    $"Hit-Points: {player.HP}   | Magic-Points: {player.MP}",
                    $"Strength: {player.STR}      | Intelligence: {player.INT}",
                    $"Agility: {player.AGI}       | Evasion: {player.EVA}"
            };
            for (int i = 0; i < pStats.Length; i++)
            {
                if (i > 0) Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write($"{dumbMini}{pStats[i].Substring(0, pStats[i].IndexOf(' ') + 1)}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(pStats[i].Substring(pStats[i].IndexOf(' ') + 1, Extensions.IndexOfNth(pStats[i], " ", 1) - (pStats[i].IndexOf(' ') + 1)));
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(pStats[i].Substring(Extensions.IndexOfNth(pStats[i], " ", 1), pStats[i].Length - Extensions.IndexOfNth(pStats[i], " ", 1) - (pStats[i].Length - pStats[i].LastIndexOf(' '))));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(pStats[i].Substring(pStats[i].LastIndexOf(' '), pStats[i].Length - pStats[i].LastIndexOf(' ')));

                if (i == pStats.Length - 1) Console.WriteLine();
            }

            DrawLine();

            if (SetClass == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\n{dumbSpace}SELECT A CLASS:\n");

                var pClassSelect = new string[] { "WARRIOR", "ARCHER", "MAGE", "SUMMONER", "NINJA" };
                for (int i = 0; i < pClassSelect.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write($"{dumbSpace}{i + 1}. ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(pClassSelect[i]);
                }
                Console.WriteLine();
                DrawLine();
                Console.Write("\n:>");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("SET NAME:>");
                XtronGame.HeroName = Console.ReadLine();
            }
            LoadedStart = true;
        }

        public void PickClass()
        {
            var testo = "12345";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                ClearCurrentLine();
                Console.Write(":>");
            } while (!testo.Contains(keyInfo.KeyChar));


            var ClassCase = Convert.ToInt32(keyInfo.KeyChar);

            ClearCurrentLine();
            ClearLine(21);

            switch (ClassCase)
            {
                case 49:
                    var warrior = new PlayerClassWarrior();
                    player = warrior;
                    XtronGame.HeroSelect = 1;
                    break;
                case 50:
                    var archer = new PlayerClassArcher();
                    player = archer;
                    XtronGame.HeroSelect = 2;
                    break;
                case 51:
                    var mage = new PlayerClassMage();
                    player = mage;
                    XtronGame.HeroSelect = 3;
                    break;
                case 52:
                    var summoner = new PlayerClassSummoner();
                    player = summoner;
                    XtronGame.HeroSelect = 4;
                    break;
                case 53:
                    var ninja = new PlayerClassNinja();
                    player = ninja;
                    XtronGame.HeroSelect = 5;
                    break;
            }

            SetClass = true;
        }

        public void StartMeUp()
        {
            GenerateHeader();
            Console.Write("\n\n");
            DrawLine();
            StartMenu();
            DrawLine();
            GameStarter();


            switch (GameMode)
            {
                case 1:
                    NewGame();
                    PickClass();
                    NewGame();

                    break;

                case 2:
                    break;
                case 3:
                    Console.WriteLine("SO LONG! UNTIL NEXT TIME!");
                    break;
            }

        }

        //FUNKTIONER

        public string ReplaceAt(string str, string replacewithchr, int index)
        {
            str = str.Remove(index, 1);
            str = str.Insert(index, replacewithchr);
            return str;
        }

        public string FindKeyInArray(string[] StringArray)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
            } while (!Array.Exists(StringArray, element => element == Convert.ToString(keyInfo.Key)));
            return Convert.ToString(keyInfo.Key);
        }

    }


    //FRÅN STATICOVERFLOW ISTÄLLET FÖR ATT ENKELT GÖRA MED REGEX
    public static class Extensions
    {
        public static int IndexOfNth(this string str, string value, int nth = 0)
        {
            if (nth < 0)
                throw new ArgumentException("Can not find a negative index of substring in string. Must start with 0");

            int offset = str.IndexOf(value);
            for (int i = 0; i < nth; i++)
            {
                if (offset == -1) return -1;
                offset = str.IndexOf(value, offset + 1);
            }

            return offset;
        }
    }
}
