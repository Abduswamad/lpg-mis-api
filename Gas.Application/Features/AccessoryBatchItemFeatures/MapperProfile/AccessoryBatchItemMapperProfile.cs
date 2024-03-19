using AutoMapper;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.AccessoryBatchItemFeatures.MapperProfile
{
    public class AccessoryBatchItemMapperProfile : Profile
    {
        public AccessoryBatchItemMapperProfile()
        {
            CreateMap<InsAccessoryBatchItemModel, AddAccessoryBatchItemModel>();
            CreateMap<AddAccessoryBatchItemModel, InsAccessoryBatchItemModel>();
        }
    }
}
