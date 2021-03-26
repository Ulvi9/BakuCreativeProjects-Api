using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakuCreativeProjects.Models
{
    public class Product
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public int ChildCategoryId { get; set; }
        public ChildCategory ChildCategory { get; set; }

    }
}