using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CylindercategoryFeatures.MapperProfile
{
    public class CylindercategoryMapperProfile : Profile
    {
        public CylindercategoryMapperProfile()
        {
            CreateMap<InsCylindercategoryModel, AddCylindercategoryModel>();
            CreateMap<AddCylindercategoryModel, InsCylindercategoryModel>();
        }
    }
}
