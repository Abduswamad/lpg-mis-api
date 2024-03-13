using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CommonstreetFeatures.MapperProfile
{
    public class CommonstreetMapperProfile : Profile
    {
        public CommonstreetMapperProfile()
        {
            CreateMap<InsCommonstreetModel, AddCommonstreetModel>();
            CreateMap<AddCommonstreetModel, InsCommonstreetModel>();
        }
    }
}
