using Feane.Models.Base;

namespace Feane.Models
{
    public class DiscountedProduct : BaseEntity
    {
        public string ImageUrl {  get; set; } = null!;
        public string ImageNameName { get; set; } = null!;
        public double Percentage { get; set; } 


    }
}
