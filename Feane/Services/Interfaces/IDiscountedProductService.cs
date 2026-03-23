using Feane.ViewModels.DiscountedProduct;

namespace Feane.Services.Interfaces
{
    public interface IDiscountedProductService
    {
        Task <List<DiscountedProductGetVM>>GetAllAsync();  
        Task GetByIdAsync (int id);
        Task CreateAsync (DiscountedProductCreateVM vm);
        Task Update(DiscountedProductUpdateVM vm);
        Task DeleteAsync (int id);
        Task Update(int id);

    }
}
