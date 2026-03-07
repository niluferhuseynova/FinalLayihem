using Feane.Models.Base;

namespace Feane.Models
{
    public class Appeareance : BaseEntity
    { 
    public string Title { get; set; } = null!;
    public string ImageName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string Description { get; set; }



    }
}
