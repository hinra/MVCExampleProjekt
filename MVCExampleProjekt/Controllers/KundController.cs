using Microsoft.AspNetCore.Mvc;
using MVCExampleProjekt.Models;
using System.Collections.Generic;



namespace MVCExampleProjekt.Controllers
{
    public class KundController : Controller
    {
        public IActionResult Index()
        {
            //   List<Kund> allaKunder = Kund.generateFakeKundList();
            //  return View( allaKunder ); 
            return View();
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

    }
	
}
