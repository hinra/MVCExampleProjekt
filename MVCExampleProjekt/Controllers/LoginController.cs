using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCExampleProjekt.Models;

namespace MVCExampleProjekt.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(Employee emp)
        {
            // Remove namn och roll för det finns inte med i formuläret 
            // i filen Views/Login/LoginPartial.cshtml
            ModelState.Remove("namn");
            ModelState.Remove("roll");
            if (!ModelState.IsValid) return View("index"); // om inte korrekt
            // Skpa Employee, fyll den med uppgifter från databasen
            Employee nyBesökare = Employee.GetEmployeeByMail(emp.mailadress); 

            //Kolla om lösen är rätt

            //Spara nyBesökare i Session-variablar
            HttpContext.Session.SetString("mailadress", nyBesökare.mailadress);
            HttpContext.Session.SetString("namn", nyBesökare.namn);
            HttpContext.Session.SetString("roll", nyBesökare.roll);

            return RedirectToAction("Index", "Home"); // Skicka till HomeControllern -->Index. 
        }



    }
}
