using System.ComponentModel.DataAnnotations;

namespace MangoBlog.Model
{
    public class CategoryModel
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
