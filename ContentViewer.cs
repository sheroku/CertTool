using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertTool
{
    public partial class ContentViewer : Form
    {
        public ContentViewer()
        {
            InitializeComponent();
        }

        public void SetContent(string content)
        {
            this.txtContent.Text = content;
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(this.txtContent.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
