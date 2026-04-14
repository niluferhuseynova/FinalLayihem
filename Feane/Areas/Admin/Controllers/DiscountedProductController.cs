using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    public class DiscountedProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
