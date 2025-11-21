using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace CertTool.Models
{
    public partial class Certificate
    {
        public Guid CertificateId { get; set; }
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
        public string algorithm { get; set; } = string.Empty;
        public string serialNumber { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string pemdata { get; set; } = string.Empty;

        public Certificate() { }

        public Certificate(X509Certificate2 cert, Guid guid)
        {
            this.CertificateId = guid;
            this.ParseCert(cert);
        }

        public Certificate(X509Certificate2 cert)
        {
            this.ParseCert(cert);
        }

        private void ParseCert(X509Certificate2 cert)
        {
            var subject = new CertificateSigningRequest();
            var issuer = new CertificateSigningRequest();
            foreach (string part in cert.SubjectName.Decode(X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons).Split(';'))
            {
                if (part.Trim().StartsWith("CN="))
                {
                    subject.commonname = Regex.Replace(part, @"\s*CN=", "");
                }
                else if (part.Trim().StartsWith("L="))
                {
                    subject.locality = Regex.Replace(part, @"\s*L=", "");
                }
                else if (part.Trim().StartsWith("S="))
                {
                    subject.state = Regex.Replace(part, @"\s*S=", "");
                }
                else if (part.Trim().StartsWith("C="))
                {
                    subject.country = Regex.Replace(part, @"\s*C=", "");
                }
                else if (part.Trim().StartsWith("O="))
                {
                    subject.organization = Regex.Replace(part, @"\s*O=", "").Replace("\"", ""); ;
                }
                else if (part.Trim().StartsWith("OU="))
                {
                    subject.organizationUnit = Regex.Replace(part, @"\s*OU=", "");
                }
                else if (part.Trim().StartsWith("E=") && subject.commonname == "")
                {
                    subject.commonname = Regex.Replace(part, @"\s*E=", "");
                }
            }

            foreach (X509Extension data in cert.Extensions)
            {
                if (data.Oid?.FriendlyName == "Subject Alternative Name")
                {
                    X509SubjectAlternativeNameExtension ext = (X509SubjectAlternativeNameExtension)data;

                    AsnEncodedData asndata = new AsnEncodedData(ext.Oid, ext.RawData);

                    subject.sans = Array.ConvertAll(asndata.Format(false).Split(','), p => p.Trim().Replace("DNS Name=", "").Replace("RFC822 Name=", "").Replace("Other Name:Principal Name=", ""));
                }
            }

            foreach (string part in cert.IssuerName.Decode(X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons).Split(';'))
            {
                if (part.Trim().StartsWith("CN="))
                {
                    issuer.commonname = Regex.Replace(part, @"\s*CN=", "");
                }
                else if (part.Trim().StartsWith("L="))
                {
                    issuer.locality = Regex.Replace(part, @"\s*L=", "");
                }
                else if (part.Trim().StartsWith("S="))
                {
                    issuer.state = Regex.Replace(part, @"\s*S=", "");
                }
                else if (part.Trim().StartsWith("C="))
                {
                    issuer.country = Regex.Replace(part, @"\s*C=", "");
                }
                else if (part.Trim().StartsWith("O="))
                {
                    issuer.organization = Regex.Replace(part, @"\s*O=", "").Replace("\"", ""); ;
                }
                else if (part.Trim().StartsWith("OU="))
                {
                    issuer.organizationUnit = Regex.Replace(part, @"\s*OU=", "");
                }
                else if (part.Trim().StartsWith("E=") && issuer.commonname == "")
                {
                    issuer.commonname = Regex.Replace(part, @"\s*E=", "");
                }

            }

            using (X509Chain chain = new X509Chain())
            {
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online; // Or X509RevocationMode.Offline, or X509RevocationMode.NoCheck
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot; // Or other flags as needed

                // Build and validate the certificate chain
                bool isValid = chain.Build(cert);

                if (!isValid)
                {
                    foreach (X509ChainStatus status in chain.ChainStatus)
                    {
                        if (status.Status == X509ChainStatusFlags.Revoked)
                        {
                            this.status = "Revoked";
                        }
                    }
                }

                this.status = (isValid ? "Valid" : "Invalid");
            }

            this.commonname = subject.commonname != "" ? subject.commonname : subject.organizationUnit;
            this.locality = subject.locality;
            this.state = subject.state;
            this.country = subject.country;
            this.organization = subject.organization;
            this.organizationUnit = subject.organizationUnit;
            this.sans = string.Join(", ", subject.sans);
            this.issuer = issuer.commonname;
            this.validFrom = cert.NotBefore;
            this.validTo = cert.NotAfter;
            this.keySize = cert.GetRSAPublicKey()?.KeySize.ToString() ?? "";
            this.algorithm = cert.SignatureAlgorithm.FriendlyName!;
            this.serialNumber = cert.SerialNumber;

            this.pemdata = "-----BEGIN CERTIFICATE-----\n" + Convert.ToBase64String(cert.Export(X509ContentType.Cert)) + "\n-----END CERTIFICATE-----";
        }

    }
}
