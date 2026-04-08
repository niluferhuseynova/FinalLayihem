

using Feane.Context;
using Feane.Helper;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.Appaeareance.cs;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace Feane.Services.Implementations
{
    public class AppearanceService : IAppearanceService
        
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly string _folderPath;
       
        public AppearanceService(AppDbContext context, IWebHostEnvironment env, string folderPath)
        {
            _context = context;
            _env = env;
            _folderPath = Path.Combine(_env.WebRootPath, "images");
        }

        public async Task CreateAsync(AppaereanceCreateVM vm)

        {
            string uniqueFileName = await vm.ImageName.FileUploadAsync(_folderPath);
            Appeareance appeareance = new()
            {
                Title = vm.Title,
                ImageName = uniqueFileName,
                Description = vm.Description
            };
            await _context.Appeareances.AddAsync(appeareance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appearance = await _context.Appeareances.FindAsync(id);
            if (appearance== null) return;
            _context.Appeareances.Remove(appearance);
            await _context.SaveChangesAsync();
        }
        public async Task<List<AppaeareanceGetVM>> GetAllAsync()
        {
            return await _context.Appeareances.Select(p => new AppaeareanceGetVM ()
            {
                Title = p.Title,
                Description = p.Description,
                Id = p.Id
            }).ToListAsync();
        }

        public async Task<AppaeareanceUpdateVM> GetByIdAsync(int id)
        {
            var product = await _context.Appeareances.FindAsync(id);
            if (product is null) return null;

            return new AppaeareanceUpdateVM
            {
                Description = product.Description,
                Id = product.Id,
                Title = product.Title
            };
        }
        public async Task Update(AppaeareanceUpdateVM vm)
        {
            var product = await _context.Appeareances.FindAsync(vm.Id);
            if (product is null) return;

            if(vm.ImageName is not null)
            {
                string newImage = await vm.ImageName.FileUploadAsync(_folderPath);
                string oldImage = Path.Combine(_folderPath, product.ImageName);
                ExtensionMethod.DeleteFile(oldImage);
                product.ImageName = newImage;
            }
            product.ImageName = vm.ImageName;
            product.Percentage = vm.Percentage;

            _context.DiscountedProducts.Update(product);
            await _context.SaveChangesAsync();
        }

       
    }
}
