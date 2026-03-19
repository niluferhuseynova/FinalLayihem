using Feane.ViewModels.Dish.Product;

namespace Feane.Services.Interfaces
{
    public interface IDishService
    { 
        Task<List<DishGetVM>>GetAllAsync();
        Task GetByIdAsync(int id);
        Task CreateAsync(DishCreateVM vm);
        Task Update(DishUpdateVM vm);
        Task Update(int id);
        Task DeleteAsync(int id);
       
    }
}
