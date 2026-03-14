using Feane.ViewModels.DiscountedProduct;
using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.SliderProduct
{
    public class SliderCeateVM
    {

        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
