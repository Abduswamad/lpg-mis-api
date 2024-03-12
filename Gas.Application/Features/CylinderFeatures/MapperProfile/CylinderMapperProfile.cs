using AutoMapper;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.CylinderFeatures.MapperProfile
{
    public class CylinderMapperProfile : Profile
    {
        public CylinderMapperProfile()
        {
            CreateMap<InsCylinderModel, AddCylinderModel>();
            CreateMap<AddCylinderModel, InsCylinderModel>();
        }
    }
}
