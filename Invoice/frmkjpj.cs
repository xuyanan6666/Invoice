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
    public partial class frmkjpj : Form
    {
        public frmkjpj()
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
            selMzpj();
        }
        public void selMzpj() 
        {
            string ls_qssj = qssj.Text;
            string ls_zzsj = zzsj.Text;
            dt = SqlHelp.ProcTable("pjjk_kjmzfp", new SqlParameter("@qssj", ls_qssj), new SqlParameter("@zzsj", ls_zzsj));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }
        //开具门诊票据
        public void kj_Mzpj()
        {
            string ls_qssj = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") ;
            string ls_zzsj = ls_qssj;
            dt = SqlHelp.ProcTable("pjjk_kjmzfp", new SqlParameter("@qssj", ls_qssj), new SqlParameter("@zzsj", ls_zzsj));
            this.Cursor = Cursors.WaitCursor;
            string method = "invoice.issue.do";
            string message = "";
            string jgdm = SqlHelp.ExecuteScalar("select cfgvalue from jk_cfg where cfgname='组织机构代码'");
       
                if (dt.Rows.Count > 0)
                {
                    #region 开始循环
                    foreach (DataRow r in dt.Rows)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("{\"message\": {");
                        sb.Append("\"serial_number\": \"" + r["fph"].ToString().Trim() + "\",");//业务流水号，不能重复
                        sb.Append("\"place_code\": \"" + r["place_code"].ToString().Trim() + "\",");//开票点编码
                        sb.Append("\"payer\": \"" + r["blczy"].ToString().Trim() + "\",");//缴款人/单位
                        sb.Append("\"payer_tel\":\"\",");//缴款人手机号或电话号码
                        sb.Append("\"date\": \"" + DateTime.Parse(r["blsj"].ToString()).ToString("yyyy-MM-dd") + "\",");
                        sb.Append("\"author\": \"" + r["kpr"].ToString().Trim() + "\",");//开票人
                        sb.Append("\"payer_type\": \"" + 2 + "\",");//缴款人类型：1 个人 2 单位
                        sb.Append("\"credit_code\": \"" + jgdm + "\",");//组织机构代码                        
                        sb.Append("\"bill_code\":\"" + r["bill_code"].ToString().Trim() + "\",");//票据种类编码
                        sb.Append("\"bill_batch_code\":\"" + r["bill_batch_code"].ToString().Trim() + "\",");//票据批次号
                        sb.Append("\"bill_no\":\"" + r["bill_no"].ToString().Trim() + "\",");//票据号
                        sb.Append("\"total_amt\":\"" + r["je"].ToString().Trim() + "\",");
                        sb.Append("\"rec_mode\": \"" + 1 + "\",");//收款方式:1现金,2转账,3其它
                        sb.Append("\"memo\": \"\",");//备注
                        sb.Append("\"print_info\":null,");//打印域
                        sb.Append("\"notice_infos\":[],");
                        sb.Append("\"assist_infos\":[],");
                        sb.Append("\"extend_infos\": [],");
                        sb.Append("\"item_details\": [");
                        DataTable dl = Getfpdl(r["fph"].ToString().Trim());
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
                            sb.Remove(sb.Length - 1, 1);
                        }
                        sb.Append("]}}");
                        message = sb.ToString();
                        string json = String.Empty;
                        Tools.WriteLog("开具门诊发票入参", message);
                        try
                        {
                            json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                            Tools.WriteLog("获取开具门诊发票信息出参", json);
                            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                            if (json.IndexOf("error_message") == -1)
                            {
                                KjfpJson jd = jsSerializer.Deserialize<KjfpJson>(json);
                                SqlParameter fpzl = new SqlParameter("@fpzl", "门诊发票");
                                SqlParameter batchcode = new SqlParameter("@bill_batch_code", jd.message.bill_batch_code);
                                SqlParameter billno = new SqlParameter("@bill_no", jd.message.bill_no);
                                SqlParameter serialnumber = new SqlParameter("@serial_number", jd.message.serial_number);
                                SqlParameter random = new SqlParameter("@random", jd.message.random);
                                SqlParameter createtime = new SqlParameter("@create_time", jd.message.create_time);
                                string ls_sql = "insert into ptjk_fpsc(fpzl,bill_batch_code,bill_no,serial_number,random,create_time) values('门诊发票','" + jd.message.bill_batch_code + "','" + jd.message.bill_no + "','" + jd.message.serial_number + "','" + jd.message.random + "','" + jd.message.create_time + "')";
                                Tools.WriteLog("开具门诊发票sql", ls_sql);
                                SqlHelp.ExecuteNonQuery(ls_sql);
                            }
                            else
                            {
                                ErrorJson jd = jsSerializer.Deserialize<ErrorJson>(json);
                                SqlParameter error_code = new SqlParameter("@error_code", jd.error_message.error_code);
                                SqlParameter error_msg = new SqlParameter("@error_msg", jd.error_message.error_msg);
                                SqlParameter fph = new SqlParameter("@fph", r["fph"].ToString().Trim());
                                SqlParameter blsj = new SqlParameter("@blsj", r["blsj"].ToString().Trim());
                                string ls_sql = "insert into ptjk_fpscsb(fph,error_code,error_msg,blsj) values(@fph,@error_code,@error_msg,@blsj)";
                                Tools.WriteLog("门诊开具失败:", ls_sql);
                                SqlHelp.ExecuteNonQuery(ls_sql, fph, error_code, error_msg, blsj);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    #endregion
                    this.Cursor = Cursors.Default;
                   // MessageBox.Show("传入完成");
                }
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string method = "invoice.issue.do";
            string place_code = "";
            if (comboBox1.SelectedIndex > -1)
            {
                place_code = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
            }
            string message = "";
            string jgdm = SqlHelp.ExecuteScalar("select cfgvalue from jk_cfg where cfgname='组织机构代码'");
            DataTable dtmx = (DataTable)dataGridView1.DataSource;
            if(dtmx!=null)
            {
                if(dtmx.Rows.Count>0)
                {
                    #region 开始循环
                    foreach (DataRow r in dtmx.Rows)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("{\"message\": {");
                        sb.Append("\"serial_number\": \"" + r["fph"].ToString().Trim() + "\",");//业务流水号，不能重复
                        sb.Append("\"place_code\": \"" + place_code + "\",");//开票点编码
                        sb.Append("\"payer\": \"" + r["blczy"].ToString().Trim() + "\",");//缴款人/单位
                        sb.Append("\"payer_tel\":\"\",");//缴款人手机号或电话号码
                        sb.Append("\"date\": \"" + DateTime.Parse(r["blsj"].ToString()).ToString("yyyy-MM-dd") + "\",");
                        sb.Append("\"author\": \"" + r["kpr"].ToString().Trim() + "\",");//开票人
                        sb.Append("\"payer_type\": \"" + 2 + "\",");//缴款人类型：1 个人 2 单位
                        sb.Append("\"credit_code\": \""+jgdm+"\",");//组织机构代码                        
                        sb.Append("\"bill_code\":\"" + r["bill_code"].ToString().Trim() + "\",");//票据种类编码
                        sb.Append("\"bill_batch_code\":\"" + r["bill_batch_code"].ToString().Trim() + "\",");//票据批次号
                        sb.Append("\"bill_no\":\"" + r["bill_no"].ToString().Trim() + "\",");//票据号
                        sb.Append("\"total_amt\":\"" + r["je"].ToString().Trim() + "\",");
                        sb.Append("\"rec_mode\": \"" + 1 + "\",");//收款方式:1现金,2转账,3其它
                        sb.Append("\"memo\": \"\",");//备注
                        sb.Append("\"print_info\":null,");//打印域
                        sb.Append("\"notice_infos\":[],");
                        sb.Append("\"assist_infos\":[],");
                        //sb.Append("\"notice_infos\":[{");
                        //sb.Append("\"type\":\"\",");
                        //sb.Append("\"value\":\"\"");
                        //sb.Append("}],");
                       /* sb.Append("\"assist_infos\":[");
                        DataTable mx = Getfpmx(r["fph"].ToString().Trim());
                        if (mx != null && mx.Rows.Count > 0)
                        {
                            foreach (DataRow rmc in mx.Rows)
                            {
                                sb.Append("{");
                                sb.Append("\"name\":\""+rmc["fymc"].ToString().Trim()+"\",");
                                sb.Append("\"price\":\"" + rmc["dj"].ToString() + "\",");
                                sb.Append("\"number\":\"" + rmc["sl"].ToString() + "\",");
                                sb.Append("\"amt\":\"" + rmc["je"].ToString() + "\",");
                                sb.Append("\"extend_infos\": []");*/
                                //sb.Append("\"extend_infos\":[{");
                                //sb.Append("\"info_name\":\"门诊发票\",");
                                //sb.Append("\"info_value\":\" \"");
                                //sb.Append("}]");
                            /*    sb.Append("},");
                            }
                            sb.Remove(sb.Length - 1, 1);
                        }
                        sb.Append("],");*/
                        sb.Append("\"extend_infos\": [],");
                        //sb.Append("\"extend_infos\": [{");
                        //sb.Append("\"info_name\":\"门诊发票\",");
                        //sb.Append("\"info_value\":\" \"");
                        //sb.Append("}],");
                        sb.Append("\"item_details\": [");
                        DataTable dl = Getfpdl(r["fph"].ToString().Trim());
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
                                //sb.Append("\"extend_infos\":[{");
                                //sb.Append("\"info_name\":\"门诊发票\",");
                                //sb.Append("\"info_value\": \"" + rr["fydl"].ToString().Trim() + "\"");
                                //sb.Append("}]");                                 
                                sb.Append("},");
                            }
                            sb.Remove(sb.Length - 1,1);
                        }
                        sb.Append("]}}");
                        message = sb.ToString();
                        string json = String.Empty;
                        Tools.WriteLog("开具门诊发票", message);
                        try
                        {
                            json = Tools.callService(Jbxx._url, method, Jbxx._appid, Jbxx._appkey, Jbxx._version, Jbxx._code, Jbxx._dwbm, message);
                            Tools.WriteLog("获取开具门诊发票信息", json);
                            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                            if (json.IndexOf("error_message") == -1)
                            {
                                KjfpJson jd = jsSerializer.Deserialize<KjfpJson>(json);
                                SqlParameter fpzl = new SqlParameter("@fpzl", "门诊发票");
                                SqlParameter batchcode = new SqlParameter("@bill_batch_code", jd.message.bill_batch_code);
                                SqlParameter billno = new SqlParameter("@bill_no", jd.message.bill_no);
                                SqlParameter serialnumber = new SqlParameter("@serial_number", jd.message.serial_number);
                                SqlParameter random = new SqlParameter("@random", jd.message.random);
                                SqlParameter createtime = new SqlParameter("@create_time", jd.message.create_time);
                                //string ls_sql = "insert into ptjk_fpsc(fpzl,bill_batch_code,bill_no,serial_number,random,create_time) values(@fpzl,@bill_batch_code,@bill_no,@serial_number,@random,@create_time)";
                                string ls_sql = "insert into ptjk_fpsc(fpzl,bill_batch_code,bill_no,serial_number,random,create_time) values('门诊发票','" + jd.message.bill_batch_code + "','"+jd.message.bill_no+"','"+jd.message.serial_number+"','"+jd.message.random+"','"+jd.message.create_time+"')";
                                //SqlHelp.ExecuteNonQuery(ls_sql,fpzl,batchcode,billno,serialnumber,random,createtime);
                                Tools.WriteLog("开具门诊发票sql", ls_sql);
                                SqlHelp.ExecuteNonQuery(ls_sql); 
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
                            MessageBox.Show(ex.Message);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    #endregion
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("传入完成");
                    selMzpj();
                }
            }
            
           
             
        }

        public DataTable Getfpmx(string fph)
        {
            Tools.WriteLog("发票号：",fph);
            DataTable mx = new DataTable();
            StringBuilder sb = new StringBuilder();
            /*sb.Append("select top 20 c.fybm,c.fymc as fydl,b.fyid,b.fymc,b.dw,cast(a.zfje/a.sl as decimal(16,4)) as dj,a.sl,a.zfje je from mz_brsf a,dm_mzsfxm b,dm_mzsfxm c where left(b.fybm,4)=c.fybm and len(c.fybm)=4 and a.fyid=b.fyid and a.fph=@fph and cfh is null and a.sl>0");
            sb.Append(" union all ");
            sb.Append("select d.fybm,d.fymc as fydl,c.ypid,c.ypmc,c.xsdw,cast(b.zfje/b.sl as decimal(16,4)) as dj,b.sl,b.zfje from mz_brsf a,mz_brcf b,dm_yd c,dm_mzsfxm d where a.fyid=d.fyid and a.cfh=b.cfh and b.ypid=c.ypid and a.fph=@fph and b.sl>0");*/
            sb.Append("select top 20 c.fybm,c.fymc as fydl,b.fyid,b.fymc,b.dw,a.zfje  as dj, 1 sl,a.zfje je from mz_brsf a,dm_mzsfxm b,dm_mzsfxm c where left(b.fybm,4)=c.fybm and len(c.fybm)=4 and a.fyid=b.fyid and a.fph=@fph and cfh is null and a.sl>0");
            sb.Append(" union all ");
            sb.Append("select d.fybm,d.fymc as fydl,c.ypid,c.ypmc,c.xsdw,b.zfje dj , 1 sl,b.zfje from mz_brsf a,mz_brcf b,dm_yd c,dm_mzsfxm d where a.fyid=d.fyid and a.cfh=b.cfh and b.ypid=c.ypid and a.fph=@fph and b.sl>0");
            mx = SqlHelp.HisTable(sb.ToString(), new SqlParameter("@fph", fph));
            //Tools.WriteLog("门诊Getfpmx：", sb.ToString());
            return mx;
        }

        public DataTable Getfpdl(string fph)
        {
            DataTable mx = new DataTable();
            StringBuilder sb = new StringBuilder();
<<<<<<< HEAD
            sb.Append("select top 20 c.fyid as fybm,c.fymc as fydl,sum(a.zfje) je from mz_brsf a,dm_mzsfxm b,dm_mzsfxm c,ptjk_dm d where c.fyid=d.hisbm and left(b.fybm,4)=c.fybm and len(c.fybm)=4 and a.fyid=b.fyid and a.fph=@fph and cfh is null and d.bz='门诊' group by c.fyid,c.fymc");
            sb.Append(" union all ");
            sb.Append("select d.fyid as fybm,d.fymc as fydl,sum(a.zfje) as je from mz_brsf a,dm_mzsfxm d,ptjk_dm e where d.fyid=e.hisbm and  a.cfh is not null and a.fyid=d.fyid and e.bz='门诊' and a.fph=@fph group by d.fyid,d.fymc");
=======
            sb.Append("select top 20 c.fyid as fybm,c.fymc as fydl,sum(a.zfje) je from mz_brsf a,dm_mzsfxm b,dm_mzsfxm c,ptjk_dm d where c.fybm=d.hisbm and left(b.fybm,4)=c.fybm and len(c.fybm)=4 and a.fyid=b.fyid and a.fph=@fph and cfh is null and d.bz='门诊' group by c.fyid,c.fymc");
            sb.Append(" union all ");
            sb.Append("select d.fyid as fybm,d.fymc as fydl,sum(a.zfje) as je from mz_brsf a,dm_mzsfxm d,ptjk_dm e where d.fybm=e.hisbm and  a.cfh is not null and a.fyid=d.fyid and e.bz='门诊' and a.fph=@fph group by d.fyid,d.fymc");
>>>>>>> d9cbb534583626ca525badf907d7f14b526880ea
            mx = SqlHelp.HisTable(sb.ToString(), new SqlParameter("@fph", fph));
          //  Tools.WriteLog("门诊Getfpdl：", sb.ToString());
            return mx;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
