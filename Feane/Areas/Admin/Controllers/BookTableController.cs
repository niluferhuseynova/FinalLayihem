using Feane.Services.Implementations;
using Feane.ViewModels.BookTable;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers

{
    [Area("Admin")]
    public class BookTableController : Controller
    {
        private readonly BookTableService service;

        public BookTableController(BookTableService service)
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
        public async Task<IActionResult> CreateAsync(BookTableCreateVM vm) //parametr list 
        {

            await service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));

        }
    }
}
