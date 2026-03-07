using Microsoft.AspNetCore.Mvc;

namespace Feane.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
