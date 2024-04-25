using AutoMapper;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.CylinderSaleFeatures.MapperProfile
{
    public class CylinderSalesWithItemMapperProfile : Profile
    {
        public CylinderSalesWithItemMapperProfile()
        {
            CreateMap<InsCylinderSalesWithItemModel, AddCylinderSalesWithItemModel>();
            CreateMap<AddCylinderSalesWithItemModel, InsCylinderSalesWithItemModel>();

            CreateMap<InsCylinderSalesItemModel, AddCylinderSalesItemModel>();
            CreateMap<AddCylinderSalesItemModel, InsCylinderSalesItemModel>();

            
        }
    }
}
