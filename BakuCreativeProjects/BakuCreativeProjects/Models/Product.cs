using System.Collections.Generic;

namespace BakuCreativeProjects.Models
{
    public class Product
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int ChildCategoryId { get; set; }
        public ChildCategory ChildCategory { get; set; }

    }
}