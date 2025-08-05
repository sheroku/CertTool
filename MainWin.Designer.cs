namespace CertTool
{
    partial class MainWin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgCerts = new DataGridView();
            commonnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sansDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            localityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            countryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            organizationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            organizationUnitDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            validFromDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            validToDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            issuerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            keySizeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            serialNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            certificateBindingSource = new BindingSource(components);
            tabPage2 = new TabPage();
            dgRoots = new DataGridView();
            commonnameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            sansDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            localityDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            stateDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            countryDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            organizationDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            organizationUnitDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            validFromDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            validToDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            issuerDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            keySizeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            serialNumberDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            tabPage3 = new TabPage();
            dgCsrKey = new DataGridView();
            chkrecordid = new DataGridViewCheckBoxColumn();
            guid = new DataGridViewTextBoxColumn();
            commonname = new DataGridViewTextBoxColumn();
            csr = new DataGridViewTextBoxColumn();
            key = new DataGridViewTextBoxColumn();
            keysize = new DataGridViewTextBoxColumn();
            createdate = new DataGridViewTextBoxColumn();
            deleteCsrBtn = new Button();
            newCsrBtn = new Button();
            tabPage4 = new TabPage();
            clearBtn = new Button();
            createBtn = new Button();
            label2 = new Label();
            cmbExtension = new ComboBox();
            txtPassphrase = new TextBox();
            lblPassphrase = new Label();
            importBtn = new Button();
            txtPrivatekey = new TextBox();
            lblPrivatekey = new Label();
            txtCertificate = new TextBox();
            lblCertificate = new Label();
            label1 = new Label();
            tabPage5 = new TabPage();
            csrResult = new GroupBox();
            txtAlgorithm = new TextBox();
            label10 = new Label();
            txtCountry = new TextBox();
            label9 = new Label();
            txtState = new TextBox();
            label8 = new Label();
            txtLocality = new TextBox();
            label7 = new Label();
            txtOrganiztionUnit = new TextBox();
            label6 = new Label();
            txtOrganization = new TextBox();
            label5 = new Label();
            txtSan = new TextBox();
            label4 = new Label();
            txtCommonname = new TextBox();
            label3 = new Label();
            txtCsr = new TextBox();
            lblCsr = new Label();
            errorProvider1 = new ErrorProvider(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgCerts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)certificateBindingSource).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgRoots).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgCsrKey).BeginInit();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            csrResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 724);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgCerts);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 696);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Installed Certificates";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Enter += tabPage1_Enter;
            // 
            // dgCerts
            // 
            dgCerts.AllowUserToAddRows = false;
            dgCerts.AllowUserToDeleteRows = false;
            dgCerts.AllowUserToOrderColumns = true;
            dgCerts.AutoGenerateColumns = false;
            dgCerts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgCerts.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgCerts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgCerts.Columns.AddRange(new DataGridViewColumn[] { commonnameDataGridViewTextBoxColumn, sansDataGridViewTextBoxColumn, localityDataGridViewTextBoxColumn, stateDataGridViewTextBoxColumn, countryDataGridViewTextBoxColumn, organizationDataGridViewTextBoxColumn, organizationUnitDataGridViewTextBoxColumn, validFromDataGridViewTextBoxColumn, validToDataGridViewTextBoxColumn, issuerDataGridViewTextBoxColumn, keySizeDataGridViewTextBoxColumn, serialNumberDataGridViewTextBoxColumn });
            dgCerts.DataSource = certificateBindingSource;
            dgCerts.Dock = DockStyle.Fill;
            dgCerts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgCerts.Location = new Point(3, 3);
            dgCerts.MultiSelect = false;
            dgCerts.Name = "dgCerts";
            dgCerts.ReadOnly = true;
            dgCerts.RowHeadersVisible = false;
            dgCerts.RowTemplate.Resizable = DataGridViewTriState.False;
            dgCerts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgCerts.ShowEditingIcon = false;
            dgCerts.Size = new Size(786, 690);
            dgCerts.TabIndex = 0;
            dgCerts.CellMouseDoubleClick += dgCerts_CellMouseDoubleClick;
            dgCerts.ColumnHeaderMouseDoubleClick += dgCerts_ColumnHeaderMouseDoubleClick;
            dgCerts.RowPrePaint += dgCerts_RowPrePaint;
            // 
            // commonnameDataGridViewTextBoxColumn
            // 
            commonnameDataGridViewTextBoxColumn.DataPropertyName = "commonname";
            commonnameDataGridViewTextBoxColumn.HeaderText = "Commonname";
            commonnameDataGridViewTextBoxColumn.Name = "commonnameDataGridViewTextBoxColumn";
            commonnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sansDataGridViewTextBoxColumn
            // 
            sansDataGridViewTextBoxColumn.DataPropertyName = "sans";
            sansDataGridViewTextBoxColumn.HeaderText = "SANs";
            sansDataGridViewTextBoxColumn.Name = "sansDataGridViewTextBoxColumn";
            sansDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localityDataGridViewTextBoxColumn
            // 
            localityDataGridViewTextBoxColumn.DataPropertyName = "locality";
            localityDataGridViewTextBoxColumn.HeaderText = "Locality";
            localityDataGridViewTextBoxColumn.Name = "localityDataGridViewTextBoxColumn";
            localityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            stateDataGridViewTextBoxColumn.DataPropertyName = "state";
            stateDataGridViewTextBoxColumn.HeaderText = "State";
            stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            stateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            countryDataGridViewTextBoxColumn.DataPropertyName = "country";
            countryDataGridViewTextBoxColumn.HeaderText = "Country";
            countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            countryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // organizationDataGridViewTextBoxColumn
            // 
            organizationDataGridViewTextBoxColumn.DataPropertyName = "organization";
            organizationDataGridViewTextBoxColumn.HeaderText = "Organization";
            organizationDataGridViewTextBoxColumn.Name = "organizationDataGridViewTextBoxColumn";
            organizationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // organizationUnitDataGridViewTextBoxColumn
            // 
            organizationUnitDataGridViewTextBoxColumn.DataPropertyName = "organizationUnit";
            organizationUnitDataGridViewTextBoxColumn.HeaderText = "Organization Unit";
            organizationUnitDataGridViewTextBoxColumn.Name = "organizationUnitDataGridViewTextBoxColumn";
            organizationUnitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // validFromDataGridViewTextBoxColumn
            // 
            validFromDataGridViewTextBoxColumn.DataPropertyName = "validFrom";
            validFromDataGridViewTextBoxColumn.HeaderText = "Valid From";
            validFromDataGridViewTextBoxColumn.Name = "validFromDataGridViewTextBoxColumn";
            validFromDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // validToDataGridViewTextBoxColumn
            // 
            validToDataGridViewTextBoxColumn.DataPropertyName = "validTo";
            validToDataGridViewTextBoxColumn.HeaderText = "Valid To";
            validToDataGridViewTextBoxColumn.Name = "validToDataGridViewTextBoxColumn";
            validToDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // issuerDataGridViewTextBoxColumn
            // 
            issuerDataGridViewTextBoxColumn.DataPropertyName = "issuer";
            issuerDataGridViewTextBoxColumn.HeaderText = "Issuer";
            issuerDataGridViewTextBoxColumn.Name = "issuerDataGridViewTextBoxColumn";
            issuerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keySizeDataGridViewTextBoxColumn
            // 
            keySizeDataGridViewTextBoxColumn.DataPropertyName = "keySize";
            keySizeDataGridViewTextBoxColumn.HeaderText = "Key Size";
            keySizeDataGridViewTextBoxColumn.Name = "keySizeDataGridViewTextBoxColumn";
            keySizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serialNumberDataGridViewTextBoxColumn
            // 
            serialNumberDataGridViewTextBoxColumn.DataPropertyName = "serialNumber";
            serialNumberDataGridViewTextBoxColumn.HeaderText = "Serial Number";
            serialNumberDataGridViewTextBoxColumn.Name = "serialNumberDataGridViewTextBoxColumn";
            serialNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // certificateBindingSource
            // 
            certificateBindingSource.AllowNew = false;
            certificateBindingSource.DataSource = typeof(Models.Certificate);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgRoots);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 696);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Root Certificates";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Enter += tabPage2_Enter;
            // 
            // dgRoots
            // 
            dgRoots.AllowUserToAddRows = false;
            dgRoots.AllowUserToDeleteRows = false;
            dgRoots.AllowUserToOrderColumns = true;
            dgRoots.AutoGenerateColumns = false;
            dgRoots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgRoots.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgRoots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgRoots.Columns.AddRange(new DataGridViewColumn[] { commonnameDataGridViewTextBoxColumn1, sansDataGridViewTextBoxColumn1, localityDataGridViewTextBoxColumn1, stateDataGridViewTextBoxColumn1, countryDataGridViewTextBoxColumn1, organizationDataGridViewTextBoxColumn1, organizationUnitDataGridViewTextBoxColumn1, validFromDataGridViewTextBoxColumn1, validToDataGridViewTextBoxColumn1, issuerDataGridViewTextBoxColumn1, keySizeDataGridViewTextBoxColumn1, serialNumberDataGridViewTextBoxColumn1 });
            dgRoots.DataSource = certificateBindingSource;
            dgRoots.Dock = DockStyle.Fill;
            dgRoots.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgRoots.Location = new Point(3, 3);
            dgRoots.MultiSelect = false;
            dgRoots.Name = "dgRoots";
            dgRoots.ReadOnly = true;
            dgRoots.RowHeadersVisible = false;
            dgRoots.RowTemplate.Resizable = DataGridViewTriState.False;
            dgRoots.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgRoots.Size = new Size(786, 690);
            dgRoots.TabIndex = 0;
            dgRoots.CellMouseDoubleClick += dgRoots_CellMouseDoubleClick;
            dgRoots.ColumnHeaderMouseDoubleClick += dgRoots_ColumnHeaderMouseDoubleClick;
            dgRoots.RowPrePaint += dgRoots_RowPrePaint;
            // 
            // commonnameDataGridViewTextBoxColumn1
            // 
            commonnameDataGridViewTextBoxColumn1.DataPropertyName = "commonname";
            commonnameDataGridViewTextBoxColumn1.HeaderText = "Commonname";
            commonnameDataGridViewTextBoxColumn1.Name = "commonnameDataGridViewTextBoxColumn1";
            commonnameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // sansDataGridViewTextBoxColumn1
            // 
            sansDataGridViewTextBoxColumn1.DataPropertyName = "sans";
            sansDataGridViewTextBoxColumn1.HeaderText = "SANs";
            sansDataGridViewTextBoxColumn1.Name = "sansDataGridViewTextBoxColumn1";
            sansDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // localityDataGridViewTextBoxColumn1
            // 
            localityDataGridViewTextBoxColumn1.DataPropertyName = "locality";
            localityDataGridViewTextBoxColumn1.HeaderText = "Locality";
            localityDataGridViewTextBoxColumn1.Name = "localityDataGridViewTextBoxColumn1";
            localityDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // stateDataGridViewTextBoxColumn1
            // 
            stateDataGridViewTextBoxColumn1.DataPropertyName = "state";
            stateDataGridViewTextBoxColumn1.HeaderText = "State";
            stateDataGridViewTextBoxColumn1.Name = "stateDataGridViewTextBoxColumn1";
            stateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // countryDataGridViewTextBoxColumn1
            // 
            countryDataGridViewTextBoxColumn1.DataPropertyName = "country";
            countryDataGridViewTextBoxColumn1.HeaderText = "Country";
            countryDataGridViewTextBoxColumn1.Name = "countryDataGridViewTextBoxColumn1";
            countryDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // organizationDataGridViewTextBoxColumn1
            // 
            organizationDataGridViewTextBoxColumn1.DataPropertyName = "organization";
            organizationDataGridViewTextBoxColumn1.HeaderText = "Organization";
            organizationDataGridViewTextBoxColumn1.Name = "organizationDataGridViewTextBoxColumn1";
            organizationDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // organizationUnitDataGridViewTextBoxColumn1
            // 
            organizationUnitDataGridViewTextBoxColumn1.DataPropertyName = "organizationUnit";
            organizationUnitDataGridViewTextBoxColumn1.HeaderText = "Organization Unit";
            organizationUnitDataGridViewTextBoxColumn1.Name = "organizationUnitDataGridViewTextBoxColumn1";
            organizationUnitDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // validFromDataGridViewTextBoxColumn1
            // 
            validFromDataGridViewTextBoxColumn1.DataPropertyName = "validFrom";
            validFromDataGridViewTextBoxColumn1.HeaderText = "Valid From";
            validFromDataGridViewTextBoxColumn1.Name = "validFromDataGridViewTextBoxColumn1";
            validFromDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // validToDataGridViewTextBoxColumn1
            // 
            validToDataGridViewTextBoxColumn1.DataPropertyName = "validTo";
            validToDataGridViewTextBoxColumn1.HeaderText = "Valid To";
            validToDataGridViewTextBoxColumn1.Name = "validToDataGridViewTextBoxColumn1";
            validToDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // issuerDataGridViewTextBoxColumn1
            // 
            issuerDataGridViewTextBoxColumn1.DataPropertyName = "issuer";
            issuerDataGridViewTextBoxColumn1.HeaderText = "Issuer";
            issuerDataGridViewTextBoxColumn1.Name = "issuerDataGridViewTextBoxColumn1";
            issuerDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // keySizeDataGridViewTextBoxColumn1
            // 
            keySizeDataGridViewTextBoxColumn1.DataPropertyName = "keySize";
            keySizeDataGridViewTextBoxColumn1.HeaderText = "Key Size";
            keySizeDataGridViewTextBoxColumn1.Name = "keySizeDataGridViewTextBoxColumn1";
            keySizeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // serialNumberDataGridViewTextBoxColumn1
            // 
            serialNumberDataGridViewTextBoxColumn1.DataPropertyName = "serialNumber";
            serialNumberDataGridViewTextBoxColumn1.HeaderText = "Serial Number";
            serialNumberDataGridViewTextBoxColumn1.Name = "serialNumberDataGridViewTextBoxColumn1";
            serialNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgCsrKey);
            tabPage3.Controls.Add(deleteCsrBtn);
            tabPage3.Controls.Add(newCsrBtn);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 696);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "CSRs & Keys";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Enter += tabPage3_Enter;
            // 
            // dgCsrKey
            // 
            dgCsrKey.AllowUserToAddRows = false;
            dgCsrKey.AllowUserToDeleteRows = false;
            dgCsrKey.AllowUserToResizeRows = false;
            dgCsrKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgCsrKey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgCsrKey.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgCsrKey.Columns.AddRange(new DataGridViewColumn[] { chkrecordid, guid, commonname, csr, key, keysize, createdate });
            dgCsrKey.EditMode = DataGridViewEditMode.EditOnF2;
            dgCsrKey.Location = new Point(0, 69);
            dgCsrKey.Name = "dgCsrKey";
            dgCsrKey.RowHeadersVisible = false;
            dgCsrKey.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgCsrKey.Size = new Size(792, 438);
            dgCsrKey.TabIndex = 3;
            dgCsrKey.CellBeginEdit += dgCsrKey_CellBeginEdit;
            dgCsrKey.CellContentDoubleClick += dgCsrKey_CellContentDoubleClick;
            dgCsrKey.CellValueChanged += dgCsrKey_CellValueChanged;
            dgCsrKey.CurrentCellDirtyStateChanged += dgCsrKey_CurrentCellDirtyStateChanged;
            // 
            // chkrecordid
            // 
            chkrecordid.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chkrecordid.FalseValue = "false";
            chkrecordid.FillWeight = 35.5329933F;
            chkrecordid.HeaderText = "";
            chkrecordid.Name = "chkrecordid";
            chkrecordid.Resizable = DataGridViewTriState.False;
            chkrecordid.TrueValue = "true";
            chkrecordid.Width = 20;
            // 
            // guid
            // 
            guid.DataPropertyName = "recordid";
            guid.FillWeight = 110.744492F;
            guid.HeaderText = "ID";
            guid.Name = "guid";
            // 
            // commonname
            // 
            commonname.DataPropertyName = "commonname";
            commonname.FillWeight = 110.744492F;
            commonname.HeaderText = "Commonname";
            commonname.Name = "commonname";
            // 
            // csr
            // 
            csr.DataPropertyName = "csr";
            csr.FillWeight = 110.744492F;
            csr.HeaderText = "CSR";
            csr.Name = "csr";
            // 
            // key
            // 
            key.DataPropertyName = "key";
            key.FillWeight = 110.744492F;
            key.HeaderText = "Key";
            key.Name = "key";
            // 
            // keysize
            // 
            keysize.DataPropertyName = "keysize";
            keysize.FillWeight = 110.744492F;
            keysize.HeaderText = "Key Size";
            keysize.Name = "keysize";
            // 
            // createdate
            // 
            createdate.DataPropertyName = "createdate";
            createdate.FillWeight = 110.744492F;
            createdate.HeaderText = "Create Date";
            createdate.Name = "createdate";
            // 
            // deleteCsrBtn
            // 
            deleteCsrBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteCsrBtn.BackColor = Color.Firebrick;
            deleteCsrBtn.Cursor = Cursors.Hand;
            deleteCsrBtn.FlatStyle = FlatStyle.Flat;
            deleteCsrBtn.ForeColor = SystemColors.GradientInactiveCaption;
            deleteCsrBtn.Location = new Point(688, 21);
            deleteCsrBtn.Name = "deleteCsrBtn";
            deleteCsrBtn.Size = new Size(83, 31);
            deleteCsrBtn.TabIndex = 2;
            deleteCsrBtn.Text = "Delete";
            deleteCsrBtn.UseMnemonic = false;
            deleteCsrBtn.UseVisualStyleBackColor = false;
            deleteCsrBtn.Click += deleteCsrBtn_Click;
            // 
            // newCsrBtn
            // 
            newCsrBtn.BackColor = Color.RoyalBlue;
            newCsrBtn.Cursor = Cursors.Hand;
            newCsrBtn.FlatAppearance.BorderColor = Color.RoyalBlue;
            newCsrBtn.FlatAppearance.BorderSize = 0;
            newCsrBtn.FlatAppearance.MouseDownBackColor = Color.CornflowerBlue;
            newCsrBtn.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
            newCsrBtn.FlatStyle = FlatStyle.Flat;
            newCsrBtn.ForeColor = SystemColors.ButtonFace;
            newCsrBtn.Location = new Point(20, 21);
            newCsrBtn.Name = "newCsrBtn";
            newCsrBtn.Size = new Size(101, 31);
            newCsrBtn.TabIndex = 0;
            newCsrBtn.Text = "New CSR";
            newCsrBtn.UseVisualStyleBackColor = false;
            newCsrBtn.Click += newCsrBtn_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(clearBtn);
            tabPage4.Controls.Add(createBtn);
            tabPage4.Controls.Add(label2);
            tabPage4.Controls.Add(cmbExtension);
            tabPage4.Controls.Add(txtPassphrase);
            tabPage4.Controls.Add(lblPassphrase);
            tabPage4.Controls.Add(importBtn);
            tabPage4.Controls.Add(txtPrivatekey);
            tabPage4.Controls.Add(lblPrivatekey);
            tabPage4.Controls.Add(txtCertificate);
            tabPage4.Controls.Add(lblCertificate);
            tabPage4.Controls.Add(label1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(792, 696);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "PKCS #12";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            clearBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            clearBtn.BackColor = Color.Firebrick;
            clearBtn.Cursor = Cursors.Hand;
            clearBtn.FlatStyle = FlatStyle.Flat;
            clearBtn.ForeColor = SystemColors.GradientInactiveCaption;
            clearBtn.Location = new Point(232, 455);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(83, 31);
            clearBtn.TabIndex = 11;
            clearBtn.Text = "Clear";
            clearBtn.UseMnemonic = false;
            clearBtn.UseVisualStyleBackColor = false;
            clearBtn.Click += clearBtn_Click;
            // 
            // createBtn
            // 
            createBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            createBtn.BackColor = Color.RoyalBlue;
            createBtn.Cursor = Cursors.Hand;
            createBtn.FlatAppearance.BorderColor = Color.RoyalBlue;
            createBtn.FlatAppearance.BorderSize = 0;
            createBtn.FlatAppearance.MouseDownBackColor = Color.CornflowerBlue;
            createBtn.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
            createBtn.FlatStyle = FlatStyle.Flat;
            createBtn.ForeColor = SystemColors.ButtonFace;
            createBtn.Location = new Point(19, 455);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(101, 31);
            createBtn.TabIndex = 10;
            createBtn.Text = "Create";
            createBtn.UseVisualStyleBackColor = false;
            createBtn.Click += createBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 403);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 9;
            label2.Text = "Extension";
            // 
            // cmbExtension
            // 
            cmbExtension.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExtension.FormattingEnabled = true;
            cmbExtension.Items.AddRange(new object[] { "PFX", "P12" });
            cmbExtension.Location = new Point(99, 400);
            cmbExtension.Name = "cmbExtension";
            cmbExtension.Size = new Size(121, 23);
            cmbExtension.TabIndex = 8;
            cmbExtension.SelectedIndexChanged += cmbExtension_SelectedIndexChanged;
            // 
            // txtPassphrase
            // 
            txtPassphrase.Location = new Point(99, 348);
            txtPassphrase.Name = "txtPassphrase";
            txtPassphrase.PasswordChar = '*';
            txtPassphrase.Size = new Size(313, 23);
            txtPassphrase.TabIndex = 7;
            // 
            // lblPassphrase
            // 
            lblPassphrase.AutoSize = true;
            lblPassphrase.Location = new Point(19, 351);
            lblPassphrase.Name = "lblPassphrase";
            lblPassphrase.Size = new Size(65, 15);
            lblPassphrase.TabIndex = 6;
            lblPassphrase.Text = "Passphrase";
            // 
            // importBtn
            // 
            importBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            importBtn.Location = new Point(654, 330);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(117, 23);
            importBtn.TabIndex = 5;
            importBtn.Text = "Load from store";
            importBtn.UseVisualStyleBackColor = true;
            importBtn.Click += importBtn_Click;
            // 
            // txtPrivatekey
            // 
            txtPrivatekey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            errorProvider1.SetIconAlignment(txtPrivatekey, ErrorIconAlignment.TopRight);
            txtPrivatekey.Location = new Point(99, 192);
            txtPrivatekey.Multiline = true;
            txtPrivatekey.Name = "txtPrivatekey";
            txtPrivatekey.ScrollBars = ScrollBars.Both;
            txtPrivatekey.Size = new Size(672, 122);
            txtPrivatekey.TabIndex = 4;
            txtPrivatekey.TextChanged += txtPrivatekey_TextChanged;
            // 
            // lblPrivatekey
            // 
            lblPrivatekey.AutoSize = true;
            lblPrivatekey.Location = new Point(19, 192);
            lblPrivatekey.Name = "lblPrivatekey";
            lblPrivatekey.Size = new Size(65, 15);
            lblPrivatekey.TabIndex = 3;
            lblPrivatekey.Text = "Private Key";
            // 
            // txtCertificate
            // 
            txtCertificate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            errorProvider1.SetIconAlignment(txtCertificate, ErrorIconAlignment.TopRight);
            txtCertificate.Location = new Point(99, 47);
            txtCertificate.Multiline = true;
            txtCertificate.Name = "txtCertificate";
            txtCertificate.ScrollBars = ScrollBars.Both;
            txtCertificate.Size = new Size(672, 122);
            txtCertificate.TabIndex = 2;
            txtCertificate.TextChanged += txtCertificate_TextChanged;
            // 
            // lblCertificate
            // 
            lblCertificate.AutoSize = true;
            lblCertificate.Location = new Point(19, 47);
            lblCertificate.Name = "lblCertificate";
            lblCertificate.Size = new Size(61, 15);
            lblCertificate.TabIndex = 1;
            lblCertificate.Text = "Certificate";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 13);
            label1.Name = "label1";
            label1.Size = new Size(645, 15);
            label1.TabIndex = 0;
            label1.Text = "PKCS #12 is format stores cryptography objects in single file. PFX / P12 file extensions are popular for PKCS#12 file format.";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(csrResult);
            tabPage5.Controls.Add(txtCsr);
            tabPage5.Controls.Add(lblCsr);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(792, 696);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "CSR Decoder";
            tabPage5.UseVisualStyleBackColor = true;
            tabPage5.Enter += tabPage5_Enter;
            // 
            // csrResult
            // 
            csrResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            csrResult.Controls.Add(txtAlgorithm);
            csrResult.Controls.Add(label10);
            csrResult.Controls.Add(txtCountry);
            csrResult.Controls.Add(label9);
            csrResult.Controls.Add(txtState);
            csrResult.Controls.Add(label8);
            csrResult.Controls.Add(txtLocality);
            csrResult.Controls.Add(label7);
            csrResult.Controls.Add(txtOrganiztionUnit);
            csrResult.Controls.Add(label6);
            csrResult.Controls.Add(txtOrganization);
            csrResult.Controls.Add(label5);
            csrResult.Controls.Add(txtSan);
            csrResult.Controls.Add(label4);
            csrResult.Controls.Add(txtCommonname);
            csrResult.Controls.Add(label3);
            csrResult.Location = new Point(18, 275);
            csrResult.Name = "csrResult";
            csrResult.Size = new Size(752, 400);
            csrResult.TabIndex = 2;
            csrResult.TabStop = false;
            csrResult.Text = "Result";
            // 
            // txtAlgorithm
            // 
            txtAlgorithm.Location = new Point(122, 350);
            txtAlgorithm.Name = "txtAlgorithm";
            txtAlgorithm.Size = new Size(222, 23);
            txtAlgorithm.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 353);
            label10.Name = "label10";
            label10.Size = new Size(61, 15);
            label10.TabIndex = 10;
            label10.Text = "Algorithm";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(122, 303);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(222, 23);
            txtCountry.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 306);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 8;
            label9.Text = "Country";
            // 
            // txtState
            // 
            txtState.Location = new Point(122, 259);
            txtState.Name = "txtState";
            txtState.Size = new Size(222, 23);
            txtState.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 262);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 8;
            label8.Text = "State";
            // 
            // txtLocality
            // 
            txtLocality.Location = new Point(122, 215);
            txtLocality.Name = "txtLocality";
            txtLocality.Size = new Size(222, 23);
            txtLocality.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 218);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 8;
            label7.Text = "Locality";
            // 
            // txtOrganiztionUnit
            // 
            txtOrganiztionUnit.Location = new Point(122, 175);
            txtOrganiztionUnit.Name = "txtOrganiztionUnit";
            txtOrganiztionUnit.Size = new Size(222, 23);
            txtOrganiztionUnit.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 178);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 6;
            label6.Text = "Organization Unit";
            // 
            // txtOrganization
            // 
            txtOrganization.Location = new Point(122, 136);
            txtOrganization.Name = "txtOrganization";
            txtOrganization.Size = new Size(222, 23);
            txtOrganization.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 139);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 4;
            label5.Text = "Organization";
            // 
            // txtSan
            // 
            txtSan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSan.Location = new Point(122, 62);
            txtSan.Multiline = true;
            txtSan.Name = "txtSan";
            txtSan.Size = new Size(613, 60);
            txtSan.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 65);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 2;
            label4.Text = "SANs";
            // 
            // txtCommonname
            // 
            txtCommonname.Location = new Point(122, 26);
            txtCommonname.Name = "txtCommonname";
            txtCommonname.Size = new Size(222, 23);
            txtCommonname.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 29);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 0;
            label3.Text = "Commonname";
            // 
            // txtCsr
            // 
            txtCsr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCsr.Location = new Point(65, 23);
            txtCsr.Multiline = true;
            txtCsr.Name = "txtCsr";
            txtCsr.Size = new Size(705, 232);
            txtCsr.TabIndex = 1;
            txtCsr.TextChanged += txtCsr_TextChanged;
            // 
            // lblCsr
            // 
            lblCsr.AutoSize = true;
            lblCsr.Location = new Point(18, 26);
            lblCsr.Name = "lblCsr";
            lblCsr.Size = new Size(28, 15);
            lblCsr.TabIndex = 0;
            lblCsr.Text = "CSR";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 724);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWin";
            Text = "CertTool";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgCerts).EndInit();
            ((System.ComponentModel.ISupportInitialize)certificateBindingSource).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgRoots).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgCsrKey).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            csrResult.ResumeLayout(false);
            csrResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dgCerts;
        private DataGridView dgRoots;
        private DataGridViewTextBoxColumn commonnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sansDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn localityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn organizationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn organizationUnitDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn validFromDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn validToDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn issuerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn keySizeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private BindingSource certificateBindingSource;
        private DataGridViewTextBoxColumn commonnameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn sansDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn localityDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn organizationDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn organizationUnitDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn validFromDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn validToDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn issuerDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn keySizeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn1;
        private Button newCsrBtn;
        private Button deleteCsrBtn;
        private DataGridView dgCsrKey;
        private DataGridViewCheckBoxColumn chkrecordid;
        private DataGridViewTextBoxColumn guid;
        private DataGridViewTextBoxColumn commonname;
        private DataGridViewTextBoxColumn csr;
        private DataGridViewTextBoxColumn key;
        private DataGridViewTextBoxColumn keysize;
        private DataGridViewTextBoxColumn createdate;
        private Label label1;
        private TextBox txtCertificate;
        private Label lblCertificate;
        private TextBox txtPrivatekey;
        private Label lblPrivatekey;
        private Button importBtn;
        private Label lblPassphrase;
        private TextBox txtPassphrase;
        private ComboBox cmbExtension;
        private Label label2;
        private Button createBtn;
        private Button clearBtn;
        private ErrorProvider errorProvider1;
        private TabPage tabPage5;
        private TextBox txtCsr;
        private Label lblCsr;
        private GroupBox csrResult;
        private TextBox txtCommonname;
        private Label label3;
        private TextBox txtSan;
        private Label label4;
        private Label label5;
        private TextBox txtOrganization;
        private TextBox txtOrganiztionUnit;
        private Label label6;
        private TextBox txtLocality;
        private Label label7;
        private TextBox txtState;
        private Label label8;
        private TextBox txtCountry;
        private Label label9;
        private TextBox txtAlgorithm;
        private Label label10;
    }
}
