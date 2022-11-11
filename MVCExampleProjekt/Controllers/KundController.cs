using Microsoft.AspNetCore.Mvc;
using MVCExampleProjekt.Models;
using System.Collections.Generic;



namespace MVCExampleProjekt.Controllers
{
    public class KundController : Controller
    {
        public IActionResult Index()
        {
            return View(Kund.generateFakeKundList()); 
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




        public IActionResult Detaljer()
        {
            // någon process som ta fram rätt kund.
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
        public ActionResult SparaNyKund(string username, string realname, string language)
        {
            string s = realname + " (" + username + ", lang = " + language + ")";

            ViewBag.Message = s; 
               
                return View("Index"); // Leda fel om det inte finns Kund/Index.cshtml        
        }


        public ActionResult RedigeraKundPara(int id, string type)
        {
            ViewBag.Message = "Inputparameter: id=" + id + ", type=" + type ;

            // Plocka fram rätt Kund från DB med hjälp av Id

            List<Kund> kList = Kund.generateFakeKundList();

            Kund searchresult = null; 
            foreach(Kund k in kList)
            {
                if(k.Id == id) {  searchresult = k; break; };
            }

            return View("RedigeraKund", searchresult); 
        }

        public ActionResult RedigeraKund()
        {
            ViewBag.Message = "Önskad aktion: redigera en kund";
            // mer kod som hämta kund-data från databasen (senare moment i kursen) 
            Kund k = Kund.generateFakeKund(); 
            return View(k);
        }


        [HttpPost]
        public ActionResult SparaKundByClass(Kund inkommandeK)
        {
            if (ModelState.IsValid)
            {
                Kund nyK = new Kund()
                {
                    username = inkommandeK.username,
                    realname = inkommandeK.realname,
                    language = inkommandeK.language
                };

                //Går något med kunden, tex spara i DB


                return View("Index");
            }
            else
            {
                return View("Redigera");
            }
            
        }


        
    }
}
