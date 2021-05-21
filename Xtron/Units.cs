using System;
using System.Collections.Generic;
using System.Text;

namespace Xtron
{
    public class Units
    {
        public string Name { get; set; }
        public Start.BaseClass cLs { get; set; }
        public int Level { get; set; }
        public int HP { get; set; } //HIT POINTS
        public int currentHP { get; set; } //CURRENT HP
        public int MP { get; set; } //MAGIC POINTS
        public int INT { get; set; } //INTELLIGENCE
        public int STR { get; set; } //STRENGTH
        public int AGI { get; set; } //AGILITY
        public int EVA { get; set; } //EVASION        

        public Units()
        {
            Name = "";
            cLs = Start.BaseClass.SELECT;
            Level = 1;
            HP = 100;
            currentHP = HP;
            MP = 0;
            INT = 10;
            STR = 20;
            AGI = 15;
            EVA = 5;
        }

    }

    

    public class Player : Units
    {
        public int EXP { get; set; }

        public Player()
        {
            EXP = 0;

            HP = HP * 3;
            MP = 80;
            INT = INT * 3;
            STR = STR * 2 + 5;
            AGI = AGI + 10;
            EVA = EVA + 10;
        }

        public void LevelUp()
        {
            switch (cLs)
            {
                case Start.BaseClass.Warrior:
                    HP += 20;
                    break;
                case Start.BaseClass.Archer:
                    HP += 15;
                    MP += 15;
                    INT += 2;
                    STR += 6;
                    AGI += 8;
                    EVA += 10;
                    break;
                case Start.BaseClass.Mage:
                    break;
                case Start.BaseClass.Summoner:
                    break;
                case Start.BaseClass.Ninja:
                    HP += 20;
                    MP += 10;
                    INT += 2;
                    STR += 4;
                    AGI += 10;
                    EVA += 10;
                    break;
            }
        }
    }

    public class PlayerClassWarrior : Player
    {
        public PlayerClassWarrior()
        {
            cLs = Start.BaseClass.Warrior;
            HP += 100;
            MP /= 2;
            INT /= 2;
            STR += 15;
            AGI += 5;
            EVA += 5;
        }
    }

    public class PlayerClassArcher : Player
    {
        public PlayerClassArcher()
        {
            cLs = Start.BaseClass.Archer;
            HP += 30;
            MP += 5;
            INT += 0;
            STR += 5;
            AGI += 15;
            EVA += 15;
        }
    }

    public class PlayerClassMage : Player
    {
        public PlayerClassMage()
        {
            cLs = Start.BaseClass.Mage;
            HP -= 100;
            MP += 100;
            INT += 20;
            STR -= 10;
            AGI += 0;
            EVA += 0;
        }
    }

    public class PlayerClassSummoner : Player
    {
        public PlayerClassSummoner()
        {
            cLs = Start.BaseClass.Summoner;
            HP -= 80;
            MP += 120;
            INT += 25;
            STR -= 5;
            AGI += 0;
            EVA += 0;
        }
    }

    public class PlayerClassNinja : Player
    {
        public PlayerClassNinja()
        {
            cLs = Start.BaseClass.Ninja;
            HP += 0;
            MP += 0;
            INT += 0;
            STR += 0;
            AGI += 35;
            EVA += 25;
        }

    }

    public class Monster : Units
    {

    }
}
