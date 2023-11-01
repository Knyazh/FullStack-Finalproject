using Microsoft.AspNetCore.Mvc;

namespace Electro_Ecommerce_MVC_Project.Areas.Admin.Controllers;

[Route("admin/dash")]
[Area("admin")]
public class DashBoardController : Controller
{
    [HttpGet("index")]
    public IActionResult Index()
    {
        return View();
    }
}
