using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CertTool.Classes;
using CertTool.Models;
using DBreeze;
using DBreeze.DataTypes;

namespace CertTool
{
    public partial class ListPrivatekey : Form
    {
        SortableBindingList<CsrKeyRecord> csrkeys = new SortableBindingList<CsrKeyRecord>();
        DBreezeEngine? engine = null;
        string key = "";

        public ListPrivatekey()
        {
            InitializeComponent();
        }

        private void ListPrivatekey_Load(object sender, EventArgs e)
        {
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

                    dgPrivatekeys.DataSource = csrkeys;
                }
            }
        }

        private void dgPrivatekeys_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.key = csrkeys[e.RowIndex].key;
            this.DialogResult = DialogResult.OK;
        }

        public string getSelectKey()
        {
            return this.key;
        }
    }
}
