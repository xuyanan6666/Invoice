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
    public partial class FrmFymc : Form
    {
        public FrmFymc()
        {
            InitializeComponent();
        }


        DataTable dt = new DataTable();
        public DataTable getBills(string code)
        {
            string ls_sql = "select item_code 项目编码,item_name 项目名称 from pjjk_items";
            if (!String.IsNullOrEmpty(code))
            {
                ls_sql = ls_sql + " where item_code='" + code + "'";
            }
            dt = SqlHelp.HisTable(ls_sql);
            return dt;
        }


        private void FrmFymc_Load(object sender, EventArgs e)
        {
            dataGridView1.VirtualMode = true;
            dataGridView1.DataSource = null;
            DataTable dt =  getBills("");
            dataGridView1.DataSource = dt;
        }

        private void toolStripLabel2_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string method = "basic.items.get";
            string place_code = txt_bm.Text.Trim();
            string message = "{\"message\":{\"place_code\":\"\"}}";
            string json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
            try
            {
                var j = Tools.FromJson(json);
                var ms = j.message;
                List<Items> list = new List<Items>();
                var bill = ms.items;
                foreach (var pn in bill)
                {
                    Items items = new Items();
                    foreach (var item in pn)
                    {
                        if (item.Key == "item_code")
                        {
                            items.item_code = item.Value;
                        }
                        if (item.Key == "item_name")
                        {
                            items.item_name = item.Value;
                        }
                    }
                    list.Add(items);
                }
                DataTable dtmx = Tools.ListToDataTable(list);

                string i = "0";
                string code = "";
                string ls_sql = "select count(*) from pjjk_items where item_code=@code";
                if (dtmx == null || dtmx.Rows.Count == 0)
                {
                    return;
                }
                foreach (DataRow r in dtmx.Rows)
                {
                    code = r["item_code"].ToString();
                    i = SqlHelp.ExecuteScalar(ls_sql,new SqlParameter("@code",code));
                    if (Convert.ToInt32(i) == 0)
                    {
                        if (Convert.ToInt32(i) == 0)
                        {
                            SqlParameter Pcode = new SqlParameter("item_code", r["item_code"].ToString());
                            SqlParameter Pname = new SqlParameter("item_name", r["item_name"].ToString());
                            SqlHelp.ExecuteNonQuery("insert into pjjk_items(item_code,item_name) values(@item_code,@item_name)",
                                                     Pcode,
                                                     Pname
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
            
            dt = getBills("");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("已完成");
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex == dt.Rows.Count)
                return;
            e.Value = dt.Rows[e.RowIndex][e.ColumnIndex].ToString();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
