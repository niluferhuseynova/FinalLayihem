using Feane.Context;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.SliderProduct;
using Microsoft.EntityFrameworkCore;

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
            string uniqueFileName = await vm.Image.FileUploadAsync(_FolderPath);
            Slider slider = new();
            {
             
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

        public async Task GetByIdAsync(int id)
        {
            await _context.Sliders.FindAsync(id)
            return;
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SliderUpdateVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
