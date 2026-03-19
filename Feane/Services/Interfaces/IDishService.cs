using Feane.Services.Implementations;
using Feane.ViewModels.Dish.Product;

namespace Feane.Services.Interfaces
{
    public class IDishService 
    {
        Task<List<DishGetVM>> GettAll { get;>> }
      
}
