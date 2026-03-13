namespace Feane.ViewModels.DiscountedProduct
{
    public class DiscountedProductCreateVM
    {   
        public int Id {  get; set; }
        public IFromFile? Image { get; set; }
        public string Name { get; set; } 
        public double Percentage { get; set; }

    }
}
