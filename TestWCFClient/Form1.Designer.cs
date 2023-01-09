namespace TestWCFClient
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
            this.btnWriteTag = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnAlert = new System.Windows.Forms.Button();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWriteTagPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWriteEqpId = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCallOutputCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCallMethod = new System.Windows.Forms.Button();
            this.txtCallInputArg = new System.Windows.Forms.TextBox();
            this.txtCallMethodPath = new System.Windows.Forms.TextBox();
            this.txtCallParentPath = new System.Windows.Forms.TextBox();
            this.txtCallEqpID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cboMethodList = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboEquipment = new System.Windows.Forms.ComboBox();
            this.txtInputArgInfo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWriteTag
            // 
            this.btnWriteTag.Location = new System.Drawing.Point(312, 162);
            this.btnWriteTag.Name = "btnWriteTag";
            this.btnWriteTag.Size = new System.Drawing.Size(75, 23);
            this.btnWriteTag.TabIndex = 0;
            this.btnWriteTag.Text = "Send WCF";
            this.btnWriteTag.UseVisualStyleBackColor = true;
            this.btnWriteTag.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtURL);
            this.panel1.Controls.Add(this.btnAlert);
            this.panel1.Controls.Add(this.txtWriteValue);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtWriteTagPath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtWriteEqpId);
            this.panel1.Controls.Add(this.btnWriteTag);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 206);
            this.panel1.TabIndex = 1;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(17, 15);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(324, 21);
            this.txtURL.TabIndex = 9;
            this.txtURL.Text = "http://localhost:48010/atemfmscmd";
            // 
            // btnAlert
            // 
            this.btnAlert.BackColor = System.Drawing.Color.Tomato;
            this.btnAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlert.Location = new System.Drawing.Point(347, 13);
            this.btnAlert.Name = "btnAlert";
            this.btnAlert.Size = new System.Drawing.Size(39, 23);
            this.btnAlert.TabIndex = 8;
            this.btnAlert.UseVisualStyleBackColor = false;
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(114, 164);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.Size = new System.Drawing.Size(115, 21);
            this.txtWriteValue.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(14, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "TAG Value";
            // 
            // txtWriteTagPath
            // 
            this.txtWriteTagPath.Location = new System.Drawing.Point(114, 131);
            this.txtWriteTagPath.Name = "txtWriteTagPath";
            this.txtWriteTagPath.Size = new System.Drawing.Size(273, 21);
            this.txtWriteTagPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(14, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "TAG Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Write TAG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(14, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Eqp ID";
            // 
            // txtWriteEqpId
            // 
            this.txtWriteEqpId.Location = new System.Drawing.Point(114, 95);
            this.txtWriteEqpId.Name = "txtWriteEqpId";
            this.txtWriteEqpId.Size = new System.Drawing.Size(273, 21);
            this.txtWriteEqpId.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstLog);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtCallOutputCount);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnCallMethod);
            this.panel2.Controls.Add(this.txtCallInputArg);
            this.panel2.Controls.Add(this.txtCallMethodPath);
            this.panel2.Controls.Add(this.txtCallParentPath);
            this.panel2.Controls.Add(this.txtCallEqpID);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(4, 215);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 391);
            this.panel2.TabIndex = 2;
            // 
            // lstLog
            // 
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(17, 265);
            this.lstLog.Name = "lstLog";
            this.lstLog.ScrollAlwaysVisible = true;
            this.lstLog.Size = new System.Drawing.Size(370, 110);
            this.lstLog.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(14, 236);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(199, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "(*) Input은 콤마로 구분해주세요";
            // 
            // txtCallOutputCount
            // 
            this.txtCallOutputCount.Location = new System.Drawing.Point(114, 201);
            this.txtCallOutputCount.Name = "txtCallOutputCount";
            this.txtCallOutputCount.Size = new System.Drawing.Size(273, 21);
            this.txtCallOutputCount.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(14, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Output Count";
            // 
            // btnCallMethod
            // 
            this.btnCallMethod.Location = new System.Drawing.Point(312, 236);
            this.btnCallMethod.Name = "btnCallMethod";
            this.btnCallMethod.Size = new System.Drawing.Size(75, 23);
            this.btnCallMethod.TabIndex = 8;
            this.btnCallMethod.Text = "Send WCF";
            this.btnCallMethod.UseVisualStyleBackColor = true;
            this.btnCallMethod.Click += new System.EventHandler(this.btnCallMethod_Click);
            // 
            // txtCallInputArg
            // 
            this.txtCallInputArg.Location = new System.Drawing.Point(114, 161);
            this.txtCallInputArg.Name = "txtCallInputArg";
            this.txtCallInputArg.Size = new System.Drawing.Size(273, 21);
            this.txtCallInputArg.TabIndex = 13;
            // 
            // txtCallMethodPath
            // 
            this.txtCallMethodPath.Location = new System.Drawing.Point(114, 124);
            this.txtCallMethodPath.Name = "txtCallMethodPath";
            this.txtCallMethodPath.Size = new System.Drawing.Size(273, 21);
            this.txtCallMethodPath.TabIndex = 12;
            // 
            // txtCallParentPath
            // 
            this.txtCallParentPath.Location = new System.Drawing.Point(114, 87);
            this.txtCallParentPath.Name = "txtCallParentPath";
            this.txtCallParentPath.Size = new System.Drawing.Size(273, 21);
            this.txtCallParentPath.TabIndex = 11;
            // 
            // txtCallEqpID
            // 
            this.txtCallEqpID.Location = new System.Drawing.Point(114, 47);
            this.txtCallEqpID.Name = "txtCallEqpID";
            this.txtCallEqpID.Size = new System.Drawing.Size(273, 21);
            this.txtCallEqpID.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(14, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Input Array";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(14, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Method Path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(14, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Parent Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(14, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Eqp ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Call Method";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(422, 614);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.panel4.Controls.Add(this.txtInputArgInfo);
            this.panel4.Controls.Add(this.btnSelect);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.cboMethodList);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.cboEquipment);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(422, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(405, 614);
            this.panel4.TabIndex = 4;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(292, 59);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 21;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(25, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 20;
            this.label13.Text = "Method";
            // 
            // cboMethodList
            // 
            this.cboMethodList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMethodList.FormattingEnabled = true;
            this.cboMethodList.Location = new System.Drawing.Point(80, 61);
            this.cboMethodList.Name = "cboMethodList";
            this.cboMethodList.Size = new System.Drawing.Size(206, 20);
            this.cboMethodList.TabIndex = 19;
            this.cboMethodList.SelectedIndexChanged += new System.EventHandler(this.cboMethodList_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(25, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "Eqp ID";
            // 
            // cboEquipment
            // 
            this.cboEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipment.FormattingEnabled = true;
            this.cboEquipment.Location = new System.Drawing.Point(80, 19);
            this.cboEquipment.Name = "cboEquipment";
            this.cboEquipment.Size = new System.Drawing.Size(121, 20);
            this.cboEquipment.TabIndex = 0;
            this.cboEquipment.SelectedIndexChanged += new System.EventHandler(this.cboEquipment_SelectedIndexChanged);
            // 
            // txtInputArgInfo
            // 
            this.txtInputArgInfo.Location = new System.Drawing.Point(28, 97);
            this.txtInputArgInfo.Multiline = true;
            this.txtInputArgInfo.Name = "txtInputArgInfo";
            this.txtInputArgInfo.Size = new System.Drawing.Size(339, 121);
            this.txtInputArgInfo.TabIndex = 22;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 614);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "MainForm";
            this.Text = "WCF Client for Simple";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWriteTag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWriteTagPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWriteEqpId;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCallMethod;
        private System.Windows.Forms.TextBox txtCallInputArg;
        private System.Windows.Forms.TextBox txtCallMethodPath;
        private System.Windows.Forms.TextBox txtCallParentPath;
        private System.Windows.Forms.TextBox txtCallEqpID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCallOutputCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnAlert;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboMethodList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboEquipment;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtInputArgInfo;
    }
}

