using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace New_World.db
{
    class MaterialDB
    {
        public static Material Einzellesen(int id)
        {
            Material m = new Material();

            MySqlParameter[] aParms = new MySqlParameter[1];

            aParms[0] = new MySqlParameter("@ID", id);

            string sql = "Select * from Material where matID = @id";

            MySqlDataReader rdr = DBZugriff.ExecuteReader(sql, aParms);

            if(rdr.Read())
            {
                m = new Material(Convert.ToInt32(rdr["matID"]),
                                Convert.ToString(rdr["bezeichnung"]));

                DBZugriff.CloseDB();

                return m;
            }
            else
            {
                DBZugriff.CloseDB();

                throw new Exception("Es wurde kein Material mit dieser ID gefunden");
            }
        }
    }
}
