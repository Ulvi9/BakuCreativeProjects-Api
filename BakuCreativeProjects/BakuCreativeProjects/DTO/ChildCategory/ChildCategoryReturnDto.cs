using System.Collections.Generic;
using BakuCreativeProjects.DTO.Product;

namespace BakuCreativeProjects.DTO.ChildCategory
{
    public class ChildCategoryReturnDto
    {
        public string Name { get; set; }

        public string SubCategory { get; set; }
        public string MainCategory { get; set; }
        public ICollection<string> Productss { get; set; }


    }
}