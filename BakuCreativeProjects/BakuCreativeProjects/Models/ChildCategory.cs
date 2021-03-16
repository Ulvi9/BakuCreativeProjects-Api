using System.Collections;
using System.Collections.Generic;

namespace BakuCreativeProjects.Models
{
    public class ChildCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}