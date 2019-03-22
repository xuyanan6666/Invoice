using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Invoice
{
    public partial class frmfpddm : Form
    {
        public frmfpddm()
        {
            InitializeComponent();
        }

        private void frmfpddm_Load(object sender, EventArgs e)
        {
            DataTable kpd = SqlHelp.HisTable("select place_code 编码,place_name 名称 from pjjk_place");
            dataGridView1.DataSource = kpd;
            DataTable czdt = SqlHelp.HisTable("select  czyid 操作员标识,czy 操作员,qsh 起始号,zzh 终止号 from  cwjk_fply where zfsj is null");
            dataGridView2.DataSource = czdt;
            kpdm();
        }
        private  void kpdm()
        {
            DataTable dmdt = SqlHelp.HisTable("select  kpbm 开票点编码,czyid 操作员标识  from  ptjk_kpdm");
            dataGridView3.DataSource = dmdt;
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //将领用操作员与开票人进行对照
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1 || dataGridView2.SelectedRows.Count < 1)//小于等于0 为没有选中任何行
            {
                MessageBox.Show("请选择对照数据！");
            }
            else
            {
                SqlParameter kpbm = new SqlParameter("@kpbm", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                SqlParameter czyid = new SqlParameter("@czyid", dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                DataTable seldt = SqlHelp.HisTable("select * from  ptjk_kpdm  where kpbm = '" + kpbm + "'");
                if (seldt.Rows.Count > 0)
                {
                    string ls_delsql = "delete  ptjk_kpdm  where kpbm= @kpbm";
                    SqlHelp.ExecuteNonQuery(ls_delsql, kpbm);
                    string ls_sql = "insert into ptjk_kpdm(kpbm,czyid) values(@kpbm,@czyid)";
                    SqlHelp.ExecuteNonQuery(ls_sql, kpbm, czyid);
                    kpdm();
                }
                else
                {
                    string ls_sql = "insert into ptjk_kpdm(kpbm,czyid) values(@kpbm,@czyid)";
                    SqlHelp.ExecuteNonQuery(ls_sql, kpbm, czyid);
                    kpdm();
                }
              
            }
        }
        //取消对照
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count < 1)//小于等于0 为没有选中任何行
            {
                MessageBox.Show("请选择一条数据！");
            }
            else
            {
                SqlParameter kpbm = new SqlParameter("@kpbm", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string ls_delsql = "delete  ptjk_kpdm  where kpbm= @kpbm";
                SqlHelp.ExecuteNonQuery(ls_delsql, kpbm);
                kpdm();
            }
        }
    }
}
