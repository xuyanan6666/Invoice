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
    public partial class frmpjzt : Form
    {
        public frmpjzt()
        {
            InitializeComponent();
        }

        private string getbatchcode(string bill_no)
        {
            string bath_code = String.Empty;
            if(!String.IsNullOrEmpty(bill_no))
            {
                bath_code = SqlHelp.ExecuteScalar("select top 1 bill_batch_code from pjjk_fply where " + bill_no + " between bgn_no and end_no");
            }
            return bath_code;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string method = "invoice.state.get";
            string message = "";
            DataTable dtmx = new DataTable();
            //1、添加列
            dtmx.Columns.Add("date", typeof(string)); //开票日期
            dtmx.Columns.Add("bill_name", typeof(string)); //票据种类名称
            dtmx.Columns.Add("bill_batch_code", typeof(string)); //票据代码
            dtmx.Columns.Add("bill_no", typeof(string)); //票据号码
            dtmx.Columns.Add("state", typeof(string)); //状态：1正常，2作废
            dtmx.Columns.Add("is_print_paper", typeof(string)); //电子打印纸票：0未打印，1已打印
            dtmx.Columns.Add("paper_bill_batch_code", typeof(string)); //纸质票据代码
            dtmx.Columns.Add("paper_bill_no", typeof(string)); //纸质票据号码
            dtmx.Columns.Add("is_scarlet", typeof(string)); //已开红票：0未开红票，1已开红票
            dtmx.Columns.Add("scarlet_bill_batch_code", typeof(string)); //红字电子票据代码
            dtmx.Columns.Add("scarlet_bill_no", typeof(string)); //红字电子票据号码
            this.Cursor = Cursors.WaitCursor;
            string bill_batch_code;
            string bill_no;
            bill_no = txt_fph.Text.Trim();
            if(String.IsNullOrEmpty(bill_no))
            {
                MessageBox.Show("必须输入票据号码!");
                return;
            }
            bill_batch_code = getbatchcode(bill_no);
            if (String.IsNullOrEmpty(bill_batch_code))
            {
                MessageBox.Show("未查询到票据代码！");
                return;
            }
            message = "{\"message\":{\"bill_batch_code\":\"" + bill_batch_code + "\",\"bill_no\":\""+bill_no+"\"}}";
            string json = String.Empty;
            try
            {
                json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
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
                    DataRow dr2 = dtmx.NewRow();
                    dr2[0] = ms.date;
                    dr2[1] = ms.bill_name;
                    dr2[2] = ms.bill_batch_code;
                    dr2[3] = ms.bill_no;
                    if (ms.state == "1")
                    {
                        dr2[4] = "正常";
                    }
                    else if (ms.state == "2")
                    {
                        dr2[4] = "作废";
                    }
                    if (ms.is_print_paper == "0")
                    {
                        dr2[5] = "未打印";
                    }
                    else if (ms.is_print_paper == "1")
                    {
                        dr2[5] = "已打印";
                    }
                    dr2[6] = ms.paper_bill_batch_code;
                    dr2[7] = ms.paper_bill_no;
                    if (ms.is_scarlet == "0")
                    {
                        dr2[8] = "未开红票";
                    }
                    else if (ms.is_scarlet == "1")
                    {
                        dr2[8] = "已开红票";
                    }
                    dr2[9] = ms.scarlet_bill_batch_code;
                    dr2[10] = ms.scarlet_bill_no;
                    
                    dtmx.Rows.Add(dr2);
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
                return;
            }
            this.Cursor = Cursors.Default;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dtmx;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
