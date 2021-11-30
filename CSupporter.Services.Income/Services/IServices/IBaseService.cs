using CSupporter.Services.Income.Models;
using System;
using System.Threading.Tasks;

namespace CSupporter.Services.Income.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        Task<string> SendAsync<T>(RequestAPI requestAPI);
    }
}
