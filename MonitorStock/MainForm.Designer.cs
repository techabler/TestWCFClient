namespace MonitorStock
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarkStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarkGoldCrossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarkTodayTop20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarkUpStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Controls.Add(this.menuStrip1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1137, 639);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.DimGray;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 24);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(4);
            this.pnlBody.Size = new System.Drawing.Size(1137, 615);
            this.pnlBody.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managementToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1137, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockListToolStripMenuItem,
            this.bookmarkStockToolStripMenuItem,
            this.bookmarkGoldCrossToolStripMenuItem,
            this.bookmarkTodayTop20ToolStripMenuItem,
            this.bookmarkUpStockToolStripMenuItem});
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.managementToolStripMenuItem.Text = "Management";
            // 
            // stockListToolStripMenuItem
            // 
            this.stockListToolStripMenuItem.Name = "stockListToolStripMenuItem";
            this.stockListToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.stockListToolStripMenuItem.Text = "Stock List";
            this.stockListToolStripMenuItem.Click += new System.EventHandler(this.stockListToolStripMenuItem_Click);
            // 
            // bookmarkStockToolStripMenuItem
            // 
            this.bookmarkStockToolStripMenuItem.Name = "bookmarkStockToolStripMenuItem";
            this.bookmarkStockToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.bookmarkStockToolStripMenuItem.Text = "Bookmark Stock";
            this.bookmarkStockToolStripMenuItem.Click += new System.EventHandler(this.bookmarkStockToolStripMenuItem_Click);
            // 
            // bookmarkGoldCrossToolStripMenuItem
            // 
            this.bookmarkGoldCrossToolStripMenuItem.Name = "bookmarkGoldCrossToolStripMenuItem";
            this.bookmarkGoldCrossToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.bookmarkGoldCrossToolStripMenuItem.Text = "Bookmark GoldCross";
            // 
            // bookmarkTodayTop20ToolStripMenuItem
            // 
            this.bookmarkTodayTop20ToolStripMenuItem.Name = "bookmarkTodayTop20ToolStripMenuItem";
            this.bookmarkTodayTop20ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.bookmarkTodayTop20ToolStripMenuItem.Text = "Bookmark Today Top20";
            // 
            // bookmarkUpStockToolStripMenuItem
            // 
            this.bookmarkUpStockToolStripMenuItem.Name = "bookmarkUpStockToolStripMenuItem";
            this.bookmarkUpStockToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.bookmarkUpStockToolStripMenuItem.Text = "Bookmark Up Stock";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 639);
            this.Controls.Add(this.pnlMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Monitor Stock";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookmarkStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookmarkGoldCrossToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookmarkTodayTop20ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookmarkUpStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.Panel pnlBody;
    }
}

