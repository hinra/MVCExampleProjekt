using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace MVCExampleProjekt.Models
{
    public class Order
    {
        public DateTime orderDatum { get; set; }
        public string kund  { get; set; }

        public string orderStatus {  get; set; }

        public List<Produkt> inkopslista; 
    }
}
