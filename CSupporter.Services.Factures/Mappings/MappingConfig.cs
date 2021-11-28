using AutoMapper;
using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Models.Dtos;

namespace CSupporter.Services.Factures.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<FactureDto, Facture>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
