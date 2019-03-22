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
    public partial class frmpjzh : Form
    {
        public frmpjzh()
        {
            InitializeComponent();
        }

        
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            
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
            string method = "invoice.e.turn.bySN";
            string placecode = String.Empty;
            if(comboBox1.SelectedIndex>-1)
            {
                placecode = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
            }

            string lsh = txt_lsh.Text.Trim();
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("请选择发票种类");
                return;
            }
            string bill_no = txt_fph.Text.Trim();
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
            this.Cursor = Cursors.WaitCursor;
            string message = "{\"message\":{\"serial_number\":\"" + lsh + "\",\"bill_batch_code\":\"" + batchcode + "\""
                             + ",\"bill_no\":\""+bill_no+"\",\"place_code\":\""+placecode+"\"}}";

            Tools.WriteLog("据流水号纸质票据入参:", message);
            string json = String.Empty;
            try
            {
                json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                Tools.WriteLog("据流水号纸质票据出参:", json);
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
                    MessageBox.Show("领用成功！");
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


        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
