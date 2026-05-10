using Feane.Context;
using Feane.Models;
using Feane.ViewModels.DiscountedProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Feane.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.DiscountedProducts.Select(p => new DiscountedProductGetVM()
            {
                Id = p.Id,
                Name = p.Name,
                ImageName = p.ImageName,
                Percentage = p.Percentage
            }).ToListAsync();
            return View(products);
        }
    }
}
