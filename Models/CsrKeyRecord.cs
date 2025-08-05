namespace CertTool.Models
{
    public partial class CsrKeyRecord
    {
        public Guid recordid { get; set; }
        public string commonname { get; set; } = string.Empty;
        public string csr { get; set; } = string.Empty;
        public string key { get; set; } = string.Empty;
        public AsymmetricAlgorithmType keysize { get; set; }
        public DateTime createdate { get; set; } = DateTime.Now;
    }
}
