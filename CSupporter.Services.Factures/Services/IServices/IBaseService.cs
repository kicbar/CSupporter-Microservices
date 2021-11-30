using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Models.Dtos;
using System;
using System.Threading.Tasks;

namespace CSupporter.Services.Factures.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<string> SendAsync<T>(RequestAPI requestAPI);
    }
}
