using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    public class BookTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
