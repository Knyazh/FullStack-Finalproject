namespace Electro_Ecommerce_MVC_Project.Database.Models;

public class Memory
{

    public int Id { get; set; }
    public decimal Count { get; set; }
    public DateTime CreatedDate  { get; set; }
    public DateTime UpdatedDate { get; set; }

    public List<ProductMemory> ProductMemories { get; set; }
}
