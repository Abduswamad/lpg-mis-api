using AutoMapper;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.AccessorySaleFeatures.MapperProfile
{
    public class AccessorySalesWithItemMapperProfile : Profile
    {
        public AccessorySalesWithItemMapperProfile()
        {
            CreateMap<InsAccessorySaleWithItemModel, AddAccessorySaleWithItemModel>();
            CreateMap<AddAccessorySaleWithItemModel, InsAccessorySaleWithItemModel>();

            CreateMap<InsAccessorySaleItemModel, AddAccessorySaleItemModel>();
            CreateMap<AddAccessorySaleItemModel, InsAccessorySaleItemModel>();

            
        }
    }
}
