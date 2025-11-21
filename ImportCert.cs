using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using CertTool.Models;
using DBreeze;
using DBreeze.DataTypes;

namespace CertTool
{
    public partial class ImportCert : Form
    {
        DBreezeEngine? engine = null;
        X509Certificate2? cert = null;
        public ImportCert()
        {
            InitializeComponent();
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text.Trim().StartsWith("https://"))
            {
                try
                {
                    var host = new Uri(txtUrl.Text.Trim()).Host;
                    using (var client = new TcpClient())
                    {
                        await client.ConnectAsync(host, 443);
                        using (var sslStream = new SslStream(client.GetStream(), false))
                        {
                            await sslStream.AuthenticateAsClientAsync(host);
                            if (sslStream.RemoteCertificate != null)
                            {
                                this.cert = new X509Certificate2(sslStream.RemoteCertificate);
                                this.RenderCertInfo();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching certificate: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid URL starting with https://", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RenderCertInfo()
        {
            lblCommonname.Text = "";
            lblOrganization.Text = "";
            lblValidFrom.Text = "";
            lblValidTill.Text = "";
            lblLocality.Text = "";
            lblState.Text = "";
            lblCountry.Text = "";
            lblIssuer.Text = "";

            if (this.cert != null)
            {
                var data = new Certificate(this.cert);

                lblCommonname.Text = data.commonname;
                lblOrganization.Text = data.organization;
                lblValidFrom.Text = data.validFrom.ToString();
                lblValidTill.Text = data.validTo.ToString();
                lblLocality.Text = data.locality;
                lblState.Text = data.state;
                lblCountry.Text = data.country;
                lblIssuer.Text = data.issuer;

                //txtCertInfo.Text = $"Subject: {this.cert.Subject}\r\nIssuer: {this.cert.Issuer}\r\nValid From: {this.cert.NotBefore}\r\nValid To: {this.cert.NotAfter}\r\nThumbprint: {this.cert.Thumbprint}\r\nSerial Number: {this.cert.SerialNumber}\r\nSignature Algorithm: {this.cert.SignatureAlgorithm.FriendlyName}\r\nPublic Key Format: {this.cert.PublicKey.Oid.FriendlyName}\r\nPublic Key Size: {this.cert.PublicKey.Key.KeySize} bits";
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (this.engine = new DBreezeEngine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CertTool")))
            {
                using (var tran = engine.GetTransaction())
                {
                    var guid = Guid.NewGuid();
                    var obj = new Certificate(this.cert, guid);

                    tran.Insert<Guid, DbMJSON<Certificate>>("mycerts", guid, new Certificate(this.cert!));
                    tran.Commit();
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCert_TextChanged(object sender, EventArgs e)
        {
            if (txtCert.Text.Trim().Length > 0 && txtCert.Text.Trim().StartsWith("-----BEGIN CERTIFICATE-----") && txtCert.Text.Trim().EndsWith("-----END CERTIFICATE-----"))
            {
                this.cert = X509Certificate2.CreateFromPem(txtCert.Text.Trim());
                this.RenderCertInfo();
            }
        }
    }
}
