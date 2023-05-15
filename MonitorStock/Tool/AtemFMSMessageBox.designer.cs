namespace AtemFMSOpStationUI.Stations
{
    partial class AtemFMSMessageBox
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelMsg = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.BTNOK = new System.Windows.Forms.Button();
            this.BTN_CANCEL = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.panelMsg.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            //this.panelTop.BackgroundImage = global::AtemFMSOpStationUI.Properties.Resources.freyr_logo;
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(742, 72);
            this.panelTop.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.tbTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 72);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(742, 69);
            this.panelTitle.TabIndex = 1;
            // 
            // panelMsg
            // 
            this.panelMsg.Controls.Add(this.tbMessage);
            this.panelMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMsg.Location = new System.Drawing.Point(0, 141);
            this.panelMsg.Name = "panelMsg";
            this.panelMsg.Size = new System.Drawing.Size(742, 351);
            this.panelMsg.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.BTN_CANCEL);
            this.panelBottom.Controls.Add(this.BTNOK);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 492);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(742, 69);
            this.panelBottom.TabIndex = 0;
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.DarkBlue;
            this.tbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.ForeColor = System.Drawing.Color.Gold;
            this.tbTitle.Location = new System.Drawing.Point(0, 0);
            this.tbTitle.Multiline = true;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Size = new System.Drawing.Size(742, 69);
            this.tbTitle.TabIndex = 0;
            this.tbTitle.Text = "Title...";
            this.tbTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMessage
            // 
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessage.Location = new System.Drawing.Point(0, 0);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.Size = new System.Drawing.Size(742, 351);
            this.tbMessage.TabIndex = 0;
            this.tbMessage.Text = "Message...";
            this.tbMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BTNOK
            // 
            this.BTNOK.BackColor = System.Drawing.Color.SpringGreen;
            this.BTNOK.Location = new System.Drawing.Point(12, 3);
            this.BTNOK.Name = "BTNOK";
            this.BTNOK.Size = new System.Drawing.Size(352, 62);
            this.BTNOK.TabIndex = 0;
            this.BTNOK.Text = "YES";
            this.BTNOK.UseVisualStyleBackColor = false;
            this.BTNOK.Click += new System.EventHandler(this.BTNOK_Click);
            // 
            // BTN_CANCEL
            // 
            this.BTN_CANCEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_CANCEL.BackColor = System.Drawing.Color.LightPink;
            this.BTN_CANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_CANCEL.Location = new System.Drawing.Point(378, 3);
            this.BTN_CANCEL.Name = "BTN_CANCEL";
            this.BTN_CANCEL.Size = new System.Drawing.Size(352, 62);
            this.BTN_CANCEL.TabIndex = 1;
            this.BTN_CANCEL.Text = "NO";
            this.BTN_CANCEL.UseVisualStyleBackColor = false;
            this.BTN_CANCEL.Click += new System.EventHandler(this.BTN_CANCEL_Click);
            // 
            // AtemFMSMessageBox
            // 
            this.AcceptButton = this.BTNOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_CANCEL;
            this.ClientSize = new System.Drawing.Size(742, 561);
            this.Controls.Add(this.panelMsg);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "AtemFMSMessageBox";
            this.Text = "HMI MESSAGE";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelMsg.ResumeLayout(false);
            this.panelMsg.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Panel panelMsg;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button BTN_CANCEL;
        private System.Windows.Forms.Button BTNOK;
    }
}