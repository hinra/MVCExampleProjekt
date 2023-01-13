using Microsoft.AspNetCore.Mvc;
using MVCExampleProjekt.Models;

namespace MVCExampleProjekt.Controllers
{
    public class ProduktController : Controller
    {
        public IActionResult Index()
        {
            // Ett anrop https://localhost/Produkt/Index leda hit
            return View(Produkt.getAllProdukt() );
            // högerklick på getAllProdukt --> Go to Definition
        }

        public IActionResult RedigeraProdukt()
        {
            return View();
        }

        public IActionResult showDetail(int id)
        {
            // Ett anrop https://localhost/Produkt/showDetail leda hit
            Produkt p = Produkt.getSingleProduktById(id);
            return View("RedigeraProdukt", p);
        }

        public IActionResult sparaProdukt(Produkt p)
        {
            // Ett anrop https://localhost/Produkt/sparaProdukt leda hit
            Produkt.sparaProdukt(p);
            ;
            return View("Index", Produkt.getAllProdukt() );
        }



        public IActionResult NyProdukt()
        {
            return View();
        }
    }
}
