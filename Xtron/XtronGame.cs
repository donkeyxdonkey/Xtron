using System;
using System.Collections.Generic;
using System.Text;

namespace Xtron
{
    public class XtronGame
    {
        public Player Hero1 = new Player();
        public Player Hero2 = new Player(); //DOFI THE SUMMONER JOINS THE PARTY

        public static int HeroSelect = 0; //TEMPFIXAR
        public static int Korva = 0;
        public static string HeroName;
        public static bool GameOver = false;

        public void XtronRUN()
        {
            while (true)
            {
                var Prg = new Start();
                Prg.StartMeUp();
                TempHeroFix();
                break;
            }

            while (Hero1.currentHP > -1 || GameOver == true)
            {
                var Wmp = new WorldMap();
                Wmp.Run();

                break;
            }

            GameOver = false;
            XtronRUN();

        }

        public void TempHeroFix()
        {
            switch (HeroSelect)
            {
                case 1:
                    Hero1 = new PlayerClassWarrior();
                    break;
                case 2:
                    Hero1 = new PlayerClassArcher();
                    break;
                case 3:
                    Hero1 = new PlayerClassMage();
                    break;
                case 4:
                    Hero1 = new PlayerClassSummoner();
                    break;
                case 5:
                    Hero1 = new PlayerClassNinja();
                    break;
            }

            Hero1.Name = HeroName;
        }




    }
}
