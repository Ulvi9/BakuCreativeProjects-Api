using System.Collections.Generic;

namespace BakuCreativeProjects.Models
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }

    }
}