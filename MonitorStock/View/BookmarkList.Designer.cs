namespace MonitorStock
{
    partial class UCBookmarkList
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbBookmark = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.cbMarket = new System.Windows.Forms.ComboBox();
            this.lbMarket = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvBookmarkList = new System.Windows.Forms.DataGridView();
            this.lbDate = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.btnCompare = new System.Windows.Forms.Button();
            this.pnlSearch.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookmarkList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnCompare);
            this.pnlSearch.Controls.Add(this.dtPicker);
            this.pnlSearch.Controls.Add(this.lbDate);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.cbBookmark);
            this.pnlSearch.Controls.Add(this.lbType);
            this.pnlSearch.Controls.Add(this.cbMarket);
            this.pnlSearch.Controls.Add(this.lbMarket);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(821, 56);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(603, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbBookmark
            // 
            this.cbBookmark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBookmark.FormattingEnabled = true;
            this.cbBookmark.Location = new System.Drawing.Point(308, 18);
            this.cbBookmark.Name = "cbBookmark";
            this.cbBookmark.Size = new System.Drawing.Size(121, 20);
            this.cbBookmark.TabIndex = 3;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(208, 22);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(94, 12);
            this.lbType.TabIndex = 2;
            this.lbType.Text = "Bookmark Type";
            // 
            // cbMarket
            // 
            this.cbMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarket.FormattingEnabled = true;
            this.cbMarket.Location = new System.Drawing.Point(65, 19);
            this.cbMarket.Name = "cbMarket";
            this.cbMarket.Size = new System.Drawing.Size(121, 20);
            this.cbMarket.TabIndex = 1;
            // 
            // lbMarket
            // 
            this.lbMarket.AutoSize = true;
            this.lbMarket.Location = new System.Drawing.Point(16, 22);
            this.lbMarket.Name = "lbMarket";
            this.lbMarket.Size = new System.Drawing.Size(43, 12);
            this.lbMarket.TabIndex = 0;
            this.lbMarket.Text = "Market";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.dgvBookmarkList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 56);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(821, 535);
            this.pnlBody.TabIndex = 1;
            // 
            // dgvBookmarkList
            // 
            this.dgvBookmarkList.AllowUserToAddRows = false;
            this.dgvBookmarkList.AllowUserToDeleteRows = false;
            this.dgvBookmarkList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookmarkList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookmarkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookmarkList.Location = new System.Drawing.Point(0, 0);
            this.dgvBookmarkList.MultiSelect = false;
            this.dgvBookmarkList.Name = "dgvBookmarkList";
            this.dgvBookmarkList.RowTemplate.Height = 23;
            this.dgvBookmarkList.Size = new System.Drawing.Size(821, 535);
            this.dgvBookmarkList.TabIndex = 0;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(453, 21);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(30, 12);
            this.lbDate.TabIndex = 8;
            this.lbDate.Text = "Date";
            // 
            // dtPicker
            // 
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker.Location = new System.Drawing.Point(489, 18);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(108, 21);
            this.dtPicker.TabIndex = 1;
            this.dtPicker.Value = new System.DateTime(2023, 7, 11, 0, 0, 0, 0);
            // 
            // btnCompare
            // 
            this.btnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompare.Location = new System.Drawing.Point(743, 15);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 9;
            this.btnCompare.Text = "비교하기";
            this.btnCompare.UseVisualStyleBackColor = true;
            // 
            // UCBookmarkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlSearch);
            this.Name = "UCBookmarkList";
            this.Size = new System.Drawing.Size(821, 591);
            this.Load += new System.EventHandler(this.BookmarkList_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookmarkList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.ComboBox cbMarket;
        private System.Windows.Forms.Label lbMarket;
        private System.Windows.Forms.ComboBox cbBookmark;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvBookmarkList;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.Button btnCompare;
    }
}
