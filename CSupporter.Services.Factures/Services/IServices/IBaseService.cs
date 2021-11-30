using CSupporter.Services.Factures.Models;
using System;
using System.Threading.Tasks;

namespace CSupporter.Services.Factures.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        Task<string> SendAsync<T>(RequestAPI requestAPI);
    }
}
