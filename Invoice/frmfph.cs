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
    public partial class frmfph : Form
    {
        public frmfph()
        {
            InitializeComponent();
        }

       


        private void frmkpd_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label4.Visible = false;
            txt_fpdm.Visible = false;
            txt_fph.Visible = false;

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
            //加载领用发票列表
            load_fply();
        }
        #region 统计发票领用明细
        private void load_fply()
        {
            DataTable dt = SqlHelp.HisTable("select bill_name,bill_batch_code from pjjk_fply ");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            string method = "stock.billno.get";
            string placecode = "";
            if(comboBox1.SelectedIndex>=0)
            {
                ComboboxItem item1 = comboBox1.SelectedItem as ComboboxItem;
                placecode = item1.Value.ToString();
            }
            if (String.IsNullOrEmpty(placecode))
            {
                MessageBox.Show("开票点不能为空");
                return;
            }
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("请选择发票种类");
                return;
            }
            string com2 = comboBox2.SelectedItem.ToString();
            string billcode = com2.Substring(com2.IndexOf("--"));
            com2 = com2.Substring(com2.IndexOf("--")+2);
            com2 = com2.Substring(com2.IndexOf("--")+2);
            string batchcode = com2;
            if(String.IsNullOrEmpty(batchcode))
            {
                MessageBox.Show("票据代码不能为空");
                return;
            }


            string message = "{\"message\":{\"place_code\":\"" + placecode + "\",\"bill_code\":\""+billcode+"\",\"bill_batch_code\":\"" + batchcode + "\"}}";

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
                FplyJson jd = jsSerializer.Deserialize<FplyJson>(json);
                string code = jd.message.bill_batch_code;
                string name = jd.message.bill_no;
                txt_fpdm.Text = code;
                txt_fph.Text = name;
                label2.Visible = true;
                label4.Visible = true;
                txt_fpdm.Visible = true;
                txt_fph.Visible = true;
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

        private void button3_Click(object sender, EventArgs e)
        {

            string method = "stock.billno.get";
            string placecode = "";
            string message;
            string bill_name;
            string bill_batch_code;
            if (comboBox1.SelectedIndex >= 0)
            {
                ComboboxItem item1 = comboBox1.SelectedItem as ComboboxItem;
                placecode = item1.Value.ToString();
            }
            if (String.IsNullOrEmpty(placecode))
            {
                MessageBox.Show("开票点不能为空");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if(dt!=null)
            {
                if(dt.Rows.Count>0)
                {
                    DataTable dtmx = new DataTable();
                    dtmx.Columns.Add("bill_name", typeof(string));
                    dtmx.Columns.Add("bill_batch_code", typeof(string));
                    dtmx.Columns.Add("bill_no", typeof(string));
                    foreach(DataRow r in dt.Rows)
                    {
                        bill_name = r["bill_name"].ToString();
                        bill_batch_code = r["bill_batch_code"].ToString();
                        DataRow d = dtmx.NewRow();
                        d[0] = bill_name;
                        d[1] = bill_batch_code;
                        message = "{\"message\":{\"place_code\":\"" + placecode + "\",\"bill_batch_code\":\"" + bill_batch_code + "\"}}";

                        string json = String.Empty;
                        try
                        {
                            json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            this.Cursor = Cursors.Default;
                            return;
                        }

                        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                        if (json.IndexOf("error_message") == -1)
                        {
                            FplyJson jd = jsSerializer.Deserialize<FplyJson>(json);
                            d[2] = jd.message.bill_no;
                            dtmx.Rows.Add(d);
                        }
                        else
                        {
                            JavaScriptSerializer Serializer = new JavaScriptSerializer();
                            ErrorJson jd2 = Serializer.Deserialize<ErrorJson>(json);
                            string msg2 = jd2.error_message.error_msg.ToString();
                            MessageBox.Show(msg2);
                        }
                    }
                    dataGridView1.DataSource = dtmx;
                    this.Cursor = Cursors.Default;
                }

            }



            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
