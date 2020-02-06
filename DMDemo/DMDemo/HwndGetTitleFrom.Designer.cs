namespace DMDemo
{
    partial class HwndGetTitleFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HwndGetTitleFrom));
            this.btnGetActiveLocation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtHwnd = new System.Windows.Forms.TextBox();
            this.btnRealTimeGetHwndData = new System.Windows.Forms.Button();
            this.linkRegsActiveX = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnGetActiveLocation
            // 
            this.btnGetActiveLocation.Location = new System.Drawing.Point(267, 30);
            this.btnGetActiveLocation.Name = "btnGetActiveLocation";
            this.btnGetActiveLocation.Size = new System.Drawing.Size(131, 34);
            this.btnGetActiveLocation.TabIndex = 0;
            this.btnGetActiveLocation.Text = "获取位置";
            this.btnGetActiveLocation.UseVisualStyleBackColor = true;
            this.btnGetActiveLocation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGetActiveLocation_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "句柄：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "内容：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(26, 90);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(226, 138);
            this.txtTitle.TabIndex = 3;
            // 
            // txtHwnd
            // 
            this.txtHwnd.Location = new System.Drawing.Point(26, 38);
            this.txtHwnd.Name = "txtHwnd";
            this.txtHwnd.ReadOnly = true;
            this.txtHwnd.Size = new System.Drawing.Size(226, 21);
            this.txtHwnd.TabIndex = 4;
            this.txtHwnd.TextChanged += new System.EventHandler(this.txtHwnd_TextChanged);
            // 
            // btnRealTimeGetHwndData
            // 
            this.btnRealTimeGetHwndData.Enabled = false;
            this.btnRealTimeGetHwndData.Location = new System.Drawing.Point(267, 187);
            this.btnRealTimeGetHwndData.Name = "btnRealTimeGetHwndData";
            this.btnRealTimeGetHwndData.Size = new System.Drawing.Size(131, 41);
            this.btnRealTimeGetHwndData.TabIndex = 5;
            this.btnRealTimeGetHwndData.Text = "开始同步获取内容";
            this.btnRealTimeGetHwndData.UseVisualStyleBackColor = true;
            this.btnRealTimeGetHwndData.Click += new System.EventHandler(this.btnRealTimeGetHwndData_Click);
            // 
            // linkRegsActiveX
            // 
            this.linkRegsActiveX.AutoSize = true;
            this.linkRegsActiveX.Location = new System.Drawing.Point(265, 138);
            this.linkRegsActiveX.Name = "linkRegsActiveX";
            this.linkRegsActiveX.Size = new System.Drawing.Size(77, 12);
            this.linkRegsActiveX.TabIndex = 6;
            this.linkRegsActiveX.TabStop = true;
            this.linkRegsActiveX.Text = "重新注册组件";
            this.linkRegsActiveX.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegsActiveX_LinkClicked);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 249);
            this.Controls.Add(this.linkRegsActiveX);
            this.Controls.Add(this.btnRealTimeGetHwndData);
            this.Controls.Add(this.txtHwnd);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetActiveLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能识别窗体DEMO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrom_FormClosing);
            this.Load += new System.EventHandler(this.MainFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetActiveLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtHwnd;
        private System.Windows.Forms.Button btnRealTimeGetHwndData;
        private System.Windows.Forms.LinkLabel linkRegsActiveX;
    }
}

