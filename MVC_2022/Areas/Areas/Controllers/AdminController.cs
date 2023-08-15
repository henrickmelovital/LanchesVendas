using Microsoft.AspNetCore.Mvc;

namespace MVC_2022.Areas.Areas.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
