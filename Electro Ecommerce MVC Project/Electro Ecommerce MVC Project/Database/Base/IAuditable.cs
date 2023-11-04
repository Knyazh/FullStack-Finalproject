namespace Electro_Ecommerce_MVC_Project.Database.Base;

public interface IAuditable
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
