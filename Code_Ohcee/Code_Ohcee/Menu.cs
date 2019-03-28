using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Code_Ohcee
{
    class Menu
    {

        // start up menu
        public void Startup()
        {
            // clear the console
            Console.Clear();

            MySqlConnection conn = null;

            Console.WriteLine("   ___    _                          ");
            Console.WriteLine("  / _ \\  | |__     ___    ___    ___ ");
            Console.WriteLine(" | | | | | '_ \\   / __|  / _ \\  / _ \\");
            Console.WriteLine(" | |_| | | | | | | (__  |  __/ |  __/");
            Console.WriteLine("  \\___/  |_| |_|  \\___|  \\___|  \\___|");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine();


            // welcome the user
            Console.WriteLine("\r\nWelcome to Ohcee! You can use this simple program to store and organize all your characters. :)\r\n");

            string[] initialChoices = new string[3];
            initialChoices[0] = "[1] Create a new character";
            initialChoices[1] = "[2] Search for a character";
            initialChoices[2] = "[3] Exit";

            for (int i = 0; i < initialChoices.Length; i++)
            {
                Console.WriteLine(initialChoices[i]);

            }

            // prompt the user with menu choices
            Console.WriteLine("\r\nWhat would you like to do?");
            string userSelection = Console.ReadLine();


            Console.WriteLine();



            if (userSelection == "1")
            {
                Console.Clear();
                Character createCharacter = new Character();
                createCharacter.CreateCharacter(conn);

            }
            else if (userSelection == "2")
            {

                CharacterMenu();


            }
            else if (userSelection == "3")
            {
                Console.WriteLine("Bye for now!");

            }
            else
            {
                while (string.IsNullOrWhiteSpace(userSelection))
                {

                    Console.WriteLine("\r\nPlease choose a number from the menu!\r\n");


                    for (int i = 0; i < initialChoices.Length; i++)
                    {
                        Console.WriteLine(initialChoices[i]);

                    }

                    // prompt the user with menu choices
                    Console.WriteLine("\r\nWhat would you like to do?");
                    userSelection = Console.ReadLine();

                }
           

            }

        }


        // return to main menu (startup)
        public void ReturnToMain()
        {
            MySqlConnection conn = null;

            Console.WriteLine("\r\nWould you like to return to the main menu?");
            Console.WriteLine("[yes]");
            Console.WriteLine("[no]");

            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "yes")
            {
                Startup();

            }
            else if (userInput.ToLower() == "no")
            {
                Console.WriteLine("\r\nGood-bye then!\r\n");

            }
            else
            {
                while (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("\r\nPlease write 'yes' or 'no'.");

                    Console.WriteLine("Would you like to return to the main menu?");

                    userInput = Console.ReadLine();

                }

            }


        }


          





        // search for a character menu

        public void CharacterMenu()
        {

            Console.Clear();

            MySqlConnection conn = null;
         
            Console.WriteLine("\r\nOkay! How would you like to search the character?\r\n");

            string[] searchChoices = new string[3];
            searchChoices[0] = "[1] By Name";
            searchChoices[1] = "[2] By Species";
            searchChoices[2] = "[3] By Fandom";

            for (int i = 0; i < searchChoices.Length; i++)
            {
                Console.WriteLine(searchChoices[i]);

            }

            Console.WriteLine();

            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
               
                Character byName = new Character();
                byName.NameSearch(conn);


            }
            else if (userChoice == "2")
            {

                Console.WriteLine("\r\nSorry! The dev hasn't added this function yet :(");
                Console.WriteLine("Try again later!\r\n");

                ReturnToMain();

            }
            else if (userChoice == "3")
            {

                Console.WriteLine("\r\nSorry! The dev hasn't added this function yet :(");
                Console.WriteLine("Try again later!\r\n");

                ReturnToMain();

            }
            else
            {

                while (string.IsNullOrWhiteSpace(userChoice))
                {

                    Console.WriteLine("\r\nPlease choose a number from the menu!");

                    CharacterMenu();

                }

            }



        }


    }
}
