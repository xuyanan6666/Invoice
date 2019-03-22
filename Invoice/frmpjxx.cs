using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Invoice.Mode;
using System.Data.SqlClient;
using System.Dynamic;
using System.Web.Script.Serialization;

namespace Invoice
{
    public partial class frmpjxx : Form
    {
        public frmpjxx()
        {
            InitializeComponent();
        }
      
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
        }
        DataTable dt = new DataTable();
        public DataTable getBills(string code)
        {
            string ls_sql = "select bill_code 票据种类编码,bill_name 票据种类名称,bill_batch_code 票据代码,case when type=1 then '电子开票' when type=2 then '机打开票' when type=3 then '手工开票' end as 类型 from pjjk_bill";
            if(!String.IsNullOrEmpty(code))
            {
                ls_sql = ls_sql + " where bill_code='" + code + "'";
            }
            dt = SqlHelp.HisTable(ls_sql);
            return dt;
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {


        }

        private void frmpjxx_Load(object sender, EventArgs e)
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

            dataGridView1.VirtualMode = true;
            DataTable dt = getBills("");
            if(dt!=null)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex == dt.Rows.Count)
                return;
            e.Value = dt.Rows[e.RowIndex][e.ColumnIndex].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string method = "basic.bills.get";
            string place_code = "";
            if(comboBox1.SelectedIndex>-1)
            {
                place_code = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
            }
            this.Cursor = Cursors.WaitCursor;
            string message = "{\"message\":{\"place_code\":\"\"}}";
            string json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
            try
            {
                var j = Tools.FromJson(json);
                var ms = j.message;
                List<Bills> list = new List<Bills>();
                var bill = ms.bills;
                foreach (var pn in bill)
                {
                    Bills bills = new Bills();
                    foreach (var item in pn)
                    {
                        if (item.Key == "bill_code")
                        {
                            bills.bill_code = item.Value;
                        }
                        if (item.Key == "bill_batch_code")
                        {
                            bills.bill_batch_code = item.Value;
                        }
                        if (item.Key == "bill_name")
                        {
                            bills.bill_name = item.Value;
                        }
                        if (item.Key == "type")
                        {
                            bills.type = item.Value;
                        }
                    }
                    list.Add(bills);
                }
                DataTable dtmx = Tools.ListToDataTable(list);

                string i = "0";
                string code = "";
                string ls_sql = "select count(*) from pjjk_bill where bill_code=@code";
                if (dt == null || dtmx.Rows.Count == 0)
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
                            SqlParameter Pcode = new SqlParameter("bill_code", r["bill_code"].ToString());
                            SqlParameter Pname = new SqlParameter("bill_name", r["bill_name"].ToString());
                            SqlParameter Pbatcode = new SqlParameter("bill_batch_code", r["bill_batch_code"].ToString());
                            SqlParameter Ptype = new SqlParameter("type", r["type"].ToString());
                            SqlHelp.ExecuteNonQuery("insert into pjjk_bill(bill_code,bill_name,bill_batch_code,type) values(@bill_code,@bill_name,@bill_batch_code,@type)",
                                                     Pcode,
                                                     Pname,
                                                     Pbatcode,
                                                     Ptype
                                                    );

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
                return;
            }
            this.Cursor = Cursors.Default;
            dt = getBills("");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
