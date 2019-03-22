using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Invoice
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        
        public string logins;
        private void button2_Click(object sender, EventArgs e)
        {
            logins = "th";
            Close();
        }

        private void txt_yhm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                this.txt_kl.Focus();
            }
        }

        private void txt_kl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                this.button1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bm;
            string kl;
            bm = txt_yhm.Text.Trim();
            kl = txt_kl.Text.Trim();
            if(String.IsNullOrEmpty(bm))
            {
                MessageBox.Show("用户名不能为空！");
                txt_yhm.Focus();
                return;
            }
            string i = SqlHelp.ExecuteScalar("select count(*) from xt_czyzl where bm=@bm and kl=@kl", new SqlParameter("@bm", bm), new SqlParameter("@kl", kl));
            if(!String.IsNullOrEmpty(i))
            {
                if(Convert.ToInt32(i)==0)
                {
                    MessageBox.Show("用户名或密码错误!");
                    txt_kl.Focus();
                    return;
                }
                else
                {
                    logins = "ok";
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txt_yhm.Focus();
        }
    }
}
