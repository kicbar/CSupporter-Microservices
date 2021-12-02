using CSupporter.Services.Contractors.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSupporter.Services.Contractors.Services.IServices
{
    public interface IContractorService
    {
        List<ContractorDto> GetAllContractors();
        ContractorDto GetContractorById(int contractorId);
        ContractorDto CreateUpdateContractor(ContractorDto contractorDto);
        Task<bool> DeleteContractorAsync(int contractorId);
    }
}
