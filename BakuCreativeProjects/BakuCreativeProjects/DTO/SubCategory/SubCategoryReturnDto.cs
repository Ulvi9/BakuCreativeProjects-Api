using System.Collections.Generic;

namespace BakuCreativeProjects.DTO.SubCategory
{
    public class SubCategoryReturnDto
    {
        public string Name { get; set; }
        public ICollection<ChildCategoryDto> Childs{ get; set; }
    }
}