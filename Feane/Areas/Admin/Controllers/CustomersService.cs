using Feane.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly CustomersService service;

        public CustomersController(CustomersService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomersCreateVM vm) // parametr list    
        {

            await service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));
        }                                                                
    }
}
