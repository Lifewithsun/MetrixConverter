using AutoMapper;
using ApplicationCore.Entities;
using PublicApi.MatrixDataItemEndpoints;


namespace PublicApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MatrixDataItem, MatrixDataItemDto>();
      
    }
}
