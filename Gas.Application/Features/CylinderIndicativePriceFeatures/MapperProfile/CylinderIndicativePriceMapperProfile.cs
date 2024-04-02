using AutoMapper;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.CylinderIndicativePriceFeatures.MapperProfile
{
    public class CylinderIndicativePriceMapperProfile : Profile
    {
        public CylinderIndicativePriceMapperProfile()
        {
            CreateMap<InsCylinderIndicativePriceModel, AddCylinderIndicativePriceModel>();
            CreateMap<AddCylinderIndicativePriceModel, InsCylinderIndicativePriceModel>();
        }
    }
}
