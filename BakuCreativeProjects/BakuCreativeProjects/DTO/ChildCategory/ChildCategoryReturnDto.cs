using System.Collections.Generic;
using BakuCreativeProjects.Models;

namespace BakuCreativeProjects.DTO.ChildCategory
{
    public class ChildCategoryReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubCategory { get; set; }
        public string MainCategory { get; set; }
        public ICollection<string> Products { get; set; }


    }
}