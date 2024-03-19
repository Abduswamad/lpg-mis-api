using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.SuperdealerFeatures.MapperProfile
{
    public class SuperdealerMapperProfile : Profile
    {
        public SuperdealerMapperProfile()
        {
            CreateMap<InsSuperdealerModel, AddSuperdealerModel>();
            CreateMap<AddSuperdealerModel, InsSuperdealerModel>();
        }
    }
}
