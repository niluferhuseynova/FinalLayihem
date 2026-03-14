namespace Feane.ViewModels.Dish.Product
{
    public class DishGetVM
    {
       public int Id { get; set; }  
        public string ImageName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal DishPrice { get; set; }
    }
}
