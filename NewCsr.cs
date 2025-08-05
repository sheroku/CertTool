using System.Resources;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using CertTool.Models;
using DBreeze;
using DBreeze.DataTypes;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CertTool
{
    public partial class NewCsr : Form
    {
        private class AsymmetricAlgorithmParameters
        {
            private readonly AsymmetricAlgorithmType type;
            public AsymmetricAlgorithmParameters(AsymmetricAlgorithmType type)
            {
                this.type = type;
            }
            public bool IsECC => type < AsymmetricAlgorithmType.RSA_2048;
            public bool IsRSA => type >= AsymmetricAlgorithmType.RSA_2048;

            public AsymmetricAlgorithm CreateAsymmetricAlgorithm()
            {
                return type switch
                {
                    AsymmetricAlgorithmType.EC_P256 => ECDsa.Create(ECCurve.NamedCurves.nistP256),
                    AsymmetricAlgorithmType.EC_P384 => ECDsa.Create(ECCurve.NamedCurves.nistP384),
                    AsymmetricAlgorithmType.EC_P521 => ECDsa.Create(ECCurve.NamedCurves.nistP521),
                    AsymmetricAlgorithmType.RSA_2048 => RSA.Create(2048),
                    AsymmetricAlgorithmType.RSA_4096 => RSA.Create(4096),
                    _ => throw new NotSupportedException()
                };
            }

            public CertificateRequest CreateCertificateRequest(X500DistinguishedName names, AsymmetricAlgorithm algorithm)
            {
                return type switch
                {
                    AsymmetricAlgorithmType.EC_P256 or AsymmetricAlgorithmType.EC_P384 or AsymmetricAlgorithmType.EC_P521
                    => new CertificateRequest(names, algorithm as ECDsa, HashAlgorithmName.SHA256),

                    AsymmetricAlgorithmType.RSA_2048 or AsymmetricAlgorithmType.RSA_4096
                    => new CertificateRequest(names, algorithm as RSA, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1),

                    _ => throw new NotSupportedException()
                };
            }
        }

        KeyValuePair<AsymmetricAlgorithmType, string>[] algorithms = {
            new KeyValuePair<AsymmetricAlgorithmType, string>(AsymmetricAlgorithmType.RSA_2048, "RSA 2048"),
            new KeyValuePair<AsymmetricAlgorithmType, string>(AsymmetricAlgorithmType.RSA_4096, "RSA 4096"),
            new KeyValuePair<AsymmetricAlgorithmType, string>(AsymmetricAlgorithmType.EC_P256, "ECC P256"),
            new KeyValuePair<AsymmetricAlgorithmType, string>(AsymmetricAlgorithmType.EC_P384, "ECC P384"),
            new KeyValuePair<AsymmetricAlgorithmType, string>(AsymmetricAlgorithmType.EC_P521, "ECC P512"),
        };

        DBreezeEngine? engine = null;

        public NewCsr()
        {
            InitializeComponent();

            cmbAlgorithm.DataSource = algorithms;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.ResetText();
            }
            ValidateForm();
            this.Close();
        }

        private void ValidateForm()
        {
            bool hasErrors = false;
            foreach (Control control in this.Controls)
            {
                if (errorProvider1.GetError(control).Length > 0)
                {
                    hasErrors = true;
                    break;
                }
            }
            createBtn.Enabled = !hasErrors;
        }

        private void txtCommonname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtCommonname.Text.Trim().Length < 2)
            {
                errorProvider1.SetError(txtCommonname, "Please enter a commonname.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCommonname, "");
            }
            ValidateForm();
        }

        private void txtOrganization_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtOrganization.Text.Trim().Length < 2)
            {
                errorProvider1.SetError(txtOrganization, "Please enter organization.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtOrganization, "");
            }
            ValidateForm();
        }

        private void txtOrganizationUnit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtOrganizationUnit.Text.Trim().Length < 2)
            {
                errorProvider1.SetError(txtOrganizationUnit, "Please enter organization unit.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtOrganizationUnit, "");
            }
            ValidateForm();
        }

        private void txtLocality_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtLocality.Text.Trim().Length < 2)
            {
                errorProvider1.SetError(txtLocality, "Please enter locality.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLocality, "");
            }
            ValidateForm();
        }

        private void txtState_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtState.Text.Trim().Length < 2)
            {
                errorProvider1.SetError(txtState, "Please enter state.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtState, "");
            }
            ValidateForm();
        }

        private void txtCountry_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtCountry.Text.Trim().Length < 2)
            {
                errorProvider1.SetError(txtCountry, "Please enter country.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCountry, "");
            }
            ValidateForm();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            AsymmetricAlgorithmParameters algorithm = new((AsymmetricAlgorithmType)cmbAlgorithm.SelectedValue!);

            var input = $"CN={txtCommonname.Text},O=\"{txtOrganization.Text}\",OU={txtOrganizationUnit.Text},L={txtLocality.Text},S={txtState.Text},C={txtCountry.Text}";
            X500DistinguishedName names = new($"CN={txtCommonname.Text},O=\"{txtOrganization.Text}\",OU={txtOrganizationUnit.Text},L={txtLocality.Text},S={txtState.Text},C={txtCountry.Text}");

            using AsymmetricAlgorithm provider = algorithm.CreateAsymmetricAlgorithm();

            CertificateRequest request = algorithm.CreateCertificateRequest(names, provider);

            var sans = txtSans.Text.Replace("\r\n", ",").Replace("\r", ",").Replace("\n", ",").Split(",");
            if (sans.Count() > 0 && sans[0] != "")
            {
                SubjectAlternativeNameBuilder builder = new();

                if (!sans.Contains(txtCommonname.Text))
                {
                    builder.AddDnsName(txtCommonname.Text);
                }

                foreach (string dnsName in sans)
                {
                    builder.AddDnsName(dnsName);
                }

                request.CertificateExtensions.Add(builder.Build());
            }
            var guid = Guid.NewGuid();
            var obj = new CsrKeyRecord()
            {
                recordid = guid,
                key = GenetratePemContents(provider.ExportPkcs8PrivateKey(), "PRIVATE KEY"),
                csr = GenetratePemContents(request.CreateSigningRequest(), "CERTIFICATE REQUEST"),
                keysize = (AsymmetricAlgorithmType)cmbAlgorithm.SelectedValue,
                commonname = txtCommonname.Text,
                createdate = DateTime.Now,
            };

            using (this.engine = new DBreezeEngine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CertTool")))
            {
                using (var tran = engine.GetTransaction())
                {
                    tran.Insert<Guid, DbMJSON<CsrKeyRecord>>("csrkey", guid, obj);
                    tran.Commit();
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private string GenetratePemContents(byte[] data, string tag)
        {
            return $"-----BEGIN {tag}-----\r\n{Convert.ToBase64String(data, Base64FormattingOptions.None)}\r\n-----END {tag}-----";
        }
    }
}
