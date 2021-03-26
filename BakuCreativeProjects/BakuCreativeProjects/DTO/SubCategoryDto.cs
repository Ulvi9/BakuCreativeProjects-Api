using System.Collections.Generic;

namespace BakuCreativeProjects.DTO
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ChildCategoryDto> ChildCategories { get; set; }
    }
}