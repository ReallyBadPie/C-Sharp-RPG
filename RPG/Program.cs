using System;
using System.Collections.Generic;

namespace RPG
{
    class Program
    {
        private static Player player;
        private List<Item> items;

        static void Main(string[] args)
        {
            bool gameRunning = true;

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
                    //TODO: show player stats
                    break;
                case 2:
                    Console.WriteLine("Entering fight...");
                    //TODO: Create fight options
                    break;
                case 3:
                    Console.WriteLine("Enter quest mode...");
                    //TODO: Create questing options
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
            Console.WriteLine("[3] Quest");
            Console.WriteLine("[4] Exit");

            Console.WriteLine("");
            Console.Write("Enter option: ");
        }
        
    }


}
