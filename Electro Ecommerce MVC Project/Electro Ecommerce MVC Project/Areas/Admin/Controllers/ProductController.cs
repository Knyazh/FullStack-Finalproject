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

        _DbContext.SaveChanges();

        return View(viewModel);
    }


    [HttpGet("read")]
    public IActionResult Read()

    {
        var products = _DbContext.Products.OrderBy(p => p.CreateDate).ToList();
        var productList = ConvertProductsToViewModel(products);
        var colors = _DbContext.Colors.ToList();
        return View(productList);
    }

    public List<ProductListItemViewModel> ConvertProductsToViewModel(List<Product> products)
    {
        List<ProductListItemViewModel> viewModels = new List<ProductListItemViewModel>();

        foreach (var product in products)
        {
            ProductListItemViewModel viewModel = new ProductListItemViewModel
            {
                ID = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = _fileService.GetStaticFilesUrl(CustomUploadDirectories.Products, product.PhysicalImageName),
                Colors = _DbContext.ProductColors.Where(pc => pc.ProductId == product.Id).Select(pc => pc.Color).ToList(),
                Memories = _DbContext.ProductMemories.Where(pm => pm.ProductId == product.Id).Select(pm => pm.Memory).ToList(),
                Categories = _DbContext.ProductCategories.Where(cp => cp.ProductId == product.Id).Select(cp => cp.Category).ToList(),
            };

            viewModels.Add(viewModel);
        }

        return viewModels;
    }

    [HttpGet("{id}/update")]
    public IActionResult Update(int id)
    {
        var product = _DbContext.Products.SingleOrDefault(p => p.Id == id);
        if (product is null)
        {
            return RedirectToAction("NotFoundPage", "ErrorPages");
        }
        var colors = _DbContext.ProductColors.Where(pc => pc.ProductId == product.Id).Select(pc => pc.Color).ToList();
        var memories = _DbContext.ProductMemories.Where(pm => pm.ProductId == product.Id).Select(pm => pm.Memory).ToList();
        var categories = _DbContext.ProductCategories.Where(cp => cp.ProductId == product.Id).Select(cp => cp.Category).ToList();
        var model = new ProductUpdateViewModel
        {
            Colors = colors,
            Memories = memories,
            Categories = categories,
            ProductId = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = _fileService.GetStaticFilesUrl(CustomUploadDirectories.Products, product.PhysicalImageName),
            NewColors = _DbContext.Colors.ToList(),
            NewMemories = _DbContext.Memories.ToList(),
            NewCategories = _DbContext.Categories.ToList()
        };
        return View(model);
    }

    [HttpPost("{id}/update")]
    public IActionResult Update(ProductUpdateViewModel model)
    {
        var product = _DbContext.Products.SingleOrDefault(p => p.Id == model.ProductId);
        if (!ModelState.IsValid)
        {
            var newViewModel = new ProductUpdateViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = _fileService.GetStaticFilesUrl(CustomUploadDirectories.Products, product.PhysicalImageName),
                Colors = _DbContext.ProductColors.Where(pc => pc.ProductId == product.Id).Select(pc => pc.Color).ToList(),
                Categories = _DbContext.ProductCategories.Where(cp => cp.ProductId == product.Id).Select(cp => cp.Category).ToList(),
                Memories = _DbContext.ProductMemories.Where(pm => pm.ProductId == product.Id).Select(pm => pm.Memory).ToList(),
                NewColors = _DbContext.Colors.ToList(),
                NewCategories = _DbContext.Categories.ToList(),
                NewMemories = _DbContext.Memories.ToList(),
            };

            return View(newViewModel);
        }
        if (product is null)
        {
            return RedirectToAction("NotFoundPage", "ErrorPages");
        }

        var previousFileName = product.PhysicalImageName;

        if (model.Image != null)
        {
            product.PhysicalImageName = _fileService.Upload(model.Image, CustomUploadDirectories.Products);
        }

        product.Name = model.Name;
        product.Price = model.Price;
        product.Description = model.Description;
        product.UpdateDate = DateTime.UtcNow;

        _DbContext.Products.Update(product);

        if (model.Image != null && previousFileName != null)
        {
            var previousFullPath = _fileService
                .GetStaticFilesDirectory(CustomUploadDirectories.Products, previousFileName);

            System.IO.File.Delete(previousFullPath);
        }



        List<ProductColor> existProductColors = new List<ProductColor>();
        List<ProductMemory> existProductMemory = new List<ProductMemory>();
        List<ProductCategory> existProductCategory = new List<ProductCategory>();
        var ProductColors = _DbContext.ProductColors.Where(pc => pc.ProductId == product.Id).ToList();
        existProductColors.AddRange(ProductColors);
        var ProductMemories = _DbContext.ProductMemories.Where(ps => ps.ProductId == product.Id).ToList();
        existProductMemory.AddRange(ProductMemories);
        var ProductCategies = _DbContext.ProductCategories.Where(cp => cp.ProductId == product.Id).ToList();
        existProductCategory.AddRange(ProductCategies);

        #region Category
        foreach (var categoryID in model.CategoryIds)
        {
            bool result = _DbContext.ProductCategories.Contains(_DbContext.ProductCategories.SingleOrDefault(cp => cp.CategoryId.Equals(categoryID) && cp.ProductId.Equals(product.Id)));
            if (result is false)
            {
                var newProductCategory = new ProductCategory
                {
                    CategoryId = categoryID,
                    ProductId = product.Id,
                };
                _DbContext.ProductCategories.Add(newProductCategory);
            }
            else
            {
                existProductCategory.Remove(_DbContext.ProductCategories.SingleOrDefault(cp => cp.CategoryId.Equals(categoryID) && cp.ProductId.Equals(product.Id))!);
            }
        }
        #endregion
        #region Color
        foreach (var colorID in model.ColorIds)
        {
            bool result = _DbContext.ProductColors.Contains(_DbContext.ProductColors.SingleOrDefault(pc => pc.ColorId.Equals(colorID) && pc.ProductId.Equals(product.Id)));
            if (result is false)
            {
                var newProductColor = new ProductColor
                {
                    ColorId = colorID,
                    ProductId = product.Id,
                };
                _DbContext.ProductColors.Add(newProductColor);
            }
            else
            {
                existProductColors.Remove(_DbContext.ProductColors.SingleOrDefault(pc => pc.ColorId.Equals(colorID) && pc.ProductId.Equals(product.Id))!);
            }

        }
        #endregion


        #region Memory

        foreach (var memoryID in model.SizeIds)
        {
            bool result = _DbContext.ProductMemories.Contains(_DbContext.ProductMemories.SingleOrDefault(pm => pm.MemoryId.Equals(MemoryID) && pm.ProductId.Equals(product.Id)));
            if (result is false)
            {
                var newProductMemory = new ProductMemory
                {
                    MemoryId =memoryID,
                    ProductId = product.Id,
                };
                _DbContext.ProductMemories.Add(newProductMemory);
            }
            else
            {
                existProductMemory.Remove(_DbContext.ProductMemories.SingleOrDefault(pm => pm.MemoryId.Equals(memoryID) && pm.ProductId.Equals(product.Id))!);

            }

        }

        #endregion

        _DbContext.ProductCategories.RemoveRange(existProductCategory);
        _DbContext.ProductMemories.RemoveRange(existProductMemory);
        _DbContext.ProductColors.RemoveRange(existProductColors);

        _DbContext.SaveChanges();

        return RedirectToAction("Read", "Product");
    }
    [HttpPost("{id}/delete")]
    public IActionResult Delete(int id)
    {
        var product = _DbContext.Products.Where(product => product.Id == id).SingleOrDefault();
        if (product is null)
        {
            return RedirectToAction("NotFoundPage", "ErrorPages");
        }
        _DbContext.Products.Remove(product);
        _DbContext.SaveChanges();
        return RedirectToAction(nameof(Read));
    }

}
