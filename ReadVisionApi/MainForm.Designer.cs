namespace ReadVisionApi
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
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.imageButton = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlResultList = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.pnlImageList = new System.Windows.Forms.Panel();
            this.pnlFlowList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlResultList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.pnlImageList.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultTextBox
            // 
            this.resultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTextBox.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.resultTextBox.Location = new System.Drawing.Point(0, 0);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(526, 790);
            this.resultTextBox.TabIndex = 0;
            // 
            // imageButton
            // 
            this.imageButton.Location = new System.Drawing.Point(12, 12);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(75, 23);
            this.imageButton.TabIndex = 1;
            this.imageButton.Text = "Image";
            this.imageButton.UseVisualStyleBackColor = true;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnExportExcel);
            this.pnlMenu.Controls.Add(this.imageButton);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1198, 47);
            this.pnlMenu.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.pnlResultList);
            this.panel2.Controls.Add(this.pnlImageList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1198, 790);
            this.panel2.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.resultTextBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(229, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(526, 790);
            this.panel5.TabIndex = 3;
            // 
            // pnlResultList
            // 
            this.pnlResultList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlResultList.Controls.Add(this.dgvResult);
            this.pnlResultList.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlResultList.Location = new System.Drawing.Point(755, 0);
            this.pnlResultList.Name = "pnlResultList";
            this.pnlResultList.Size = new System.Drawing.Size(443, 790);
            this.pnlResultList.TabIndex = 2;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(443, 790);
            this.dgvResult.TabIndex = 0;
            // 
            // pnlImageList
            // 
            this.pnlImageList.AutoScroll = true;
            this.pnlImageList.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlImageList.Controls.Add(this.pnlFlowList);
            this.pnlImageList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlImageList.Location = new System.Drawing.Point(0, 0);
            this.pnlImageList.Name = "pnlImageList";
            this.pnlImageList.Size = new System.Drawing.Size(229, 790);
            this.pnlImageList.TabIndex = 1;
            // 
            // pnlFlowList
            // 
            this.pnlFlowList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFlowList.AutoScroll = true;
            this.pnlFlowList.Location = new System.Drawing.Point(8, 6);
            this.pnlFlowList.Name = "pnlFlowList";
            this.pnlFlowList.Size = new System.Drawing.Size(215, 772);
            this.pnlFlowList.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(105, 12);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 2;
            this.btnExportExcel.Text = "Export";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 837);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlMenu);
            this.Name = "MainForm";
            this.Text = "Main";
            this.pnlMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlResultList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.pnlImageList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button imageButton;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlResultList;
        private System.Windows.Forms.Panel pnlImageList;
        private System.Windows.Forms.FlowLayoutPanel pnlFlowList;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnExportExcel;
    }
}

