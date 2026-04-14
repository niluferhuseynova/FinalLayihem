using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
