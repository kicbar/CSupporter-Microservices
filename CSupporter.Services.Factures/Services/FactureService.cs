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

        public FactureDto GetFactureById(int factureId)
        {
            Facture facture = _factureRepository.GetFactureById(factureId);

            return _mapper.Map<FactureDto>(facture);
        }

        public FactureDto CreateUpdateFacture(FactureDto factureDto)
        {
            Facture facture = _factureRepository.CreateUpdateFacture(_mapper.Map<Facture>(factureDto));
            
            return _mapper.Map<FactureDto>(facture);
        }

        public bool DeleteFacture(int factureId)
        {
            return _factureRepository.DeleteFacture(factureId);
        }
    }
}
