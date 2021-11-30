namespace CSupporter.Services.Income.Models
{
    public static class SD
    {
        public static string FacturesAPI { get; set; }
        public enum ApiType { GET, POST, PUT, DELETE }
        public enum FactureType { INCOME, OUTCOME }
    }
}
