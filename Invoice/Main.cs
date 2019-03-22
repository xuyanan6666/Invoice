using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace Invoice
{
    public partial class Main : Skin_VS
    {
        public Main()
        {
            InitializeComponent();
        }

       

        private void Main_Load(object sender, EventArgs e)
        {
            string url;
            string appid;
            string appkey;
            string dwbm;
            string code;
            string version;
            try
            {
                string msg = SqlHelp.Conncs();
                if (!String.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            DataTable dt = SqlHelp.HisTable("select * from jk_cfg");
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("jk_cfg表没有维护必要的参数");
                return;
            }
            else
            {
                url = SqlHelp.ExecuteScalar("select cfgvalue from jk_cfg where cfgname='url'");
                if(String.IsNullOrEmpty(url))
                {
                    MessageBox.Show("url地址不能为空！");
                    return;
                }
                Jbxx._url = url;

                appid = SqlHelp.ExecuteScalar("select cfgvalue from jk_cfg where cfgname='appid'");
                if (String.IsNullOrEmpty(appid))
                {
                    MessageBox.Show("应用帐号不能为空！");
                    return;
                }
                Jbxx._appid = appid;

                appkey = SqlHelp.ExecuteScalar("select cfgvalue from jk_cfg where cfgname='appkey'");
                if (String.IsNullOrEmpty(appkey))
                {
                    MessageBox.Show("appkey不能为空！");
                    return;
                }
                Jbxx._appkey = appkey;

                
                code = SqlHelp.ExecuteScalar("select cfgvalue from jk_cfg where cfgname='regioncode'");
                if (String.IsNullOrEmpty(code))
                {
                    MessageBox.Show("地区编码不能为空！");
                    return;
                }
                Jbxx._code = code;

                dwbm = SqlHelp.ExecuteScalar("select cfgvalue from jk_cfg where cfgname='dwmc'");
                if (String.IsNullOrEmpty(dwbm))
                {
                    MessageBox.Show("单位编码不能为空！");
                    return;
                }
                Jbxx._dwbm = dwbm;

                version = SqlHelp.ExecuteScalar("select cfgvalue from jk_cfg where cfgname='version'");
                if (String.IsNullOrEmpty(version))
                {
                    MessageBox.Show("版本不能为空！");
                    return;
                }
                Jbxx._version = version;
            }

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private bool CheckFormIsOpen(string Forms)
        {
            bool bResult = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == Forms)
                {
                    bResult = true;
                    this.panel1.Controls.Clear();
                    this.panel1.Controls.Add(frm);
                    this.Text = frm.Text;
                    frm.Activate();
                    break;
                }

            }
            return bResult;
        }

        private void 获取票据信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmpjxx"))
            {
                this.panel1.Controls.Clear();
                frmpjxx t = new frmpjxx();
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                t.MdiParent = this;
                t.Parent = this.panel1;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 获取项目信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmFymc"))
            {
                this.panel1.Controls.Clear();
                FrmFymc t = new FrmFymc();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 获取开票点信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmkpd"))
            {
                this.panel1.Controls.Clear();
                frmkpd t = new frmkpd();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                //this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 获取票据信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmlyxx"))
            {
                this.panel1.Controls.Clear();
                frmlyxx t = new frmlyxx();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 票据下发ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmpjxf"))
            {
                this.panel1.Controls.Clear();
                frmpjxf t = new frmpjxf();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 发票回退ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmfpht"))
            {
                this.panel1.Controls.Clear();
                frmfpht t = new frmfpht();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 发票作废ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmfpzf"))
            {
                this.panel1.Controls.Clear();
                frmfpzf t = new frmfpzf();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 获取发票号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmfph"))
            {
                this.panel1.Controls.Clear();
                frmfph t = new frmfph();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 开具票据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (!CheckFormIsOpen("frmkjpj"))
            {
                this.panel1.Controls.Clear();
                frmkjpj t = new frmkjpj();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
          
        }

        private void 根据流水号纸质票据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmpjzh"))
            {
                this.panel1.Controls.Clear();
                frmpjzh t = new frmpjzh();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 门诊收费项目对码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("FrmMzsfxm"))
            {
                this.panel1.Controls.Clear();
                FrmMzsfxm t = new FrmMzsfxm();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 住院收费项目对码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("FrmZysfxm"))
            {
                this.panel1.Controls.Clear();
                FrmZysfxm t = new FrmZysfxm();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 开具住院票据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmkjpjzy"))
            {
                this.panel1.Controls.Clear();
                frmkjpjzy t = new frmkjpjzy();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 批量开具门诊票据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmkjpjbatch"))
            {
                this.panel1.Controls.Clear();
                frmkjpjbatch t = new frmkjpjbatch();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);

            }
        }

        private void 批量开具住院票据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmkjpjzybatch"))
            {
                this.panel1.Controls.Clear();
                frmkjpjzybatch t = new frmkjpjzybatch();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 票据作废ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmpjzf"))
            {
                this.panel1.Controls.Clear();
                frmpjzf t = new frmpjzf();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 退费情况票据作废ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmpjzftf"))
            {
                this.panel1.Controls.Clear();
                frmpjzftf t = new frmpjzftf();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 开票信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmkpxxsearch"))
            {
                this.panel1.Controls.Clear();
                frmkpxxsearch t = new frmkpxxsearch();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 批量开票信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmkpxxbatchsearch"))
            {
                this.panel1.Controls.Clear();
                frmkpxxbatchsearch t = new frmkpxxbatchsearch();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 开票信息明细查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmkpxxmxsearch"))
            {
                this.panel1.Controls.Clear();
                frmkpxxmxsearch t = new frmkpxxmxsearch();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 票据状态查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmpjzt"))
            {
                this.panel1.Controls.Clear();
                frmpjzt t = new frmpjzt();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 获取票据图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmpjImage"))
            {
                this.panel1.Controls.Clear();
                frmpjImage t = new frmpjImage();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        System.Timers.Timer timer;
        private void 开始上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("定时上传开启");
            timer = new System.Timers.Timer(); 
            timer.Interval = 1000;  //设置计时器事件间隔执行时间
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
           
        }
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (e.SignalTime.Hour == 00 && e.SignalTime.Minute == 00 && e.SignalTime.Second == 00)//晚上0点开票据
            {
                frmkjpj tmz = new frmkjpj();
                tmz.kj_Mzpj();//门诊开票据
                frmkjpjzy tzy = new frmkjpjzy();
                tzy.kj_Zypj();//住院开票据
<<<<<<< HEAD
                //发票作废
                frmpjzftf tf = new frmpjzftf();
                tf.getfpmx("");
                tf.zffp();
=======
>>>>>>> d9cbb534583626ca525badf907d7f14b526880ea

            }
        }

        private void 结束上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer.AutoReset = false;
            timer1.Stop();
            MessageBox.Show("定时上传关闭");
        }

        private void 开具失败信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmkpsbxxsearch"))
            {
                this.panel1.Controls.Clear();
                frmkpsbxxsearch t = new frmkpsbxxsearch();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }

        private void 开票点对照ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFormIsOpen("frmfpddm"))
            {
                this.panel1.Controls.Clear();
                frmfpddm t = new frmfpddm();
                t.MdiParent = this;
                t.Parent = this.panel1;
                t.Dock = DockStyle.Fill;
                t.Show();
                t.Height = this.panel1.Height;
                t.Width = this.panel1.Width;
                this.Text = t.Text;
                this.panel1.Controls.Add(t);
            }
        }
    }

}
