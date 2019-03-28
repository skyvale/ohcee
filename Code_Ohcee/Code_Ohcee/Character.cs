using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Code_Ohcee

    // THIS CLASS IS FOR ORGANIZING AND SEARCHING FOR CHARACTERS
    // Adding characters is done in the Add class!
{
    class Character
    {

        // declare variables
        public string Name;
        public string Age;
        public string Gender;
        public string Species;
        public string Fandoms;
        public string OGDesigner;
        public DateTime CreatedDate;
        public string PrevOwner;
        public string About;
        public string cs = @"server=10.63.22.234; userid=skyvale; password=password; database=Ohcee; port=8889";

        MySqlConnection conn = null;


        // this will display the character's information
        public void Display (MySqlConnection conn)
        {


            Console.WriteLine("\r\n-------------------------------\r\n");
            Console.WriteLine("\r\nName: " + Name);
            Console.WriteLine("\r\nAge: " + Age);
            Console.WriteLine("\r\nGender: " + Gender);
            Console.WriteLine("\r\nSpecies: " + Species);
            Console.WriteLine("\r\nFandom: " + Fandoms);
            Console.WriteLine("\r\nOriginal Designer: " + OGDesigner);
            Console.WriteLine("\r\nPrevious Owner: " + PrevOwner);
            Console.WriteLine("\r\nCreated On: " + CreatedDate);
            Console.WriteLine("\r\nAbout:\r\n" + About);
            Console.WriteLine();


        }


        // search character by name
        public void NameSearch(MySqlConnection conn)
        {

            Console.Clear();


            try
            {

                // Open a connection to MySQL
                conn = new MySqlConnection(cs);
                conn.Open();

                // Prompt the user
                Console.WriteLine("\r\nEnter a name.");
                string nameInput = Console.ReadLine();

                Console.WriteLine();
                NameSearchContinued(conn, nameInput);



            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }



        // information for name search method
        public void NameSearchContinued(MySqlConnection conn, string name)
        {
            string stm = "SELECT name, age, gender.genderName, species.speciesName, fandoms.fandomName, about, ogDesigner, createdDate " +
                         "FROM ocs " +
                         "JOIN gender ON ocs.genderId = gender.genderId " +
                         "JOIN fandoms ON ocs.fandomId = fandoms.fandomId " +
                         "JOIN species ON ocs.speciesId = species.speciesId " +
                         "WHERE name = @name";

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@name", name);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                // set variables
                Name = rdr["name"].ToString();
                Age = rdr["age"].ToString();
                Gender = rdr["genderName"].ToString();
                Species = rdr["speciesName"].ToString();
                Fandoms = rdr["fandomName"].ToString();
                OGDesigner = rdr["ogDesigner"].ToString();

                DateTime created;
                DateTime.TryParse(rdr["createdDate"].ToString(), out created);
                CreatedDate = created;

                About = rdr["about"].ToString();


                // print out to console
                Console.WriteLine("-------------------------------");
                Console.WriteLine("\r\nName: " + Name);
                Console.WriteLine("\r\nAge: " + Age);
                Console.WriteLine("\r\nGender: " + Gender);
                Console.WriteLine("\r\nSpecies: " + Species);
                Console.WriteLine("\r\nFandom: " + Fandoms);
                Console.WriteLine("\r\nOG Designer: " + OGDesigner);
                Console.WriteLine("\r\nCreated On: " + CreatedDate);
                Console.WriteLine("\r\nAbout:\r\n" + About);


            }

            rdr.Close();

        }






        // METHOD TO CREATE A NEW CHARACTER 
        public void CreateCharacter(MySqlConnection conn)
        {

            // Open a connection to MySQL
            conn = new MySqlConnection(cs);
            conn.Open();

            //prompt user for information
            //TODO !! get this top menu to stay after each console.clear()
            Console.WriteLine("\r\nCREATE A NEW CHARACTER");
            Console.WriteLine("----------------------------------");




            // name
            Console.WriteLine("\r\nWhat is your character's name?");
            string name = Validation.StringEmpty(Console.ReadLine(), "\r\nWhat is your character's name?");
            Name = name;



            // age
            Console.Clear();
            Console.WriteLine("\r\nWhat is their age?");
            string age = Validation.StringEmpty(Console.ReadLine(), "\r\nWhat is their age?");
            Age = age;




            // gender
            Console.Clear();
            Console.WriteLine("\r\nWhat is your character's gender? :\r\n");
            string[] genderArray = new string[5];
            genderArray[0] = "[1] Male";
            genderArray[1] = "[2] Female";
            genderArray[2] = "[3] Transgender";
            genderArray[3] = "[4] Non-binary";
            genderArray[4] = "[5] Genderless";

            for (int i = 0; i < genderArray.Length; i++)
            {
                Console.WriteLine(genderArray[i]);

            }

            Console.WriteLine();

            //TODO !! put this in an IF loop so that you can reprint the array if needed
            string gender = Validation.StringEmpty(Console.ReadLine(), "\r\nPlease choose your character's gender!");


            if (gender == "1")
            {
                Gender = "Male";

            }
            else if (gender == "2")
            {
                Gender = "Female";

            }
            else if (gender == "3")
            {
                Gender = "Transgender";

            }
            else if (gender == "4")
            {
                Gender = "Non-binary";

            }
            else if (gender == "5")
            {
                Gender = "Genderless";

            }
            else
            {

                Console.WriteLine("\r\nPlease choose a number from the menu! (1-5)");

                Console.WriteLine("\r\nWhat is your character's gender? :");

                for (int i = 0; i < genderArray.Length; i++)
                {
                    Console.WriteLine(genderArray[i]);

                }

                Console.WriteLine();

            }



            // species
            Console.Clear();
            Console.WriteLine("What species are they? :\r\n");
            string[] speciesArray = new string[13];
            speciesArray[0] = "[1] Human";
            speciesArray[1] = "[2] Feline";
            speciesArray[2] = "[3] Canine";
            speciesArray[3] = "[4] Bird";
            speciesArray[4] = "[5] Lizard";
            speciesArray[5] = "[6] Aquatic";
            speciesArray[6] = "[7] Dinosaur";
            speciesArray[7] = "[8] Anthro";
            speciesArray[8] = "[9] Mythical";
            speciesArray[9] = "[10] Monster";
            speciesArray[10] = "[11] Canon Species";
            speciesArray[11] = "[12] Original Species";
            speciesArray[12] = "[13] Other";

            for (int i = 0; i < speciesArray.Length; i++)
            {
                Console.WriteLine(speciesArray[i]);
                
            }

            Console.WriteLine();

            string species = Validation.StringEmpty(Console.ReadLine(), "\r\nPlease choose your character's species!");
          
            //TODO !! add option to input canon species name or create a new canon species if it doesn't already exist in the system

            if (species == "1")
            {
                Species = "Human";

            }
            else if (species == "2")
            {
                Species = "Feline";

            }
            else if (species == "3")
            {
                Species = "Canine";

            }
            else if (species == "4")
            {
                Species = "Bird";

            }
            else if (species == "5")
            {
                Species = "Lizard";

            }
            else if (species == "6")
            {
                Species = "Aquatic";

            }
            else if (species == "7")
            {
                Species = "Dinosaur";

            }
            else if (species == "8")
            {
                Species = "Anthro";

            }
            else if (species == "9")
            {
                Species = "Mythical";

            }
            else if (species == "10")
            {
                Species = "Monster";

            }
            else if (species == "11")
            {

                Console.WriteLine("\r\nWhat is the name of the canon species?");
                string canonSpecies = Validation.StringEmpty(Console.ReadLine(), "\r\nWhat is the name of the canon species?");

                Species = canonSpecies;

            }
            else if (species == "12")
            {
                Console.WriteLine("\r\nWhat is the name of the original species?");
                string ogSpecies = Validation.StringEmpty(Console.ReadLine(), "\r\nWhat is the name of the original species?");

                Species = ogSpecies;

            }
            else if (species == "13")
            {
                Console.WriteLine("\r\nWhat species is your character?");
                string otherSpecies = Validation.StringEmpty(Console.ReadLine(), "\r\nWhat species is your character?");

                Species = otherSpecies;


            }
            else
            {

                Console.WriteLine("\r\nPlease choose a number from the menu! (1-13)");

                Console.WriteLine("\r\nWhat species are they? :\r\n");

                for (int i = 0; i < speciesArray.Length; i++)
                {
                    Console.WriteLine(speciesArray[i]);

                }

                Console.WriteLine();

                species = Validation.StringEmpty(Console.ReadLine(), "\r\nPlease choose a number from the menu!");

            }


            // fandom
            Console.Clear();
            Console.WriteLine("\r\nWhat fandom are they a part of?");
            Console.WriteLine("If they are not a fan character, just write 'original'.");

            string fandom = Validation.StringEmpty(Console.ReadLine(), "\r\nWhat fandom are they a part of?");

            Validation doesFandomExist = new Validation();
            doesFandomExist.fandomCheck(conn, fandom);




            // ogDesigner
            Console.Clear();
            Console.WriteLine("\r\nWho is the original designer?");

            string designer = Validation.StringEmpty(Console.ReadLine(), "\r\nWho is the original designer?");
            OGDesigner = designer;




            // prevOwner
            Console.Clear();
            Console.WriteLine("\r\nWho was the previous owner? Leave blank if there wasn't one.");

            string previousOwner = Console.ReadLine();



            // About
            Console.Clear();
            Console.WriteLine("\r\nWrite about your character. When done, press 'enter'.");

            string about = Validation.ReturnLater(Console.ReadLine(), "\r\nWho is the original Designer?");




            // Confirm with user
            Console.Clear();
            Console.WriteLine("\r\nOkay! Here is your new character. Is this information correct? (*note* You may edit this later) :");
            Console.WriteLine("[yes]");
            Console.WriteLine("[no]\r\n");

            Display(conn);

            string characterConfirm = Validation.StringEmpty(Console.ReadLine(), "\r\nIf the information is correct, please type 'yes'!");

            if (characterConfirm.ToLower() == "yes")
            {

                Add addCharacter = new Add();
                addCharacter.AddCharacter(conn);


            }
            else if (characterConfirm.ToLower() == "no")
            {

                Console.Clear();
                CreateCharacter(conn);
                

            }
            else
            {
                Console.WriteLine("\r\nPlease type 'yes' or 'no'!");

                Console.WriteLine("\r\nIs all this information correct?");

                characterConfirm = Validation.StringEmpty(Console.ReadLine(), "\r\nIf the information is correct, please type 'yes'!");

            }



        }





    }
}
