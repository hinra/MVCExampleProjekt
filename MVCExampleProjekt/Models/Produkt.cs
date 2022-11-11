using System.Collections.Generic;

namespace MVCExampleProjekt.Models
{
    public class Produkt
    {
        public string produktnamn { get; set; }
        public string tillverkare { get; set; }
        public int produktnum { get; set; }
        public  double pris { get; set; }


        public static Produkt generateFakeProdukt()
        {
            return new Produkt(); 
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
