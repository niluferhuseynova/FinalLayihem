using Feane.Helper;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.Customers;
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
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var discountedProduct  = await _service.GetByIdAsync(id);
            DiscountedProductUpdateVM vm  = discountedProduct;
            if (discountedProduct== null)
                return NotFound();
            return View(discountedProduct);

            [HttpPost]
            public  async Task<IActionResult> Update(DiscountedProductUpdateVM vm)
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
            }  
            await _service.Update(vm);
            return RedirectToAction(nameof(Index));

        }

    }   
}
