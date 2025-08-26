using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CertTool.Classes;
using CertTool.Models;
using DBreeze;
using DBreeze.DataTypes;
using static System.Net.Mime.MediaTypeNames;

namespace CertTool
{
    public partial class MainWin : Form
    {
        SortableBindingList<Certificate> certificates = new SortableBindingList<Certificate>();
        SortableBindingList<CsrKeyRecord> csrkeys = new SortableBindingList<CsrKeyRecord>();
        DBreezeEngine? engine = null;

        public MainWin()
        {
            InitializeComponent();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            certificates = new SortableBindingList<Certificate>();
            X509Store store = new X509Store(StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 certificate in store.Certificates)
            {
                var subject = new CertificateSigningRequest();
                var issuer = new CertificateSigningRequest();
                foreach (string part in certificate.SubjectName.Decode(X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons).Split(';'))
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

                foreach (X509Extension data in certificate.Extensions)
                {
                    if (data.Oid?.FriendlyName == "Subject Alternative Name")
                    {
                        X509SubjectAlternativeNameExtension ext = (X509SubjectAlternativeNameExtension)data;

                        AsnEncodedData asndata = new AsnEncodedData(ext.Oid, ext.RawData);

                        subject.sans = Array.ConvertAll(asndata.Format(false).Split(','), p => p.Trim().Replace("DNS Name=", "").Replace("RFC822 Name=", "").Replace("Other Name:Principal Name=", ""));
                    }
                }

                foreach (string part in certificate.IssuerName.Decode(X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons).Split(';'))
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

                certificates.Add(new Certificate()
                {
                    commonname = subject.commonname != "" ? subject.commonname : subject.organizationUnit,
                    locality = subject.locality,
                    state = subject.state,
                    country = subject.country,
                    organization = subject.organization,
                    organizationUnit = subject.organizationUnit,
                    sans = string.Join(", ", subject.sans),
                    issuer = issuer.commonname,
                    validFrom = certificate.NotBefore,
                    validTo = certificate.NotAfter,
                    keySize = certificate.GetRSAPublicKey()?.KeySize.ToString() ?? "",
                    serialNumber = certificate.SerialNumber
                });
            }

            dgCerts.DataSource = certificates;
        }

        private void dgCerts_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (this.certificates[e.RowIndex].validFrom > DateTime.Now || this.certificates[e.RowIndex].validTo < DateTime.Now)
            {

                using (Brush brush = new SolidBrush(Color.Red))
                {
                    e.Graphics.FillRectangle(brush, e.RowBounds);
                }
                e.PaintParts &= ~DataGridViewPaintParts.Background;
                e.PaintCells(e.ClipBounds, e.PaintParts);
                e.Handled = true;
            }
        }

        private void dgCerts_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = dgCerts.Columns[e.ColumnIndex];

            ListSortDirection sortDirection = ListSortDirection.Ascending;
            if (dgCerts.SortedColumn == clickedColumn && dgCerts.SortOrder == SortOrder.Ascending)
            {
                sortDirection = ListSortDirection.Descending;
            }
            dgCerts.Sort(clickedColumn, sortDirection);
        }

        private void dgCerts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                X509Store store = new X509Store(StoreLocation.CurrentUser);

                store.Open(OpenFlags.ReadOnly);

                X509Certificate2Collection CertColl = store.Certificates.Find(X509FindType.FindBySerialNumber, ((Certificate)certificates[e.RowIndex]).serialNumber, false);
                X509Certificate2UI.DisplayCertificate(CertColl[0]);
                CertColl[0].Reset();
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            certificates = new SortableBindingList<Certificate>();
            X509Store store = new X509Store(StoreName.AuthRoot);

            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 certificate in store.Certificates)
            {
                var subject = new CertificateSigningRequest();
                var issuer = new CertificateSigningRequest();
                foreach (string part in certificate.SubjectName.Decode(X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons).Split(';'))
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

                foreach (X509Extension data in certificate.Extensions)
                {
                    if (data.Oid?.FriendlyName == "Subject Alternative Name")
                    {
                        X509SubjectAlternativeNameExtension ext = (X509SubjectAlternativeNameExtension)data;

                        AsnEncodedData asndata = new AsnEncodedData(ext.Oid, ext.RawData);

                        subject.sans = Array.ConvertAll(asndata.Format(false).Split(','), p => p.Trim().Replace("DNS Name=", "").Replace("RFC822 Name=", "").Replace("Other Name:Principal Name=", ""));
                    }
                }

                foreach (string part in certificate.IssuerName.Decode(X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons).Split(';'))
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

                certificates.Add(new Certificate()
                {
                    commonname = subject.commonname != "" ? subject.commonname : subject.organizationUnit,
                    locality = subject.locality,
                    state = subject.state,
                    country = subject.country,
                    organization = subject.organization,
                    organizationUnit = subject.organizationUnit,
                    sans = string.Join(", ", subject.sans),
                    issuer = issuer.commonname,
                    validFrom = certificate.NotBefore,
                    validTo = certificate.NotAfter,
                    keySize = certificate.GetRSAPublicKey()?.KeySize.ToString() ?? "",
                    serialNumber = certificate.SerialNumber
                });
            }

            dgRoots.DataSource = certificates;
        }

        private void dgRoots_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (this.certificates[e.RowIndex].validFrom > DateTime.Now || this.certificates[e.RowIndex].validTo < DateTime.Now)
            {

                using (Brush brush = new SolidBrush(Color.Red))
                {
                    e.Graphics.FillRectangle(brush, e.RowBounds);
                }
                e.PaintParts &= ~DataGridViewPaintParts.Background;
                e.PaintCells(e.ClipBounds, e.PaintParts);
                e.Handled = true;
            }
        }

        private void dgRoots_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                X509Store store = new X509Store(StoreName.AuthRoot);

                store.Open(OpenFlags.ReadOnly);

                X509Certificate2Collection CertColl = store.Certificates.Find(X509FindType.FindBySerialNumber, ((Certificate)certificates[e.RowIndex]).serialNumber, false);
                X509Certificate2UI.DisplayCertificate(CertColl[0]);
                CertColl[0].Reset();
            }
        }

        private void dgRoots_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = dgRoots.Columns[e.ColumnIndex];

            ListSortDirection sortDirection = ListSortDirection.Ascending;
            if (dgRoots.SortedColumn == clickedColumn && dgRoots.SortOrder == SortOrder.Ascending)
            {
                sortDirection = ListSortDirection.Descending;
            }
            dgRoots.Sort(clickedColumn, sortDirection);
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            this.reloadCsrTable();
        }

        private void reloadCsrTable()
        {
            csrkeys.Clear();
            using (this.engine = new DBreezeEngine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CertTool")))
            {
                using (var tran = engine.GetTransaction())
                {
                    tran.SynchronizeTables("csrkey");
                    ulong cnt = tran.Count("csrkey");
                    foreach (var row in tran.SelectForward<Guid, DbMJSON<CsrKeyRecord>>("csrkey"))
                    {
                        var obj = row.Value.Get;
                        csrkeys.Add(obj);
                    }

                    dgCsrKey.DataSource = csrkeys;
                }
            }
        }

        private void newCsrBtn_Click(object sender, EventArgs e)
        {
            var dlg = new NewCsr();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                this.reloadCsrTable();
            }
        }

        private void dgCsrKey_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgCsrKey_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgCsrKey.IsCurrentCellDirty)
            {
                dgCsrKey.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgCsrKey_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.deleteCsrBtn.Enabled = false;

            if (dgCsrKey.Columns[e.ColumnIndex].Name == "chkrecordid")
            {
                foreach (DataGridViewRow row in dgCsrKey.Rows)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)row.Cells["chkrecordid"];
                    if (checkCell.Value == "true")
                    {
                        this.deleteCsrBtn.Enabled = true;
                    }
                }
                dgCsrKey.Invalidate();
            }
        }

        private void deleteCsrBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete selected records?", "Deleting confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (this.engine = new DBreezeEngine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CertTool")))
                {
                    using (var tran = engine.GetTransaction())
                    {
                        tran.SynchronizeTables("csrkey");

                        foreach (DataGridViewRow row in dgCsrKey.Rows)
                        {
                            DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)row.Cells["chkrecordid"];
                            if (checkCell.Value == "true")
                            {
                                tran.RemoveKey<Guid>("csrkey", (Guid)row.Cells["guid"].Value);
                            }
                        }

                        tran.Commit();
                    }
                }
            }
        }

        private void dgCsrKey_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string data = (string)dgCsrKey.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                ContentViewer dlg = new ContentViewer();
                dlg.SetContent(data);
                dlg.ShowDialog(this);
            }
            else if (e.ColumnIndex == 4)
            {
                string data = (string)dgCsrKey.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                ContentViewer dlg = new ContentViewer();
                dlg.SetContent(data);
                dlg.ShowDialog(this);
            }
        }

        private void txtCertificate_TextChanged(object sender, EventArgs e)
        {
            if (txtCertificate.Text.Trim().StartsWith("-----BEGIN CERTIFICATE-----") && txtCertificate.Text.Trim().EndsWith("-----END CERTIFICATE-----"))
            {
                errorProvider1.SetError(txtCertificate, null);
            }
            else
            {
                errorProvider1.SetError(txtCertificate, "Please enter a valid certificate.");
            }
            ValidatePkcs12();
        }

        private void txtPrivatekey_TextChanged(object sender, EventArgs e)
        {
            if (txtPrivatekey.Text.Trim().StartsWith("-----BEGIN PRIVATE KEY-----") && txtPrivatekey.Text.Trim().EndsWith("-----END PRIVATE KEY-----"))
            {
                errorProvider1.SetError(txtPrivatekey, null);
            }
            else
            {
                errorProvider1.SetError(txtPrivatekey, "Please enter a valid private key.");
            }
            ValidatePkcs12();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            ListPrivatekey dlg = new ListPrivatekey();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                txtPrivatekey.Text = dlg.getSelectKey();
            }
        }

        private void cmbExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExtension.SelectedItem != null)
            {
                errorProvider1.SetError(cmbExtension, null);
            }
            else
            {
                errorProvider1.SetError(cmbExtension, "Please select an extension.");
            }
            ValidatePkcs12();
        }

        private void ValidatePkcs12()
        {
            bool hasErrors = false;
            foreach (Control control in this.tabPage4.Controls)
            {
                if (errorProvider1.GetError(control).Length > 0)
                {
                    hasErrors = true;
                    break;
                }
            }
            createBtn.Enabled = !hasErrors;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            txtCertificate.Text = "";
            txtPrivatekey.Text = "";
            txtPassphrase.Text = "";
            cmbExtension.SelectedIndex = -1;
            errorProvider1.Clear();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            byte[] pfxBytes;
            string commonname = "";

            X509Certificate2 cert = X509Certificate2.CreateFromPem(txtCertificate.Text, txtPrivatekey.Text);

            foreach (string part in cert.SubjectName.Decode(X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons).Split(';'))
            {
                if (part.Trim().StartsWith("CN="))
                {
                    commonname = Regex.Replace(part, @"\s*CN=", "");
                }
            }

            if (txtPassphrase.Text != null && txtPassphrase.Text.Trim() != "")
            {
                pfxBytes = cert.Export(X509ContentType.Pkcs12, txtPassphrase.Text);
            }
            else
            {
                pfxBytes = cert.Export(X509ContentType.Pkcs12);
            }

            string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + "." + cmbExtension.Text.ToLower();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PKCS12 file|*.pfx,*.p12";
            saveFileDialog1.Title = "Save PKCS #12 File";
            saveFileDialog1.FileName = commonname + "." + cmbExtension.Text.ToLower();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(pfxBytes, 0, pfxBytes.Length);
                }

                MessageBox.Show("File saved successful.");
            }
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            this.csrResult.Visible = false;
        }

        private void txtCsr_TextChanged(object sender, EventArgs e)
        {
            this.csrResult.Visible = false;

            if(txtCsr.Text == "")
            {
                errorProvider1.Clear();
            }
            else if ((txtCsr.Text.StartsWith("-----BEGIN CERTIFICATE REQUEST-----") || txtCsr.Text.StartsWith("-----BEGIN NEW CERTIFICATE REQUEST-----")) && (txtCsr.Text.EndsWith("-----END CERTIFICATE REQUEST-----") || txtCsr.Text.EndsWith("-----END NEW CERTIFICATE REQUEST-----")))
            {
                errorProvider1.SetError(txtCsr, null);

                CertificateRequest? certReq = null;

                try
                {
                    certReq = CertificateRequest.LoadSigningRequestPem(txtCsr.Text, HashAlgorithmName.SHA1, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                }
                catch
                {
                    
                }

                if (certReq != null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(txtCsr.Text, HashAlgorithmName.SHA256, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq != null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(txtCsr.Text, HashAlgorithmName.SHA384, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq != null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(txtCsr.Text, HashAlgorithmName.SHA512, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq != null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(txtCsr.Text, HashAlgorithmName.SHA3_256, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq != null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(txtCsr.Text, HashAlgorithmName.SHA3_384, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq != null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(txtCsr.Text, HashAlgorithmName.SHA3_512, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                var ret = new CertificateSigningRequest();
                if (certReq.PublicKey.GetRSAPublicKey() != null)
                {
                    ret.keyalgorithm = certReq.PublicKey.GetRSAPublicKey()?.KeyExchangeAlgorithm!;
                    ret.signaturealgorithm = certReq.HashAlgorithm.Name! + certReq.PublicKey.GetRSAPublicKey()?.SignatureAlgorithm;
                    ret.keylength = certReq.PublicKey.GetRSAPublicKey().KeySize!;
                }
                else if (certReq.PublicKey.GetDSAPublicKey() != null)
                {
                    ret.keyalgorithm = certReq.PublicKey.GetDSAPublicKey()?.KeyExchangeAlgorithm!;
                    ret.signaturealgorithm = certReq.HashAlgorithm.Name! + certReq.PublicKey.GetDSAPublicKey()?.SignatureAlgorithm;
                    ret.keylength = certReq.PublicKey.GetDSAPublicKey().KeySize!;
                }
                else if (certReq.PublicKey.GetECDiffieHellmanPublicKey() != null)
                {
                    ret.keyalgorithm = certReq.PublicKey.GetECDiffieHellmanPublicKey()?.KeyExchangeAlgorithm!;
                    ret.signaturealgorithm = certReq.HashAlgorithm.Name! + certReq.PublicKey.GetECDiffieHellmanPublicKey()?.SignatureAlgorithm;
                    ret.keylength = certReq.PublicKey.GetECDiffieHellmanPublicKey().KeySize!;
                }
                else if (certReq.PublicKey.GetECDsaPublicKey() != null)
                {
                    ret.keyalgorithm = certReq.PublicKey.GetECDsaPublicKey()?.KeyExchangeAlgorithm!;
                    ret.signaturealgorithm = certReq.HashAlgorithm.Name! + certReq.PublicKey.GetECDsaPublicKey()?.SignatureAlgorithm;
                    ret.keylength = certReq.PublicKey.GetECDsaPublicKey().KeySize!;
                }

                foreach (string part in certReq.SubjectName.Decode(X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons).Split(';'))
                {
                    if (part.Trim().StartsWith("CN="))
                    {
                        ret.commonname = Regex.Replace(part, @"\s+CN=", "");
                    }
                    else if (part.Trim().StartsWith("L="))
                    {
                        ret.locality = Regex.Replace(part, @"\s+L=", "");
                    }
                    else if (part.Trim().StartsWith("S="))
                    {
                        ret.state = Regex.Replace(part, @"\s+S=", "");
                    }
                    else if (part.Trim().StartsWith("C="))
                    {
                        ret.country = Regex.Replace(part, @"\s+C=", "");
                    }
                    else if (part.Trim().StartsWith("O="))
                    {
                        ret.organization = Regex.Replace(part, @"\s+O=", "").Replace("\"", ""); ;
                    }
                    else if (part.Trim().StartsWith("OU="))
                    {
                        ret.organizationUnit = Regex.Replace(part, @"\s+OU=", "");
                    }

                }

                foreach (X509Extension data in certReq.CertificateExtensions)
                {
                    if (data.Oid?.FriendlyName == "Subject Alternative Name")
                    {
                        X509SubjectAlternativeNameExtension ext = (X509SubjectAlternativeNameExtension)data;

                        AsnEncodedData asndata = new AsnEncodedData(ext.Oid, ext.RawData);

                        ret.sans = Array.ConvertAll(asndata.Format(false).Split(','), p => p.Trim().Replace("DNS Name=", ""));
                    }
                    else if (data.Oid?.FriendlyName == "Key Usage")
                    {
                        X509KeyUsageExtension ext = (X509KeyUsageExtension)data;
                        ret.keyusages = Array.ConvertAll(ext.Format(false).Split(','), p => p.Trim());
                    }
                    else if (data.Oid?.FriendlyName == "Enhanced Key Usage")
                    {
                        X509EnhancedKeyUsageExtension ext = (X509EnhancedKeyUsageExtension)data;
                        OidCollection oids = ext.EnhancedKeyUsages;

                        List<string> eku = new List<string>();
                        foreach (Oid oid in oids)
                        {
                            eku.Add(oid.FriendlyName!);
                        }
                        ret.extendkeyusages = eku.ToArray();
                    }
                }

                txtCommonname.Text = ret.commonname;
                txtSan.Text = String.Join("\r\n", ret.sans);
                txtOrganization.Text = ret.organization;
                txtOrganiztionUnit.Text = ret.organizationUnit;
                txtLocality.Text = ret.locality;
                txtState.Text = ret.state;
                txtCountry.Text = ret.country;
                txtAlgorithm.Text = ret.keyalgorithm + ret.keylength;
                this.csrResult.Visible = true;
            }
            else
            {
                errorProvider1.SetError(txtCsr, "Please enter a valid certificate signing request.");
            }
        }

        
    }
}
