using System.Collections.Generic;

namespace BakuCreativeProjects.DTO
{
    public class SubCategoryDto
    {
        public string Name { get; set; }
        public ICollection<ChildCategoryDto> Childs { get; set; }
    }
}