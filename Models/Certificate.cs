namespace CertTool.Models
{
    public partial class Certificate
    {
        public string commonname { get; set; } = string.Empty;
        public string sans { get; set; } = string.Empty;
        public string locality { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string organization { get; set; } = string.Empty;
        public string organizationUnit { get; set; } = string.Empty;
        public DateTime validFrom { get; set; } = DateTime.MinValue;
        public DateTime validTo { get; set; } = DateTime.MinValue;
        public string issuer { get; set; } = string.Empty;
        public string keySize { get; set; } = string.Empty;
        public string serialNumber { get; set; } = string.Empty;

    }
}
