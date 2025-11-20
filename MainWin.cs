using System.ComponentModel;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using CertTool.Classes;
using CertTool.Models;
using DBreeze;
using DBreeze.DataTypes;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


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

                using (Brush brush = new SolidBrush(System.Drawing.Color.Red))
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

                using (Brush brush = new SolidBrush(System.Drawing.Color.Red))
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
                            if (checkCell.Value?.ToString() == "true")
                            {
                                tran.RemoveKey<Guid>("csrkey", (Guid)row.Cells["guid"].Value!);
                            }
                        }

                        tran.Commit();
                    }
                }

                reloadCsrTable();
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

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            txtCertificate.Text = "";
            txtPrivatekey.Text = "";
            txtPassphrase.Text = "";
            cmbExtension.SelectedIndex = -1;
            errorProvider1.Clear();
        }

        private void ValidatePkcs12()
        {
            bool hasErrors = false;
            foreach (System.Windows.Forms.Control control in this.tabPage4.Controls)
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
            this.txtCsr.Text = "";
            this.csrResult.Visible = false;
        }

        private void txtCsr_TextChanged(object sender, EventArgs e)
        {
            this.csrResult.Visible = false;

            if (txtCsr.Text == "")
            {
                errorProvider1.Clear();
            }
            else if ((txtCsr.Text.Trim().StartsWith("-----BEGIN CERTIFICATE REQUEST-----") || txtCsr.Text.Trim().StartsWith("-----BEGIN NEW CERTIFICATE REQUEST-----")) && (txtCsr.Text.Trim().EndsWith("-----END CERTIFICATE REQUEST-----") || txtCsr.Text.Trim().EndsWith("-----END NEW CERTIFICATE REQUEST-----")))
            {
                var req = txtCsr.Text.Trim();

                if (req.StartsWith("-----BEGIN NEW CERTIFICATE REQUEST-----") && req.EndsWith("-----END NEW CERTIFICATE REQUEST-----"))
                {
                    req = req.Replace("-----BEGIN NEW CERTIFICATE REQUEST-----", "-----BEGIN CERTIFICATE REQUEST-----").Replace("-----END NEW CERTIFICATE REQUEST-----", "-----END CERTIFICATE REQUEST-----");
                }


                errorProvider1.SetError(txtCsr, null);

                CertificateRequest? certReq = null;

                try
                {
                    certReq = CertificateRequest.LoadSigningRequestPem(req, HashAlgorithmName.SHA1, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                }
                catch
                {

                }

                if (certReq == null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(req, HashAlgorithmName.SHA256, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq == null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(req, HashAlgorithmName.SHA384, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq == null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(req, HashAlgorithmName.SHA512, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq == null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(req, HashAlgorithmName.SHA3_256, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq == null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(req, HashAlgorithmName.SHA3_384, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
                    }
                    catch
                    {

                    }
                }

                if (certReq == null)
                {
                    try
                    {
                        certReq = CertificateRequest.LoadSigningRequestPem(req, HashAlgorithmName.SHA3_512, CertificateRequestLoadOptions.UnsafeLoadCertificateExtensions);
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
                        ret.commonname = Regex.Replace(part, @"\s*CN=", "");
                    }
                    else if (part.Trim().StartsWith("L="))
                    {
                        ret.locality = Regex.Replace(part, @"\s*L=", "");
                    }
                    else if (part.Trim().StartsWith("S="))
                    {
                        ret.state = Regex.Replace(part, @"\s*S=", "");
                    }
                    else if (part.Trim().StartsWith("C="))
                    {
                        ret.country = Regex.Replace(part, @"\s*C=", "");
                    }
                    else if (part.Trim().StartsWith("O="))
                    {
                        ret.organization = Regex.Replace(part, @"\s*O=", "").Replace("\"", ""); ;
                    }
                    else if (part.Trim().StartsWith("OU="))
                    {
                        ret.organizationUnit = Regex.Replace(part, @"\s*OU=", "");
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

        private void btn_showhidepass_Click(object sender, EventArgs e)
        {
            if (txtPassphrase.UseSystemPasswordChar)
            {
                txtPassphrase.UseSystemPasswordChar = false;
                txtPassphrase.PasswordChar = '\0';
                btn_showhidepass.BackgroundImage = Resource1.icon_eye_o;
            }
            else
            {
                txtPassphrase.UseSystemPasswordChar = true;
                txtPassphrase.PasswordChar = '*';
                btn_showhidepass.BackgroundImage = Resource1.icon_eye_c;
            }
        }

        private void btn_randpass_Click(object sender, EventArgs e)
        {
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numericChars = "0123456789";

            string allChars = lowercaseChars + uppercaseChars + numericChars;

            StringBuilder password = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[12];
                rng.GetBytes(randomBytes); // Fills the array with cryptographically strong random bytes

                for (int i = 0; i < 12; i++)
                {
                    // Use the random bytes to select characters from the combined set
                    int index = randomBytes[i] % allChars.Length;
                    password.Append(allChars[index]);
                }
            }

            txtPassphrase.Text = password.ToString();

        }

        private async void btn_certfetch_Click(object sender, EventArgs e)
        {
            if (txt_certurl.Text.Trim().StartsWith("https://"))
            {
                try
                {
                    tree_certchain.Nodes.Clear();

                    var host = new Uri(txt_certurl.Text.Trim()).Host;
                    using (var client = new TcpClient())
                    {
                        await client.ConnectAsync(host, 443);
                        using (var sslStream = new SslStream(client.GetStream(), false, RemoteCertificateValidationCallback))
                        {
                            await sslStream.AuthenticateAsClientAsync(host);
                            if (sslStream.RemoteCertificate != null)
                            {
                                var cert = new X509Certificate2(sslStream.RemoteCertificate);

                                this.RenderCertChain(cert);
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

        private void RenderCertChain(X509Certificate2 cert)
        {
            using (X509Chain chain = new X509Chain())
            {
                chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                var chainbuilt = chain.Build(cert);
                if (chainbuilt)
                {
                    var rchain = chain.ChainElements.Reverse();
                    TreeNode lastnode = null;

                    for (int i = 0; i < rchain.ToList().Count; i++)
                    {
                        var element = rchain.ToList()[i];

                        var subject = new CertificateSigningRequest();
                        foreach (string part in element.Certificate.SubjectName.Decode(X500DistinguishedNameFlags.Reversed | X500DistinguishedNameFlags.UseSemicolons).Split(';'))
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

                        foreach (X509Extension data in element.Certificate.Extensions)
                        {
                            if (data.Oid?.FriendlyName == "Subject Alternative Name")
                            {
                                X509SubjectAlternativeNameExtension ext = (X509SubjectAlternativeNameExtension)data;

                                AsnEncodedData asndata = new AsnEncodedData(ext.Oid, ext.RawData);

                                subject.sans = Array.ConvertAll(asndata.Format(false).Split(','), p => p.Trim().Replace("DNS Name=", "").Replace("RFC822 Name=", "").Replace("Other Name:Principal Name=", ""));
                            }
                        }

                        var currentcert = new Certificate()
                        {
                            commonname = subject.commonname != "" ? subject.commonname : subject.organizationUnit,
                            locality = subject.locality,
                            state = subject.state,
                            country = subject.country,
                            organization = subject.organization,
                            organizationUnit = subject.organizationUnit,
                            sans = string.Join(", ", subject.sans),
                            validFrom = element.Certificate.NotBefore,
                            validTo = element.Certificate.NotAfter,
                            keySize = element.Certificate.GetRSAPublicKey()?.KeySize.ToString() ?? "",
                            serialNumber = element.Certificate.SerialNumber
                        };

                        TreeNode node = new TreeNode($"{currentcert.commonname} ({currentcert.validFrom} - {currentcert.validTo})");
                        node.Tag = currentcert;


                        if (i == 0)
                        {
                            lastnode = node;
                            tree_certchain.Nodes.Add(node);
                        }
                        else
                        {
                            lastnode.Nodes.Add(node);
                            lastnode = node;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to build certificate chain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Certificate error: {sslPolicyErrors}");
                return false;
            }
        }

        private void btn_chain2excel_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\export.xlsx";

            if (tree_certchain.Nodes.Count > 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel Files|*.xlsx";
                saveFileDialog1.Title = "Save Certificate Chain to Excel File";
                saveFileDialog1.FileName = "certchain.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog1.FileName;
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("No certificate chain data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

                Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                Row row = new Row();

                row.Append(
                    new Cell() { CellReference = "A1", DataType = CellValues.String, CellValue = new CellValue("Commonname") },
                    new Cell() { CellReference = "B1", DataType = CellValues.String, CellValue = new CellValue("Valid From") },
                    new Cell() { CellReference = "C1", DataType = CellValues.String, CellValue = new CellValue("Valid To") },
                    new Cell() { CellReference = "D1", DataType = CellValues.String, CellValue = new CellValue("Organization") },
                    new Cell() { CellReference = "E1", DataType = CellValues.String, CellValue = new CellValue("Organization Unit") },
                    new Cell() { CellReference = "F1", DataType = CellValues.String, CellValue = new CellValue("State") },
                    new Cell() { CellReference = "G1", DataType = CellValues.String, CellValue = new CellValue("Country") },
                    new Cell() { CellReference = "H1", DataType = CellValues.String, CellValue = new CellValue("Key Size") },
                    new Cell() { CellReference = "I1", DataType = CellValues.String, CellValue = new CellValue("Serial number") }
                );

                sheetData.Append(row);


                TreeNode root = tree_certchain.Nodes[0];
                sheetData.Append(this.GenNodeData(root));
                var lastnode = root;
                while (lastnode.Nodes.Count > 0)
                {
                    lastnode = lastnode.Nodes[0];
                    sheetData.Append(this.GenNodeData(lastnode));
                }

                // Save the worksheet.
                worksheetPart.Worksheet.Save();
            }
        }

        private Row GenNodeData(TreeNode node)
        {
            Row dataRow = new Row();
            if (node.Tag is Certificate cert)
            {
                dataRow.Append(
                    new Cell() { DataType = CellValues.String, CellValue = new CellValue(cert.commonname) },
                    new Cell() { DataType = CellValues.String, CellValue = new CellValue(cert.validFrom.ToString()) },
                    new Cell() { DataType = CellValues.String, CellValue = new CellValue(cert.validTo.ToString()) },
                    new Cell() { DataType = CellValues.String, CellValue = new CellValue(cert.organization) },
                    new Cell() { DataType = CellValues.String, CellValue = new CellValue(cert.organizationUnit) },
                    new Cell() { DataType = CellValues.String, CellValue = new CellValue(cert.state) },
                    new Cell() { DataType = CellValues.String, CellValue = new CellValue(cert.country) },
                    new Cell() { DataType = CellValues.String, CellValue = new CellValue(cert.keySize) },
                    new Cell() { DataType = CellValues.String, CellValue = new CellValue(cert.serialNumber) }
                );
            }
            return dataRow;
        }

        private void btn_decodecert_Click(object sender, EventArgs e)
        {
            if (txt_cert2decode.Text.Trim().StartsWith("-----BEGIN CERTIFICATE-----") && txt_cert2decode.Text.Trim().EndsWith("-----END CERTIFICATE-----"))
            {
                tree_certchain.Nodes.Clear();
                X509Certificate2 cert = X509Certificate2.CreateFromPem(txt_cert2decode.Text.Trim());

                if(cert.NotAfter < DateTime.Now)
                {
                    MessageBox.Show($"Error: Cannot complete certificate chain the certificate is already expired ({cert.NotAfter}).", "Certificate Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.RenderCertChain(cert);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid PEM encoded certificate.", "Invalid Certificate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
