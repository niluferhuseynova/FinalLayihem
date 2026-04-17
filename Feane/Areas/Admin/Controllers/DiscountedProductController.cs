using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountedProductService : Controller
    {
        private readonly DiscountedProductService  service;

        public DiscountedProductService(DiscountedProductService service)
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
        [HttpGet]
        public async Task<IActionResult> CreateAsync(DiscountedProductCreateVM vm) //parametr list
        {
           if(!ModelState.IsValid) 
                return View(vm);
           
            {
                ModelState.AddModelError("Image", "sekilin [lcusu 2mb-dan cox ola bilmez");
                return View();  
            }
            if (!vm.Image.CheckSize(2))
            {
                ModelState.AddModelError("Image", "Zehmet olmasa image tipli data ywkleyin");
                return View();
            }
                await service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));
        }
    }
}
