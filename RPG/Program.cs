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

        public static void Main(string[] args)
        {
            player = new Player();
        }

        public static Monster generateMonster()
        {
            Random rnd = new Random();
            int levelMultiplier = rnd.Next(1, 6);

            string baseName = "";
            int baseLevel = player.getLevel() + levelMultiplier;
            int baseHealth = baseLevel * levelMultiplier;
            int baseMoneyDrop = 10;
            int baseExpDrop = 10;
            int baseStr = baseLevel;
            int baseDef = baseLevel;

            int monsterChoice = rnd.Next(1, 5);
            switch (monsterChoice)
            {
                case 1:
                    baseName = "Giant";
                    baseHealth += 120;
                    baseStr = baseLevel * 2;
                    baseDef = baseLevel / 2;
                    baseMoneyDrop *= 3;
                    baseExpDrop *= 3;
                    break;
                case 2:
                    baseName = "Wizard";
                    baseHealth += 80;
                    baseStr = baseLevel * 3;
                    baseDef = baseLevel / 3;
                    baseMoneyDrop *= 2;
                    baseExpDrop *= 4;
                    break;
                case 3:
                    baseName = "Bandit";
                    baseHealth += 100;
                    baseMoneyDrop *= 2;
                    baseExpDrop *= 2;
                    break;
                case 4:
                    baseName = "Cactus";
                    baseHealth += 420;
                    baseStr = 3;
                    baseDef = baseLevel * 5;
                    baseExpDrop *= 6;
                    break;
            }

            Monster monster = new Monster(
                baseName,
                baseLevel,
                baseHealth,
                baseHealth,
                baseStr,
                baseDef,
                baseMoneyDrop,
                baseExpDrop
            );

            return monster;
        }
    }
}
