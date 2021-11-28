using AutoMapper;
using CSupporter.Services.Contractors.Models;
using CSupporter.Services.Contractors.Models.Dtos;

namespace CSupporter.Services.Contractors.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ContractorDto, Contractor>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
