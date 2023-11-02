namespace Electro_Ecommerce_MVC_Project.Database.Models;

public class Color
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<ProductColor> ProductColors { get; set; }
}
