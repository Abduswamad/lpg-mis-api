using AutoMapper;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchItemFeatures.MapperProfile
{
    public class BatchItemMapperProfile : Profile
    {
        public BatchItemMapperProfile()
        {
            CreateMap<InsBatchItemModel, AddBatchItemModel>();
            CreateMap<AddBatchItemModel, InsBatchItemModel>();
        }
    }
}
