using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCExampleProjekt.Other;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient; 

namespace MVCExampleProjekt.Models
{
    public class Kund
    
        {
        /// <summary>
        /// Ett unikt namn för varje kund. Borde innehåller 8 tecken. 
        /// </summary>


        [ScaffoldColumn(false)]
		public int Id { get; set; }

        [DisplayName("Användarnamn eller Epost")]
		[Required(ErrorMessage = "Ange ett namn pucko!"), MaxLength(30)]
		public string username { get; set; } 


        public string password { get; set; }
        [DisplayName("fullständig namn")]
        public string realname { get; set; }

       public string language { get; set; }

        public int? age { get; set; }
		public int? credit { get; set; }
        [ScaffoldColumn(false)]
        public List<string> items { get; set; }


		// Statiska metod, anropas Kund.generateFakeKund();

		public static Kund generateFakeKund()
        {
            return new Kund()
            {
                Id = 6671,
                username = "lennart@gmail.se",
                realname = "Lennart Johannsson",
                language = "sv",
                age = 45,
                credit = 12300,
                password = "12345",
                items = new List<string>()
            };
        }

        

        internal static Kund GetKundById(int kundID)
        {
            // Se ovan för förklaring           
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Kund where id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", kundID);
            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            Kund singleK = new Kund();
            if (reader.Read())
            {
                singleK.Id = reader.GetInt32("Id");
                singleK.realname = reader.GetString("realname");
                singleK.username = reader.GetString("username");
                singleK.password= reader.GetString("password");
                singleK.age = reader.GetInt32("age");
                singleK.language = reader.GetString("language");
                singleK.credit = reader.GetInt32("credit"); 

            }

            MyCom.Dispose();
            conn.Close();

            return singleK;
        }

		internal static Kund GetAllaKunder()
		{
			// Se ovan för förklaring           
			MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
			MySqlCommand MyCom = new MySqlCommand("Select * from kund", conn);
			conn.Open();

			MySqlDataReader reader = MyCom.ExecuteReader();

			Kund singleK = new Kund();
			if (reader.Read())
			{
				singleK.Id = reader.GetInt32("Id");
				singleK.realname = reader.GetString("realname");
				singleK.username = reader.GetString("username");
				singleK.password = reader.GetString("password");
				singleK.age = reader.GetInt32("age");
				singleK.language = reader.GetString("language");
				singleK.credit = reader.GetInt32("credit");

			}

			MyCom.Dispose();
			conn.Close();

			return singleK;
		}

		public override string ToString()
        {
            return realname + "( " + username + " )";
        }       

    } // End of class Kund
}


