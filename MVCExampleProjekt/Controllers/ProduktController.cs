using Microsoft.AspNetCore.Mvc;

namespace MVCExampleProjekt.Controllers
{
    public class ProduktController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RedigeraProdukt()
        {
            return View();
        }

        public IActionResult NyProdukt()
        {
            return View();
        }
    }
}
