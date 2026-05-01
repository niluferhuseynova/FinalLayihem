using Feane.Helper;
using Feane.Services.Implementations;
using Feane.Services.Interfaces;
using Feane.ViewModels.Dish.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DishController : Controller
    {
        private readonly IDishService _service;

        public DishController(IDishService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var product = await _service.GetAllAsync();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(DishCreateVM vm) //parametr list 
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (!vm.Image.CheckSize(2))
            {
                ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                return View(vm);
            }
            if (!vm.Image.CheckType("Image"))
            {
                ModelState.AddModelError("Image", "Zehmet olmasa image data yukleyin");
                return View(vm);
            }
            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
