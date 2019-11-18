using AutoMapper;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.Discount, opt => opt.MapFrom(s => s.Discount.DiscountValue))
                .ForMember(d => d.ProductType, opt => opt.MapFrom(s => s.ProductType.TypeName));
            CreateMap<Product, ProductDetailViewModel>()
                .ForMember(d => d.Discount, opt => opt.MapFrom(s => s.Discount.DiscountValue))
                .ForMember(d => d.Trademark, opt => opt.MapFrom(s => s.Trademark.Logo));
            CreateMap<Customer, CheckOutViewModel>();
        }
    }
}
