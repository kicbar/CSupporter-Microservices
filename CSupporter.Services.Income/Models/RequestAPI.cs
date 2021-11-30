using static CSupporter.Services.Income.Models.SD;

namespace CSupporter.Services.Income.Models
{
    public class RequestAPI
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
