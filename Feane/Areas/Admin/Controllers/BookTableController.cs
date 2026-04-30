using Feane.Services.Implementations;
using Feane.Services.Interfaces;
using Feane.ViewModels.BookTable;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Feane.Areas.Admin.Controllers

{
    [Area("Admin")]
    public class BookTableController : Controller
    {
        private readonly IBookTableService _service;

        public BookTableController(IBookTableService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _service.GetAllAsync();
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(BookTableCreateVM vm) //parametr list 
        {

            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));

        }
    }
}
