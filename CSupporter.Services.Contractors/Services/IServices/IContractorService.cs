using CSupporter.Services.Contractors.Models.Dtos;
using System.Collections.Generic;

namespace CSupporter.Services.Contractors.Services.IServices
{
    public interface IContractorService
    {
        List<ContractorDto> GetAllContractors();
        ContractorDto GetContractorById(int contractorId);
        ContractorDto CreateUpdateContractor(ContractorDto contractorDto);
    }
}
