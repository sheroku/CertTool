namespace CertTool
{
    partial class ListPrivatekey
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
            dgPrivatekeys = new DataGridView();
            commonname = new DataGridViewTextBoxColumn();
            privatekey = new DataGridViewTextBoxColumn();
            keysize = new DataGridViewTextBoxColumn();
            createdate = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgPrivatekeys).BeginInit();
            SuspendLayout();
            // 
            // dgPrivatekeys
            // 
            dgPrivatekeys.AllowUserToAddRows = false;
            dgPrivatekeys.AllowUserToDeleteRows = false;
            dgPrivatekeys.AllowUserToResizeRows = false;
            dgPrivatekeys.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPrivatekeys.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgPrivatekeys.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPrivatekeys.Columns.AddRange(new DataGridViewColumn[] { commonname, privatekey, keysize, createdate });
            dgPrivatekeys.Dock = DockStyle.Fill;
            dgPrivatekeys.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgPrivatekeys.Location = new Point(0, 0);
            dgPrivatekeys.MultiSelect = false;
            dgPrivatekeys.Name = "dgPrivatekeys";
            dgPrivatekeys.ReadOnly = true;
            dgPrivatekeys.RowHeadersVisible = false;
            dgPrivatekeys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPrivatekeys.Size = new Size(800, 450);
            dgPrivatekeys.TabIndex = 0;
            dgPrivatekeys.CellContentDoubleClick += dgPrivatekeys_CellContentDoubleClick;
            // 
            // commonname
            // 
            commonname.DataPropertyName = "commonname";
            commonname.HeaderText = "Commonname";
            commonname.Name = "commonname";
            commonname.ReadOnly = true;
            // 
            // privatekey
            // 
            privatekey.DataPropertyName = "key";
            privatekey.HeaderText = "Private Key";
            privatekey.Name = "privatekey";
            privatekey.ReadOnly = true;
            // 
            // keysize
            // 
            keysize.DataPropertyName = "keysize";
            keysize.HeaderText = "Key Size";
            keysize.Name = "keysize";
            keysize.ReadOnly = true;
            // 
            // createdate
            // 
            createdate.DataPropertyName = "createdate";
            createdate.HeaderText = "Create Date";
            createdate.Name = "createdate";
            createdate.ReadOnly = true;
            // 
            // ListPrivatekey
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgPrivatekeys);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "ListPrivatekey";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Private Key";
            Load += ListPrivatekey_Load;
            ((System.ComponentModel.ISupportInitialize)dgPrivatekeys).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgPrivatekeys;
        private DataGridViewTextBoxColumn commonname;
        private DataGridViewTextBoxColumn privatekey;
        private DataGridViewTextBoxColumn keysize;
        private DataGridViewTextBoxColumn createdate;
    }
}