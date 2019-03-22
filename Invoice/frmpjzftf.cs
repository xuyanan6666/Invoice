using Invoice.Mode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Invoice
{
    public partial class frmpjzftf : Form
    {
        public frmpjzftf()
        {
            InitializeComponent();
        }

        
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void frmkpd_Load(object sender, EventArgs e)
        {

            //getZffp();
        }

        private int zffp(string bill_no, string bill_batch_code)
        {
            this.Cursor = Cursors.WaitCursor; 
            string method = "invoice.p.invalidate.do";    
  
            string message = "{\"message\":{\"bill_batch_code\":\"" + bill_batch_code + "\",\"bill_no\":\"" + bill_no + "\""
                             + ",\"scarlet_bill_code\":\"\",\"scarlet_bill_batch_code\":\"\",\"scarlet_bill_no\":\"\"}}";
            Tools.WriteLog("作废纸质票入参", message);
            string json = String.Empty;
            try
            {
                json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                Tools.WriteLog("作废纸质票出参", json);
            }
            catch(Exception ex)
            {
                this.Cursor = Cursors.Default; 
                MessageBox.Show(ex.Message);
                return -1;
            }
            this.Cursor = Cursors.Default; 
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            if(json.IndexOf("error_message")==-1)
            {
                SuccessJson jd = jsSerializer.Deserialize<SuccessJson>(json);
                string msg = jd.message.succ_code;
                if (msg.Equals("0000"))
                {
                    SqlHelp.ExecuteNonQuery("insert into ptjk_fpzf values(@billno,@billbatchcode,@sj)", new SqlParameter("@billno", bill_no), new SqlParameter("@billbatchcode", bill_batch_code), new SqlParameter("@sj", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    return 0;
                }
            }
            else
            {
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                ErrorJson jd2 = Serializer.Deserialize<ErrorJson>(json);
                string msg2 = jd2.error_message.error_msg.ToString();
                MessageBox.Show(msg2);
                return -1;
            }

            return 0;   
            
        }

        private void getZffp()
        {
            DataTable dt = SqlHelp.HisTable("select bill_no 发票号,bill_batch_code 发票代码,sj 作废时间 from ptjk_fpzf order by sj desc");
            dataGridView1.DataSource = dt;
        }

        public void getfpmx(string fph)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = null;
            try
            {
                sb.Append(" select * from (");
                sb.Append(" select a.fph HIS发票号,right(a.sgfph,LEN(zzph)) 发票流水号,tfsj 退费时间,tfczy 退费操作员,c.bill_batch_code as 发票代码");
                sb.Append(" from mz_fpmx a,(select distinct fph,tfsj,tfczy from mz_brsf where tfsj is not null) b,pjjk_fply c");
                sb.Append(" where a.fph=b.fph and right(a.sgfph,LEN(zzph)) between c.bgn_no and c.end_no");
                sb.Append(" and not exists(select 1 from ptjk_fpzf g where right(a.sgfph,LEN(zzph))=g.bill_no)");
                sb.Append(" union all ");
                sb.Append(" select a.zyid HIS发票号,right(a.sgfph,LEN(a.zzph)) 发票流水号,a.zfsj 退费时间,a.zfczy 退费操作员,c.bill_batch_code as 发票代码");
                sb.Append(" from zy_fpmx a,pjjk_fply c,v_zy_brxx d");
                sb.Append(" where a.zyid=d.zyid and right(a.sgfph,LEN(zzph)) between c.bgn_no and c.end_no and a.zfsj is not null");
                sb.Append(" and not exists(select 1 from ptjk_fpzf g where right(a.sgfph,LEN(zzph))=g.bill_no)");
                sb.Append(" ) a");
                if (!String.IsNullOrEmpty(fph))
                {
                    sb.Append(" and HIS发票号 like " + @fph + "%");
                    Tools.WriteLog("退费sql",sb.ToString());
                    dt = SqlHelp.HisTable(sb.ToString(), new SqlParameter("@fph", fph));
                }
                else
                {
                    dt = SqlHelp.HisTable(sb.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            dataGridView2.DataSource = dt;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fph = txt_fph.Text.Trim();
            getfpmx(fph);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           int i =  zffp(g_bill_no, g_billbatch_code);
           getfpmx("");
         
        }


        string g_bill_no;
        string g_billbatch_code;
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView2.CurrentRow.Index;
            g_bill_no = dataGridView2.Rows[i].Cells["发票流水号"].Value.ToString();
            g_billbatch_code = dataGridView2.Rows[i].Cells["发票代码1"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView2.DataSource;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow r in dt.Rows)
                    {
                        zffp(r["发票流水号"].ToString(), r["发票代码"].ToString());
                    }
                    getfpmx("");
                }
            }
        }

        public void zffp()
        {
            getfpmx("");
            DataTable dt = (DataTable)dataGridView2.DataSource;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        zffp(r["发票流水号"].ToString(), r["发票代码"].ToString());
                    }
                }
            }
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
