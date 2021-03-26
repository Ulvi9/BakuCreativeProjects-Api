using System.Collections.Generic;

namespace BakuCreativeProjects.DTO.SubCategory
{
    public class SubCategoryReturnDto
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public ICollection<ChildCategoryDto> ChildCategories{ get; set; }
    }
}