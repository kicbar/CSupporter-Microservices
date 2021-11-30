namespace CSupporter.Services.Factures.Models
{
    public static class SD
    {
        public static string ContractorsAPI { get; set; }
        public enum ApiType { GET, POST, PUT, DELETE }
        public enum FactureType { INCOME, OUTCOME }
    }
}
