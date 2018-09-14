using AutoMapper;
using Shop.Data.Entities;
using Shop.Model.Entities;
using Shop.ViewModels;
using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DaycareMappingProfile : Profile
    {
        public DaycareMappingProfile()
        {
            CreateMap<DaycareIdentityUser, AccountViewModel>().ForMember(dest => dest.Email, m => m.MapFrom(src => src.Email));
            CreateMap<Category, CategoryModel>();
            CreateMap<Category, ProductCategoryModel>();
            CreateMap<Product, ProductModel>();
        }
    }
}
