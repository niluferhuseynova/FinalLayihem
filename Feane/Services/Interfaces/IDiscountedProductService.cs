using Feane.ViewModels.DiscountedProduct;

namespace Feane.Services.Interfaces
{
    public interface IDiscountedProductService
    {
        Task <List<DiscountedProductGetVM>>GetAllAsync();    
    }
}
