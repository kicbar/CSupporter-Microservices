using CSupporter.Services.Income.Models;
using CSupporter.Services.Income.Models.Dtos;
using CSupporter.Services.Income.Repositories.IRepositories;
using CSupporter.Services.Income.Services.IServices;
using System;
using System.Collections.Generic;

namespace CSupporter.Services.Income.Services
{
    public class IncomeCalculateService : IIncomeCalculateService
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeCalculateService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public double CalculateExecutor(List<FactureDto> factureDtos)
        {
            double outcomes = 0;
            double incomes = 0;
            double final = 0;

            foreach (FactureDto factureDto in factureDtos)
            {
                if (factureDto.FactureType == "INCOME")
                    incomes = incomes + factureDto.Value;
                else if (factureDto.FactureType == "OUTCOME")
                    outcomes = outcomes + factureDto.Value;
                final = incomes - outcomes;
            }

            IncomeCalculation incomeCalculation = new IncomeCalculation() { CalculateValue = final };
            _incomeRepository.CreateIncomeCalculation(incomeCalculation);

            return  Math.Round(final);
        }
    }
}
