using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CountryFeatures.MapperProfile
{
    public class CountryMapperProfile : Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<InsCountryModel, AddCountryModel>();
            CreateMap<AddCountryModel, InsCountryModel>();
        }
    }
}
