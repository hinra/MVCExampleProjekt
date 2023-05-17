using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCExampleProjekt.Models;

namespace MVCExampleProjekt.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult IndexPersonal()
        {
            return View();
        }

        public IActionResult IndexKund()
        {
            return View();
        }

        public IActionResult LoginPersonal(Employee emp)
        {
            // Remove namn och roll för det finns inte med i formuläret 
            // i filen Views/Login/LoginPartial.cshtml
            ModelState.Remove("namn");
            ModelState.Remove("roll");
            if (!ModelState.IsValid) return View("index"); // om inte korrekt
                                                           // Skapa Employee, fyll den med uppgifter från databasen
            Employee nyBesökare = Employee.GetEmployeeByMail(emp.mailadress);

            //Kolla om användaren finns och lösen är rätt
            // annars felmeddelande 
            if (nyBesökare.password != emp.password)
            {
                ViewBag.LoginError = true;
                return View("index");
            }

            //Spara nyBesökare i Session-variablar
            HttpContext.Session.SetString("mailadress", nyBesökare.mailadress);
            HttpContext.Session.SetString("namn", nyBesökare.namn);
            HttpContext.Session.SetString("roll", nyBesökare.roll);

            return RedirectToAction("Index", "Home"); // Skicka till HomeController -->Index. 
        }

        public IActionResult LoginKund(string username, string password)
        {
			
			//if (!ModelState.IsValid) return View("index"); // om inte korrekt
														   // Skapa Employee, fyll den med uppgifter från databasen
			Employee nyBesökare = Employee.GetEmployeeByMail(username);

			//Kolla om användaren finns och lösen är rätt
			// annars felmeddelande 
			if (nyBesökare.password != password)
			{
				ViewBag.LoginError = true;
				return View("index");
			}

			//Spara nyBesökare i Session-variablar
			HttpContext.Session.SetString("mailadress", nyBesökare.mailadress);
			HttpContext.Session.SetString("namn", nyBesökare.namn);
			HttpContext.Session.SetString("roll", nyBesökare.roll);


			return RedirectToAction("Index", "Home");
        }
    }
}
