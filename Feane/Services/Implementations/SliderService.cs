using Feane.Services.Interfaces;
using Feane.ViewModels.SliderProduct;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class SliderService : ISliderService
    {
        public Task CreateAsync(SliderCeateVM vm)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var SilderService = await _context.SilderService.FindAsync(id);
            if (SilderService == null) return; 
            _context.SilderService.Remove(SilderService);
            await _context.SaveChangesAsync();
        }
            
        }

        public Task<List<SliderGetVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
