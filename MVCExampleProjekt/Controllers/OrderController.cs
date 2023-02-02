using Microsoft.AspNetCore.Mvc;
using MVCExampleProjekt.Models; 

namespace MVCExampleProjekt.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
            List<Order> allaOrder = Order.getEveryOrder();  
			return View(allaOrder);

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
