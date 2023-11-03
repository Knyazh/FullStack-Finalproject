using System.ComponentModel.DataAnnotations;

namespace Electro_Ecommerce_MVC_Project.Areas.Admin.ViewModels.Category
{
    public class CategoryAddViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
