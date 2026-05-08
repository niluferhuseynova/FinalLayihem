using Feane.Helper;
using Feane.Services.Interfaces;
using Feane.ViewModels.Appaeareance;
using Feane.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Feane.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly ICustomersService _service;

        public CustomersController(ICustomersService service)
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
        public async Task<IActionResult> CreateAsync(CustomersCreateVM vm) // parametr list                                                                
        {
            if(!ModelState.IsValid) 
                return View(vm);
            if (!vm.ImageName.CheckSize(2))
            {
                ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                return View(vm);
            }
            if (!vm.ImageName.CheckType("Image"))
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
            var Customers = await _service.GetByIdAsync(id);
            CustomersUpdateVM customers = Customers;
            if (customers ==null)
                return NotFound();
            return View(Customers); 
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomersUpdateVM vm)
        {

            if (!ModelState.IsValid)
                return View(vm);
            if (!vm.ImageName.CheckSize(2))
            {
                ModelState.AddModelError("Image", "seklin olcusu 2mb-dan cox ola bilmez");
                return View(vm);
            }
            if (!vm.ImageName.CheckType("Image"))
            {
                ModelState.AddModelError("Image", "Zehmet olmasa image data yukleyin");
                return View(vm);
            }
            await _service.Update(vm);
            return RedirectToAction(nameof(Index));
        }

    }
}
