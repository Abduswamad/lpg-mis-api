using AutoMapper;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.CylinderSaleFeatures.MapperProfile
{
    public class CylinderSaleMapperProfile : Profile
    {
        public CylinderSaleMapperProfile()
        {
            CreateMap<InsCylinderSaleModel, AddCylinderSaleModel>();
            CreateMap<AddCylinderSaleModel, InsCylinderSaleModel>();
        }
    }
}
