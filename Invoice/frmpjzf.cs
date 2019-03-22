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
    public partial class frmpjzf : Form
    {
        public frmpjzf()
        {
            InitializeComponent();
        }

        
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void frmkpd_Load(object sender, EventArgs e)
        {

            getZffp();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string method = "invoice.p.invalidate.do";    
            string bill_no = txt_lsh.Text.Trim();
            if (String.IsNullOrEmpty(bill_no))
            {
                MessageBox.Show("请输入发票流水号");
                return;
            }
            string sql = "select top 1 bill_batch_code from pjjk_fply where " + bill_no + " between bgn_no and end_no ";
            Tools.WriteLog("sql:",sql);
            string bill_batch_code = SqlHelp.ExecuteScalar(sql);
            this.Cursor = Cursors.WaitCursor;
            string message = "{\"message\":{\"bill_batch_code\":\"" + bill_batch_code + "\",\"bill_no\":\"" + bill_no + "\""
                             + ",\"scarlet_bill_code\":\"\",\"scarlet_bill_batch_code\":\"\",\"scarlet_bill_no\":\"\"}}";
            string json = String.Empty;
            Tools.WriteLog("卡纸等情况作废入参 ：",message);
            try
            {
                json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                Tools.WriteLog("卡纸等情况作废出参 ：", json);
            }
            catch(Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
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
                    MessageBox.Show("作废成功！");
                    getZffp();
                    return;
                }
            }
            else
            {
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                ErrorJson jd2 = Serializer.Deserialize<ErrorJson>(json);
                string msg2 = jd2.error_message.error_msg.ToString();
                MessageBox.Show(msg2);
                return;
            }
            
               
            
        }

        private void getZffp()
        {
            DataTable dt = SqlHelp.HisTable("select bill_no 发票号,bill_batch_code 发票代码,sj 作废时间 from ptjk_fpzf order by sj desc");
            dataGridView1.DataSource = dt;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
