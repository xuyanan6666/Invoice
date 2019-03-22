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
    public partial class frmkpxxmxsearch : Form
    {
        public frmkpxxmxsearch()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            string ls_fph;
            ls_fph = txt_fph.Text.Trim();
            getKpxx(ls_fph);
        }

        private void getKpxx(string fph)
        {
            string ls_sql = "select  serial_number 发票号,fpzl 发票种类,bill_no 票据号码 from ptjk_fpsc ";
            if (!String.IsNullOrEmpty(fph))
            {
                ls_sql = ls_sql + " where serial_number='MP'+dbo.padl(" + fph + ",8)";
            }
            DataTable dt = SqlHelp.HisTable(ls_sql);
            dataGridView1.DataSource = dt; 
        }

        private void getKpxxsearch(string fph)
        {
            string ls_sql = "select  serial_number 发票号,fpzl 发票种类,bill_no 票据号码,case when del=1 then '未上传成功' else '成功上传' end as 备注 from ptjk_fpsc ";
            if (!String.IsNullOrEmpty(fph))
            {
                ls_sql = ls_sql + " where serial_number='MP'+dbo.padl(" + fph + ",8)";
            }
            DataTable dt = SqlHelp.HisTable(ls_sql);
            dataGridView1.DataSource = dt;
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            string method = "invoice.detail.bySN.get"; 
            string serial_number = "";
            string message = "";
            string msg = "";
            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataTable dtmx = new DataTable();
            //1、添加列
            
            dtmx.Columns.Add("rgn_code", typeof(string)); //区划编码
            dtmx.Columns.Add("rgn_name", typeof(string)); //区划名称
            dtmx.Columns.Add("agen_code", typeof(string)); //单位编码
            dtmx.Columns.Add("agen_name", typeof(string)); //单位名称
            dtmx.Columns.Add("place_code", typeof(string)); //开票点编码
            dtmx.Columns.Add("place_name", typeof(string)); //开票点名称
            dtmx.Columns.Add("payer", typeof(string)); //缴款人/单位
            dtmx.Columns.Add("payer_tel", typeof(string)); //电话号码
            dtmx.Columns.Add("date", typeof(string)); //开票日期
            dtmx.Columns.Add("author", typeof(string)); //开票人
            dtmx.Columns.Add("payer_type", typeof(string)); //缴款人类型
            dtmx.Columns.Add("payer_type_name", typeof(string)); //缴款人类型名
            dtmx.Columns.Add("credit_code", typeof(string)); //交款单位组织机构代码
            dtmx.Columns.Add("bill_code", typeof(string)); //票据种类编码
            dtmx.Columns.Add("bill_name", typeof(string)); //票据种类名称
            dtmx.Columns.Add("bill_batch_code", typeof(string)); //票据代码
            dtmx.Columns.Add("bill_no", typeof(string)); //票据号码
            dtmx.Columns.Add("random", typeof(string)); //校验码
            dtmx.Columns.Add("total_amt", typeof(string)); //合计金额
            dtmx.Columns.Add("rec_mode_name", typeof(string)); //收款方式
            dtmx.Columns.Add("state", typeof(string)); //状态：1正常，2作废
            dtmx.Columns.Add("pj_fph", typeof(string)); //发票号
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    foreach (DataRow r in dt.Rows)
                    {
                        serial_number = r["发票号"].ToString();
                        message = "{\"message\":{\"serial_number\":\"" + serial_number + "\"}}";
                        string json = String.Empty;
                        try
                        {
                            json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                            var j = Tools.FromJson(json);
                            if (json.IndexOf("error_message") > -1)
                            {
                                if (j.error_message.error_msg.IndexOf("找不到对应票据") > -1)
                                {
                                    SqlHelp.ExecuteNonQuery("update ptjk_fpsc set del=1 where serial_number=@fph", new SqlParameter("@fph", serial_number));
                                }                                
                            }
                            else
                            {
                                var ms = j.message;
                                DataRow dr2 = dtmx.NewRow();
                                dr2[0] = ms.rgn_code;
                                dr2[1] = ms.rgn_name;
                                dr2[2] = ms.agen_code;
                                dr2[3] = ms.agen_name;
                                dr2[4] = ms.place_code;
                                dr2[5] = ms.place_name;
                                dr2[6] = ms.payer;
                                dr2[7] = ms.payer_tel;
                                dr2[8] = ms.date;
                                dr2[9] = ms.author;
                                dr2[10] = ms.payer_type;
                                dr2[11] = ms.payer_type_name;
                                dr2[12] = ms.credit_code;
                                dr2[13] = ms.bill_code;
                                dr2[14] = ms.bill_name;
                                dr2[15] = ms.bill_batch_code;
                                dr2[16] = ms.bill_no;
                                dr2[17] = ms.random;
                                dr2[18] = ms.total_amt;
                                dr2[19] = ms.rec_mode_name;
                                if (ms.state=="1")
                                {
                                    dr2[20] = "正常";
                                }
                                else if (ms.state == "2")
                                {
                                    dr2[20] = "作废";
                                }
                                dr2[21] = serial_number;
                                dtmx.Rows.Add(dr2);
                                
                               
                                SqlHelp.ExecuteNonQuery("update ptjk_fpsc set del=0 where del=1 and serial_number=@fph", new SqlParameter("@fph", serial_number));
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dtmx;

            string ls_fph;
            ls_fph = txt_fph.Text.Trim();
            getKpxxsearch(ls_fph);
        }

        private void txt_fph_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string ls_fph;
                ls_fph = txt_fph.Text.Trim();
                getKpxx(ls_fph);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
