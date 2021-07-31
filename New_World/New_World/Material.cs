using MySql.Data.MySqlClient;
using New_World.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace New_World
{
    class Material
    {
        public int id { get; set; }
        public string bezeichnung { get; set; }

        public Material()
        {

        }

        public Material(int id)
        {
            this.id = id;
        }

        public Material(int id, string bezeichnung)
        {
            this.id = id;
            this.bezeichnung = bezeichnung;
        }

        public static Material Lesen(int id)
        {
            try
            {
                return MaterialDB.Einzellesen(id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
