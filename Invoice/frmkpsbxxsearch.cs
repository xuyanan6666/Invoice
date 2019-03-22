using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Invoice
{
    public partial class frmkpsbxxsearch : Form
    {
        public frmkpsbxxsearch()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void toolStripLabel3_Click_1(object sender, EventArgs e)
        {
            string sql = "select *   from  ptjk_fpscsb where 1=1";
            if (txt_fph.Text.Trim().Length > 0)
            {
                sql += " and   (zyid like'%" + txt_fph.Text.Trim() + "%' or  fph like'%" + txt_fph.Text.Trim() + "%' )";
            }
            sql += "  order  by   blsj  desc";
            DataTable pt = SqlHelp.HisTable(sql);
            if (pt != null)
            {
                dataGridView1.DataSource = pt;
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
