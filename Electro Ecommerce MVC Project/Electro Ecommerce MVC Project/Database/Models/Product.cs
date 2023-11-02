namespace Electro_Ecommerce_MVC_Project.Database.Models;

public class Product
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PhysicalImageName { get; set;}
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }


    public List<ProductCategory> ProductCategories { get; set;}
    public List<ProductColor> ProductColors { get; set; }

    public List<ProductMemory> ProductMemories { get; set; }
}
