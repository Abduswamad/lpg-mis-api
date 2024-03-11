using AutoMapper;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.UserFeatures.MapperProfile
{
    public class StaffMapperProfile : Profile
    {
        public StaffMapperProfile()
        {
            CreateMap<InsStaffModel, AddStaffModel>();
            CreateMap<AddStaffModel, InsStaffModel>();
        }
    }
}
