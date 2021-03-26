using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace BakuCreativeProjects.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}