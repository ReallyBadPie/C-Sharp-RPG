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

            currentPlayer = new Player("Test", 1, 100, 100, 20, 1, 0, 10, 10, 5);

            // Main game loop
            while (gameRunning)
            {
                gameRunning = selectMenuOptions();
            }
        }


        public static Monster generateMonster()
        {
            Random rnd = new Random();
            int levelMultiplier = rnd.Next(1, 6);

            string baseName = "";

            // Create base stats for monster
            int baseLevel = currentPlayer.Level + levelMultiplier;
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

            // Create monster
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
                    //TODO: show player stats
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
            Random rand = new Random();

            // Create the current monster
            Monster fightingMonster = generateMonster();
            Console.WriteLine(fightingMonster.Name + " appeared!");

            int playerDmg;
            int monsterDmg;

            bool playerTurn = currentPlayer.Speed > fightingMonster.Speed;

            while (currentPlayer.Health > 0 && fightingMonster.Health > 0)
            {
                if (playerTurn && currentPlayer.Health > 0)
                {
                    // Players turn to attack
                    playerDmg = rand.Next(1, (currentPlayer.Strength * 2));
                    Console.WriteLine("You attack dealing " + playerDmg + " damage to " + fightingMonster.Name);

                    // Deal damage to monster
                    fightingMonster.Health -= playerDmg;
                    Console.WriteLine(fightingMonster.Name + " is now on " + fightingMonster.Health + " HP\n");

                    playerTurn = false;
                }
                else
                {
                    // Monsters turn to attack
                    monsterDmg = rand.Next(1, (fightingMonster.Strength * 2));
                    Console.WriteLine(fightingMonster.Name + " attacked dealing " + monsterDmg + " damge!");

                    // Deal damage to player
                    currentPlayer.Health -= monsterDmg;
                    Console.WriteLine("You are now on " + currentPlayer.Health + " HP\n");

                    playerTurn = true;
                }
                Thread.Sleep(1000);
            }

            if (currentPlayer.Health > 0)
            {
                Console.WriteLine("You defeated the monster and found " + fightingMonster.MoneyDrop + " Gold and gained " + fightingMonster.ExperienceDrop + " EXP");
                currentPlayer.Money += fightingMonster.MoneyDrop;
                currentPlayer.Experience += fightingMonster.ExperienceDrop;
                if (currentPlayer.Experience >= currentPlayer.MaxExperience)
                {
                    levelUp();
                }
            }
            else
            {
                Console.WriteLine(fightingMonster.Name + " has killed you\n");
                currentPlayer.Experience = 0;
            }

            currentPlayer.Health = currentPlayer.MaxHealth;
          
        
        }

        private static void levelUp()
        {
            Console.WriteLine("LEVEL UP !");
            currentPlayer.Level += 1;
            currentPlayer.MaxExperience *= 2;
            currentPlayer.Experience = 0;
            currentPlayer.Strength += 2;
            currentPlayer.Defence += 2;
            currentPlayer.Speed += 1;
            currentPlayer.MaxHealth += 10; 
            currentPlayer.Health = currentPlayer.MaxHealth;
        }

    }


}
