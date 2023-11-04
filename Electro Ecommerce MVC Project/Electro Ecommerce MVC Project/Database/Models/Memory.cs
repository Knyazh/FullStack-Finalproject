using Electro_Ecommerce_MVC_Project.Database.Base;

namespace Electro_Ecommerce_MVC_Project.Database.Models;

public class Memory : BaseEntity<int>, IAuditable
{

    public string Count { get; set; }
    public DateTime CreatedDate  { get; set; }
    public DateTime UpdatedDate { get; set; }

    public List<ProductMemory> ProductMemories { get; set; }
}
