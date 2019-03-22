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
    public partial class frmkpxxsearch : Form
    {
        public frmkpxxsearch()
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
            string ls_sql = "select  serial_number 发票号,fpzl,bill_batch_code,bill_no from ptjk_fpsc ";
            if (!String.IsNullOrEmpty(fph))
            {
                ls_sql = ls_sql + " where serial_number='MP'+dbo.padl(" + fph + ",8)";
            }
            DataTable dt = SqlHelp.HisTable(ls_sql);
            dataGridView1.DataSource = dt; 
        }

        private void getKpxxsearch(string fph)
        {
            string ls_sql = "select  serial_number 发票号,fpzl,bill_batch_code,bill_no,case when del=1 then '未上传成功' else '成功上传' end as 备注 from ptjk_fpsc ";
            if (!String.IsNullOrEmpty(fph))
            {
                ls_sql = ls_sql + " where serial_number='MP'+dbo.padl(" + fph + ",8)";
            }
            DataTable dt = SqlHelp.HisTable(ls_sql);
            dataGridView1.DataSource = dt;
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            string method = "invoice.get";
            string serial_number = "";
            string message = "";
            int ls_i = 0;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            List<Kjfp> list = new List<Kjfp>();
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
                                if (j.error_message.error_msg == "找不到对应票据")
                                {
                                    ls_i = ls_i + 1;
                                    SqlHelp.ExecuteNonQuery("update ptjk_fpsc set del=1 where serial_number=@fph", new SqlParameter("@fph", serial_number));
                                }                                
                            }
                            else
                            {
                                var ms = j.message;
                                Kjfp kjfp = new Kjfp();
                                kjfp.bill_name = ms.bill_name;
                                kjfp.bill_batch_code = ms.bill_batch_code;
                                kjfp.bill_no = ms.bill_no;
                                kjfp.create_time = ms.create_time;
                                string state = ms.state;
                                kjfp.serial_number = serial_number;
                                if (state == "1")
                                {
                                    kjfp.state = "正常";
                                }
                                else
                                {
                                    kjfp.state = "作废";
                                }
                                kjfp.date = ms.date;
                                list.Add(kjfp);
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
            DataTable dtmx = Tools.ListToDataTable(list);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dtmx;
            if (ls_i > 0)
            {
                MessageBox.Show("有未上传成功的发票请在开具功能中重新上传发票！");
            }
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
