using AutoMapper;
using CSupporter.Services.Contractors.Models;
using CSupporter.Services.Contractors.Models.Dtos;
using CSupporter.Services.Contractors.Repositories.IRepositories;
using CSupporter.Services.Contractors.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSupporter.Services.Contractors.Services
{
    public class ContractorService : IContractorService
    {
        private readonly IMapper _mapper;
        private readonly IFactureAPIService _factureAPIService;
        private readonly IContractorRepository _contractorRepository;

        public ContractorService(IContractorRepository contractorRepository, IFactureAPIService factureAPIService, IMapper mapper)
        {
            _mapper = mapper;
            _factureAPIService = factureAPIService;
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

        public ContractorDto CreateUpdateContractor(ContractorDto contractorDto)
        {
            Contractor contractor = _mapper.Map<Contractor>(contractorDto);

            return _mapper.Map<ContractorDto>(_contractorRepository.CreateUpdateContractor(contractor));
        }

        public async Task<bool> DeleteContractorAsync(int contractorId)
        {
            Contractor contractor = _contractorRepository.GetContractorById(contractorId);

            string factureExist = await _factureAPIService.GetFactureForContractorAsync<string>(contractorId);
            bool factureExistBool = bool.Parse(factureExist);
            if (factureExistBool)
                return false;

            bool resultOfRemove = _contractorRepository.DeleteContractor(contractor);

            return resultOfRemove;
        }
    }
}
