namespace CertTool
{
    partial class ImportCert
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
            label1 = new Label();
            txtUrl = new TextBox();
            btnFetch = new Button();
            label2 = new Label();
            label3 = new Label();
            txtCert = new TextBox();
            btnCancel = new Button();
            btnImport = new Button();
            groupBox1 = new GroupBox();
            lblIssuer = new Label();
            label11 = new Label();
            lblCountry = new Label();
            label10 = new Label();
            lblState = new Label();
            label9 = new Label();
            lblLocality = new Label();
            label8 = new Label();
            label7 = new Label();
            lblValidTill = new Label();
            lblValidFrom = new Label();
            label6 = new Label();
            lblOrganization = new Label();
            label5 = new Label();
            lblCommonname = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 22);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "URL:";
            // 
            // txtUrl
            // 
            txtUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrl.Location = new Point(88, 19);
            txtUrl.MaxLength = 256;
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(619, 23);
            txtUrl.TabIndex = 1;
            // 
            // btnFetch
            // 
            btnFetch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFetch.Location = new Point(713, 18);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(75, 23);
            btnFetch.TabIndex = 2;
            btnFetch.Text = "Fetch";
            btnFetch.UseVisualStyleBackColor = true;
            btnFetch.Click += btnFetch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(359, 57);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 3;
            label2.Text = "Or";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 94);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 4;
            label3.Text = "Certificate";
            // 
            // txtCert
            // 
            txtCert.Location = new Point(88, 91);
            txtCert.Multiline = true;
            txtCert.Name = "txtCert";
            txtCert.Size = new Size(700, 135);
            txtCert.TabIndex = 5;
            txtCert.TextChanged += txtCert_TextChanged;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(713, 479);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnImport
            // 
            btnImport.DialogResult = DialogResult.OK;
            btnImport.Location = new Point(612, 479);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(75, 23);
            btnImport.TabIndex = 7;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblIssuer);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(lblCountry);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(lblState);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lblLocality);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblValidTill);
            groupBox1.Controls.Add(lblValidFrom);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblOrganization);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblCommonname);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 243);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 213);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Certificate information";
            // 
            // lblIssuer
            // 
            lblIssuer.AutoSize = true;
            lblIssuer.Location = new Point(470, 164);
            lblIssuer.Name = "lblIssuer";
            lblIssuer.Size = new Size(0, 15);
            lblIssuer.TabIndex = 16;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(399, 164);
            label11.Name = "label11";
            label11.Size = new Size(37, 15);
            label11.TabIndex = 15;
            label11.Text = "Issuer";
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Location = new Point(112, 164);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(0, 15);
            lblCountry.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 164);
            label10.Name = "label10";
            label10.Size = new Size(50, 15);
            label10.TabIndex = 13;
            label10.Text = "Country";
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(470, 127);
            lblState.Name = "lblState";
            lblState.Size = new Size(0, 15);
            lblState.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(399, 127);
            label9.Name = "label9";
            label9.Size = new Size(33, 15);
            label9.TabIndex = 11;
            label9.Text = "State";
            // 
            // lblLocality
            // 
            lblLocality.AutoSize = true;
            lblLocality.Location = new Point(112, 127);
            lblLocality.Name = "lblLocality";
            lblLocality.Size = new Size(0, 15);
            lblLocality.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 127);
            label8.Name = "label8";
            label8.Size = new Size(48, 15);
            label8.TabIndex = 9;
            label8.Text = "Locality";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(399, 95);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 8;
            label7.Text = "Valid Till";
            // 
            // lblValidTill
            // 
            lblValidTill.AutoSize = true;
            lblValidTill.Location = new Point(470, 95);
            lblValidTill.Name = "lblValidTill";
            lblValidTill.Size = new Size(0, 15);
            lblValidTill.TabIndex = 7;
            // 
            // lblValidFrom
            // 
            lblValidFrom.AutoSize = true;
            lblValidFrom.Location = new Point(112, 95);
            lblValidFrom.Name = "lblValidFrom";
            lblValidFrom.Size = new Size(0, 15);
            lblValidFrom.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 95);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 4;
            label6.Text = "Valid From";
            // 
            // lblOrganization
            // 
            lblOrganization.AutoSize = true;
            lblOrganization.Location = new Point(112, 61);
            lblOrganization.Name = "lblOrganization";
            lblOrganization.Size = new Size(0, 15);
            lblOrganization.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 63);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 2;
            label5.Text = "Organization";
            // 
            // lblCommonname
            // 
            lblCommonname.AutoSize = true;
            lblCommonname.Location = new Point(112, 34);
            lblCommonname.Name = "lblCommonname";
            lblCommonname.Size = new Size(0, 15);
            lblCommonname.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 34);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 0;
            label4.Text = "Commonname";
            // 
            // ImportCert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 514);
            Controls.Add(groupBox1);
            Controls.Add(btnImport);
            Controls.Add(btnCancel);
            Controls.Add(txtCert);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnFetch);
            Controls.Add(txtUrl);
            Controls.Add(label1);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ImportCert";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Import Certificate";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUrl;
        private Button btnFetch;
        private Label label2;
        private Label label3;
        private TextBox txtCert;
        private Button btnCancel;
        private Button btnImport;
        private GroupBox groupBox1;
        private Label lblCommonname;
        private Label label4;
        private Label lblOrganization;
        private Label label5;
        private Label lblValidFrom;
        private Label label6;
        private Label label7;
        private Label lblValidTill;
        private Label lblIssuer;
        private Label label11;
        private Label lblCountry;
        private Label label10;
        private Label lblState;
        private Label label9;
        private Label lblLocality;
        private Label label8;
    }
}