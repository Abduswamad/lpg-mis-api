using AutoMapper;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchFeatures.MapperProfile
{
    public class BatchMapperProfile : Profile
    {
        public BatchMapperProfile()
        {
            CreateMap<InsBatchModel, AddBatchModel>();
            CreateMap<AddBatchModel, InsBatchModel>();
        }
    }
}
