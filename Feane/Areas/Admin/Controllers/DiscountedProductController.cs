using Feane.Helper;
using Feane.Services.Interfaces;
using Feane.ViewModels.DiscountedProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountedProductService : Controller
    {
        private readonly IDiscountedProductService  _service;

        public DiscountedProductService(IDiscountedProductService service)
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
        [HttpGet]
        public async Task<IActionResult> CreateAsync(DiscountedProductCreateVM vm) //parametr list
        {
           if(!ModelState.IsValid) 
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
    }
}
