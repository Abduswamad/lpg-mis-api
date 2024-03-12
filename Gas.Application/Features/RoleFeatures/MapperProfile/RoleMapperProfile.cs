using AutoMapper;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.RoleFeatures.MapperProfile
{
    public class RoleMapperProfile : Profile
    {
        public RoleMapperProfile()
        {
            CreateMap<InsRoleModel, AddRoleModel>();
            CreateMap<AddRoleModel, InsRoleModel>();
        }
    }
}
