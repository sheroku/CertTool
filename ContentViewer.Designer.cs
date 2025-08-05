namespace CertTool
{
    partial class ContentViewer
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
            txtContent = new TextBox();
            copyBtn = new Button();
            closeBtn = new Button();
            SuspendLayout();
            // 
            // txtContent
            // 
            txtContent.Location = new Point(12, 12);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ReadOnly = true;
            txtContent.ScrollBars = ScrollBars.Both;
            txtContent.Size = new Size(488, 378);
            txtContent.TabIndex = 0;
            // 
            // copyBtn
            // 
            copyBtn.BackColor = Color.RoyalBlue;
            copyBtn.Cursor = Cursors.Hand;
            copyBtn.DialogResult = DialogResult.OK;
            copyBtn.FlatAppearance.BorderColor = Color.RoyalBlue;
            copyBtn.FlatAppearance.BorderSize = 0;
            copyBtn.FlatAppearance.MouseDownBackColor = Color.CornflowerBlue;
            copyBtn.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
            copyBtn.FlatStyle = FlatStyle.Flat;
            copyBtn.ForeColor = SystemColors.ButtonFace;
            copyBtn.Location = new Point(21, 406);
            copyBtn.Name = "copyBtn";
            copyBtn.Size = new Size(173, 31);
            copyBtn.TabIndex = 1;
            copyBtn.Text = "Copy to Clipboard & Close";
            copyBtn.UseMnemonic = false;
            copyBtn.UseVisualStyleBackColor = false;
            copyBtn.Click += copyBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeBtn.BackColor = Color.Firebrick;
            closeBtn.Cursor = Cursors.Hand;
            closeBtn.DialogResult = DialogResult.Cancel;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.ForeColor = SystemColors.GradientInactiveCaption;
            closeBtn.Location = new Point(400, 406);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(83, 31);
            closeBtn.TabIndex = 3;
            closeBtn.Text = "Close";
            closeBtn.UseMnemonic = false;
            closeBtn.UseVisualStyleBackColor = false;
            // 
            // ContentViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 449);
            ControlBox = false;
            Controls.Add(closeBtn);
            Controls.Add(copyBtn);
            Controls.Add(txtContent);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ContentViewer";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ContentViewer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtContent;
        private Button copyBtn;
        private Button closeBtn;
    }
}