using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.GenderFeatures.MapperProfile
{
    public class GenderMapperProfile : Profile
    {
        public GenderMapperProfile()
        {
            CreateMap<InsGenderModel, AddGenderModel>();
            CreateMap<AddGenderModel, InsGenderModel>();
        }
    }
}
