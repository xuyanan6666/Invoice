﻿using System;
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
    public partial class frmkjpjzybatch : Form
    {
        public frmkjpjzybatch()
        {
            InitializeComponent();
        }
      
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
        }

        DataTable dt = new DataTable();
       
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
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex == dt.Rows.Count)
                return;
            e.Value = dt.Rows[e.RowIndex][e.ColumnIndex].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getTjxx();
        }

        public void getTjxx()
        {
            string ls_qssj = qssj.Text;
            string ls_zzsj = zzsj.Text;
            dt = SqlHelp.ProcTable("pjjk_kjzyfp", new SqlParameter("@qssj", ls_qssj), new SqlParameter("@zzsj", ls_zzsj));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string method = "invoice.batch.issue.do";
            string place_code = "";
            if (comboBox1.SelectedIndex > -1)
            {
                place_code = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
            }
            this.Cursor = Cursors.WaitCursor;
            string message = "";
            string jgdm = SqlHelp.ExecuteScalar("select cfgvalue from jk_cfg where cfgname='组织机构代码'");
            DataTable dtmx = (DataTable)dataGridView1.DataSource;
            if(dtmx!=null)
            {
                if(dtmx.Rows.Count>0)
                {
                    #region 开始循环
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{\"message\": {");
                    sb.Append("\"batch_no\": \"" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "\",");
                  //  sb.Append("\"tickets\": ");
                    sb.Append("\"tickets\": [");
                    foreach (DataRow r in dtmx.Rows)
                    {

                        sb.Append("{\"serial_number\": \"" + r["zyid"].ToString().Trim() + "\",");//业务流水号，不能重复
                        sb.Append("\"place_code\": \"" + place_code + "\",");//开票点编码
                        sb.Append("\"payer\": \"" + r["blczy"].ToString().Trim() + "\",");//缴款人/单位
                        sb.Append("\"payer_tel\":\"\",");//缴款人手机号或电话号码
                        sb.Append("\"date\": \"" + DateTime.Parse(r["blsj"].ToString()).ToString("yyyy-MM-dd") + "\",");
                        sb.Append("\"author\": \"" + r["kpr"].ToString().Trim() + "\",");//开票人
                        sb.Append("\"payer_type\": \"" + 2 + "\",");//缴款人类型：1 个人 2 单位
                        sb.Append("\"credit_code\": \""+jgdm+"\",");//组织机构代码                        
                        sb.Append("\"bill_code\":\"" + r["bill_code"].ToString().Trim() + "\",");//票据种类编码
                        sb.Append("\"bill_batch_code\":\"" + r["bill_batch_code"].ToString().Trim() + "\",");//票据批次号
                        sb.Append("\"bill_no\":\"" + r["bill_no"].ToString().Trim() + "\",");//票据号码
                        sb.Append("\"total_amt\":\"" + r["zhf"].ToString().Trim() + "\",");
                        sb.Append("\"rec_mode\": \"" + 1 + "\",");//收款方式:1现金,2转账,3其它
                        sb.Append("\"memo\": \"\",");//备注
                        sb.Append("\"print_info\":null,");//打印域
                        sb.Append("\"notice_infos\":[],");
                        sb.Append("\"assist_infos\":[");
                      /*  DataTable mx = Getfpmx(r["zyid"].ToString().Trim());
                        if (mx != null && mx.Rows.Count > 0)
                        {
                            foreach (DataRow rmc in mx.Rows)
                            {
                                sb.Append("{");
                                sb.Append("\"name\":\""+rmc["fymc"].ToString().Trim()+"\",");
                                sb.Append("\"price\":\"" + rmc["dj"].ToString() + "\",");
                                sb.Append("\"number\":\"" + rmc["sl"].ToString() + "\",");
                                sb.Append("\"amt\":\"" + rmc["je"].ToString() + "\",");
                                sb.Append("\"extend_infos\": []");
                                sb.Append("},");
                            }
                            sb.Remove(sb.Length - 1, 1);
                        }*/
                        sb.Append("],");
                        sb.Append("\"extend_infos\": [],");
                        sb.Append("\"item_details\": [");
                        DataTable dl = Getfpdl(r["zyid"].ToString().Trim());
                        if (dl != null && dl.Rows.Count > 0)
                        {
                            foreach (DataRow rr in dl.Rows)
                            {
                                sb.Append("{");
                                sb.Append("\"item_code\": \"" + rr["fybm"].ToString().Trim() + "\",");
                                sb.Append("\"unit\": \"a\",");
                                sb.Append("\"std\": \"" + rr["je"].ToString() + "\",");
                                sb.Append("\"number\": \"1\",");
                                sb.Append("\"amt\": \"" + rr["je"].ToString() + "\",");
                                sb.Append("\"extend_infos\":[]");                               
                                sb.Append("},");
                            }
                            sb.Remove(sb.Length - 1,1);
                        }
                        sb.Append("]");
                        sb.Append("},");   
                    }
                    #endregion
                    sb.Remove(sb.Length - 1, 1);
                    //sb.Append("}");
                    sb.Append("]}}");
                    message = sb.ToString();
                    Tools.WriteLog("住院批次开具票据入参",message);
                    string json = String.Empty;
                    try
                    {
                        json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                        Tools.WriteLog("住院批次开具票据出参", json);
                        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                        if (json.IndexOf("error_message") == -1)
                        {
                            //KjfpJson jd = jsSerializer.Deserialize<KjfpJson>(json);
                            foreach (DataRow r in dtmx.Rows)
                            {
                                SqlParameter fpzl = new SqlParameter("@fpzl", "出院发票");
                                SqlParameter batchcode = new SqlParameter("@bill_batch_code", r["bill_batch_code"].ToString());
                                SqlParameter billno = new SqlParameter("@bill_no", r["bill_no"].ToString());
                                SqlParameter serialnumber = new SqlParameter("@serial_number", r["zyid"].ToString());
                                SqlParameter random = new SqlParameter("@random", "");
                                SqlParameter createtime = new SqlParameter("@create_time",DateTime.Now.ToString("yyyyMMddHHmmssfff") );
                                string ls_sql = "insert into ptjk_fpsc(fpzl,bill_batch_code,bill_no,serial_number,random,create_time) values(@fpzl,@bill_batch_code,@bill_no,@serial_number,@random,@create_time)";
                                SqlHelp.ExecuteNonQuery(ls_sql, fpzl, batchcode, billno, serialnumber, random, createtime);
                            }
                            
                        }
                        else
                        {
                            ErrorJson jd = jsSerializer.Deserialize<ErrorJson>(json);
                            string msg = jd.error_message.error_msg.ToString();
                            MessageBox.Show(msg);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    MessageBox.Show("传入完成");
                    getTjxx();
                    this.Cursor = Cursors.Default;
                }
            }
            
           
             
        }

        public DataTable Getfpmx(string fph)
        {
            DataTable mx = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 20 b.fyid,b.fymc,b.dw,a.dj,a.sl,a.zfje je from v_zy_brjz a,dm_zysfxm b where  a.fyid=b.fyid and a.zyid=@fph and cfh is null");
            sb.Append(" union all ");
            sb.Append("select c.ypid,c.ypmc,c.xsdw,b.dj,b.sl,b.zfje from v_zy_brjz a,v_zy_brcf b,dm_yd c where a.zyid=b.zyid and a.cfh=b.cfh and b.ypid=c.ypid and a.zyid=@fph");
            mx = SqlHelp.HisTable(sb.ToString(), new SqlParameter("@fph", fph));
            return mx;
        }

        public DataTable Getfpdl(string fph)
        {
            DataTable mx = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 20 d.ptbm as fybm,c.fymc as fydl,sum(a.zfje) je from v_zy_brjz a,dm_zysfxm b,dm_zysfxm c,ptjk_dm d where a.tfsj is null and c.fybm=d.hisbm and left(b.fybm,4)=c.fybm and len(c.fybm)=4 and a.fyid=b.fyid and a.zyid=@fph and cfh is null and d.bz='住院' group by d.ptbm,c.fymc");
            sb.Append(" union all ");
            sb.Append("select e.ptbm as fybm,d.fymc as fydl,sum(a.zfje) as je from v_zy_brjz a,dm_zysfxm d,ptjk_dm e where a.tfsj is null and  d.fybm=e.hisbm and  a.cfh is not null and a.fyid=d.fyid and e.bz='住院' and a.zyid=@fph group by e.ptbm,d.fymc");
            mx = SqlHelp.HisTable(sb.ToString(), new SqlParameter("@fph", fph));
            return mx;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
