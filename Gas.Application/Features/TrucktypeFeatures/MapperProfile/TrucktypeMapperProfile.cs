using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.TrucktypeFeatures.MapperProfile
{
    public class TrucktypeMapperProfile : Profile
    {
        public TrucktypeMapperProfile()
        {
            CreateMap<InsTrucktypeModel, AddTrucktypeModel>();
            CreateMap<AddTrucktypeModel, InsTrucktypeModel>();
        }
    }
}
