using Microsoft.VisualBasic;
using MVCExampleProjekt.Other;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient; 

namespace MVCExampleProjekt.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime orderDatum { get; set; }
       
        public Kund Bestallare {get; set;}

        public string? orderStatus {  get; set; }

        public List<Produkt> inkopslist { get; set; }

        public static List<Order> getEveryOrder()
        {
            List<Order> orders = new List<Order>();
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr); // skapa förbindelse 'conn' till databasen
            conn.Open(); // öppna kanal till databasen
            MySqlCommand MyCom = new MySqlCommand("Select * from Orders", conn); // skapa sql-sats för 'conn'
            MySqlDataReader reader = MyCom.ExecuteReader();  // skicka satsen till DB och spara svaret i 'reader'
            while (reader.Read())  // while håller på tills ingen data kvar
                                   // en omgång per rad i databastabellen
            {
                Order ord = new Order(); // Skapa ny objekt av typen Order
                ord.Id = reader.GetInt32("id");  // hämta värde från kolumnen 'id'
                ord.orderDatum = reader.GetDateTime("orderDatum");// hämta värde från kolumnen 'orderDatum'
                ord.orderStatus = reader.GetString("orderStatus");  // ...

                int KundID = reader.GetInt32("KundId");
                Kund k = Kund.GetKundById(KundID);
                ord.Bestallare = k;
                string[] prId = reader.GetString("inkopsLista").Split(","); 
                
                List<Produkt> prList = new List<Produkt>();
                foreach(string pr in prId)
                {
                    prList.Add(Produkt.getSingleProduktById(int.Parse(pr) ) ); 
                }
                ord.inkopslist = prList;
                orders.Add(ord);                // spara objektet i listan 
            }

            MyCom.Dispose();  // släng förbindelse
            conn.Close();  // stäng kanalen till DB


            return orders; 
        }
    }
}
