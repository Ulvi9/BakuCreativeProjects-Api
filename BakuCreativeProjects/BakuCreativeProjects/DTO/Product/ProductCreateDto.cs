using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace BakuCreativeProjects.DTO
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int ChildCategoryId { get; set; }
        [NotMapped,Required]
        public IFormFile[] Images { get; set; }
    }
}