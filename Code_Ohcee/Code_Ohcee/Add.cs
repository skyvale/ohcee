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

        // variables
        public string Name;
        public string Age;
        public string Gender;
        public string Species;
        public string Fandoms;
        public string OGDesigner;
        public string PrevOwner;
        public DateTime CreatedDate;
        public string About;
        public string cs = @"server=10.63.22.234; userid=skyvale; password=password; database=Ohcee; port=8889";



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

            string stm = "INSERT INTO ocs (name, age, gender, species, about, ogDesigner, prevOwner) " +
                         "VALUES (@name, @age, @gender, @species, @about, @ogDesigner, @prevOwner)";

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@age", Age);
            cmd.Parameters.AddWithValue("@gender", Gender);
            cmd.Parameters.AddWithValue("@species", Species);
            cmd.Parameters.AddWithValue("@about", About);
            cmd.Parameters.AddWithValue("@ogDesigner", OGDesigner);
            cmd.Parameters.AddWithValue("@prevOwner", PrevOwner);
  

            MySqlDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("\r\nYour character has been created!");

            rdr.Close();


        }



    }
}
