using System.Collections;
using System.Collections.Generic;

namespace BakuCreativeProjects.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public ICollection<ChildCategory> ChildCategories { get; set; }
    }
}