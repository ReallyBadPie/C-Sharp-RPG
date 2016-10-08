using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;

            // Main game loop
            while(gameRunning)
            {
                gameRunning = selectMenuOptions();
            }
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
