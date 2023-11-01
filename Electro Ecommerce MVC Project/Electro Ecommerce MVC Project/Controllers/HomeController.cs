using Microsoft.AspNetCore.Mvc;

namespace Electro_Ecommerce_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
