using AutoMapper;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.TruckFeatures.MapperProfile
{
    public class TruckMapperProfile : Profile
    {
        public TruckMapperProfile()
        {
            CreateMap<InsTruckModel, AddTruckModel>();
            CreateMap<AddTruckModel, InsTruckModel>();
        }
    }
}
