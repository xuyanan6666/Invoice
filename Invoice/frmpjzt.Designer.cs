namespace Invoice
{
    partial class frmpjzt
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_fph = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_batch_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_print_paper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paper_bill_batch_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paper_bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_scarlet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scarlet_bill_batch_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scarlet_bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txt_fph);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 43);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Image = global::Invoice.Properties.Resources.cross;
            this.button2.Location = new System.Drawing.Point(341, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "关闭";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Invoice.Properties.Resources.accept;
            this.button1.Location = new System.Drawing.Point(245, 13);
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
            this.txt_fph.Location = new System.Drawing.Point(68, 14);
            this.txt_fph.Name = "txt_fph";
            this.txt_fph.Size = new System.Drawing.Size(165, 21);
            this.txt_fph.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "票据号码：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(661, 335);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.bill_name,
            this.bill_batch_code,
            this.bill_no,
            this.state,
            this.is_print_paper,
            this.paper_bill_batch_code,
            this.paper_bill_no,
            this.is_scarlet,
            this.scarlet_bill_batch_code,
            this.scarlet_bill_no});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(661, 335);
            this.dataGridView1.TabIndex = 0;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "开票日期";
            this.date.Name = "date";
            // 
            // bill_name
            // 
            this.bill_name.DataPropertyName = "bill_name";
            this.bill_name.HeaderText = "票据种类名称";
            this.bill_name.Name = "bill_name";
            // 
            // bill_batch_code
            // 
            this.bill_batch_code.DataPropertyName = "bill_batch_code";
            this.bill_batch_code.HeaderText = "票据代码";
            this.bill_batch_code.Name = "bill_batch_code";
            // 
            // bill_no
            // 
            this.bill_no.DataPropertyName = "bill_no";
            this.bill_no.HeaderText = "票据号码";
            this.bill_no.Name = "bill_no";
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "状态";
            this.state.Name = "state";
            // 
            // is_print_paper
            // 
            this.is_print_paper.DataPropertyName = "is_print_paper";
            this.is_print_paper.HeaderText = "电子打印纸票";
            this.is_print_paper.Name = "is_print_paper";
            // 
            // paper_bill_batch_code
            // 
            this.paper_bill_batch_code.DataPropertyName = "paper_bill_batch_code";
            this.paper_bill_batch_code.HeaderText = "纸质票据代码";
            this.paper_bill_batch_code.Name = "paper_bill_batch_code";
            // 
            // paper_bill_no
            // 
            this.paper_bill_no.DataPropertyName = "paper_bill_no";
            this.paper_bill_no.HeaderText = "纸质票据号码";
            this.paper_bill_no.Name = "paper_bill_no";
            // 
            // is_scarlet
            // 
            this.is_scarlet.DataPropertyName = "is_scarlet";
            this.is_scarlet.HeaderText = "已开红票";
            this.is_scarlet.Name = "is_scarlet";
            // 
            // scarlet_bill_batch_code
            // 
            this.scarlet_bill_batch_code.DataPropertyName = "scarlet_bill_batch_code";
            this.scarlet_bill_batch_code.HeaderText = "红字电子票据代码";
            this.scarlet_bill_batch_code.Name = "scarlet_bill_batch_code";
            // 
            // scarlet_bill_no
            // 
            this.scarlet_bill_no.DataPropertyName = "scarlet_bill_no";
            this.scarlet_bill_no.HeaderText = "红字电子票据号码";
            this.scarlet_bill_no.Name = "scarlet_bill_no";
            // 
            // frmpjzt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 378);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmpjzt";
            this.Text = "票据状态查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_fph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_batch_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_print_paper;
        private System.Windows.Forms.DataGridViewTextBoxColumn paper_bill_batch_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn paper_bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_scarlet;
        private System.Windows.Forms.DataGridViewTextBoxColumn scarlet_bill_batch_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn scarlet_bill_no;
        private System.Windows.Forms.Button button2;
    }
}