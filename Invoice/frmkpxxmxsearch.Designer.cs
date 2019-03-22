namespace Invoice
{
    partial class frmkpxxmxsearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_fph = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pj_fph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rgn_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rgn_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agen_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agen_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.place_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.place_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payer_tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payer_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payer_type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_batch_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.random = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rec_mode_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txt_fph,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.toolStripSeparator2,
            this.toolStripLabel4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(925, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "发票号";
            // 
            // txt_fph
            // 
            this.txt_fph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_fph.Name = "txt_fph";
            this.txt_fph.Size = new System.Drawing.Size(100, 25);
            this.txt_fph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fph_KeyPress);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Image = global::Invoice.Properties.Resources.accept;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel2.Text = "调入";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Image = global::Invoice.Properties.Resources.disconnect;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel3.Text = "开票情况查询";
            this.toolStripLabel3.Click += new System.EventHandler(this.toolStripLabel3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Image = global::Invoice.Properties.Resources.cross;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel4.Text = "关闭";
            this.toolStripLabel4.Click += new System.EventHandler(this.toolStripLabel4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 462);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(567, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(358, 462);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pj_fph,
            this.bill_no,
            this.rgn_code,
            this.rgn_name,
            this.agen_code,
            this.agen_name,
            this.place_code,
            this.place_name,
            this.payer,
            this.payer_tel,
            this.date,
            this.author,
            this.payer_type,
            this.payer_type_name,
            this.credit_code,
            this.bill_code,
            this.bill_name,
            this.bill_batch_code,
            this.random,
            this.total_amt,
            this.rec_mode_name,
            this.state});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(358, 462);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // pj_fph
            // 
            this.pj_fph.DataPropertyName = "pj_fph";
            this.pj_fph.HeaderText = "发票号";
            this.pj_fph.Name = "pj_fph";
            this.pj_fph.Width = 66;
            // 
            // bill_no
            // 
            this.bill_no.DataPropertyName = "bill_no";
            this.bill_no.HeaderText = "票据号码";
            this.bill_no.Name = "bill_no";
            this.bill_no.Width = 78;
            // 
            // rgn_code
            // 
            this.rgn_code.DataPropertyName = "rgn_code";
            this.rgn_code.HeaderText = "区划编码";
            this.rgn_code.Name = "rgn_code";
            this.rgn_code.Width = 78;
            // 
            // rgn_name
            // 
            this.rgn_name.DataPropertyName = "rgn_name";
            this.rgn_name.HeaderText = "区划名称";
            this.rgn_name.Name = "rgn_name";
            this.rgn_name.Width = 78;
            // 
            // agen_code
            // 
            this.agen_code.DataPropertyName = "agen_code";
            this.agen_code.HeaderText = "单位编码";
            this.agen_code.Name = "agen_code";
            this.agen_code.Width = 78;
            // 
            // agen_name
            // 
            this.agen_name.DataPropertyName = "agen_name";
            this.agen_name.HeaderText = "单位名称";
            this.agen_name.Name = "agen_name";
            this.agen_name.Width = 78;
            // 
            // place_code
            // 
            this.place_code.DataPropertyName = "place_code";
            this.place_code.HeaderText = "开票点编码";
            this.place_code.Name = "place_code";
            this.place_code.Width = 90;
            // 
            // place_name
            // 
            this.place_name.DataPropertyName = "place_name";
            this.place_name.HeaderText = "开票点名称";
            this.place_name.Name = "place_name";
            this.place_name.Width = 90;
            // 
            // payer
            // 
            this.payer.DataPropertyName = "payer";
            this.payer.HeaderText = "缴款人";
            this.payer.Name = "payer";
            this.payer.Width = 66;
            // 
            // payer_tel
            // 
            this.payer_tel.DataPropertyName = "payer_tel";
            this.payer_tel.HeaderText = "电话号码";
            this.payer_tel.Name = "payer_tel";
            this.payer_tel.Width = 78;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "开票日期";
            this.date.Name = "date";
            this.date.Width = 78;
            // 
            // author
            // 
            this.author.DataPropertyName = "author";
            this.author.HeaderText = "开票人";
            this.author.Name = "author";
            this.author.Width = 66;
            // 
            // payer_type
            // 
            this.payer_type.DataPropertyName = "payer_type";
            this.payer_type.HeaderText = "缴款人类型";
            this.payer_type.Name = "payer_type";
            this.payer_type.Width = 90;
            // 
            // payer_type_name
            // 
            this.payer_type_name.DataPropertyName = "payer_type_name";
            this.payer_type_name.HeaderText = "缴款人类型名";
            this.payer_type_name.Name = "payer_type_name";
            this.payer_type_name.Width = 102;
            // 
            // credit_code
            // 
            this.credit_code.DataPropertyName = "credit_code";
            this.credit_code.HeaderText = "组织机构代码";
            this.credit_code.Name = "credit_code";
            this.credit_code.Width = 102;
            // 
            // bill_code
            // 
            this.bill_code.DataPropertyName = "bill_code";
            this.bill_code.HeaderText = "票据种类编码";
            this.bill_code.Name = "bill_code";
            this.bill_code.Width = 102;
            // 
            // bill_name
            // 
            this.bill_name.DataPropertyName = "bill_name";
            this.bill_name.HeaderText = "票据种类名称";
            this.bill_name.Name = "bill_name";
            this.bill_name.Width = 102;
            // 
            // bill_batch_code
            // 
            this.bill_batch_code.DataPropertyName = "bill_batch_code";
            this.bill_batch_code.HeaderText = "票据代码";
            this.bill_batch_code.Name = "bill_batch_code";
            this.bill_batch_code.Width = 78;
            // 
            // random
            // 
            this.random.DataPropertyName = "random";
            this.random.HeaderText = "校验码";
            this.random.Name = "random";
            this.random.Width = 66;
            // 
            // total_amt
            // 
            this.total_amt.DataPropertyName = "total_amt";
            this.total_amt.HeaderText = "合计金额";
            this.total_amt.Name = "total_amt";
            this.total_amt.Width = 78;
            // 
            // rec_mode_name
            // 
            this.rec_mode_name.DataPropertyName = "rec_mode_name";
            this.rec_mode_name.HeaderText = "收款方式";
            this.rec_mode_name.Name = "rec_mode_name";
            this.rec_mode_name.Width = 78;
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "状态";
            this.state.Name = "state";
            this.state.Width = 54;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 462);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(567, 462);
            this.dataGridView1.TabIndex = 0;
            // 
            // frmkpxxmxsearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 487);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmkpxxmxsearch";
            this.Text = "开票信息明细查询";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_fph;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pj_fph;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn rgn_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn rgn_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn agen_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn agen_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn place_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn place_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn payer;
        private System.Windows.Forms.DataGridViewTextBoxColumn payer_tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn payer_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn payer_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_batch_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn random;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn rec_mode_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
    }
}