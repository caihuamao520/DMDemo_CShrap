namespace DMDemo
{
    partial class fro_HwndAndOCR_PlanA
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
            this.btnsynData = new System.Windows.Forms.Button();
            this.btnGetHwnd = new System.Windows.Forms.Button();
            this.labHwendTitle = new System.Windows.Forms.Label();
            this.txtHwndPath = new System.Windows.Forms.TextBox();
            this.txtHwndConfig = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbHwndSrceen = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labOCRConten = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkAdvnSet = new System.Windows.Forms.LinkLabel();
            this.linkClear = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnsynData
            // 
            this.btnsynData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsynData.Location = new System.Drawing.Point(431, 25);
            this.btnsynData.Name = "btnsynData";
            this.btnsynData.Size = new System.Drawing.Size(91, 42);
            this.btnsynData.TabIndex = 0;
            this.btnsynData.Text = "同步获取数据";
            this.btnsynData.UseVisualStyleBackColor = true;
            this.btnsynData.Click += new System.EventHandler(this.btnsynData_Click);
            // 
            // btnGetHwnd
            // 
            this.btnGetHwnd.Location = new System.Drawing.Point(12, 12);
            this.btnGetHwnd.Name = "btnGetHwnd";
            this.btnGetHwnd.Size = new System.Drawing.Size(86, 37);
            this.btnGetHwnd.TabIndex = 1;
            this.btnGetHwnd.Text = "获取句柄";
            this.btnGetHwnd.UseVisualStyleBackColor = true;
            this.btnGetHwnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGetHwnd_MouseDown);
            // 
            // labHwendTitle
            // 
            this.labHwendTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labHwendTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHwendTitle.ForeColor = System.Drawing.Color.Red;
            this.labHwendTitle.Location = new System.Drawing.Point(119, 12);
            this.labHwendTitle.Name = "labHwendTitle";
            this.labHwendTitle.Size = new System.Drawing.Size(418, 37);
            this.labHwendTitle.TabIndex = 2;
            this.labHwendTitle.Text = "---";
            this.labHwendTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtHwndPath
            // 
            this.txtHwndPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHwndPath.Location = new System.Drawing.Point(12, 62);
            this.txtHwndPath.Name = "txtHwndPath";
            this.txtHwndPath.ReadOnly = true;
            this.txtHwndPath.Size = new System.Drawing.Size(525, 21);
            this.txtHwndPath.TabIndex = 5;
            // 
            // txtHwndConfig
            // 
            this.txtHwndConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHwndConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHwndConfig.Location = new System.Drawing.Point(12, 89);
            this.txtHwndConfig.Multiline = true;
            this.txtHwndConfig.Name = "txtHwndConfig";
            this.txtHwndConfig.ReadOnly = true;
            this.txtHwndConfig.Size = new System.Drawing.Size(525, 78);
            this.txtHwndConfig.TabIndex = 6;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLog.Location = new System.Drawing.Point(0, 25);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(425, 167);
            this.txtLog.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "同步获取日志：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.linkClear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnsynData);
            this.panel1.Controls.Add(this.txtLog);
            this.panel1.Location = new System.Drawing.Point(12, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 198);
            this.panel1.TabIndex = 9;
            // 
            // ckbHwndSrceen
            // 
            this.ckbHwndSrceen.AutoSize = true;
            this.ckbHwndSrceen.Checked = true;
            this.ckbHwndSrceen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbHwndSrceen.Location = new System.Drawing.Point(12, 179);
            this.ckbHwndSrceen.Name = "ckbHwndSrceen";
            this.ckbHwndSrceen.Size = new System.Drawing.Size(96, 16);
            this.ckbHwndSrceen.TabIndex = 10;
            this.ckbHwndSrceen.Text = "句柄截图识别";
            this.ckbHwndSrceen.UseVisualStyleBackColor = true;
            this.ckbHwndSrceen.CheckedChanged += new System.EventHandler(this.ckbHwndSrceen_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.linkAdvnSet);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labOCRConten);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(12, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 117);
            this.panel2.TabIndex = 12;
            // 
            // labOCRConten
            // 
            this.labOCRConten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labOCRConten.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labOCRConten.ForeColor = System.Drawing.Color.Red;
            this.labOCRConten.Location = new System.Drawing.Point(275, 28);
            this.labOCRConten.Name = "labOCRConten";
            this.labOCRConten.Size = new System.Drawing.Size(244, 55);
            this.labOCRConten.TabIndex = 12;
            this.labOCRConten.Text = "---";
            this.labOCRConten.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "识别内容：";
            // 
            // linkAdvnSet
            // 
            this.linkAdvnSet.AutoSize = true;
            this.linkAdvnSet.Location = new System.Drawing.Point(443, 95);
            this.linkAdvnSet.Name = "linkAdvnSet";
            this.linkAdvnSet.Size = new System.Drawing.Size(77, 12);
            this.linkAdvnSet.TabIndex = 14;
            this.linkAdvnSet.TabStop = true;
            this.linkAdvnSet.Text = "识别高级设置";
            this.linkAdvnSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAdvnSet_LinkClicked);
            // 
            // linkClear
            // 
            this.linkClear.AutoSize = true;
            this.linkClear.Location = new System.Drawing.Point(431, 180);
            this.linkClear.Name = "linkClear";
            this.linkClear.Size = new System.Drawing.Size(53, 12);
            this.linkClear.TabIndex = 15;
            this.linkClear.TabStop = true;
            this.linkClear.Text = "清空日志";
            this.linkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClear_LinkClicked);
            // 
            // fro_HwndAndOCR_PlanA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 532);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ckbHwndSrceen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtHwndConfig);
            this.Controls.Add(this.txtHwndPath);
            this.Controls.Add(this.labHwendTitle);
            this.Controls.Add(this.btnGetHwnd);
            this.Name = "fro_HwndAndOCR_PlanA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "窗体识别+OCR";
            this.Load += new System.EventHandler(this.fro_HwndAndOCR_PlanA_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsynData;
        private System.Windows.Forms.Button btnGetHwnd;
        private System.Windows.Forms.Label labHwendTitle;
        private System.Windows.Forms.TextBox txtHwndPath;
        private System.Windows.Forms.TextBox txtHwndConfig;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckbHwndSrceen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labOCRConten;
        private System.Windows.Forms.LinkLabel linkAdvnSet;
        private System.Windows.Forms.LinkLabel linkClear;
    }
}