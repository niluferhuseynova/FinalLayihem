using Feane.Context;
using Feane.Models;
using Feane.ViewModels.Appaeareance;
using Feane.ViewModels.BookTable;
using Feane.ViewModels.Customers;
using Feane.ViewModels.DiscountedProduct;
using Feane.ViewModels.Dish.Product;
using Feane.ViewModels.Slider;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Feane.Controllers
{
    public class HomeVM : Controller
    {
        private readonly AppDbContext _context;

        public HomeVM()
        {
        }

        public HomeVM(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM();
            var products = await _context.DiscountedProducts.Select(p => new DiscountedProductGetVM()
            {
                Id = p.Id,
                Name = p.Name,
                ImageName = p.ImageName,
                Percentage = p.Percentage
            }).ToListAsync();

            var product = await _context.Appeareances.Select(p => new AppeareanceGetVM()
            {
                Description = p.Description,
                Id = p.Id,
                ImageName = $"{p.ImageName}",
                Title = p.Title
            }
            ).ToListAsync();
            var product = await _context.BookTables.Select( p => new BookTableGetVM()
            {
                Id=p.Id,
                PersonNumber = p.PersonNumber
                
            }
            ).ToListAsync();
            var product = await _context.Customers.Select( p => new CustomersGetVM()
            {
                Name = p.Name,
                Comment = p.Comment,
                Id = p.Id,
                ImageName= p.ImageName,
                ImageUrl = p.ImageUrl
            }
            ).ToListAsync();
            var product = await _context.Dish.Select(p => new DishGetVM() 
            {
                Id = p.Id,
                Name = p.Name
                
            }
            ).ToListAsync();
            
            var product = _context.Sliders.Select(p => new SliderGetVM()
            {
                Name = p.Name,
                Description = p.Description,
                Id = p.Id,                           
            }
            ).ToListAsync();
            return View(product);
            

            
           
            

            

        }

       
    }
}
