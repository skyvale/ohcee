﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Code_Ohcee
{
    class Validation
    {



        // validate if user didn't enter anything
        public static string StringEmpty(string userInput, string question)
        {
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("\r\nPlease don't leave this blank!");

                Console.WriteLine(question);

                userInput = Console.ReadLine();
            }

            return userInput;



        }





        // validate if NAME already exists within database
        //public void NameCheck(MySqlConnection conn, string userInput)
        //{

        //    string stm = "SELECT name FROM ocs WHERE name = @name";

        //    MySqlCommand cmd = new MySqlCommand(stm, conn);
        //    cmd.Parameters.AddWithValue("@name", Name);

        //    MySqlDataReader rdr = cmd.ExecuteReader();

        //    if (rdr.HasRows)
        //    {

        //        rdr.Read();

        //        Fandoms = rdr["name"].ToString();

        //    }
        //    else
        //    {

        //        Console.WriteLine("Character does not exist.");
        //        Console.WriteLine("Would you like to add a new character?");
        //        Console.WriteLine("[1] Add New Character ");
        //        Console.WriteLine("[2] Return to Main Menu \r\n");

        //        string decision = Validation.StringEmpty(Console.ReadLine(), "Would you like to add a new character?\r\n[1] Add New Character\r\n[2] Return to Main Menu\r\n")

        //        if (decision.ToLower() == "1")
        //        {
        //            Console.Clear();
        //            Character createCharacter = new Character();
        //            createCharacter.CreateCharacter(conn);

        //        }
        //        else if (decision.ToLower() == "2")
        //        {
        //            Console.Clear();
        //            Menu mainMenu = new Menu();
        //            mainMenu.Startup();

        //        }
        //        else
        //        {
        //            Console.WriteLine("\r\nPlease choose [1] or [2]!");

        //            Console.WriteLine("\r\nWould you like to add a new character?");
        //            Console.WriteLine("[1] Add New Character ");
        //            Console.WriteLine("[2] Return to Main Menu \r\n");

        //            decision = Validation.StringEmpty(Console.ReadLine(), "Would you like to add a new character?\r\n[1] Add New Character\r\n[2] Return to Main Menu\r\n");
        //        }


        //    }

        //    rdr.Close();


        //}





        // validate if user didn't enter anything AND give them the option to come back later
        public static string ReturnLater(string userInput, string question)
        {
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("\r\nWould you like to come back to this later?");
                Console.WriteLine("[yes]");
                Console.WriteLine("[no]\r\n");

                string comeBack = Validation.StringEmpty(Console.ReadLine(), "\r\nWould you like to come back to this later?");

                if (comeBack.ToLower() == "yes")
                {
                    Console.WriteLine("\r\nYou can edit your character from the main menu!");

                }
                else if (comeBack.ToLower() == "no")
                {

                    Console.WriteLine(question);

                }

                userInput = Console.ReadLine();
            }

            return userInput;



        }




        // validate if the custom fandom already exists in the system
        public void FandomCheck(MySqlConnection conn, string userInput)
        {

            string stm = "SELECT fandomName FROM fandoms WHERE fandomName = @fandomName";

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@fandomName", Fandoms);

            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {

                rdr.Read();

                Fandoms = rdr["fandom"].ToString();

                rdr.Close();


            }
            else
            {

                rdr.Close();

                Add addFandom = new Add();
                addFandom.AddFandom(conn, userInput);

                // check
                Console.WriteLine("\r\nAdded new fandom!");

            }

            rdr.Close();


        }


        

    }
}
