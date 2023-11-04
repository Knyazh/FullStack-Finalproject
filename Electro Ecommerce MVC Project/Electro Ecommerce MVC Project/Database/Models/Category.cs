using Electro_Ecommerce_MVC_Project.Database.Base;

namespace Electro_Ecommerce_MVC_Project.Database.Models;

public class Category : BaseEntity<int> ,IAuditable  
{
    public string Name { get; set; }
    public string Description { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set;}
    public List<ProductCategory> ProductCategories { get; set; }
   
}
