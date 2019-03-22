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
    public partial class frmlyxx : Form
    {
        public frmlyxx()
        {
            InitializeComponent();
        }

        public DataTable getBills(string code)
        {
            string ls_sql = "select date 日期,bill_code 票据种类编码,bill_name 票据种类名称,bill_batch_code as 票据代码,bgn_no as 起始号,end_no as 终止号 from pjjk_fply";
            if (!String.IsNullOrEmpty(code))
            {
                ls_sql = ls_sql + " where bill_code='" + code + "'";
            }
            DataTable dt = SqlHelp.HisTable(ls_sql);
            return dt;
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void frmkpd_Load(object sender, EventArgs e)
        {
            DataTable dtmx = getBills("");
            if (dtmx != null)
            {
                dataGridView1.DataSource = dtmx;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string method = "stock.outs.get";
            string place_code = txt_bm.Text.Trim();
            string qssj = date_qssj.Text;
            string zzsj = date_zzsj.Text;
            this.Cursor = Cursors.WaitCursor;
            string message = "{\"message\":{\"place_code\":\"\",\"bgn_date\":\""+qssj+"\",\"end_date\":\""+zzsj+"\"}}";
            string json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
            Tools.WriteLog("获取票据领用信息列表", json);
                var j = Tools.FromJson(json);
                
                if (json.IndexOf("error_message") == -1)
                {
                    try
                    {
                        var ms = j.message;
                        List<Fply> list = new List<Fply>();
                        var bill = ms.stock_outs;
                        foreach (var pn in bill)
                        {
                            Fply fply = new Fply();
                            foreach (var item in pn)
                            {
                                if (item.Key == "date")
                                {
                                    fply.date = item.Value;
                                }
                                if (item.Key == "bill_code")
                                {
                                    fply.bill_code = item.Value;
                                }
                                if (item.Key == "bill_name")
                                {
                                    fply.bill_name = item.Value;
                                }
                                if (item.Key == "bill_batch_code")
                                {
                                    fply.bill_batch_code = item.Value;
                                }
                                if (item.Key == "bgn_no")
                                {
                                    fply.bgn_no = item.Value;
                                }
                                if (item.Key == "end_no")
                                {
                                    fply.end_no = item.Value;
                                }
                            }
                            list.Add(fply);
                        }
                        DataTable dt = Tools.ListToDataTable(list);

                        string i = "0";
                        string code = "";
                        string ls_sql = "select count(*) from pjjk_fply where bill_code=@code";
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            return;
                        }
                        foreach (DataRow r in dt.Rows)
                        {
                            code = r["bill_code"].ToString();
                            i = SqlHelp.ExecuteScalar(ls_sql, new SqlParameter("@code", code));
                            if (Convert.ToInt32(i) == 0)
                            {
                                if (Convert.ToInt32(i) == 0)
                                {
                                    SqlParameter Pdate = new SqlParameter("@date", r["date"].ToString());
                                    SqlParameter Pcode = new SqlParameter("@bill_code", r["bill_code"].ToString());
                                    SqlParameter Pname = new SqlParameter("@bill_name", r["bill_name"].ToString());
                                    SqlParameter Pbatchcode = new SqlParameter("@bill_batch_code", r["bill_batch_code"].ToString());
                                    SqlParameter Pbgnno = new SqlParameter("@bgn_no", r["bgn_no"].ToString());
                                    SqlParameter Pendno = new SqlParameter("@end_no", r["end_no"].ToString());
                                    SqlHelp.ExecuteNonQuery("insert into pjjk_fply(date,bill_code,bill_name,bill_batch_code,bgn_no,end_no) values(@date,@bill_code,@bill_name,@bill_batch_code,@bgn_no,@end_no)",
                                                             Pdate,
                                                             Pcode,
                                                             Pname,
                                                             Pbatchcode,
                                                             Pbgnno,
                                                             Pendno
                                                            );

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    DataTable dtmx = getBills("");
                    if (dtmx != null)
                    {
                        dataGridView1.DataSource = dtmx;
                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("已完成");
                }
                else
                {
                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    ErrorJson jd = jsSerializer.Deserialize<ErrorJson>(json);
                    string msg = jd.error_message.error_msg.ToString();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(msg);
                }
                this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
