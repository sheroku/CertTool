namespace CertTool.Models
{
    public class CsrRequest
    {
        public string commonname { get; set; } = string.Empty;
        public string sans { get; set; } = string.Empty;
        public string organization { get; set; } = string.Empty;
        public string organizationunit { get; set; } = string.Empty;
        public string locality { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public AsymmetricAlgorithmType algorithm { get; set; }
    }
}
