using CSupporter.Gateway.Options;
using System;
using System.Threading.Tasks;

namespace CSupporter.Gateway.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        Task<string> SendAsync<T>(RequestAPI requestAPI);
    }
}
