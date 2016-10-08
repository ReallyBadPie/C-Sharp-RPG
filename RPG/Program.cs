using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        private static Player player;

        static void Main(string[] args)
        {
            player = new Player();
        }

        static void GenMonster()
        {
            Random rnd = new Random();
   
            int powerLevel = rnd.Next(1, 6);
            int monsterChoice = rnd.Next(1, 5);
            int monsterLevel = player.getLevel() + powerLevel;
            int monsterHealth = monsterLevel * powerLevel;
            int monsterMoney = 10;
            int monsterExperience = 10;

            switch (monsterChoice)
            {
                case 1:
                    Monster giant = new Monster("Giant", monsterLevel, 120 + monsterHealth, 120 + monsterHealth, monsterLevel * 2, monsterLevel / 2, monsterMoney * 3, monsterExperience * 3);
                    break;
                case 2:
                    Monster wizard = new Monster("Wizard", monsterLevel, 80 + monsterHealth, 80 + monsterHealth, monsterLevel * 3, monsterLevel / 3, monsterMoney * 2, monsterExperience * 4);
                    break;
                case 3:
                    Monster bandit = new Monster("Bandit", monsterLevel, 100 + monsterHealth, 100 + monsterHealth, monsterLevel , monsterLevel, monsterMoney * 2, monsterExperience * 2);
                    break;
                case 4:
                    Monster cactus = new Monster("Cactus", monsterLevel, 420 + monsterHealth, 420 + monsterHealth, 3, monsterLevel *5, monsterMoney, monsterExperience * 6);
                    break;
        }
    
    }
}
