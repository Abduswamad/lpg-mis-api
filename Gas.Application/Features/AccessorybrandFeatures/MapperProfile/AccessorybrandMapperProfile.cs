using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.AccessorybrandFeatures.MapperProfile
{
    public class AccessorybrandMapperProfile : Profile
    {
        public AccessorybrandMapperProfile()
        {
            CreateMap<InsAccessorybrandModel, AddAccessorybrandModel>();
            CreateMap<AddAccessorybrandModel, InsAccessorybrandModel>();
        }
    }
}
