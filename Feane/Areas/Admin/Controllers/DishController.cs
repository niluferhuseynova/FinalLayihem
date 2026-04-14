using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    public class DishController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
