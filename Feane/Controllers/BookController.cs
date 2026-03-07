using Microsoft.AspNetCore.Mvc;

namespace Feane.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
