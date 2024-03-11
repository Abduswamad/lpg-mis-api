using AutoMapper;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.StaffFeatures.MapperProfile
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
