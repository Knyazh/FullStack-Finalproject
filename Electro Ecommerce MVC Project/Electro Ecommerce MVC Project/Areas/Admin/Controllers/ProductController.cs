using Electro_Ecommerce_MVC_Project.Areas.Admin.ViewModels.Product;
using Electro_Ecommerce_MVC_Project.Contracts;
using Electro_Ecommerce_MVC_Project.Database;
using Electro_Ecommerce_MVC_Project.Database.Models;
using Electro_Ecommerce_MVC_Project.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Electro_Ecommerce_MVC_Project.Areas.Admin.Controllers;
[Route("admin/products")]
[Area("admin")]
public class ProductController : Controller
{
    private readonly EcommerceDbContext _DbContext;
    private readonly IFileService _fileService;

    public ProductController(EcommerceDbContext context, IFileService fileService)
    {
        _DbContext = context;
        _fileService = fileService;
    }

    [HttpGet("add")]
    public IActionResult Add()
    {
        var model = new ProductAddViewModel
        {
            Categories = _DbContext.Categories.ToList(),
            Memories = _DbContext.Memories.ToList(),
            Colors = _DbContext.Colors.ToList(),
        };

        return View(model);
    }


    [HttpPost("add")]

    public IActionResult Add(ProductAddViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            var model = new ProductAddViewModel
            {
                Categories = _DbContext.Categories.ToList(),
                Memories = _DbContext.Memories.ToList(),
                Colors = _DbContext.Colors.ToList(),
            };
            return View(model);
        }

        Product newProduct = new Product
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            Price = viewModel.Price,
            UpdateDate = DateTime.UtcNow,
            CreateDate = DateTime.UtcNow
        };

        if (viewModel.Image is not null)
        {
            newProduct.PhysicalImageName = _fileService
                .Upload(viewModel.Image, CustomUploadDirectories.Products);
        }

        _DbContext.Products.Add(newProduct);

        foreach (var categoryID in viewModel.CategoryIds)
        {
            var category = _DbContext.Categories.SingleOrDefault(c => c.Id == categoryID);
            if (category is null)
            {
                var categories = _DbContext.Categories.ToList();
                ModelState.AddModelError("CategoryIds", "Category not found");
                return View(categories);
            }
            var productCategory = new ProductCategory
            {
                CategoryId = category.Id,
                Product = newProduct
            };
            _DbContext.ProductCategories.Add(productCategory);
        }

        foreach (var memoryID in viewModel.MemoryIds)
        {
            var memory = _DbContext.Memories.SingleOrDefault(m => m.Id == memoryID);

            if (memory is null)
            {
                var memories = _DbContext.Memories.ToList();
                ModelState.AddModelError("MemoryIds", "Memory not found");
                return View(memories);
            }

            var productMemory = new ProductMemory
            {
                MemoryId=memory.Id,
                Product=newProduct
            };

            _DbContext.ProductMemories.Add(productMemory);

        }

        foreach(var colorID in viewModel.ColorIds)
        {
            var color = _DbContext.Colors.SingleOrDefault(c=>c.Id == colorID);
            if(color is null)
            {
                var colors = _DbContext.Colors.ToList();
                ModelState.AddModelError("ColorIds", "Color not found");
                return View(colors);
            }

            var productColor = new ProductColor
            {
                ColorId = color.Id,
                Product = newProduct
            };

            _DbContext.ProductColors.Add(productColor);

        }
        

        return View(viewModel);
    }

}
