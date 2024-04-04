using AutoMapper;
using InventoryManagement.Dtos.Catalogs;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.Catalogs;

namespace InventoryManagement.Presenters.Mappers.AutoMapper.Catalogs
{
    public class CurrencyCatalogMappingProfile : Profile
    {
        public CurrencyCatalogMappingProfile()
        {
            CreateMap<CurrencyTypeCatalog, ResponseCatalogDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.ControlCode))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.CurrencyTypeName));
            CreateMap<ResponseResult<IEnumerable<CurrencyTypeCatalog>>, ResponseResult<IEnumerable<ResponseCatalogDto>>>();
            CreateMap<ResponseResult<CurrencyTypeCatalog>, ResponseResult<ResponseCatalogDto>>();
            CreateMap<RequestCatalogDto, CurrencyTypeCatalog>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.ControlCode, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.CurrencyTypeName, o => o.MapFrom(s => s.Name!.Trim()));
        }
    }
}
