using AutoMapper;
using DtoLayer.CafeTableDto;
using EntityLayer.Entities;

namespace Api.Mapping {
    public class CafeTableMapping : Profile {
        public CafeTableMapping()
        {
            CreateMap<CafeTable, ResultCafeTableDto>();
            CreateMap<CafeTable, CreateCafeTableDto>();
            CreateMap<CafeTable, UpdateCafeTableDto>();
            CreateMap<CafeTable, GetCafeTableDto>();
        }
    }
}
