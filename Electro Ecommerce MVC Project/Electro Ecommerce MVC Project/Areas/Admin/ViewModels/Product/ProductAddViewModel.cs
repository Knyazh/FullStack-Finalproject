using Electro_Ecommerce_MVC_Project.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Electro_Ecommerce_MVC_Project.Areas.Admin.ViewModels.Product;

public class ProductAddViewModel
{
    [Required(ErrorMessage = "Add Product Name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Add Product Description.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Add Product Price.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Please min 1 category select.")]
    public int[] CategoryIds { get; set; }
    public List<Electro_Ecommerce_MVC_Project.Database.Models.Category>? Categories { get; set; }

    [Required(ErrorMessage = "Please enter memory.")]
    public int[] MemoryIds { get; set; }
    public List<Electro_Ecommerce_MVC_Project.Database.Models.Memory>? Memories { get; set; }

    [Required(ErrorMessage = "Please enter minimum one Color.")]
    public int[] ColorIds { get; set; }
    public List<Electro_Ecommerce_MVC_Project.Database.Models.Color>? Colors { get; set; }
    [Required(ErrorMessage = "Product image must be add.")]
    public IFormFile Image { get; set; }
}
