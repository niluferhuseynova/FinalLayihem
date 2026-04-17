using Feane.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DishController : Controller
    {
        private readonly DishService service;

        public DishController(DishService service)
        {
            this.service = service;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(DishCreateVN vm) //parametr list 
        {
            if(!ModelState.IsValid) 
                return View(vm);
            if(vm.Image.CheckSize(2))
            {
                ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                return View();
                
                    if (!vm.Images.CheckType("Image"))
                
                {
                    ModelState.AddModelError("Image", "Zehmet olmasa image tipli data ywkleyin");
                    return View();
                }
                await service.CreateAsync(vm);
                return RedirectToAction(nameof(Index));
            }
        }



    }
}
