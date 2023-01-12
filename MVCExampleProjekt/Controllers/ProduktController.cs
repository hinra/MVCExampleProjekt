using Microsoft.AspNetCore.Mvc;
using MVCExampleProjekt.Models;

namespace MVCExampleProjekt.Controllers
{
    public class ProduktController : Controller
    {
        public IActionResult Index()
        {

            return View(Produkt.getAllProdukt() );
        }

        public IActionResult RedigeraProdukt()
        {
            return View();
        }

        public IActionResult showDetail(int id)
        {
            Produkt p = Produkt.getSingleProduktById(id);
            return View("RedigeraProdukt", p);
        }

        public IActionResult sparaProdukt(Produkt p)
        {
            Produkt.sparaProdukt(p);
           
            return View("Index", Produkt.getAllProdukt());
        }



        public IActionResult NyProdukt()
        {
            return View();
        }
    }
}
