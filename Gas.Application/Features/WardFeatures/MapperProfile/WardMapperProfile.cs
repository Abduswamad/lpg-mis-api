using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.WardFeatures.MapperProfile
{
    public class WardMapperProfile : Profile
    {
        public WardMapperProfile()
        {
            CreateMap<InsWardModel, AddWardModel>();
            CreateMap<AddWardModel, InsWardModel>();
        }
    }
}
