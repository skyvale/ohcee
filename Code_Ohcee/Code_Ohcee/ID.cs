using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

// This class is to find the corresponding IDs to the Names in the database.

namespace Code_Ohcee
{
    class ID
    {


        // this will find and validate the corresponding ID to the fandom name that a user types in
        public void FandomIDFinder (MySqlConnection conn, string userInput)
        {

            string stm = "SELECT fandomId FROM fandoms WHERE fandomName = @fandomName";

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@fandomName", Fandoms);

            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {

                rdr.Read();

                Fandoms = rdr["fandomId"].ToString();

                rdr.Close();

                int fandomId;
                int.TryParse(Fandoms, out fandomId);
                fandomId = FandomsID;
                


            }
            else
            {

                rdr.Close();

                // check
                Validation fandomCheck = new Validation();
                fandomCheck.FandomCheck(conn, userInput);

            }

            rdr.Close();


        }


    }
}
