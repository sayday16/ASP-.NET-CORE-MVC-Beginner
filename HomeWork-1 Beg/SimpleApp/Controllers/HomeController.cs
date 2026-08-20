using Microsoft.AspNetCore.Mvc;

namespace SimpleApp.Controllers
{
    namespace SimpleApp.Controlles {
        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        } 
    }
}
