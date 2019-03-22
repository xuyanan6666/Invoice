using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Invoice
{
    public partial class FrmMzsfxm : Form
    {
        public FrmMzsfxm()
        {
            InitializeComponent();
        }

        private void FrmMzsfxm_Load(object sender, EventArgs e)
        {
            DataTable pt = SqlHelp.HisTable("select item_code 项目编码,item_name 项目名称 from pjjk_items");
            if (pt != null)
            {
                dataGridView2.DataSource = pt;
            }
            getHisfymc();
        }
        string g_hisbm;
        string g_ptbm;
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView2.CurrentRow.Index;
            g_ptbm = dataGridView2.Rows[i].Cells["项目编码"].Value.ToString();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView3.CurrentRow.Index;
            g_hisbm = dataGridView3.Rows[i].Cells["费用编码"].Value.ToString();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(g_hisbm) && !String.IsNullOrEmpty(g_ptbm) )
            {
                Int32 i = Convert.ToInt32(SqlHelp.ExecuteScalar("select count(*) from ptjk_dm where bz='门诊' and  hisbm=@hisbm", new SqlParameter("@hisbm", g_hisbm)));
               if (i == 0)
               {
                   SqlHelp.ExecuteNonQuery("insert into ptjk_dm values(@hisbm,@ptbm,@bz)", new SqlParameter("@hisbm", g_hisbm), new SqlParameter("@ptbm", g_ptbm), new SqlParameter("@bz", "门诊"));
               }
               else
               {
                   SqlHelp.ExecuteNonQuery("update ptjk_dm set ptbm=@ptbm where bz='门诊' and   hisbm=@hisbm", new SqlParameter("@ptbm", g_ptbm), new SqlParameter("@hisbm", g_hisbm));
               }
               getHisfymc();
            }
        }

        private void getHisfymc()
        {
<<<<<<< HEAD
            DataTable mz = SqlHelp.HisTable("select fyid 费用编码,fymc 费用名称,b.ptbm 平台编码 from dm_mzsfxm a left join (select * from ptjk_dm where bz='门诊') b on a.fyid=b.hisbm where len(a.fybm)=4 ");
=======
            DataTable mz = SqlHelp.HisTable("select fyid 费用编码,fymc 费用名称,b.ptbm 平台编码 from dm_mzsfxm a left join (select * from ptjk_dm where bz='门诊') b on a.fybm=b.hisbm where len(a.fybm)=4 ");
>>>>>>> d9cbb534583626ca525badf907d7f14b526880ea
            if (mz != null)
            {
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = mz;
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            string fymc;
            string ptmc;
            this.Cursor = Cursors.WaitCursor;
            DataTable dt = (DataTable)dataGridView3.DataSource;
            DataTable ptdt = (DataTable)dataGridView2.DataSource;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        g_hisbm = r["费用编码"].ToString().Trim();
                        fymc = r["费用名称"].ToString().Trim();
                        if (!String.IsNullOrEmpty(g_hisbm))
                        {
                            Int32 i = Convert.ToInt32(SqlHelp.ExecuteScalar("select count(*) from ptjk_dm where bz='门诊' and   hisbm=@hisbm", new SqlParameter("@hisbm", g_hisbm)));
                            if (i == 0)
                            {
                                DataRow[] drArr = ptdt.Select("项目名称='"+fymc+"'");
                                if (drArr.Length > 0)
                                {
                                    SqlHelp.ExecuteNonQuery("insert into ptjk_dm values(@hisbm,@ptbm,@bz)", new SqlParameter("@hisbm", g_hisbm), new SqlParameter("@ptbm", drArr[0]["项目编码"].ToString()),new SqlParameter("@bz","门诊"));
                                }
                                
                            }
                            //else
                            //{
                            //    SqlHelp.ExecuteNonQuery("update ptjk_dm set ptbm=@ptbm where hisbm=@hisbm", new SqlParameter("@ptbm", g_ptbm), new SqlParameter("@hisbm", g_hisbm));
                            //}
                        }                       
                    }
                    getHisfymc();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
