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
        
        public int Id { get; set; } 
        public string username { get; set; } 
        public string? password { get; set; }
        public string? realname { get; set; }
        public string? language { get; set; }

        public int? age;
        public int? credit;
        public List<string>? items;


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


        public Kund(string uname)
        {
            // Kod som kollar tillgänglighet.
            //...
            username = uname;
        }

        public Kund() { }

        public override string ToString()
        {
            return realname + "( " + username + " )";
        }

        // Äldre övningar
        public string TilltalLocal()
        {
            string svar = "ej definerad";

            switch (language)
            {
                case "de": svar = "Guten Morgen " + realname; break;
                case "se": svar = "Välkommen " + realname; break;
                case "es": svar = "Holá " + realname; break;
                default: svar = "Hello " + realname; break;
            }
            return svar;
        }

    } // End of class Kund
}


