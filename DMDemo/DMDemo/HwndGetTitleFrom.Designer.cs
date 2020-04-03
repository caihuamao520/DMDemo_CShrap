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
            this.btnLikeHwnd2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtParentClassName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtParentTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOffsetPoint = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTopFormTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTopFormClassName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbIsHidForm = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.txtTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTitle.Location = new System.Drawing.Point(26, 90);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(620, 234);
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
            this.btnRealTimeGetHwndData.Location = new System.Drawing.Point(661, 283);
            this.btnRealTimeGetHwndData.Name = "btnRealTimeGetHwndData";
            this.btnRealTimeGetHwndData.Size = new System.Drawing.Size(131, 41);
            this.btnRealTimeGetHwndData.TabIndex = 5;
            this.btnRealTimeGetHwndData.Text = "同步当前数据";
            this.btnRealTimeGetHwndData.UseVisualStyleBackColor = true;
            this.btnRealTimeGetHwndData.Click += new System.EventHandler(this.btnRealTimeGetHwndData_Click);
            // 
            // linkRegsActiveX
            // 
            this.linkRegsActiveX.AutoSize = true;
            this.linkRegsActiveX.Location = new System.Drawing.Point(668, 244);
            this.linkRegsActiveX.Name = "linkRegsActiveX";
            this.linkRegsActiveX.Size = new System.Drawing.Size(77, 12);
            this.linkRegsActiveX.TabIndex = 6;
            this.linkRegsActiveX.TabStop = true;
            this.linkRegsActiveX.Text = "重新注册组件";
            this.linkRegsActiveX.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegsActiveX_LinkClicked);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(11, 76);
            this.txtClassName.Multiline = true;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.ReadOnly = true;
            this.txtClassName.Size = new System.Drawing.Size(223, 21);
            this.txtClassName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "类名：";
            // 
            // btnSelectHwnd
            // 
            this.btnSelectHwnd.Location = new System.Drawing.Point(250, 20);
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
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "鼠标位置：";
            // 
            // txtMousePoint
            // 
            this.txtMousePoint.Location = new System.Drawing.Point(77, 27);
            this.txtMousePoint.Name = "txtMousePoint";
            this.txtMousePoint.Size = new System.Drawing.Size(157, 21);
            this.txtMousePoint.TabIndex = 13;
            // 
            // btnLikeHwnd
            // 
            this.btnLikeHwnd.Location = new System.Drawing.Point(250, 76);
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
            this.label6.Location = new System.Drawing.Point(7, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "文本内容（模糊查找）：";
            // 
            // txtLikeTitle
            // 
            this.txtLikeTitle.Location = new System.Drawing.Point(9, 123);
            this.txtLikeTitle.Multiline = true;
            this.txtLikeTitle.Name = "txtLikeTitle";
            this.txtLikeTitle.Size = new System.Drawing.Size(225, 21);
            this.txtLikeTitle.TabIndex = 15;
            // 
            // btnLikeHwnd2
            // 
            this.btnLikeHwnd2.Location = new System.Drawing.Point(249, 118);
            this.btnLikeHwnd2.Name = "btnLikeHwnd2";
            this.btnLikeHwnd2.Size = new System.Drawing.Size(131, 84);
            this.btnLikeHwnd2.TabIndex = 17;
            this.btnLikeHwnd2.Text = "父窗体+间距查找句柄";
            this.btnLikeHwnd2.UseVisualStyleBackColor = true;
            this.btnLikeHwnd2.Click += new System.EventHandler(this.btnLikeHwnd2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtClassName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLikeTitle);
            this.groupBox1.Controls.Add(this.btnSelectHwnd);
            this.groupBox1.Controls.Add(this.btnLikeHwnd);
            this.groupBox1.Controls.Add(this.txtMousePoint);
            this.groupBox1.Location = new System.Drawing.Point(20, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 173);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "方式1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtParentClassName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtParentTitle);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtOffsetPoint);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtTopFormTitle);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTopFormClassName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnLikeHwnd2);
            this.groupBox2.Location = new System.Drawing.Point(412, 334);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 258);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "方式2(目前最靠谱)";
            // 
            // txtParentClassName
            // 
            this.txtParentClassName.Location = new System.Drawing.Point(11, 222);
            this.txtParentClassName.Multiline = true;
            this.txtParentClassName.Name = "txtParentClassName";
            this.txtParentClassName.Size = new System.Drawing.Size(369, 21);
            this.txtParentClassName.TabIndex = 26;
            this.txtParentClassName.Text = "WindowsForms10.Window.8.app.0.14b2c3b_r9_ad1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "父窗体类名：";
            // 
            // txtParentTitle
            // 
            this.txtParentTitle.Location = new System.Drawing.Point(11, 176);
            this.txtParentTitle.Multiline = true;
            this.txtParentTitle.Name = "txtParentTitle";
            this.txtParentTitle.Size = new System.Drawing.Size(223, 21);
            this.txtParentTitle.TabIndex = 24;
            this.txtParentTitle.Text = "收 款";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "父窗体文本：";
            // 
            // txtOffsetPoint
            // 
            this.txtOffsetPoint.Location = new System.Drawing.Point(11, 133);
            this.txtOffsetPoint.Multiline = true;
            this.txtOffsetPoint.Name = "txtOffsetPoint";
            this.txtOffsetPoint.Size = new System.Drawing.Size(223, 21);
            this.txtOffsetPoint.TabIndex = 22;
            this.txtOffsetPoint.Text = "813,695";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "组件距离顶层窗体的偏移量：";
            // 
            // txtTopFormTitle
            // 
            this.txtTopFormTitle.Location = new System.Drawing.Point(11, 88);
            this.txtTopFormTitle.Multiline = true;
            this.txtTopFormTitle.Name = "txtTopFormTitle";
            this.txtTopFormTitle.Size = new System.Drawing.Size(223, 21);
            this.txtTopFormTitle.TabIndex = 20;
            this.txtTopFormTitle.Text = "收银系统";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "顶层窗体文本：";
            // 
            // txtTopFormClassName
            // 
            this.txtTopFormClassName.Location = new System.Drawing.Point(11, 40);
            this.txtTopFormClassName.Multiline = true;
            this.txtTopFormClassName.Name = "txtTopFormClassName";
            this.txtTopFormClassName.Size = new System.Drawing.Size(369, 21);
            this.txtTopFormClassName.TabIndex = 18;
            this.txtTopFormClassName.Text = "WindowsForms10.Window.8.app.0.14b2c3b_r9_ad1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "顶层窗体类名：";
            // 
            // ckbIsHidForm
            // 
            this.ckbIsHidForm.AutoSize = true;
            this.ckbIsHidForm.Location = new System.Drawing.Point(423, 48);
            this.ckbIsHidForm.Name = "ckbIsHidForm";
            this.ckbIsHidForm.Size = new System.Drawing.Size(156, 16);
            this.ckbIsHidForm.TabIndex = 22;
            this.ckbIsHidForm.Text = "获取位置时隐藏当前窗口";
            this.ckbIsHidForm.UseVisualStyleBackColor = true;
            // 
            // HwndGetTitleFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 595);
            this.Controls.Add(this.ckbIsHidForm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button btnLikeHwnd2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOffsetPoint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTopFormTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTopFormClassName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtParentClassName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtParentTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckbIsHidForm;
    }
}

