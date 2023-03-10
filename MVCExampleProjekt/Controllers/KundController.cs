using Microsoft.AspNetCore.Mvc;
using MVCExampleProjekt.Models;
using System.Collections.Generic;



namespace MVCExampleProjekt.Controllers
{
    public class KundController : Controller
    {
        public IActionResult Index()
        {
            List<Kund> AllaKunder = Kund.HämtaAllaKunder(); 

            return View(AllaKunder);
        }


        public ActionResult NyKund()
        {

            return View();
        }

        public ActionResult SparaNyKund(Kund k)
        {
            ModelState.Remove("items"); 
            if (ModelState.IsValid)
            {
                Kund.SparaNyKund(k);

                return RedirectToAction("Index");
            }
            else
            {
                return View("NyKund");
            }
        }

        public ActionResult SparaKund(Kund k)
        {
            string roll = HttpContext.Session.GetString("roll");
            if (roll == null || !roll.Contains("admin"))
            {
                return View("NotAuthorized"); 
            }
            Kund.SparaKund(k); 

            return RedirectToAction("Index");
        }


        public ActionResult RedigeraKund(int id)
        {
            Kund k = Kund.GetKundById(id);
            return View("RedigeraKund", k);
        }

        public ActionResult RaderaKund(int id)
        {
            Kund k = Kund.RaderaKund(id);
            if (k == null)
            {
                ViewBag.Meddelande = "Kund " + k.realname + " kunde inte raderas!";
            }
            else {
                ViewBag.Meddelande = "Kund " + k.realname + " raderades!";
            }
            return RedirectToAction("Index");
        }

    }
	
}
