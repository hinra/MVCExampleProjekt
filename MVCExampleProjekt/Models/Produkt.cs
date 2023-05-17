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
        public double pris { get; set; }
        public string ProduktImageFileName { get; set; }


        /// <summary>
        /// Statisk metod som hämta all data från tabellen produkt 
        /// </summary>
        /// <returns></returns>
        public static List<Produkt> getAllProdukt()
        {
            List<Produkt> list = new List<Produkt>(); // förberedda en lista för all data
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr); // skapa förbindelse 'conn' till databasen
            MySqlCommand MyCom = new MySqlCommand("Select * from Produkt", conn); // skapa sql-sats för 'conn'

            conn.Open(); // öppna kanal till databasen

            MySqlDataReader reader = MyCom.ExecuteReader();  // skicka satsen till DB och spara svaret i 'reader'

            while (reader.Read())  // while håller på tills ingen data kvar
                                   // en omgång per rad i databastabellen
            {
                Produkt p = new Produkt(); // Skapa ny objekt av typen Produkt
                p.id = reader.GetInt32("id");  // hämta värde från kolumnen 'id'
                p.produktnamn = reader.GetString("produktnamn");// hämta värde från kolumnen 'produktnamn'
                p.tillverkare = reader.GetString("tillverkare");  // ...
                p.pris = reader.GetDouble("pris"); // ...
                list.Add(p);                // spara objektet i listan 
            }

            MyCom.Dispose();  // släng förbindelse
            conn.Close();  // stäng kanalen till DB

            return list;
        }
        /// <summary>
        ///  Hämta en specifik produkt med en viss id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Produkt getSingleProduktById(int id)
        {
            // Se ovan för förklaring           
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Produkt where id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", id);
            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader(); // Om det förväntas ett svar/retur-data


            Produkt singleP = new Produkt();
            if (reader.Read())
            {
                singleP.id = reader.GetInt32("id");
                singleP.produktnamn = reader.GetString("produktnamn");
                singleP.tillverkare = reader.GetString("tillverkare");
                singleP.ProduktImageFileName = reader.GetString("produktimagefilename");
                singleP.pris = reader.GetDouble("pris");
            }

            MyCom.Dispose();
            conn.Close();

            return singleP;
        }


        public static bool sparaProdukt(Produkt p)
        {
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("UPDATE Produkt set produktnamn = @PRNAMN, tillverkare = @TILL, pris = @PRIS where id = @ID ", conn);
            MyCom.Parameters.AddWithValue("@PRNAMN", p.produktnamn);
            MyCom.Parameters.AddWithValue("@TILL", p.tillverkare);
            MyCom.Parameters.AddWithValue("@PRIS", p.pris);
            MyCom.Parameters.AddWithValue("@ID", p.id);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery(); // För SQL-satser utan förväntan av svar

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;

        }

        public static bool SparaNyProdukt(Produkt pi)
        {
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("Insert INTO Produkt (produktnamn, tillverkare, pris, produktimagefilename) VALUES ( @PRNAMN, @TILL, @PRIS, @IMAGE )", conn);
            MyCom.Parameters.AddWithValue("@PRNAMN", pi.produktnamn);
            MyCom.Parameters.AddWithValue("@TILL", pi.tillverkare);
            MyCom.Parameters.AddWithValue("@PRIS", pi.pris);
            MyCom.Parameters.AddWithValue("@IMAGE", pi.ProduktImageFileName);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;

        }

        public static bool RaderaProdukt(int id)
        {
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("DELETE FROM Produkt WHERE id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", id);

            conn.Open();
            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;

        }
    }
}
