using AutoMapper;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.DepoFeatures.MapperProfile
{
    public class DepoMapperProfile : Profile
    {
        public DepoMapperProfile()
        {
            CreateMap<InsDepoModel, AddDepoModel>();
            CreateMap<AddDepoModel, InsDepoModel>();
        }
    }
}
