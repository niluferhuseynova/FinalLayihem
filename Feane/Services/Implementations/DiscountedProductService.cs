using Feane.Context;
using Feane.Helper;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.DiscountedProduct;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class DiscountedProductService : IDiscountedProductService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly string _FolderPath;

        public DiscountedProductService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _FolderPath = Path.Combine(_env.WebRootPath, "images");
        }

        public async Task CreateAsync(DiscountedProductCreateVM vm)
        {
            string uniqueFileName = await vm.Image.FileUploadAsync(_FolderPath);
            DiscountedProduct discountedProduct = new()
            {
              Name = vm.Name,
              Percentage = vm.Percentage,
              ImageName = uniqueFileName 
            };
            await _context.DiscountedProducts.AddAsync(discountedProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var discountedproduct=  await _context.DiscountedProducts.FindAsync(id);
            if (discountedproduct == null) return;
            _context.DiscountedProducts.Remove(discountedproduct);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DiscountedProductGetVM>> GetAllAsync()
        {
            return await _context.DiscountedProducts.Select(p => new DiscountedProductGetVM ()
            {
                Id = p.Id,
                Name = p.Name,
                ImageName= p.ImageName,
                Percentage = p.Percentage
            }).ToListAsync();
        }

        public async Task GetByIdAsync(int id)
        {
            await _context.DiscountedProducts.FindAsync(id);
            return;
        }

        public Task Update(DiscountedProductUpdateVM vm)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
