using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Code_Ohcee
{
    class Add
    {
      
        
        public string Fandoms;
        public Character myCharacter;


        public void PassCharacter (Character c)
        {
            myCharacter = c;
             
        }




        // adds fandom if it doesn't already exists
        public void AddFandom (MySqlConnection conn, string userInput)
        {

            string stm = "INSERT INTO fandoms (fandomName) " +
                         "VALUES (@fandomName) ";

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@fandomName", Fandoms);

            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Close();


        }


        // adds character if character doesn't already exist
        public void AddCharacter(MySqlConnection conn)
        {

            Console.WriteLine("Inside the add method");
            string stm = "INSERT INTO ocs (name, age, genderId, speciesId, fandomId, about, ogDesigner, prevOwner, createdDate " +
                         "VALUES (@name, @age, @genderId, @speciesId, @fandomId, @about, @ogDesigner, @prevOwner, now() )";
         
   

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@name", myCharacter.Name);
            cmd.Parameters.AddWithValue("@age", myCharacter.Age);
            cmd.Parameters.AddWithValue("@genderId", myCharacter.GenderID);
            cmd.Parameters.AddWithValue("@speciesId", myCharacter.SpeciesID);
            cmd.Parameters.AddWithValue("@fandomId", myCharacter.FandomsID);
            cmd.Parameters.AddWithValue("@about", myCharacter.About);
            cmd.Parameters.AddWithValue("@ogDesigner", myCharacter.OGDesigner);
            cmd.Parameters.AddWithValue("@prevOwner", myCharacter.PrevOwner);
  

            MySqlDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("\r\nYour character has been created!");

            rdr.Close();


        }



    }
}
