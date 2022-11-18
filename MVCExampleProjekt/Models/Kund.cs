using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        public static List<Kund> generateFakeKundList()
        {
            List<Kund> list = new List<Kund>();
            list.Add(generateFakeKund());

            list.Add(new Kund()
            {
                Id = 1234,
                username = "Johnny@flamingo.br",
                realname = "Johnny G. Flamingo",
                language = "es",
                age = 25,
                credit = 400
            });

            list.Add(new Kund()
            {
                Id = 4532,
                username = "pjotr.Stakasvilli@georgien.go",
                realname = "Pjotr Stakasvilli",
                language = "go",
                age = 17,
                credit = 0
            });
            return list;    
        }

        // statiska klassvariabler och metoder

       // static public List<Kund> minDatabas;
		//static public int HighiestID=0;

	/*	static public bool InitDB()
        {
            if (minDatabas == null)
            {
                minDatabas = new List<Kund>();
                minDatabas.AddRange(generateFakeKundList());
                HighiestID = 4532 + 1; 

				return true;
            }
            else return false;

        }*/

        public override string ToString()
        {
            return realname + "( " + username + " )";
        }

       

    } // End of class Kund
}


