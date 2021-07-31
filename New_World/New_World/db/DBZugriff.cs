using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace New_World.db
{
    static class DBZugriff
    {
        static MySqlConnection _con = null;
        
        public static void Connect()
        {
            const string constring = "; database=New_World_DB";
            //; allowuservariables=True; SslMode=none
            _con = new MySqlConnection(constring);

            try
            {
                _con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception($"MIST tut nicht {ex.Message} ");
            }
        }

        public static void CloseDB()
        {
            _con.Close();
        }

        public static int ExecuteNonQuery(string sql)
        {

            try
            {
                Connect();



                // Commandobjekt managt die Verbindung zur DB
                MySqlCommand cmd = new MySqlCommand(sql, _con);

                return cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception($"Fehler beim Insert {ex.Message} ");
            }
            finally
            {
                _con.Close();

            }

        }

        public static MySqlDataReader ExecuteReader(string sql, MySqlParameter[] parms)
        {

            Connect();
            MySqlCommand cmd = new MySqlCommand(sql, _con);
            if (parms != null)
                cmd.Parameters.AddRange(parms);


            return cmd.ExecuteReader();

            // Verbindung offen lassen bis alle Sätze gelesen sind
        }


    }
}
