namespace DetectIdleTime
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
            this.components = new System.ComponentModel.Container();
            this.lbStartTickCount = new System.Windows.Forms.Label();
            this.lbIdleTickCount = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.SessionTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbStartTickCount
            // 
            this.lbStartTickCount.AutoSize = true;
            this.lbStartTickCount.Location = new System.Drawing.Point(111, 53);
            this.lbStartTickCount.Name = "lbStartTickCount";
            this.lbStartTickCount.Size = new System.Drawing.Size(113, 12);
            this.lbStartTickCount.TabIndex = 0;
            this.lbStartTickCount.Text = "Windows Idle Time";
            // 
            // lbIdleTickCount
            // 
            this.lbIdleTickCount.AutoSize = true;
            this.lbIdleTickCount.Location = new System.Drawing.Point(128, 94);
            this.lbIdleTickCount.Name = "lbIdleTickCount";
            this.lbIdleTickCount.Size = new System.Drawing.Size(86, 12);
            this.lbIdleTickCount.TabIndex = 1;
            this.lbIdleTickCount.Text = "Idle Tick Time";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 174);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(339, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(17, 17);
            this.tsStatus.Text = "\"\"";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 196);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbIdleTickCount);
            this.Controls.Add(this.lbStartTickCount);
            this.Name = "MainForm";
            this.Text = "Detect Idle Time";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStartTickCount;
        private System.Windows.Forms.Label lbIdleTickCount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.Timer SessionTimer;
    }
}

