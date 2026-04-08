using Feane.Context;
using Feane.Helper;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.SliderProduct;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Feane.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;

        public SliderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(SliderCeateVM vm)
        {
            string uniqueFileName = await vm.Name.FileUploadAsync(_FolderPath);
            Slider slider = new();
            {
                Name = p.Name,
                Description = p.Description
            }
        }
        public async Task DeleteAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return; 
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SliderGetVM>> GetAllAsync()
        {
            return await _context.Sliders.Select(p => new SliderGetVM()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
                
            }).ToListAsync();
            
        }

        public async Task<SliderUpdateVM> GetByIdAsync(int Id)
        {
           var product = await _context.Sliders.FindAsync(Id)
            if (product is null) return null;

            return new SliderUpdateVM()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            };
        }

        public async Task Update(SliderUpdateVM vm)
        {
            var product = await _context.Sliders.FindAsync(Id);
            if (product is null) return;

            if (vm.Image is not null)
            {
                string newImage =await vm.Image.FileUploadAsync(_folderPath);
                string oldImage = Path.Combine(_folderPath, product.ImageName);
                ExtensionMethod.DeleteFile(oldImage);
                product.Image = newImage;
            }
            product.Name = vm.Name;
            product.Description = vm.Description;

            _context.Sliders.Update(product);
            await _context.SaveChangesAsync();

        }

       
    }
}
