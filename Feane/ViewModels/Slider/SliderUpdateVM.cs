using Feane.ViewModels.DiscountedProduct;

namespace Feane.ViewModels.SliderProduct
{
    public class SliderUpdateVM
    {
        public int Id { get; set; }
        public IFromFile? Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
