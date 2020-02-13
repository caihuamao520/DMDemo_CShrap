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
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectHwnd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMousePoint = new System.Windows.Forms.TextBox();
            this.btnLikeHwnd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLikeTitle = new System.Windows.Forms.TextBox();
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
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(28, 295);
            this.txtClassName.Multiline = true;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.ReadOnly = true;
            this.txtClassName.Size = new System.Drawing.Size(223, 21);
            this.txtClassName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "类名：";
            // 
            // btnSelectHwnd
            // 
            this.btnSelectHwnd.Location = new System.Drawing.Point(267, 239);
            this.btnSelectHwnd.Name = "btnSelectHwnd";
            this.btnSelectHwnd.Size = new System.Drawing.Size(131, 33);
            this.btnSelectHwnd.TabIndex = 9;
            this.btnSelectHwnd.Text = "坐标查找句柄";
            this.btnSelectHwnd.UseVisualStyleBackColor = true;
            this.btnSelectHwnd.Click += new System.EventHandler(this.btnSelectHwnd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "鼠标位置：";
            // 
            // txtMousePoint
            // 
            this.txtMousePoint.Location = new System.Drawing.Point(94, 246);
            this.txtMousePoint.Name = "txtMousePoint";
            this.txtMousePoint.Size = new System.Drawing.Size(157, 21);
            this.txtMousePoint.TabIndex = 13;
            // 
            // btnLikeHwnd
            // 
            this.btnLikeHwnd.Location = new System.Drawing.Point(267, 295);
            this.btnLikeHwnd.Name = "btnLikeHwnd";
            this.btnLikeHwnd.Size = new System.Drawing.Size(131, 68);
            this.btnLikeHwnd.TabIndex = 14;
            this.btnLikeHwnd.Text = "父窗体+内容模糊查找句柄";
            this.btnLikeHwnd.UseVisualStyleBackColor = true;
            this.btnLikeHwnd.Click += new System.EventHandler(this.btnLikeHwnd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "文本内容（模糊查找）：";
            // 
            // txtLikeTitle
            // 
            this.txtLikeTitle.Location = new System.Drawing.Point(26, 342);
            this.txtLikeTitle.Multiline = true;
            this.txtLikeTitle.Name = "txtLikeTitle";
            this.txtLikeTitle.Size = new System.Drawing.Size(225, 21);
            this.txtLikeTitle.TabIndex = 15;
            // 
            // HwndGetTitleFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 391);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLikeTitle);
            this.Controls.Add(this.btnLikeHwnd);
            this.Controls.Add(this.txtMousePoint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSelectHwnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClassName);
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
            this.Name = "HwndGetTitleFrom";
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
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectHwnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMousePoint;
        private System.Windows.Forms.Button btnLikeHwnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLikeTitle;
    }
}

