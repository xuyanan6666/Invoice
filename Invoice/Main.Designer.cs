namespace Invoice
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.基础资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取开票点信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取票据信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取项目信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.门诊收费项目对码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.住院收费项目对码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.票据下发ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取票据信息ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.发票回退ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发票作废ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取发票号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开具票据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开具住院票据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量开具门诊票据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量开具住院票据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.根据流水号纸质票据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.票据作废ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退费情况票据作废ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开票信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量开票信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开票信息明细查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.票据状态查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取票据图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开具失败信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始定时上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.开票点对照ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基础资料ToolStripMenuItem,
            this.库存ToolStripMenuItem,
            this.开具ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.开始定时上传ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(8, 39);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 基础资料ToolStripMenuItem
            // 
            this.基础资料ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.获取开票点信息ToolStripMenuItem,
            this.获取票据信息ToolStripMenuItem,
            this.获取项目信息ToolStripMenuItem,
            this.门诊收费项目对码ToolStripMenuItem,
            this.住院收费项目对码ToolStripMenuItem,
            this.开票点对照ToolStripMenuItem});
            this.基础资料ToolStripMenuItem.Name = "基础资料ToolStripMenuItem";
            this.基础资料ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.基础资料ToolStripMenuItem.Text = "基础资料";
            // 
            // 获取开票点信息ToolStripMenuItem
            // 
            this.获取开票点信息ToolStripMenuItem.Name = "获取开票点信息ToolStripMenuItem";
            this.获取开票点信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.获取开票点信息ToolStripMenuItem.Text = "获取开票点信息";
            this.获取开票点信息ToolStripMenuItem.Click += new System.EventHandler(this.获取开票点信息ToolStripMenuItem_Click);
            // 
            // 获取票据信息ToolStripMenuItem
            // 
            this.获取票据信息ToolStripMenuItem.Name = "获取票据信息ToolStripMenuItem";
            this.获取票据信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.获取票据信息ToolStripMenuItem.Text = "获取票据信息";
            this.获取票据信息ToolStripMenuItem.Click += new System.EventHandler(this.获取票据信息ToolStripMenuItem_Click);
            // 
            // 获取项目信息ToolStripMenuItem
            // 
            this.获取项目信息ToolStripMenuItem.Name = "获取项目信息ToolStripMenuItem";
            this.获取项目信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.获取项目信息ToolStripMenuItem.Text = "获取项目信息";
            this.获取项目信息ToolStripMenuItem.Click += new System.EventHandler(this.获取项目信息ToolStripMenuItem_Click);
            // 
            // 门诊收费项目对码ToolStripMenuItem
            // 
            this.门诊收费项目对码ToolStripMenuItem.Name = "门诊收费项目对码ToolStripMenuItem";
            this.门诊收费项目对码ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.门诊收费项目对码ToolStripMenuItem.Text = "门诊收费项目对码";
            this.门诊收费项目对码ToolStripMenuItem.Click += new System.EventHandler(this.门诊收费项目对码ToolStripMenuItem_Click);
            // 
            // 住院收费项目对码ToolStripMenuItem
            // 
            this.住院收费项目对码ToolStripMenuItem.Name = "住院收费项目对码ToolStripMenuItem";
            this.住院收费项目对码ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.住院收费项目对码ToolStripMenuItem.Text = "住院收费项目对码";
            this.住院收费项目对码ToolStripMenuItem.Click += new System.EventHandler(this.住院收费项目对码ToolStripMenuItem_Click);
            // 
            // 库存ToolStripMenuItem
            // 
            this.库存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.票据下发ToolStripMenuItem,
            this.获取票据信息ToolStripMenuItem1,
            this.发票回退ToolStripMenuItem,
            this.发票作废ToolStripMenuItem,
            this.获取发票号ToolStripMenuItem});
            this.库存ToolStripMenuItem.Name = "库存ToolStripMenuItem";
            this.库存ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.库存ToolStripMenuItem.Text = "库存";
            // 
            // 票据下发ToolStripMenuItem
            // 
            this.票据下发ToolStripMenuItem.Name = "票据下发ToolStripMenuItem";
            this.票据下发ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.票据下发ToolStripMenuItem.Text = "票据下发";
            this.票据下发ToolStripMenuItem.Click += new System.EventHandler(this.票据下发ToolStripMenuItem_Click);
            // 
            // 获取票据信息ToolStripMenuItem1
            // 
            this.获取票据信息ToolStripMenuItem1.Name = "获取票据信息ToolStripMenuItem1";
            this.获取票据信息ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.获取票据信息ToolStripMenuItem1.Text = "获取票据信息";
            this.获取票据信息ToolStripMenuItem1.Click += new System.EventHandler(this.获取票据信息ToolStripMenuItem1_Click);
            // 
            // 发票回退ToolStripMenuItem
            // 
            this.发票回退ToolStripMenuItem.Name = "发票回退ToolStripMenuItem";
            this.发票回退ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.发票回退ToolStripMenuItem.Text = "发票回退";
            this.发票回退ToolStripMenuItem.Click += new System.EventHandler(this.发票回退ToolStripMenuItem_Click);
            // 
            // 发票作废ToolStripMenuItem
            // 
            this.发票作废ToolStripMenuItem.Name = "发票作废ToolStripMenuItem";
            this.发票作废ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.发票作废ToolStripMenuItem.Text = "作废库存票据";
            this.发票作废ToolStripMenuItem.Click += new System.EventHandler(this.发票作废ToolStripMenuItem_Click);
            // 
            // 获取发票号ToolStripMenuItem
            // 
            this.获取发票号ToolStripMenuItem.Name = "获取发票号ToolStripMenuItem";
            this.获取发票号ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.获取发票号ToolStripMenuItem.Text = "获取发票号";
            this.获取发票号ToolStripMenuItem.Click += new System.EventHandler(this.获取发票号ToolStripMenuItem_Click);
            // 
            // 开具ToolStripMenuItem
            // 
            this.开具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开具票据ToolStripMenuItem,
            this.开具住院票据ToolStripMenuItem,
            this.批量开具门诊票据ToolStripMenuItem,
            this.批量开具住院票据ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.根据流水号纸质票据ToolStripMenuItem,
            this.票据作废ToolStripMenuItem,
            this.退费情况票据作废ToolStripMenuItem});
            this.开具ToolStripMenuItem.Name = "开具ToolStripMenuItem";
            this.开具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开具ToolStripMenuItem.Text = "开具";
            // 
            // 开具票据ToolStripMenuItem
            // 
            this.开具票据ToolStripMenuItem.Name = "开具票据ToolStripMenuItem";
            this.开具票据ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.开具票据ToolStripMenuItem.Text = "开具门诊票据";
            this.开具票据ToolStripMenuItem.Click += new System.EventHandler(this.开具票据ToolStripMenuItem_Click);
            // 
            // 开具住院票据ToolStripMenuItem
            // 
            this.开具住院票据ToolStripMenuItem.Name = "开具住院票据ToolStripMenuItem";
            this.开具住院票据ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.开具住院票据ToolStripMenuItem.Text = "开具住院票据";
            this.开具住院票据ToolStripMenuItem.Click += new System.EventHandler(this.开具住院票据ToolStripMenuItem_Click);
            // 
            // 批量开具门诊票据ToolStripMenuItem
            // 
            this.批量开具门诊票据ToolStripMenuItem.Name = "批量开具门诊票据ToolStripMenuItem";
            this.批量开具门诊票据ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.批量开具门诊票据ToolStripMenuItem.Text = "批量开具门诊票据";
            this.批量开具门诊票据ToolStripMenuItem.Visible = false;
            this.批量开具门诊票据ToolStripMenuItem.Click += new System.EventHandler(this.批量开具门诊票据ToolStripMenuItem_Click);
            // 
            // 批量开具住院票据ToolStripMenuItem
            // 
            this.批量开具住院票据ToolStripMenuItem.Name = "批量开具住院票据ToolStripMenuItem";
            this.批量开具住院票据ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.批量开具住院票据ToolStripMenuItem.Text = "批量开具住院票据";
            this.批量开具住院票据ToolStripMenuItem.Visible = false;
            this.批量开具住院票据ToolStripMenuItem.Click += new System.EventHandler(this.批量开具住院票据ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // 根据流水号纸质票据ToolStripMenuItem
            // 
            this.根据流水号纸质票据ToolStripMenuItem.Name = "根据流水号纸质票据ToolStripMenuItem";
            this.根据流水号纸质票据ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.根据流水号纸质票据ToolStripMenuItem.Text = "根据流水号纸质票据";
            this.根据流水号纸质票据ToolStripMenuItem.Click += new System.EventHandler(this.根据流水号纸质票据ToolStripMenuItem_Click);
            // 
            // 票据作废ToolStripMenuItem
            // 
            this.票据作废ToolStripMenuItem.Name = "票据作废ToolStripMenuItem";
            this.票据作废ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.票据作废ToolStripMenuItem.Text = "卡纸等情况票据作废";
            this.票据作废ToolStripMenuItem.Click += new System.EventHandler(this.票据作废ToolStripMenuItem_Click);
            // 
            // 退费情况票据作废ToolStripMenuItem
            // 
            this.退费情况票据作废ToolStripMenuItem.Name = "退费情况票据作废ToolStripMenuItem";
            this.退费情况票据作废ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.退费情况票据作废ToolStripMenuItem.Text = "退费情况票据作废";
            this.退费情况票据作废ToolStripMenuItem.Click += new System.EventHandler(this.退费情况票据作废ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开票信息查询ToolStripMenuItem,
            this.批量开票信息查询ToolStripMenuItem,
            this.开票信息明细查询ToolStripMenuItem,
            this.票据状态查询ToolStripMenuItem,
            this.获取票据图片ToolStripMenuItem,
            this.开具失败信息查询ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 开票信息查询ToolStripMenuItem
            // 
            this.开票信息查询ToolStripMenuItem.Name = "开票信息查询ToolStripMenuItem";
            this.开票信息查询ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.开票信息查询ToolStripMenuItem.Text = "开票信息查询";
            this.开票信息查询ToolStripMenuItem.Click += new System.EventHandler(this.开票信息查询ToolStripMenuItem_Click);
            // 
            // 批量开票信息查询ToolStripMenuItem
            // 
            this.批量开票信息查询ToolStripMenuItem.Name = "批量开票信息查询ToolStripMenuItem";
            this.批量开票信息查询ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.批量开票信息查询ToolStripMenuItem.Text = "批量开票信息查询";
            this.批量开票信息查询ToolStripMenuItem.Click += new System.EventHandler(this.批量开票信息查询ToolStripMenuItem_Click);
            // 
            // 开票信息明细查询ToolStripMenuItem
            // 
            this.开票信息明细查询ToolStripMenuItem.Name = "开票信息明细查询ToolStripMenuItem";
            this.开票信息明细查询ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.开票信息明细查询ToolStripMenuItem.Text = "开票信息明细查询";
            this.开票信息明细查询ToolStripMenuItem.Click += new System.EventHandler(this.开票信息明细查询ToolStripMenuItem_Click);
            // 
            // 票据状态查询ToolStripMenuItem
            // 
            this.票据状态查询ToolStripMenuItem.Name = "票据状态查询ToolStripMenuItem";
            this.票据状态查询ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.票据状态查询ToolStripMenuItem.Text = "票据状态查询";
            this.票据状态查询ToolStripMenuItem.Click += new System.EventHandler(this.票据状态查询ToolStripMenuItem_Click);
            // 
            // 获取票据图片ToolStripMenuItem
            // 
            this.获取票据图片ToolStripMenuItem.Name = "获取票据图片ToolStripMenuItem";
            this.获取票据图片ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.获取票据图片ToolStripMenuItem.Text = "获取票据图片";
            this.获取票据图片ToolStripMenuItem.Click += new System.EventHandler(this.获取票据图片ToolStripMenuItem_Click);
            // 
            // 开具失败信息查询ToolStripMenuItem
            // 
            this.开具失败信息查询ToolStripMenuItem.Name = "开具失败信息查询ToolStripMenuItem";
            this.开具失败信息查询ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.开具失败信息查询ToolStripMenuItem.Text = "开票失败信息查询";
            this.开具失败信息查询ToolStripMenuItem.Click += new System.EventHandler(this.开具失败信息查询ToolStripMenuItem_Click);
            // 
            // 开始定时上传ToolStripMenuItem
            // 
            this.开始定时上传ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始上传ToolStripMenuItem,
            this.结束上传ToolStripMenuItem});
            this.开始定时上传ToolStripMenuItem.Name = "开始定时上传ToolStripMenuItem";
            this.开始定时上传ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.开始定时上传ToolStripMenuItem.Text = "定时上传";
            // 
            // 开始上传ToolStripMenuItem
            // 
            this.开始上传ToolStripMenuItem.Name = "开始上传ToolStripMenuItem";
            this.开始上传ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始上传ToolStripMenuItem.Text = "开始上传";
            this.开始上传ToolStripMenuItem.Click += new System.EventHandler(this.开始上传ToolStripMenuItem_Click);
            // 
            // 结束上传ToolStripMenuItem
            // 
            this.结束上传ToolStripMenuItem.Name = "结束上传ToolStripMenuItem";
            this.结束上传ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.结束上传ToolStripMenuItem.Text = "结束上传";
            this.结束上传ToolStripMenuItem.Click += new System.EventHandler(this.结束上传ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 377);
            this.panel1.TabIndex = 3;
            // 
            // 开票点对照ToolStripMenuItem
            // 
            this.开票点对照ToolStripMenuItem.Name = "开票点对照ToolStripMenuItem";
            this.开票点对照ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.开票点对照ToolStripMenuItem.Text = "开票点对照";
            this.开票点对照ToolStripMenuItem.Click += new System.EventHandler(this.开票点对照ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 449);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "发票管理接口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 基础资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取票据信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取项目信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取开票点信息ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 库存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取票据信息ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 票据下发ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发票回退ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发票作废ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取发票号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开具票据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 根据流水号纸质票据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开具住院票据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 门诊收费项目对码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 住院收费项目对码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量开具门诊票据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量开具住院票据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 票据作废ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退费情况票据作废ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开票信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量开票信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开票信息明细查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 票据状态查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取票据图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始定时上传ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始上传ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束上传ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 开具失败信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开票点对照ToolStripMenuItem;

    }
}

