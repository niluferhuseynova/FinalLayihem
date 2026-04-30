using Feane.Services.Implementations;
using Feane.Services.Interfaces;
using Feane.ViewModels.Slider;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _service;

        public SliderController(ISliderService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _service.GetAllAsync();
            return View(product);
        }
        [HttpGet]
        public IActionResult Slider()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(SliderCeateVM vm) //parametr list {

        {

            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));
        }


      
        
        
    }
}
