using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCExampleProjekt.Other;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

		internal static List<Kund> HämtaAllaKunder()
		{
			// Se ovan för förklaring           
			MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
			MySqlCommand MyCom = new MySqlCommand("Select * from Kund", conn);
			conn.Open();

			MySqlDataReader reader = MyCom.ExecuteReader();

			List<Kund> AllaK = new List<Kund>();
			while (reader.Read())
			{
                Kund singleK = new Kund(); 
				singleK.Id = reader.GetInt32("Id");
				singleK.realname = reader.GetString("realname");
				singleK.username = reader.GetString("username");
				singleK.password = reader.GetString("password");
				singleK.age = reader.GetInt32("age");
				singleK.language = reader.GetString("language");
				singleK.credit = reader.GetInt32("credit");

                AllaK.Add(singleK);

			}

			MyCom.Dispose();
			conn.Close();

			return AllaK;
		}

		public override string ToString()
        {
            return realname + "( " + username + " )";
        }

        internal static bool SparaNyKund(Kund k)
        {
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("INSERT INTO Kund( realname, username, age, password, language, credit) VALUES (@REALNAME, @USERNAME, @AGE,  @PSSWD, @LANG,  @CREDIT )", conn);
            
            MyCom.Parameters.AddWithValue("@REALNAME", k.realname);
            MyCom.Parameters.AddWithValue("@USERNAME", k.username);
            MyCom.Parameters.AddWithValue("@PSSWD", k.password);
            MyCom.Parameters.AddWithValue("@AGE", k.age);
            MyCom.Parameters.AddWithValue("@LANG", k.language);
            MyCom.Parameters.AddWithValue("@CREDIT", k.credit);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;
        }

        internal static bool SparaKund(Kund k)
        {
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("UPDATE Kund SET  realname = @REALNAME, username = @USERNAME," +
                " age = @AGE, password = @PSSWD, language = @LANG, credit = @CREDIT WHERE Id = @ID", conn);

            MyCom.Parameters.AddWithValue("@REALNAME", k.realname);
            MyCom.Parameters.AddWithValue("@USERNAME", k.username);
            MyCom.Parameters.AddWithValue("@PSSWD", k.password);
            MyCom.Parameters.AddWithValue("@AGE", k.age);
            MyCom.Parameters.AddWithValue("@LANG", k.language);
            MyCom.Parameters.AddWithValue("@CREDIT", k.credit);
            MyCom.Parameters.AddWithValue("@ID", k.Id);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;
        }

        internal static Kund RaderaKund(int id)
        {
           Kund k = Kund.GetKundById(id);
            MySqlConnection conn = new MySqlConnection(DatabaseVariables.conStr);
            MySqlCommand MyCom = new MySqlCommand("DELETE FROM Kund WHERE Id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", k.Id);
            
            conn.Open();
            int rader = MyCom.ExecuteNonQuery();

            if(rader > 0 )
            {
                return k;
            }
            else
            {
                return null; 
            }
           
        }
    } // End of class Kund
}


