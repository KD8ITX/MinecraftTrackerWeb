using Microsoft.AspNetCore.Mvc;

namespace MinecraftTrackerWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
