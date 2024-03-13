using AutoMapper;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.AccessoryFeatures.MapperProfile
{
    public class AccessoryMapperProfile : Profile
    {
        public AccessoryMapperProfile()
        {
            CreateMap<InsAccessoryModel, AddAccessoryModel>();
            CreateMap<AddAccessoryModel, InsAccessoryModel>();
        }
    }
}
