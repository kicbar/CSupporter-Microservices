using static CSupporter.Services.Factures.Models.SD;

namespace CSupporter.Services.Factures.Models
{
    public class RequestAPI
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
