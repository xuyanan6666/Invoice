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
    public partial class frmfpht : Form
    {
        public frmfpht()
        {
            InitializeComponent();
        }

        public DataTable getBills(string code,string qssj,string zzsj)
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
            string method = "stock.return.do";
            string placecode = String.Empty;
            if(comboBox1.SelectedIndex>-1)
            {
                placecode = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
            }            
            string lry = txt_lyr.Text;
            if(String.IsNullOrEmpty(lry))
            {
                MessageBox.Show("领用人不能为空");
                return;
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
            string yy = txt_yy.Text.Trim();
            string fpfs = txt_fpfs.Text.Trim();
            string qsh = txt_qsh.Text.Trim();
            string zzh = txt_zzh.Text.Trim();
            if(String.IsNullOrEmpty(fpfs) || String.IsNullOrEmpty(qsh) || String.IsNullOrEmpty(zzh))
            {
                MessageBox.Show("发票分数、起始号、终止号不能为空");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            string message = "{\"message\":{\"place_code\":\"" + placecode + "\",\"returner\":\"" + lry + "\",\"return_reason\":\""+yy+"\""
                             + ",\"bill_details\":[{\"bill_code\":\"" + billcode + "\",\"bill_batch_code\":\"" + batchcode + "\",\"copy_num\":\"" + fpfs + "\",\"bgn_no\":\"" + qsh + "\",\"end_no\":\""+zzh+"\"}]}}";
            string json = String.Empty;
            try
            {
                json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
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
                    /*
                      string sj = DateTime.Now.ToString("yyyy-MM-dd");
                      message = "{\"message\":{\"place_code\":\""+placecode+"\",\"bgn_date\":\"" + sj + "\",\"end_date\":\"" + sj + "\"}}";
                      json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                      var j = Tools.FromJson(json);
                      DataTable dtmx = null;
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
                              dtmx = Tools.ListToDataTable(list);

                              string i = "0";
                              string code = "";
                              string ls_sql = "select count(*) from pjjk_fply where bill_code=@code";
                              if (dtmx == null || dtmx.Rows.Count == 0)
                              {
                                  return;
                              }
                              foreach (DataRow r in dtmx.Rows)
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
                              MessageBox.Show(ex.Message);
                          }
                     
                          if (dtmx != null)
                          {
                              dataGridView1.DataSource = dtmx;
                          }
                      }
                      else
                      {
                          JavaScriptSerializer Serializer = new JavaScriptSerializer();
                          ErrorJson jd2 = Serializer.Deserialize<ErrorJson>(json);
                          string msg2 = jd2.error_message.error_msg.ToString();
                          MessageBox.Show(msg);
                      }
                      */
                }
            }
            else
            {
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                ErrorJson jd2 = Serializer.Deserialize<ErrorJson>(json);
                string msg2 = jd2.error_message.error_msg.ToString();
                MessageBox.Show(msg2);
            }
            this.Cursor = Cursors.Default; 
               
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
