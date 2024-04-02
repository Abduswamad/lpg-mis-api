using AutoMapper;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.AccessoryIndicativePriceFeatures.MapperProfile
{
    public class AccessoryIndicativePriceMapperProfile : Profile
    {
        public AccessoryIndicativePriceMapperProfile()
        {
            CreateMap<InsAccessoryIndicativePriceModel, AddAccessoryIndicativePriceModel>();
            CreateMap<AddAccessoryIndicativePriceModel, InsAccessoryIndicativePriceModel>();
        }
    }
}
