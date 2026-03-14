using System.ComponentModel.DataAnnotations;

namespace Feane.ViewModels.DiscountedProduct
{
    public class DiscountedProductCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; } = string.Empty;
        [Required]
        
        public double Percentage { get; set; }

    }
}
