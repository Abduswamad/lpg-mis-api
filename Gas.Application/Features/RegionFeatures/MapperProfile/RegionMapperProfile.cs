using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.RegionFeatures.MapperProfile
{
    public class RegionMapperProfile : Profile
    {
        public RegionMapperProfile()
        {
            CreateMap<InsRegionModel, AddRegionModel>();
            CreateMap<AddRegionModel, InsRegionModel>();
        }
    }
}
