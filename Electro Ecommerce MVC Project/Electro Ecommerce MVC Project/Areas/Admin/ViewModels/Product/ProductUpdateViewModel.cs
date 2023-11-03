using Electro_Ecommerce_MVC_Project.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Electro_Ecommerce_MVC_Project.Areas.Admin.ViewModels.Product;

public class ProductUpdateViewModel
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Product price is required.")]

    public decimal Price { get; set; }

    [Required(ErrorMessage = "At least one category must be selected.")]
    public int[] CategoryIds { get; set; }
    public List<Electro_Ecommerce_MVC_Project.Database.Models.Category>? Categories { get; set; }

    [Required(ErrorMessage = "At least one size must be selected.")]
    public int[] SizeIds { get; set; }
    public List<Electro_Ecommerce_MVC_Project.Database.Models.Memory>? Memories { get; set; }

    [Required(ErrorMessage = "At least one color must be selected.")]
    public int[] ColorIds { get; set; }
    public List<Electro_Ecommerce_MVC_Project.Database.Models.Color>? Colors { get; set; }

    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "You must add a product image.")]
    public IFormFile Image { get; set; }

    public List<Electro_Ecommerce_MVC_Project.Database.Models.Color>? NewColors { get; set; }
    public List<Electro_Ecommerce_MVC_Project.Database.Models.Memory>? NewMemories { get; set; }
    public List<Electro_Ecommerce_MVC_Project.Database.Models.Category>? NewCategories { get; set; }

}
