using Microsoft.AspNetCore.Mvc;

namespace MVCExampleProjekt.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult NyOrder()
        {
            return View();
        }

        public IActionResult RedigeraOrder()
        {
            return View();
        }


    }
}
