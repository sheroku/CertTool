namespace CertTool.Models
{
    public class CertificateSigningRequest
    {
        public string commonname { get; set; } = string.Empty;
        public string[] sans { get; set; } = [];
        public string organization { get; set; } = string.Empty;
        public string organizationUnit { get; set; } = string.Empty;
        public string locality { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string keyalgorithm { get; set; } = string.Empty;
        public string signaturealgorithm { get; set; } = string.Empty;
        public Int32 keylength { get; set; }
        public string[] keyusages { get; set; } = [];
        public string[] extendkeyusages { get; set; } = [];
    }
}
