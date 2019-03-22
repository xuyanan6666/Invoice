namespace Invoice
{
    partial class frmpjzftf
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_fph = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.发票号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发票代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.作废时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HIS发票号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发票流水号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.退费时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.退费操作员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发票代码1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 277);
            this.panel1.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1153, 241);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HIS发票号,
            this.发票流水号,
            this.退费时间,
            this.退费操作员,
            this.发票代码1});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1153, 241);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txt_fph);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1153, 36);
            this.panel2.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Image = global::Invoice.Properties.Resources.cross;
            this.button4.Location = new System.Drawing.Point(519, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "关闭";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::Invoice.Properties.Resources.disconnect;
            this.button3.Location = new System.Drawing.Point(346, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "单个作废";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Invoice.Properties.Resources.arrow_up;
            this.button2.Location = new System.Drawing.Point(433, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "全部作废";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Invoice.Properties.Resources.accept;
            this.button1.Location = new System.Drawing.Point(265, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_fph
            // 
            this.txt_fph.Location = new System.Drawing.Point(65, 5);
            this.txt_fph.Name = "txt_fph";
            this.txt_fph.Size = new System.Drawing.Size(194, 21);
            this.txt_fph.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "发票号：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.发票号,
            this.发票代码,
            this.作废时间});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 277);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1153, 202);
            this.dataGridView1.TabIndex = 16;
            // 
            // 发票号
            // 
            this.发票号.DataPropertyName = "发票号";
            this.发票号.HeaderText = "发票号";
            this.发票号.Name = "发票号";
            this.发票号.Width = 66;
            // 
            // 发票代码
            // 
            this.发票代码.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.发票代码.DataPropertyName = "发票代码";
            this.发票代码.HeaderText = "发票代码";
            this.发票代码.Name = "发票代码";
            this.发票代码.Width = 78;
            // 
            // 作废时间
            // 
            this.作废时间.DataPropertyName = "作废时间";
            this.作废时间.HeaderText = "作废时间";
            this.作废时间.Name = "作废时间";
            this.作废时间.Width = 78;
            // 
            // HIS发票号
            // 
            this.HIS发票号.DataPropertyName = "HIS发票号";
            this.HIS发票号.HeaderText = "HIS发票号";
            this.HIS发票号.Name = "HIS发票号";
            this.HIS发票号.Width = 84;
            // 
            // 发票流水号
            // 
            this.发票流水号.DataPropertyName = "发票流水号";
            this.发票流水号.HeaderText = "发票流水号";
            this.发票流水号.Name = "发票流水号";
            this.发票流水号.Width = 90;
            // 
            // 退费时间
            // 
            this.退费时间.DataPropertyName = "退费时间";
            this.退费时间.HeaderText = "退费时间";
            this.退费时间.Name = "退费时间";
            this.退费时间.Width = 78;
            // 
            // 退费操作员
            // 
            this.退费操作员.DataPropertyName = "退费操作员";
            this.退费操作员.HeaderText = "退费操作员";
            this.退费操作员.Name = "退费操作员";
            this.退费操作员.Width = 90;
            // 
            // 发票代码1
            // 
            this.发票代码1.DataPropertyName = "发票代码";
            this.发票代码1.HeaderText = "发票代码";
            this.发票代码1.Name = "发票代码1";
            this.发票代码1.Width = 78;
            // 
            // frmpjzftf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 479);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmpjzftf";
            this.Text = "退费发票作废";
            this.Load += new System.EventHandler(this.frmkpd_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_fph;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发票号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发票代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 作废时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn HIS发票号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发票流水号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 退费时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 退费操作员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发票代码1;


    }
}