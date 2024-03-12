using AutoMapper;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CylindercompanyFeatures.MapperProfile
{
    public class CylindercompanyMapperProfile : Profile
    {
        public CylindercompanyMapperProfile()
        {
            CreateMap<InsCylindercompanyModel, AddCylindercompanyModel>();
            CreateMap<AddCylindercompanyModel, InsCylindercompanyModel>();
        }
    }
}
