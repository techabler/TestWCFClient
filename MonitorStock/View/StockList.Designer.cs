namespace MonitorStock
{
    partial class UCStockList
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgsStockList = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnBookMark = new System.Windows.Forms.Button();
            this.cbBookMark = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMarket = new System.Windows.Forms.ComboBox();
            this.txtStockName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgsStockList)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgsStockList
            // 
            this.dgsStockList.AllowUserToAddRows = false;
            this.dgsStockList.AllowUserToDeleteRows = false;
            this.dgsStockList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgsStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsStockList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsStockList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgsStockList.Location = new System.Drawing.Point(0, 0);
            this.dgsStockList.MultiSelect = false;
            this.dgsStockList.Name = "dgsStockList";
            this.dgsStockList.ReadOnly = true;
            this.dgsStockList.RowTemplate.Height = 23;
            this.dgsStockList.Size = new System.Drawing.Size(959, 552);
            this.dgsStockList.TabIndex = 0;
            this.dgsStockList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsStockList_CellClick);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlSearch.Controls.Add(this.btnBookMark);
            this.pnlSearch.Controls.Add(this.cbBookMark);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.label3);
            this.pnlSearch.Controls.Add(this.txtStockCode);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.cbMarket);
            this.pnlSearch.Controls.Add(this.txtStockName);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(6);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(959, 42);
            this.pnlSearch.TabIndex = 1;
            // 
            // btnBookMark
            // 
            this.btnBookMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookMark.Location = new System.Drawing.Point(881, 8);
            this.btnBookMark.Name = "btnBookMark";
            this.btnBookMark.Size = new System.Drawing.Size(75, 23);
            this.btnBookMark.TabIndex = 8;
            this.btnBookMark.Text = "등록";
            this.btnBookMark.UseVisualStyleBackColor = true;
            this.btnBookMark.Click += new System.EventHandler(this.btnBookMark_Click);
            // 
            // cbBookMark
            // 
            this.cbBookMark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBookMark.FormattingEnabled = true;
            this.cbBookMark.Location = new System.Drawing.Point(702, 9);
            this.cbBookMark.Name = "cbBookMark";
            this.cbBookMark.Size = new System.Drawing.Size(173, 20);
            this.cbBookMark.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(570, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "종목코드";
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(260, 9);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(88, 21);
            this.txtStockCode.TabIndex = 4;
            this.txtStockCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStockCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "종목명";
            // 
            // cbMarket
            // 
            this.cbMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarket.FormattingEnabled = true;
            this.cbMarket.Location = new System.Drawing.Point(64, 11);
            this.cbMarket.Name = "cbMarket";
            this.cbMarket.Size = new System.Drawing.Size(121, 20);
            this.cbMarket.TabIndex = 2;
            this.cbMarket.SelectedIndexChanged += new System.EventHandler(this.cbMarket_SelectedIndexChanged);
            // 
            // txtStockName
            // 
            this.txtStockName.Location = new System.Drawing.Point(415, 10);
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(140, 21);
            this.txtStockName.TabIndex = 1;
            this.txtStockName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStockName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Market";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgsStockList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 552);
            this.panel2.TabIndex = 2;
            // 
            // UCStockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlSearch);
            this.Name = "UCStockList";
            this.Size = new System.Drawing.Size(959, 594);
            this.Load += new System.EventHandler(this.UCStockList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgsStockList)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgsStockList;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMarket;
        private System.Windows.Forms.TextBox txtStockName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Button btnBookMark;
        private System.Windows.Forms.ComboBox cbBookMark;
    }
}
