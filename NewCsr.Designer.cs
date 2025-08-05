namespace CertTool
{
    partial class NewCsr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtCommonname = new TextBox();
            csrRequestBindingSource = new BindingSource(components);
            lblCommonname = new Label();
            lblSans = new Label();
            txtSans = new TextBox();
            label1 = new Label();
            txtOrganization = new TextBox();
            lblOrganizationUnit = new Label();
            txtOrganizationUnit = new TextBox();
            lblLocality = new Label();
            txtLocality = new TextBox();
            lblState = new Label();
            txtState = new TextBox();
            lblCountry = new Label();
            lblAlgorithm = new Label();
            cmbAlgorithm = new ComboBox();
            createBtn = new Button();
            cancelBtn = new Button();
            txtCountry = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)csrRequestBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtCommonname
            // 
            txtCommonname.DataBindings.Add(new Binding("Text", csrRequestBindingSource, "commonname", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCommonname.DataBindings.Add(new Binding("DataContext", csrRequestBindingSource, "commonname", true));
            txtCommonname.Location = new Point(118, 26);
            txtCommonname.MaxLength = 64;
            txtCommonname.Name = "txtCommonname";
            txtCommonname.Size = new Size(354, 23);
            txtCommonname.TabIndex = 0;
            txtCommonname.Validating += txtCommonname_Validating;
            // 
            // csrRequestBindingSource
            // 
            csrRequestBindingSource.DataSource = typeof(Models.CsrRequest);
            // 
            // lblCommonname
            // 
            lblCommonname.AutoSize = true;
            lblCommonname.Location = new Point(12, 26);
            lblCommonname.Name = "lblCommonname";
            lblCommonname.Size = new Size(88, 15);
            lblCommonname.TabIndex = 1;
            lblCommonname.Text = "Commonname";
            // 
            // lblSans
            // 
            lblSans.AutoSize = true;
            lblSans.Location = new Point(12, 69);
            lblSans.Name = "lblSans";
            lblSans.Size = new Size(35, 15);
            lblSans.TabIndex = 2;
            lblSans.Text = "SANs";
            // 
            // txtSans
            // 
            txtSans.DataBindings.Add(new Binding("Text", csrRequestBindingSource, "sans", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSans.DataBindings.Add(new Binding("DataContext", csrRequestBindingSource, "sans", true));
            txtSans.Location = new Point(118, 66);
            txtSans.Multiline = true;
            txtSans.Name = "txtSans";
            txtSans.Size = new Size(354, 71);
            txtSans.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 158);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 4;
            label1.Text = "Organization";
            // 
            // txtOrganization
            // 
            txtOrganization.DataBindings.Add(new Binding("Text", csrRequestBindingSource, "organization", true, DataSourceUpdateMode.OnPropertyChanged));
            txtOrganization.DataBindings.Add(new Binding("DataContext", csrRequestBindingSource, "organization", true));
            txtOrganization.Location = new Point(118, 155);
            txtOrganization.MaxLength = 63;
            txtOrganization.Name = "txtOrganization";
            txtOrganization.Size = new Size(354, 23);
            txtOrganization.TabIndex = 5;
            txtOrganization.Validating += txtOrganization_Validating;
            // 
            // lblOrganizationUnit
            // 
            lblOrganizationUnit.AutoSize = true;
            lblOrganizationUnit.Location = new Point(12, 202);
            lblOrganizationUnit.Name = "lblOrganizationUnit";
            lblOrganizationUnit.Size = new Size(100, 15);
            lblOrganizationUnit.TabIndex = 6;
            lblOrganizationUnit.Text = "Organization Unit";
            // 
            // txtOrganizationUnit
            // 
            txtOrganizationUnit.DataBindings.Add(new Binding("Text", csrRequestBindingSource, "organizationunit", true, DataSourceUpdateMode.OnPropertyChanged));
            txtOrganizationUnit.DataBindings.Add(new Binding("DataContext", csrRequestBindingSource, "organizationunit", true));
            txtOrganizationUnit.Location = new Point(118, 199);
            txtOrganizationUnit.MaxLength = 63;
            txtOrganizationUnit.Name = "txtOrganizationUnit";
            txtOrganizationUnit.Size = new Size(354, 23);
            txtOrganizationUnit.TabIndex = 7;
            txtOrganizationUnit.Validating += txtOrganizationUnit_Validating;
            // 
            // lblLocality
            // 
            lblLocality.AutoSize = true;
            lblLocality.Location = new Point(12, 246);
            lblLocality.Name = "lblLocality";
            lblLocality.Size = new Size(48, 15);
            lblLocality.TabIndex = 8;
            lblLocality.Text = "Locality";
            // 
            // txtLocality
            // 
            txtLocality.DataBindings.Add(new Binding("Text", csrRequestBindingSource, "locality", true, DataSourceUpdateMode.OnPropertyChanged));
            txtLocality.DataBindings.Add(new Binding("DataContext", csrRequestBindingSource, "locality", true));
            txtLocality.Location = new Point(118, 243);
            txtLocality.MaxLength = 63;
            txtLocality.Name = "txtLocality";
            txtLocality.Size = new Size(354, 23);
            txtLocality.TabIndex = 9;
            txtLocality.Validating += txtLocality_Validating;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(12, 289);
            lblState.Name = "lblState";
            lblState.Size = new Size(33, 15);
            lblState.TabIndex = 10;
            lblState.Text = "State";
            // 
            // txtState
            // 
            txtState.DataBindings.Add(new Binding("Text", csrRequestBindingSource, "state", true, DataSourceUpdateMode.OnPropertyChanged));
            txtState.DataBindings.Add(new Binding("DataContext", csrRequestBindingSource, "state", true));
            txtState.Location = new Point(118, 286);
            txtState.Name = "txtState";
            txtState.Size = new Size(354, 23);
            txtState.TabIndex = 11;
            txtState.Validating += txtState_Validating;
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Location = new Point(12, 328);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(50, 15);
            lblCountry.TabIndex = 12;
            lblCountry.Text = "Country";
            // 
            // lblAlgorithm
            // 
            lblAlgorithm.AutoSize = true;
            lblAlgorithm.Location = new Point(12, 373);
            lblAlgorithm.Name = "lblAlgorithm";
            lblAlgorithm.Size = new Size(61, 15);
            lblAlgorithm.TabIndex = 14;
            lblAlgorithm.Text = "Algorithm";
            // 
            // cmbAlgorithm
            // 
            cmbAlgorithm.DataBindings.Add(new Binding("Text", csrRequestBindingSource, "algorithm", true, DataSourceUpdateMode.OnPropertyChanged));
            cmbAlgorithm.DataBindings.Add(new Binding("DataContext", csrRequestBindingSource, "algorithm", true));
            cmbAlgorithm.DisplayMember = "Value";
            cmbAlgorithm.FormattingEnabled = true;
            cmbAlgorithm.Location = new Point(118, 370);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(354, 23);
            cmbAlgorithm.TabIndex = 15;
            cmbAlgorithm.ValueMember = "Key";
            // 
            // createBtn
            // 
            createBtn.BackColor = Color.RoyalBlue;
            createBtn.FlatAppearance.BorderColor = Color.RoyalBlue;
            createBtn.FlatAppearance.BorderSize = 0;
            createBtn.FlatAppearance.MouseDownBackColor = Color.CornflowerBlue;
            createBtn.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
            createBtn.FlatStyle = FlatStyle.Flat;
            createBtn.ForeColor = SystemColors.ButtonFace;
            createBtn.Location = new Point(41, 428);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(101, 31);
            createBtn.TabIndex = 16;
            createBtn.Text = "Create";
            createBtn.UseVisualStyleBackColor = false;
            createBtn.Click += createBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.Firebrick;
            cancelBtn.CausesValidation = false;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.ForeColor = SystemColors.GradientInactiveCaption;
            cancelBtn.Location = new Point(358, 428);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(83, 31);
            cancelBtn.TabIndex = 17;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseMnemonic = false;
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // txtCountry
            // 
            txtCountry.CharacterCasing = CharacterCasing.Upper;
            txtCountry.DataBindings.Add(new Binding("Text", csrRequestBindingSource, "country", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCountry.DataBindings.Add(new Binding("DataContext", csrRequestBindingSource, "country", true));
            txtCountry.Location = new Point(118, 325);
            txtCountry.MaxLength = 2;
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(53, 23);
            txtCountry.TabIndex = 18;
            txtCountry.Validating += txtCountry_Validating;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // NewCsr
            // 
            AcceptButton = createBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(495, 485);
            ControlBox = false;
            Controls.Add(txtCountry);
            Controls.Add(cancelBtn);
            Controls.Add(createBtn);
            Controls.Add(cmbAlgorithm);
            Controls.Add(lblAlgorithm);
            Controls.Add(lblCountry);
            Controls.Add(txtState);
            Controls.Add(lblState);
            Controls.Add(txtLocality);
            Controls.Add(lblLocality);
            Controls.Add(txtOrganizationUnit);
            Controls.Add(lblOrganizationUnit);
            Controls.Add(txtOrganization);
            Controls.Add(label1);
            Controls.Add(txtSans);
            Controls.Add(lblSans);
            Controls.Add(lblCommonname);
            Controls.Add(txtCommonname);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NewCsr";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create new CSR & Key";
            ((System.ComponentModel.ISupportInitialize)csrRequestBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCommonname;
        private Label lblCommonname;
        private Label lblSans;
        private TextBox txtSans;
        private Label label1;
        private TextBox txtOrganization;
        private Label lblOrganizationUnit;
        private TextBox txtOrganizationUnit;
        private Label lblLocality;
        private TextBox txtLocality;
        private Label lblState;
        private TextBox txtState;
        private Label lblCountry;
        private Label lblAlgorithm;
        private ComboBox cmbAlgorithm;
        private Button createBtn;
        private Button cancelBtn;
        private TextBox txtCountry;
        private BindingSource csrRequestBindingSource;
        private ErrorProvider errorProvider1;
    }
}