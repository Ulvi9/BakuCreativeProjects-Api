using System.Linq;
using AutoMapper;
using BakuCreativeProjects.DTO;
using BakuCreativeProjects.DTO.ChildCategory;
using BakuCreativeProjects.DTO.SubCategory;
using BakuCreativeProjects.Models;

namespace BakuCreativeProjects.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //mainCategory
            CreateMap<ChildCategory, ChildCategoryDto>();
            CreateMap<SubCategory, SubCategoryDto>()
                .ForMember(x => x.Childs, o =>
                    o.MapFrom(x => x.ChildCategories));
            CreateMap<MainCategory, MainCategoryReturnDto>()
                .ForMember(x => x.Childs, o =>
                    o.MapFrom(x => x.SubCategories));
            CreateMap<MainCategory, MainCategoryCreateDto>().ReverseMap();
            CreateMap<MainCategory, MainCategoryUpdateDto>().ReverseMap();

            //subCategory
            CreateMap<SubCategory, SubCategoryReturnDto>()
                .ForMember(x => x.Childs, o =>
                    o.MapFrom(x => x.ChildCategories));

            CreateMap<SubCategory, SubCategoryCreateDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryUpdateDto>().ReverseMap();

            //childCategory
           
            CreateMap<ChildCategory, ChildCategoryReturnDto>()
                .ForMember(x => x.SubCategory, o =>
                    o.MapFrom(x => x.SubCategory.Name))
                .ForMember(x => x.MainCategory, o =>
                    o.MapFrom(x => x.SubCategory.MainCategory.Name));;
            CreateMap<ChildCategory, ChildCategoryCreateDto>().ReverseMap();
            CreateMap<ChildCategory, ChildCategoryUpdateDto>().ReverseMap();
        }
    }
}