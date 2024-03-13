using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.DistrictFeatures.MapperProfile
{
    public class DistrictMapperProfile : Profile
    {
        public DistrictMapperProfile()
        {
            CreateMap<InsDistrictModel, AddDistrictModel>();
            CreateMap<AddDistrictModel, InsDistrictModel>();
        }
    }
}
