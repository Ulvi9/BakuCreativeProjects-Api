using System.Collections.Generic;

namespace BakuCreativeProjects.DTO
{
    public class MainCategoryReturnDto
    {
        public string Name { get; set; }
        public ICollection<SubCategoryDto> Childs{ get; set; }
    }
}