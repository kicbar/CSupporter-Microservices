using AutoMapper;
using CSupporter.Services.Contractors.Models;
using CSupporter.Services.Contractors.Models.Dtos;
using CSupporter.Services.Contractors.Repositories.IRepositories;
using CSupporter.Services.Contractors.Services.IServices;
using System.Collections.Generic;

namespace CSupporter.Services.Contractors.Services
{
    public class ContractorService : IContractorService
    {
        private readonly IMapper _mapper;
        private readonly IContractorRepository _contractorRepository;

        public ContractorService(IContractorRepository contractorRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contractorRepository = contractorRepository;
        }

        public List<ContractorDto> GetAllContractors()
        {
            List<Contractor> contractorsList = _contractorRepository.GetAllContractors();
            return _mapper.Map<List<ContractorDto>>(contractorsList);
        }

        public ContractorDto GetContractorById(int contractorId)
        {
            Contractor contractor = _contractorRepository.GetContractorById(contractorId);
            return _mapper.Map<ContractorDto>(contractor);
        }
    }
}
