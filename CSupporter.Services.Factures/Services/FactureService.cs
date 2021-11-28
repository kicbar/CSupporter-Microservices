using AutoMapper;
using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Models.Dtos;
using CSupporter.Services.Factures.Repositories.IRepositories;
using CSupporter.Services.Factures.Services.IServices;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Services
{
    public class FactureService : IFactureService
    {
        private readonly IMapper _mapper;
        private readonly IFactureRepository _factureRepository;

        public FactureService(IFactureRepository factureRepository, IMapper mapper)
        {
            _mapper = mapper;
            _factureRepository = factureRepository;
        }

        public List<FactureDto> GetAllFactures()
        {
            List<Facture> factures = _factureRepository.GetAllFactures();

            return _mapper.Map<List<FactureDto>>(factures);
        }
    }
}
