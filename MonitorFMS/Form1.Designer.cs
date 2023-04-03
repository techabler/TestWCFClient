namespace MonitorFMS
{
    partial class MainFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgTray = new System.Windows.Forms.DataGridView();
            this.TColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTrayId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgEqp = new System.Windows.Forms.DataGridView();
            this.Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEqpId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSec = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reworkUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mCSimulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorSimulatorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPUIToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reworkUIToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceEditorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mCSimulatorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editorSimulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTray)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEqp)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgTray);
            this.panel4.Controls.Add(this.txtTrayId);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(330, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(325, 393);
            this.panel4.TabIndex = 5;
            // 
            // dgTray
            // 
            this.dgTray.AllowUserToAddRows = false;
            this.dgTray.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTray.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTray.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TColumn,
            this.TValue});
            this.dgTray.Location = new System.Drawing.Point(6, 33);
            this.dgTray.Name = "dgTray";
            this.dgTray.RowHeadersVisible = false;
            this.dgTray.RowTemplate.Height = 23;
            this.dgTray.Size = new System.Drawing.Size(307, 347);
            this.dgTray.TabIndex = 4;
            // 
            // TColumn
            // 
            this.TColumn.HeaderText = "Column";
            this.TColumn.Name = "TColumn";
            // 
            // TValue
            // 
            this.TValue.HeaderText = "Value";
            this.TValue.Name = "TValue";
            // 
            // txtTrayId
            // 
            this.txtTrayId.Location = new System.Drawing.Point(148, 6);
            this.txtTrayId.Name = "txtTrayId";
            this.txtTrayId.Size = new System.Drawing.Size(165, 21);
            this.txtTrayId.TabIndex = 3;
            this.txtTrayId.Text = "FIP-22-0014";
            this.txtTrayId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tray ID : ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgEqp);
            this.panel3.Controls.Add(this.txtEqpId);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 393);
            this.panel3.TabIndex = 4;
            // 
            // dgEqp
            // 
            this.dgEqp.AllowUserToAddRows = false;
            this.dgEqp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEqp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEqp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column,
            this.Value});
            this.dgEqp.Location = new System.Drawing.Point(8, 33);
            this.dgEqp.Name = "dgEqp";
            this.dgEqp.RowHeadersVisible = false;
            this.dgEqp.RowTemplate.Height = 23;
            this.dgEqp.Size = new System.Drawing.Size(304, 347);
            this.dgEqp.TabIndex = 3;
            // 
            // Column
            // 
            this.Column.HeaderText = "Column";
            this.Column.Name = "Column";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // txtEqpId
            // 
            this.txtEqpId.Location = new System.Drawing.Point(156, 6);
            this.txtEqpId.Name = "txtEqpId";
            this.txtEqpId.Size = new System.Drawing.Size(156, 21);
            this.txtEqpId.TabIndex = 2;
            this.txtEqpId.Text = "F01FOR01100101";
            this.txtEqpId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Equipment ID :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtURL);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSec);
            this.panel2.Controls.Add(this.txtCount);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(655, 33);
            this.panel2.TabIndex = 3;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(13, 3);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(299, 21);
            this.txtURL.TabIndex = 7;
            this.txtURL.Text = "http://localhost:48091";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "sec";
            // 
            // txtSec
            // 
            this.txtSec.Location = new System.Drawing.Point(322, 4);
            this.txtSec.Name = "txtSec";
            this.txtSec.Size = new System.Drawing.Size(40, 21);
            this.txtSec.TabIndex = 5;
            this.txtSec.Text = "5";
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCount.Location = new System.Drawing.Point(423, 4);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(47, 21);
            this.txtCount.TabIndex = 4;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(568, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(478, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Start";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(655, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPUIToolStripMenuItem,
            this.reworkUIToolStripMenuItem,
            this.sequenceEditorToolStripMenuItem,
            this.mCSimulatorToolStripMenuItem,
            this.editorSimulatorToolStripMenuItem1});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // oPUIToolStripMenuItem
            // 
            this.oPUIToolStripMenuItem.Name = "oPUIToolStripMenuItem";
            this.oPUIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.oPUIToolStripMenuItem.Text = "OP-UI";
            this.oPUIToolStripMenuItem.Click += new System.EventHandler(this.oPUIToolStripMenuItem_Click);
            // 
            // reworkUIToolStripMenuItem
            // 
            this.reworkUIToolStripMenuItem.Name = "reworkUIToolStripMenuItem";
            this.reworkUIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reworkUIToolStripMenuItem.Text = "Rework-UI";
            this.reworkUIToolStripMenuItem.Click += new System.EventHandler(this.reworkUIToolStripMenuItem_Click);
            // 
            // sequenceEditorToolStripMenuItem
            // 
            this.sequenceEditorToolStripMenuItem.Name = "sequenceEditorToolStripMenuItem";
            this.sequenceEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sequenceEditorToolStripMenuItem.Text = "Sequence Editor";
            this.sequenceEditorToolStripMenuItem.Click += new System.EventHandler(this.sequenceEditorToolStripMenuItem_Click);
            // 
            // mCSimulatorToolStripMenuItem
            // 
            this.mCSimulatorToolStripMenuItem.Name = "mCSimulatorToolStripMenuItem";
            this.mCSimulatorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mCSimulatorToolStripMenuItem.Text = "MCSimulator";
            this.mCSimulatorToolStripMenuItem.Click += new System.EventHandler(this.mCSimulatorToolStripMenuItem_Click);
            // 
            // editorSimulatorToolStripMenuItem1
            // 
            this.editorSimulatorToolStripMenuItem1.Name = "editorSimulatorToolStripMenuItem1";
            this.editorSimulatorToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.editorSimulatorToolStripMenuItem1.Text = "CSV-Editor";
            this.editorSimulatorToolStripMenuItem1.Click += new System.EventHandler(this.editorSimulatorToolStripMenuItem1_Click_1);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPUIToolStripMenuItem1,
            this.reworkUIToolStripMenuItem1,
            this.sequenceEditorToolStripMenuItem1,
            this.mCSimulatorToolStripMenuItem1,
            this.editorSimulatorToolStripMenuItem});
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.folderToolStripMenuItem.Text = "Folder";
            // 
            // oPUIToolStripMenuItem1
            // 
            this.oPUIToolStripMenuItem1.Name = "oPUIToolStripMenuItem1";
            this.oPUIToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.oPUIToolStripMenuItem1.Text = "OP-UI";
            this.oPUIToolStripMenuItem1.Click += new System.EventHandler(this.oPUIToolStripMenuItem1_Click);
            // 
            // reworkUIToolStripMenuItem1
            // 
            this.reworkUIToolStripMenuItem1.Name = "reworkUIToolStripMenuItem1";
            this.reworkUIToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.reworkUIToolStripMenuItem1.Text = "Rework-UI";
            this.reworkUIToolStripMenuItem1.Click += new System.EventHandler(this.reworkUIToolStripMenuItem1_Click);
            // 
            // sequenceEditorToolStripMenuItem1
            // 
            this.sequenceEditorToolStripMenuItem1.Name = "sequenceEditorToolStripMenuItem1";
            this.sequenceEditorToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.sequenceEditorToolStripMenuItem1.Text = "Sequence-Editor";
            this.sequenceEditorToolStripMenuItem1.Click += new System.EventHandler(this.sequenceEditorToolStripMenuItem1_Click);
            // 
            // mCSimulatorToolStripMenuItem1
            // 
            this.mCSimulatorToolStripMenuItem1.Name = "mCSimulatorToolStripMenuItem1";
            this.mCSimulatorToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.mCSimulatorToolStripMenuItem1.Text = "MCSimulator";
            this.mCSimulatorToolStripMenuItem1.Click += new System.EventHandler(this.mCSimulatorToolStripMenuItem1_Click);
            // 
            // editorSimulatorToolStripMenuItem
            // 
            this.editorSimulatorToolStripMenuItem.Name = "editorSimulatorToolStripMenuItem";
            this.editorSimulatorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editorSimulatorToolStripMenuItem.Text = "CSV-Editor";
            this.editorSimulatorToolStripMenuItem.Click += new System.EventHandler(this.editorSimulatorToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 450);
            this.Controls.Add(this.panel1);
            this.Name = "MainFrm";
            this.Text = "Monitor FMS Rest";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTray)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEqp)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTrayId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEqpId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgEqp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridView dgTray;
        private System.Windows.Forms.DataGridViewTextBoxColumn TColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TValue;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSec;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPUIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reworkUIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPUIToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reworkUIToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sequenceEditorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mCSimulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mCSimulatorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editorSimulatorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editorSimulatorToolStripMenuItem;
    }
}

