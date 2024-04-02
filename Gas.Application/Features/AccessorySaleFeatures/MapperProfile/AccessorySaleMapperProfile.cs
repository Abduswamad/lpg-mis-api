using AutoMapper;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.AccessorySaleFeatures.MapperProfile
{
    public class AccessorySaleMapperProfile : Profile
    {
        public AccessorySaleMapperProfile()
        {
            CreateMap<InsAccessorySaleModel, AddAccessorySaleModel>();
            CreateMap<AddAccessorySaleModel, InsAccessorySaleModel>();
        }
    }
}
