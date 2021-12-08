using static CSupporter.Gateway.Options.SD;

namespace CSupporter.Gateway.Options
{
    public class RequestAPI
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
