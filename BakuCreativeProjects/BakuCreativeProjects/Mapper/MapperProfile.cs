using System.Linq;
using AutoMapper;
using BakuCreativeProjects.DTO;
using BakuCreativeProjects.DTO.ChildCategory;
using BakuCreativeProjects.DTO.Product;
using BakuCreativeProjects.DTO.SubCategory;
using BakuCreativeProjects.Models;

namespace BakuCreativeProjects.Mapper
{
    public class MapperProfile : Profile
    {
        private static string BaseUrlProduct = "http://localhost:5000/images/products/";
        public MapperProfile()
        {
            //mainCategory
            CreateMap<ChildCategory, ChildCategoryDto>();
            CreateMap<SubCategory, SubCategoryDto>()
                .ForMember(x => x.ChildCategories, o =>
                    o.MapFrom(x => x.ChildCategories));
            CreateMap<MainCategory, MainCategoryReturnDto>()
                .ForMember(x => x.SubCategories, o =>
                    o.MapFrom(x => x.SubCategories));
            CreateMap<MainCategory, MainCategoryCreateDto>().ReverseMap();
            CreateMap<MainCategory, MainCategoryUpdateDto>().ReverseMap();

            //subCategory
            CreateMap<SubCategory, SubCategoryReturnDto>()
                .ForMember(x => x.ChildCategories, o =>
                    o.MapFrom(x => x.ChildCategories));

            CreateMap<SubCategory, SubCategoryCreateDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryUpdateDto>().ReverseMap();

            //childCategory

            CreateMap<ChildCategory, ChildCategoryReturnDto>()
                .ForMember(x => x.SubCategory, o =>
                    o.MapFrom(x => x.SubCategory.Name))
                .ForMember(x => x.MainCategory, o =>
                    o.MapFrom(x => x.SubCategory.MainCategory.Name))
                .ForMember(x => x.Products, o =>
                    o.MapFrom(x => x.Products.Select(p=>p.Name)));
            CreateMap<ChildCategory, ChildCategoryCreateDto>().ReverseMap();
            CreateMap<ChildCategory, ChildCategoryUpdateDto>().ReverseMap();
            
            //product
            CreateMap<Product, ProductReturnDto>()
                .ForMember(p => p.ChildCategory, c =>
                    c.MapFrom(p => p.ChildCategory.Name))
                .ForMember(p => p.PhotoUrl, c =>
                    c.MapFrom(p => p.Photos
                        .Select(p=>BaseUrlProduct+p.Url)));
            CreateMap<ProductCreateDto,Product>().ReverseMap();
            CreateMap<ProductUpdateDto,Product>().ReverseMap();

            


        }
    }
}