namespace Electro_Ecommerce_MVC_Project.Database.Models
{
    public class ProductCategory
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
