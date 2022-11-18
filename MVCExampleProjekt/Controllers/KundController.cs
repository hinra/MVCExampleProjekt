using Microsoft.AspNetCore.Mvc;
using MVCExampleProjekt.Models;
using System.Collections.Generic;



namespace MVCExampleProjekt.Controllers
{
    public class KundController : Controller
    {
        public IActionResult Index()
        {
            
            return View(Kund.generateFakeKundList() ); 
        }

        public IActionResult RedigeraKundP(int guid, int id)
        {
            
            return View(Kund.generateFakeKund()); 
        }

        public IActionResult SparaKund()
        {
            ViewBag.Message = "Kunden 13321 har sparats";
            return RedirectToAction("Index", "Kund");
        }




        public IActionResult VisaKund()
        {            
            Kund k = new Kund()
            {
                realname = "Jon Köpingsson",
                username = "kopjo"
            };
            return View(k);
        }

        public ActionResult NyKund()
        {         

            return View(); 
        }


            [HttpPost]
        public ActionResult RedigeraKundByParameter(string username, string realname, string language)
        {
            string s = realname + " (" + username + ", lang = " + language + ")";

            ViewBag.Message = "Det redigerades kunden " + s; 
               
                return View("Index"); // Leda fel om det inte finns Kund/Index.cshtml        
        }


		public ActionResult RedigeraKund(int id)
        {
            // Genererar Fake-kund och skicka till /Kund/RedigeraKund.cshtml, fyller @model med kunden
            // Senare kommer vi med hjälp id plocka fram rätt kund.
            Kund k = Kund.generateFakeKund();
            ViewBag.Message = "Redigera Kund ID=" + id; 
            return View(k); 
        }


        public ActionResult RaderaKund(int id)
        {
            // Genererar Fake-kund och skicka till /Kund/RedigeraKund.cshtml, fyller @model med kunden
            // Senare kommer vi med hjälp id plocka fram rätt kund.
            Kund k = Kund.generateFakeKund();
            ViewBag.Message = "Kunden med ID=" + id + " togs bort!";
            return View("Index", Kund.generateFakeKundList());
        }


        [HttpPost]
        public ActionResult RedigeraKundByClass(Kund inkommandeK)
        {
            ModelState.Remove("items");  // Måste finnas, pga av ett fel jag gjorde när jag la upp modellen kund.
            if (ModelState.IsValid)
            {
                //Går något med kunden, tex spara i DB

                // tillbaka till /Kund/Index
                ViewBag.Message = "Det redigerades kunden " + inkommandeK.ToString();
                return View("Index", Kund.generateFakeKundList() ); // inte rätt men vi kan returnera något!
            }
            else
            {
                // något gick snett
                return View("Redigera");
            }
            
        }

		public ActionResult SparaNyKundByClass(Kund inkommandeK)
		{

            ModelState.Remove("password");  //För att det kommer inget password från formuläret!
            ModelState.Remove("items");
            if (ModelState.IsValid)
			{
				//Går något med kunden, tex spara i DB
                ViewBag.Message = "Det sparades den nya kunden" + inkommandeK.ToString();
				// tillbaka till /Kund/Index
				return View("Index", Kund.generateFakeKundList()); // Tillbaka till Kund/Index.cshtml  (För att vi är i Kundcontrollern!) 
			}
			else
			{
				ViewBag.Message = "Det gick inte att spara " + inkommandeK.ToString();
				// något gick snett vi skicka tillbaka till 
				return View( "NyKund", inkommandeK);
			}

		}



	}
}
