using System;
using System.Collections.Generic;
using System.Text;

namespace Xtron
{
    class WorldMap
    {
        public bool ImInited = false;
        public bool ImStarted = false;
        public bool afterCombat = false;

        public Tuple<int, int> xy = new Tuple<int, int>(69, 9);
        public int xyOffset = -1;
        public int[] CurrentXY = new int[] { 10, 9 };
        public string SolidBlock = "█";

        //public string SolidBlock = "▓";

        //public string SolidBlock = "▒";

        //public string SolidBlock = "░";
        public int combatRoll = 1;
        public bool playerDead = false;
        public bool monsterDead = false;
        public Random rnd = new Random();
        public TheMaps ZeMaps = new TheMaps();
        public bool DontMove = false;
        public int SelectMap = 1;

        public string hName = XtronGame.HeroName;

        public static string MapName = "";

        public static string[] bMaps = new string[10];
        public void Run()
        {
            if (ImStarted == false)
            {
                switch (SelectMap)
                {
                    case 1:
                        bMaps = TheMaps.LoadMap(TheMaps.Maps.Map1);
                        break;
                    case 2:
                        bMaps = TheMaps.LoadMap(TheMaps.Maps.Map2);
                        break;
                    case 3:
                        bMaps = TheMaps.LoadMap(TheMaps.Maps.Map3);
                        break;
                    case 4:
                        bMaps = TheMaps.LoadMap(TheMaps.Maps.Map4);
                        break;
                    case 5:
                        bMaps = TheMaps.LoadMap(TheMaps.Maps.Map5);
                        break;
                }

                NewMap(bMaps);
                ImStarted = true;
            }
            PlacePlayer();
            Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);

            var ReturnKey = FindKeyInArray(new string[] { "UpArrow", "RightArrow", "DownArrow", "LeftArrow" });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(SolidBlock);

            Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);

            RedrawMapPiece();

            DontMove = false;
            switch (ReturnKey)
            {
                case "UpArrow":
                    if (CurrentXY[1] > 1 && bMaps[CurrentXY[1] - 2][CurrentXY[0] - 1] != 'X' && bMaps[CurrentXY[1] - 2][CurrentXY[0] - 1] != 'B')
                    {
                        Console.SetCursorPosition(CurrentXY[0], CurrentXY[1] - 1);
                        CurrentXY[1]--;
                        DontMove = false;
                    }
                    else if (CurrentXY[0] == 38 && CurrentXY[1] == 1)
                    {
                        SelectMap = 1;
                        ImStarted = false;
                        CurrentXY[1] += 9;
                        Run();
                    }
                    else
                    {
                        Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(SolidBlock);
                        DontMove = true;
                    }

                    break;
                case "RightArrow":
                    if (CurrentXY[0] < xy.Item1 && bMaps[CurrentXY[1] - 1][CurrentXY[0]] != 'X' && bMaps[CurrentXY[1] - 1][CurrentXY[0]] != 'B')
                    {
                        Console.SetCursorPosition(CurrentXY[0] + 1, CurrentXY[1]);
                        CurrentXY[0]++;
                        DontMove = false;
                    }
                    else if (CurrentXY[0] == 69 && CurrentXY[1] == 2)
                    {
                        SelectMap = 3;
                        ImStarted = false;
                        CurrentXY[0] = 1;
                        Run();
                    }
                    else if (bMaps[CurrentXY[1] - 1][CurrentXY[0]] == 'B')
                    {
                        Console.SetCursorPosition(0, 14);
                        if (CurrentXY[1] == 6)
                        {

                            bMaps[5] = ReplaceAt(bMaps[5], "X", 13);
                            bMaps[8] = ReplaceAt(bMaps[8], "O", 48);
                            bMaps[8] = ReplaceAt(bMaps[8], "O", 49);

                            NewMap(bMaps);

                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.SetCursorPosition(0, 14);
                            Console.WriteLine("MONOLITH OF THE SUN:\n");
                            Console.WriteLine("As you turn the lever you feel a scorching heat");
                            Console.WriteLine("The Monolith dissapears");

                        }
                        else if (CurrentXY[1] == 9)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("GATE OF THE MOON:\n");
                            Console.WriteLine("\"THE MIRROR REFLECTS THE SUN\"");
                        }
                        Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
                    }
                    else
                    {
                        Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(SolidBlock);
                        DontMove = true;
                    }
                    break;
                case "DownArrow":
                    if (CurrentXY[1] <= xy.Item2 && bMaps[CurrentXY[1]][CurrentXY[0] - 1] != 'X' && bMaps[CurrentXY[1]][CurrentXY[0] - 1] != 'B')
                    {
                        Console.SetCursorPosition(CurrentXY[0], CurrentXY[1] + 1);
                        CurrentXY[1]++;
                        DontMove = false;
                    }
                    else if (CurrentXY[0] == 38 && CurrentXY[1] == 10)
                    {
                        SelectMap = 2;
                        ImStarted = false;
                        CurrentXY[1] -= 9;
                        Run();
                    }
                    else if (bMaps[CurrentXY[1]][CurrentXY[0] - 1] == 'B')
                    {

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(0, 14);
                        Console.WriteLine("GATE OF ECLIPSE:\n");
                        Console.WriteLine("\"WHEN THE MOON SLEEPS THE SUN SHALL RISE\"");
                        Console.WriteLine("   \"XTRON LIES IN THE FALLENS SHADOW\"");
                        Console.WriteLine(" \"STRIKE FROM BEHIND TO INVOKE ECLIPSE\"");

                        Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
                    }
                    else
                    {
                        Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(SolidBlock);
                        DontMove = true;
                    }
                    break;
                case "LeftArrow":
                    if (CurrentXY[0] > 1 && bMaps[CurrentXY[1] - 1][CurrentXY[0] - 2] != 'X' && bMaps[CurrentXY[1] - 1][CurrentXY[0] - 2] != 'B')
                    {
                        Console.SetCursorPosition(CurrentXY[0] - 1, CurrentXY[1]);
                        CurrentXY[0]--;
                        DontMove = false;
                    }
                    else if (CurrentXY[0] == 1 && CurrentXY[1] == 2)
                    {
                        SelectMap = 1;
                        ImStarted = false;
                        CurrentXY[0] = 69;
                        Run();
                    }
                    else if (bMaps[CurrentXY[1] - 1][CurrentXY[0] - 2] == 'B')
                    {
                        if (CurrentXY[1] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.SetCursorPosition(0, 14);
                            Console.WriteLine("GATE OF THE SUN:\n");
                            Console.WriteLine("\"A GIANT SLEEPS WITHIN ITS MIRROR\"");
                        }
                        else if (CurrentXY[1] == 5)
                        {
                            bMaps[4] = ReplaceAt(bMaps[4], "X", 55);
                            bMaps[1] = ReplaceAt(bMaps[1], "O", 19);
                            bMaps[1] = ReplaceAt(bMaps[1], "O", 20);

                            NewMap(bMaps);

                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.SetCursorPosition(0, 14);
                            Console.WriteLine("MONOLITH OF THE MOON:\n");
                            Console.WriteLine("As you turn the lever you feel a shivering mist");
                            Console.WriteLine("The Monolith dissapears");
                        }
                        Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
                    }
                    else
                    {
                        Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(SolidBlock);
                        DontMove = true;
                    }
                    break;
            }
            if (ImInited == false) ImInited = true;

            if (DontMove == false)
            {
                if (bMaps[CurrentXY[1] - 1][CurrentXY[0] - 1] != 'M')
                {
                    MovePlayer();
                    var Roll = rnd.Next(combatRoll, 51);
                    if (combatRoll > 19 && Roll == 50) Combat();
                    combatRoll++;
                }
                else
                {

                    if (CurrentXY[1] == 9 && CurrentXY[0] == 67)
                    {
                        if (bMaps[1][2] != 'M')
                        {                            
                            bMaps[8] = ReplaceAt(bMaps[8], "M", 37);
                            bMaps[8] = ReplaceAt(bMaps[8], "O", 66);
                            NewMap(bMaps);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.SetCursorPosition(0, 14);
                            Console.WriteLine("BOSSFIGHT MOONGOD\n");
                            Console.WriteLine("YOU WIN!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.SetCursorPosition(0, 14);
                            Console.WriteLine("XTRON APPEARS\n");
                            Console.WriteLine("Before you know it,");
                            Console.WriteLine("you lie on the ground headless in a pool of your own blood\n");
                            Console.WriteLine("GAME OVER...");
                            Console.ReadLine();
                            Console.Clear();
                            XtronGame.GameOver = true;
                        }
                        
                    }
                    else if (CurrentXY[1] == 2 && CurrentXY[0] == 3) //lägg till mer logik för att moon gate ska vara stängd annars game over eftersom mirroreffekten är borta
                    {                                              
                        bMaps[1] = ReplaceAt(bMaps[1], "O", 2);
                        NewMap(bMaps);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(0, 14);
                        Console.WriteLine("BOSSFIGHT SUNGOD\n");
                        Console.WriteLine("YOU WIN!");
                    }
                    else if (CurrentXY[1] == 9 && CurrentXY[0] == 38)
                    {   
                        bMaps[8] = ReplaceAt(bMaps[8], "O", 37);
                        bMaps[9] = ReplaceAt(bMaps[9], "X", 37);

                        NewMap(bMaps);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(0, 14);
                        Console.WriteLine("BOSSFIGHT ECLIPSE\n");
                        Console.WriteLine("YOU WIN THE GAME!");
                    }

                    
                }

            }

            if (XtronGame.GameOver == false) Run();
        }

        public void Combat()
        {
            Console.Clear();
            Console.WriteLine("Combat!");

            while (playerDead == false && monsterDead == false)
            {
                var ReturnKey = FindKeyInArray(new string[] { "a", "A" });
                Console.WriteLine(ReturnKey);
                if (ReturnKey == "A".ToUpper())
                {
                    monsterDead = true;
                    Console.WriteLine("Great Success!");
                    Console.Clear();
                    NewMap(bMaps);

                }
            }
            monsterDead = false;
            ImStarted = true;
            afterCombat = true;
            combatRoll = 1;
        }

        public void NewMap(string[] Mapdata)
        {
            var LastUsedChr = ' ';

            Console.Clear();
            Console.WriteLine();

            for (int i = 0; i < Mapdata.Length; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < Mapdata[i].Length; j++)
                {
                    if (Mapdata[i][j] != LastUsedChr)
                    {
                        switch (Mapdata[i][j])
                        {
                            case 'B':
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 'M':
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 'O':
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 'T':
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 'X':
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                break;
                            case 'Z':
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                        }
                    }

                    Console.Write(SolidBlock);
                    if (j == Mapdata[i].Length - 1) Console.WriteLine();

                    if (i > 0 && j > 0)
                    {
                        LastUsedChr = Mapdata[i][j];
                    }
                }                
            }
            Console.WriteLine($"<< {MapName} >>");
        }

        public void RedrawMapPiece()
        {
            Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);

            switch (bMaps[CurrentXY[1] - 1][CurrentXY[0] - 1])
            {
                case 'B':
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 'M':
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 'O':
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 'T':
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 'X':
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 'Z':
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }

            Console.Write(SolidBlock);
        }

        public void MovePlayer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(SolidBlock);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
        }

        public void PlacePlayer()
        {
            Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(SolidBlock);
            Console.SetCursorPosition(CurrentXY[0], CurrentXY[1]);
            afterCombat = false;
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
}
