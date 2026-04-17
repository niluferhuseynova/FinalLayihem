using Feane.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppearanceController : Controller
    {
        private readonly AppearanceService service;

        public AppearanceController(AppearanceService service)
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
        public async Task<IActionResult> CreateAsync(AppearanceCreateVM vm) //parametr list
        {
            if (!ModelState.IsValid)
                return View(vm);
            if (vm.Image.CheckSize(2))
            {
                ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                return View();
                {
                    if (!vm.Image.CheckType("Image"))
                    {
                        ModelState.AddModelError("Image", "Zehmet olmasa image data yukleyin");
                        return View(vm);
                    }
                    await service.CreateAsync(vm);
                    return RedirectToAction(nameof(Index));
                }
            }
        }

    }
}                                                                      
                                                                          

                                                                            
           
         

    

