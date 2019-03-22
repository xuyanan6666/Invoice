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
    public partial class frmkpxxbatchsearch : Form
    {
        public frmkpxxbatchsearch()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            string ls_batch;
            ls_batch = combox_ph.Text.Trim();
            getKpxx(ls_batch);
        }

        private void getKpxx(string ls_batch)
        {
            string ls_sql = "select  batch 批次,serial_number 发票号,fpzl,bill_no from ptjk_fpsc ";
            if (!String.IsNullOrEmpty(ls_batch))
            {
                ls_sql = ls_sql + " where batch='" + ls_batch + "'";
            }
            else
            {
                ls_sql = ls_sql + " where batch is not null";
            }
            DataTable dt = SqlHelp.HisTable(ls_sql);
            dataGridView1.DataSource = dt; 
        }

        private void getKpxxsearch(string ls_batch)
        {
            string ls_sql = "select  batch 批次,serial_number 发票号,fpzl,bill_no,case when del=1 then '未上传成功' else '成功上传' end as 备注 from ptjk_fpsc ";
            if (!String.IsNullOrEmpty(ls_batch))
            {
                ls_sql = ls_sql + " where batch is not null and batch='" + ls_batch + "'";
            }
            else
            {
                ls_sql = ls_sql + " where batch is not null";
            }
            DataTable dt = SqlHelp.HisTable(ls_sql);
            dataGridView1.DataSource = dt;
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            string method = "invoice.batch.get";
            string batch = "";
            string message = "";
            string serial_number = "";
            int ls_i = 0;
            batch = combox_ph.Text.Trim();
            if (String.IsNullOrEmpty(batch))
            {
                MessageBox.Show("必须选择批次");
                return;
            }
            
            this.Cursor = Cursors.WaitCursor;
            List<BatchKpxx> dic = new List<BatchKpxx>();
            message = "{\"message\":{\"batch_no\":\"" + batch + "\"}}";
            string json = String.Empty;
            try
            {
                json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                var j = Tools.FromJson(json);
                if (json.IndexOf("error_message") > -1)
                {
                    MessageBox.Show(j.error_message.error_msg);
                    return;                              
                }
                else
                {
                    
                    var ms = j.message.tickets;
                    foreach (var pn in ms)
                    {
                        BatchKpxx kpxx = new BatchKpxx();
                        foreach (var item in pn)
                        {
                            if (item.Key == "serial_number")
                            {
                                serial_number = item.Value;
                                if (!String.IsNullOrEmpty(serial_number))
                                {
                                    kpxx.serial_number = serial_number;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (item.Key == "status")
                            {
                                if (item.Value == "0")
                                {
                                    kpxx.state = "失败" ;
                                    SqlHelp.ExecuteNonQuery("update ptjk_fpsc set del=1 where  serial_number=@fph", new SqlParameter("@fph", serial_number));
                                }
                                else
                                {
                                    kpxx.state = "成功";
                                    SqlHelp.ExecuteNonQuery("update ptjk_fpsc set del=0 where del=1 and serial_number=@fph", new SqlParameter("@fph", serial_number));
                                }                                
                            }
                        }
                        dic.Add(kpxx);
                    }
                    
                   
                }
                            
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
                    

            this.Cursor = Cursors.Default;
            DataTable dtmx = Tools.ListToDataTable(dic);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dtmx;
            if (ls_i > 0)
            {
                MessageBox.Show("有未上传成功的发票请重新上传！");
            }
            string ls_fph;
            ls_fph = combox_ph.Text.Trim();
            getKpxxsearch(ls_fph);
        }

        private void txt_fph_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string ls_fph;
                ls_fph = combox_ph.Text.Trim();
                getKpxx(ls_fph);
            }
        }

        private void frmkpxxbatchsearch_Load(object sender, EventArgs e)
        {
            string ls_sql = "select distinct batch from ptjk_fpsc where batch is not null order by batch desc";
            DataTable dt = SqlHelp.HisTable(ls_sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        combox_ph.Items.Add(r["batch"].ToString());
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
