using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Invoice
{
    public partial class frmpjImage : Form
    {
        public frmpjImage()
        {
            InitializeComponent();
        }

        private DataTable getbatchcode(string bill_no)
        {
            DataTable dt = null;
            if(!String.IsNullOrEmpty(bill_no))
            {
                dt = SqlHelp.HisTable("select top 1 * from pjjk_fply where " + bill_no + " between bgn_no and end_no");
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string method = "invoice.image.get";
            string message = "";
            
            this.Cursor = Cursors.WaitCursor;
            string bill_batch_code;
            string bill_no;
            string bill_code;
            string source_type;
            if(radioButton1.Checked)
            {
                source_type = "1";
            }
            else
            {
                source_type = "2";
            }
            bill_no = txt_fph.Text.Trim();
            if(String.IsNullOrEmpty(bill_no))
            {
                MessageBox.Show("必须输入票据号码!");
                return;
            }
            DataTable dt = getbatchcode(bill_no);
            if(dt==null || dt.Rows.Count == 0)
            {
                MessageBox.Show("未找到票据信息!");
                return;
            }
            bill_batch_code = dt.Rows[0]["bill_batch_code"].ToString();
            bill_code = dt.Rows[0]["bill_code"].ToString();

            if (String.IsNullOrEmpty(bill_batch_code))
            {
                MessageBox.Show("未查询到票据代码！");
                return;
            }
            message = "{\"message\":{\"bill_code\":\"" + bill_code + "\",\"bill_batch_code\":\"" + bill_batch_code + "\""
                                     + ",\"bill_no\":\"" + bill_no + "\",\"source_type\":\""+source_type+"\"}}";
            Tools.WriteLog("获取票据信息图片入参：", message);
            string json = String.Empty;
            try
            {
                json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                Tools.WriteLog("获取票据信息图片出参：", json);
                var j = Tools.FromJson(json);
                if (json.IndexOf("error_message") > -1)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(j.error_message.error_msg);
                    return;
                }
                else
                {
                    var ms = j.message;
                    string image = ms.image;
                    if(!String.IsNullOrEmpty(image))
                    {
                        byte[] bytes = Convert.FromBase64String(image);
                        MemoryStream buf = new MemoryStream(bytes);
                        Image images = Image.FromStream(buf, true);
                        pictureBox1.Image = images;
                    } 
                    else
                    {
                        MessageBox.Show("未获取到图片!");
                        return;
                    }
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
