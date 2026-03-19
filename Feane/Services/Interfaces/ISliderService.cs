using Feane.ViewModels.SliderProduct;

namespace Feane.Services.Interfaces
{
    public interface ISliderService
    {
        Task<List<SliderGetVM>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task CreateAsync(SliderCeateVM vm );
        Task Update(int id );
        Task Update (SliderUpdateVM vm );
        Task DeleteAsync(int id);


    }
}
