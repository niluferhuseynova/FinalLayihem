using Feane.ViewModels.DiscountedProduct;

namespace Feane.ViewModels.Dish.Product
{
    public class DishProduct
    {
        public IFromFile? Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DishPrice { get; set; }


    }
}
