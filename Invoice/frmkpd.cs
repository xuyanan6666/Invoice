using Invoice.Mode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Invoice
{
    public partial class frmkpd : Form
    {
        public frmkpd()
        {
            InitializeComponent();
        }

        public DataTable getBills(string code)
        {
            string ls_sql = "select place_code 开票点编码,place_name 开票点名称 from pjjk_place";
            if (!String.IsNullOrEmpty(code))
            {
                ls_sql = ls_sql + " where place_code='" + code + "'";
            }
            DataTable dt = SqlHelp.HisTable(ls_sql);
            return dt;
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            string method = "basic.places.get";
            string place_code = txt_bm.Text.Trim();
            string message = "{\"message\":{\"place_code\":\"\"}}";
            this.Cursor = Cursors.WaitCursor;
            string json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
            try
            {
                var j = Tools.FromJson(json);
                var ms = j.message;
                List<Places> list = new List<Places>();
                var bill = ms.places;
                foreach (var pn in bill)
                {
                    Places places = new Places();
                    foreach (var item in pn)
                    {
                        if (item.Key == "place_code")
                        {
                            places.place_code = item.Value;
                        }
                        if (item.Key == "place_name")
                        {
                            places.place_name = item.Value;
                        }
                    }
                    list.Add(places);
                }
                DataTable dt = Tools.ListToDataTable(list);

                string i = "0";
                string code = "";
                string ls_sql = "select count(*) from pjjk_place where place_code=@code";
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }
                foreach (DataRow r in dt.Rows)
                {
                    code = r["place_code"].ToString();
                    i = SqlHelp.ExecuteScalar(ls_sql, new SqlParameter("@code", code));
                    if (Convert.ToInt32(i) == 0)
                    {
                        if (Convert.ToInt32(i) == 0)
                        {
                            SqlParameter Pcode = new SqlParameter("place_code", r["place_code"].ToString());
                            SqlParameter Pname = new SqlParameter("place_name", r["place_name"].ToString());
                            SqlHelp.ExecuteNonQuery("insert into pjjk_place(place_code,place_name) values(@place_code,@place_name)",
                                                     Pcode,
                                                     Pname
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
            DataTable dtmx = getBills("");
            if (dtmx != null)
            {
                dataGridView1.DataSource = dtmx;
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("已完成");
        }

        private void frmkpd_Load(object sender, EventArgs e)
        {
            DataTable dtmx = getBills("");
            if (dtmx != null)
            {
                dataGridView1.DataSource = dtmx;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
