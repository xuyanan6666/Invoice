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
    public partial class frmfpzf : Form
    {
        public frmfpzf()
        {
            InitializeComponent();
        }

       


        private void frmkpd_Load(object sender, EventArgs e)
        {
            DataTable kpd = SqlHelp.HisTable("select * from pjjk_place");
            if (kpd.Rows.Count > 0)
            {
                foreach (DataRow r in kpd.Rows)
                {
                    ComboboxItem combox = new ComboboxItem();
                    combox.Text = r["place_name"].ToString();
                    combox.Value = r["place_code"].ToString();
                    comboBox1.Items.Add(combox);
                }
            }
            
            DataTable fpzl = SqlHelp.HisTable("select * from pjjk_bill");
            string str = "";
            if(fpzl.Rows.Count>0)
            {
                foreach (DataRow r in fpzl.Rows)
                {
                    str = r["bill_code"].ToString() + "--" + r["bill_name"].ToString() + "--" + r["bill_batch_code"].ToString();
                    comboBox2.Items.Add(str);
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string method = "stock.invalidate.do";
            string placecode = String.Empty;
            if(comboBox1.SelectedIndex>-1)
            {
                placecode = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
            }            
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("请选择发票种类");
                return;
            }
            string com2 = comboBox2.SelectedItem.ToString();
            string billcode = com2.Substring(0, com2.IndexOf("--"));
            com2 = com2.Substring(com2.IndexOf("--")+2);
            com2 = com2.Substring(com2.IndexOf("--")+2);
            string batchcode = com2;
            if(String.IsNullOrEmpty(batchcode))
            {
                MessageBox.Show("票据代码不能为空");
                return;
            }
            string lx = String.Empty;
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("请选择作废类型");
                return;
            }
            if(radioButton1.Checked)
            {
                lx = "1";
            }
            else
            {
                lx = "2";
            }
            string qsh = txt_qsh.Text.Trim();
            string zzh = txt_zzh.Text.Trim();
            if(String.IsNullOrEmpty(lx) || String.IsNullOrEmpty(qsh) || String.IsNullOrEmpty(zzh))
            {
                MessageBox.Show("作废类型、起始号、终止号不能为空");
                return;
            }
            string message = "{\"message\":{\"place_code\":\"" + placecode + "\",\"bill_batch_code\":\"" + batchcode + "\",\"bgn_no\":\"" + qsh + "\""
                             + ",\"end_no\":\"" + zzh + "\",\"invalid_type\":\"" + lx + "\"}}";
            string json = String.Empty;
            try
            {
                json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            if(json.IndexOf("error_message")==-1)
            {
                SuccessJson jd = jsSerializer.Deserialize<SuccessJson>(json);
                string msg = jd.message.succ_code;
                if (msg.Equals("0000"))
                {
                    MessageBox.Show("领用成功！");
                }
            }
            else
            {
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                ErrorJson jd2 = Serializer.Deserialize<ErrorJson>(json);
                string msg2 = jd2.error_message.error_msg.ToString();
                MessageBox.Show(msg2);
            }
             
               
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
