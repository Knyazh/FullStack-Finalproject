

using Electro_Ecommerce_MVC_Project.Database.Models;

namespace Electro_Ecommerce_MVC_Project.Areas.Admin.ViewModels.Product;

public class ProductListItemViewModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }

    public List<Color> Colors { get; set; }
    public List<Memory> Memories { get; set; }
    public List<Category> Categories { get; set; }

}
