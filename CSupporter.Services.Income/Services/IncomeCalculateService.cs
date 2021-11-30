using CSupporter.Services.Income.Models.Dtos;
using CSupporter.Services.Income.Services.IServices;
using System;
using System.Collections.Generic;

namespace CSupporter.Services.Income.Services
{
    public class IncomeCalculateService : IIncomeCalculateService
    {
        public double CalculateExecutor(List<FactureDto> factureDtos)
        {
             double outcomes = 0;
             double incomes = 0;
            
            foreach (FactureDto factureDto in factureDtos)
            {
                if (factureDto.FactureType == "INCOME")
                    incomes = incomes + factureDto.Value;
                else if (factureDto.FactureType == "OUTCOME")
                    outcomes = outcomes + factureDto.Value;
            }

            return  Math.Round(incomes - outcomes);
        }
    }
}
