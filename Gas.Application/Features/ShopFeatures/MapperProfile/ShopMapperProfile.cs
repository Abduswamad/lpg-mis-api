using AutoMapper;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.ShopFeatures.MapperProfile
{
    public class ShopMapperProfile : Profile
    {
        public ShopMapperProfile()
        {
            CreateMap<InsShopModel, AddShopModel>();
            CreateMap<AddShopModel, InsShopModel>();
        }
    }
}
