using System;
using System.Collections.Generic;
using System.Threading;

namespace RPG
{
    class Program
    {
        private static Player currentPlayer;
        private List<Item> items;

        static void Main(string[] args)
        {
            bool gameRunning = true;

            currentPlayer = new Player();

            // Main game loop
            while(gameRunning)
            {
                gameRunning = selectMenuOptions();
            }
        }


        public static Monster generateMonster()
        {
            Random rnd = new Random();
            int levelMultiplier = rnd.Next(1, 6);

            string baseName = "";
            int baseLevel = currentPlayer.getLevel() + levelMultiplier;
            int baseHealth = baseLevel * levelMultiplier;
            int baseMoneyDrop = 10;
            int baseExpDrop = 10;
            int baseStr = baseLevel;
            int baseDef = baseLevel;
            int baseSpeed = 0;

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
                    baseSpeed = 2 + baseLevel;
                    break;
                case 2:
                    baseName = "Wizard";
                    baseHealth += 80;
                    baseStr = baseLevel * 3;
                    baseDef = baseLevel / 3;
                    baseMoneyDrop *= 2;
                    baseExpDrop *= 4;
                    baseSpeed = 10 + baseLevel;
                    break;
                case 3:
                    baseName = "Bandit";
                    baseHealth += 100;
                    baseMoneyDrop *= 2;
                    baseExpDrop *= 2;
                    baseSpeed = 5 + baseLevel;
                    break;
                case 4:
                    baseName = "Cactus";
                    baseHealth += 420;
                    baseStr = 1;
                    baseDef = baseLevel * 5;
                    baseExpDrop *= 6;
                    baseSpeed = 1;
                    break;
            }

            Monster monster = new Monster(
                baseName,
                baseLevel,
                baseHealth,
                baseHealth,
                baseStr,
                baseDef,
                baseSpeed,
                baseMoneyDrop,
                baseExpDrop
            );

            return monster;
        }

        
        /**
         * FUNCTION selectMenuOptions
         * IMPORT None EXPORT None
         * Shows the main menu options to the user
         */
        private static bool selectMenuOptions()
        {
            // Default -1 for error check
            int selection = -1;
            bool success = true;

            // Display valid menu options
            showMenu();

            // Get user input and try convert to integer value
            Int32.TryParse(Console.ReadLine(), out selection);

            switch (selection)
            {
                case -1:
                    Console.WriteLine("Error has occured getting user input");
                    success = false;
                    break;
                case 1:
                    Console.WriteLine("Showing player stats...");
                    playerStats();
                    break;
                case 2:
                    Console.WriteLine("Entering fight...");
                    fighting();
                    break;
                case 3:
                    Console.WriteLine("Enter Shop...");
                    Shop shop = new Shop(currentPlayer);
                    shop.openShop();
                    break;
                case 4:
                    Console.WriteLine("Exiting Game...");
                    success = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again!");
                    break;
            }

            return success;
        }

        /**
         * FUNCTION showMenu
         * IMPORT None EXPORT None
         * Shows the menu options to the user
         */
        private static void showMenu()
        {
            Console.WriteLine("===== [ MAIN MENU ] =====");

            // All available current options
            Console.WriteLine("[1] Show Player Stats");
            Console.WriteLine("[2] Fight");
            Console.WriteLine("[3] Shop");
            Console.WriteLine("[4] Exit");

            Console.WriteLine("");
            Console.Write("Enter option: ");
        }

        private static void fighting()
        {
            Monster fightingMonster = generateMonster();
            Console.WriteLine(fightingMonster.getName() + " appeared !");
            int playerDmg = currentPlayer.getStrength();
            int monsterDmg = fightingMonster.getStrength();

            while (currentPlayer.getHealth() > 0 && fightingMonster.getHealth() > 0)
            {
                if (currentPlayer.getSpeed() > fightingMonster.getSpeed())
                {
                    Console.WriteLine("You attacked !");
                    fightingMonster.setHealth(fightingMonster.getHealth() - playerDmg);
                    Console.WriteLine("Monster has " + fightingMonster.getHealth() + " HP!");
                    Console.WriteLine();
                    if (fightingMonster.getHealth() > 1)
                    {
                        Console.WriteLine("Monster attacked !");
                        currentPlayer.setHealth(currentPlayer.getHealth() - monsterDmg);
                        Console.WriteLine("You have " + currentPlayer.getHealth() + " HP");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Monster attacked !");
                    currentPlayer.setHealth(currentPlayer.getHealth() - monsterDmg);
                    Console.WriteLine("You have " + currentPlayer.getHealth() + " HP");
                    Console.WriteLine();
                    if (currentPlayer.getHealth() > 1)
                    {
                        Console.WriteLine("You attacked !");
                        fightingMonster.setHealth(fightingMonster.getHealth() - playerDmg);
                        Console.WriteLine("Monster has " + fightingMonster.getHealth() + " HP!");
                        Console.WriteLine();
                    }
                }
                Thread.Sleep(500);
            }
            if (currentPlayer.getHealth() > 0)
            {
                Console.WriteLine("You defeated the monster and found " + fightingMonster.getMoneyDrop() + " Gold and gained " + fightingMonster.getExperienceDrop() + " EXP");
                currentPlayer.setMoney(currentPlayer.getMoney() + fightingMonster.getMoneyDrop());
                currentPlayer.setExperience(currentPlayer.getExperience() + fightingMonster.getExperienceDrop());
                currentPlayer.setKilled(currentPlayer.getKilled() + 1);
                if (currentPlayer.getExperience() >= currentPlayer.getMaxExp())
                {
                    levelUp();
                }
            }
            else
            {
                Console.WriteLine("Monster has killed you.");
                currentPlayer.setExperience(0);
            }

            currentPlayer.setHealth(currentPlayer.getMaxHealth());
          
        
        }

        private static void levelUp()
        {
            Console.WriteLine("LEVEL UP !");
            currentPlayer.setLevel(currentPlayer.getLevel() + 1);
            currentPlayer.setMaxExp(currentPlayer.getMaxExp() * 2);
            currentPlayer.setExperience(0);
            currentPlayer.setStrength(currentPlayer.getStrength() + 2);
            currentPlayer.setDefence(currentPlayer.getDefence() + 2);
            currentPlayer.setSpeed(currentPlayer.getSpeed() + 1);
            currentPlayer.setMaxHealth(currentPlayer.getMaxHealth() + 10);
            currentPlayer.setHealth(currentPlayer.getMaxHealth());
        }

        private static void playerStats()
        {
            Console.WriteLine("Name : " + currentPlayer.getName());
            Console.WriteLine("Level : " + currentPlayer.getLevel());
            Console.WriteLine("HP : " + currentPlayer.getHealth());
            Console.WriteLine("Strength : " + currentPlayer.getStrength());
            Console.WriteLine("Defence : " + currentPlayer.getDefence());
            Console.WriteLine("Speed : " + currentPlayer.getSpeed());
            Console.WriteLine("Experience : " + currentPlayer.getExperience() + "/" + currentPlayer.getMaxExp());
            Console.WriteLine("Money : " + currentPlayer.getMoney());
            Console.WriteLine("Monsters killed : " + currentPlayer.getKilled());

        }
        
    }


}
