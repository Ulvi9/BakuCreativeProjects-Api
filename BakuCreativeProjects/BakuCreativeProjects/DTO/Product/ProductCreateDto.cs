using System.ComponentModel.DataAnnotations;

namespace BakuCreativeProjects.DTO
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int ChildCategoryId { get; set; }
    }
}