using Feane.Helper;
using Feane.Services.Implementations;
using Feane.Services.Interfaces;
using Feane.ViewModels.Appaeareance;
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
        public async Task<IActionResult> CreateAsync(BookTableGetVM vm) //parametr list 
        {

            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var BookTable = await _service.GetByIdAsync(id);
            if (BookTable == null)
                return NotFound();
            return View(BookTable);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BookTableUpdateVM vm)
        {
            await _service.Update(vm);
            return RedirectToAction(nameof(Index));
        }


            
    }

}
