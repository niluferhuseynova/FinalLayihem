using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    public class AppearanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
