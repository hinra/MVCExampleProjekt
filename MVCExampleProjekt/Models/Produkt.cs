using System;
using System.Collections.Generic;
using MVCExampleProjekt.Other;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MVCExampleProjekt.Models
{
    public class Produkt
    {
        public string produktnamn { get; set; }
        public string tillverkare { get; set; }
        public int id { get; set; }
        public  double pris { get; set; }


        public static Produkt generateFakeProdukt()
        {
            return new Produkt(); 
        }

        public static List<Produkt> getAllProdukt()
        {
           
            List<Produkt> list = new List<Produkt>();
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from produkt", conn);
            
            conn.Open(); 

            MySqlDataReader reader = MyCom.ExecuteReader(); 

            while(reader.Read())
            {
                Produkt p = new Produkt();
                p.id = reader.GetInt32("id");
                p.produktnamn = reader.GetString("produktnamn");
                p.tillverkare = reader.GetString("tillverkare");
                p.pris = reader.GetDouble("pris");
                list.Add(p);               
            }

            MyCom.Dispose(); 
            conn.Close(); 

            return list;
		}

        public static Produkt getSingleProduktById(int id)
        {
           
           
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from produkt where id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", id);
            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            Produkt singleP = new Produkt();
            if (reader.Read())
            {
                singleP.id = reader.GetInt32("id"); 
                singleP.produktnamn = reader.GetString("produktnamn");
                singleP.tillverkare = reader.GetString("tillverkare");
                singleP.pris = reader.GetDouble("pris");
                
            }

            MyCom.Dispose();
            conn.Close();

            return singleP;
        }


        public static bool sparaProdukt(Produkt p)
        {
           
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("UPDATE produkt set produktnamn = @PRNAMN, tillverkare = @TILL, pris = @PRIS where id = @ID ", conn);
            MyCom.Parameters.AddWithValue("@PRNAMN", p.produktnamn);
            MyCom.Parameters.AddWithValue("@TILL", p.tillverkare);
            MyCom.Parameters.AddWithValue("@PRIS", p.pris);
            MyCom.Parameters.AddWithValue("@ID", p.id);
            conn.Open();

           int rader =  MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true ;


        }

        public static List<Produkt> generateFakeProduktList()
        {
            List<Produkt> list = new List<Produkt>();

            list.Add(generateFakeProdukt());
            list.Add(new Produkt());
            list.Add(new Produkt());
            list.Add(new Produkt());
            return list; 
        }
    }
}
