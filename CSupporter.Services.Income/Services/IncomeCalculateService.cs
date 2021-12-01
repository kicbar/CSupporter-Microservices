using CSupporter.Services.Income.Models;
using CSupporter.Services.Income.Models.Dtos;
using CSupporter.Services.Income.Repositories.IRepositories;
using CSupporter.Services.Income.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSupporter.Services.Income.Services
{
    public class IncomeCalculateService : IIncomeCalculateService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IFactureAPIService _factureAPIService;

        public IncomeCalculateService(IIncomeRepository incomeRepository, IFactureAPIService factureAPIService)
        {
            _incomeRepository = incomeRepository;
            _factureAPIService = factureAPIService;
        }

        public async Task<double> CalculateExecutor()
        {
            double final = 0;
            List<FactureDto> factureDtos;
            var response = await _factureAPIService.GetAllFactures<FactureDto>();
            if (response != null)
            {
                factureDtos = JsonConvert.DeserializeObject<List<FactureDto>>(Convert.ToString(response));

                double outcomes = 0;
                double incomes = 0;


                foreach (FactureDto factureDto in factureDtos)
                {
                    if (factureDto.FactureType == "INCOME")
                        incomes = incomes + factureDto.Value;
                    else if (factureDto.FactureType == "OUTCOME")
                        outcomes = outcomes + factureDto.Value;
                    final = incomes - outcomes;
                }
            }

            IncomeCalculation incomeCalculation = new IncomeCalculation() { CalculateValue = final };
            _incomeRepository.CreateIncomeCalculation(incomeCalculation);

            return Math.Round(final);
        }
    }
}
