using AutoMapper;
using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Models.Dtos;
using CSupporter.Services.Factures.Repositories.IRepositories;
using CSupporter.Services.Factures.Services.IServices;
using System;
using System.Collections.Generic;

namespace CSupporter.Services.Factures.Services
{
    public class PositionService : IPositionService
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public PositionDto AddPositionToFacture(Position position)
        {
            throw new NotImplementedException();
        }

        public bool DeletePositionFromFacture(int positionId)
        {
            throw new NotImplementedException();
        }

        public List<PositionDto> GetAllPositionsForFacture(int factureId)
        {
            return _mapper.Map<List<PositionDto>>(_positionRepository.GetAllPositionsForFacture(factureId));
        }
    }
}
