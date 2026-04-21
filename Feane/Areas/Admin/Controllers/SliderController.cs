using Feane.Services.Implementations;
using Feane.Services.Interfaces;
using Feane.ViewModels.SliderProduct;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View();
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
