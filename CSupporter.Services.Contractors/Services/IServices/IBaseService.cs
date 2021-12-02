using CSupporter.Services.Contractors.Models;
using System;
using System.Threading.Tasks;

namespace CSupporter.Services.Contractors.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        Task<string> SendAsync<T>(RequestAPI requestAPI);
    }
}
