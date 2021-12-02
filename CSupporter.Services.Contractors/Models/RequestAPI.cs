using static CSupporter.Services.Contractors.Models.SD;

namespace CSupporter.Services.Contractors.Models
{
    public class RequestAPI
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
