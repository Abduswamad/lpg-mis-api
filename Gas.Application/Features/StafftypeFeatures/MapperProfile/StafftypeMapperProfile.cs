using AutoMapper;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.StafftypeFeatures.MapperProfile
{
    public class StafftypeMapperProfile : Profile
    {
        public StafftypeMapperProfile()
        {
            CreateMap<InsStafftypeModel, AddStafftypeModel>();
            CreateMap<AddStafftypeModel, InsStafftypeModel>();
        }
    }
}
