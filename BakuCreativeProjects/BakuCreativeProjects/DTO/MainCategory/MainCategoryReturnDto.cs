using System.Collections.Generic;
using BakuCreativeProjects.DTO.Product;

namespace BakuCreativeProjects.DTO
{
    public class MainCategoryReturnDto
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubCategoryDto> SubCategories{ get; set; }

    }
}