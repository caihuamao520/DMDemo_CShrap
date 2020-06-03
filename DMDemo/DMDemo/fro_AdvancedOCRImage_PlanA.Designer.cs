namespace DMDemo
{
    partial class fro_AdvancedOCRImage_PlanA
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbPintScreenIsHide = new System.Windows.Forms.CheckBox();
            this.btnPintScrenn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.getTopFrom = new System.Windows.Forms.Button();
            this.btnShowFrom = new System.Windows.Forms.Button();
            this.btnHiderFrom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetAllWinFrom = new System.Windows.Forms.Button();
            this.btnHideAllForm = new System.Windows.Forms.Button();
            this.btnReceviFrom = new System.Windows.Forms.Button();
            this.chkStopCloseFrom = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 411);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择的图像";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(504, 391);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chkStopCloseFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ckbPintScreenIsHide);
            this.panel1.Controls.Add(this.btnPintScrenn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 91);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "截屏快捷键：Ctrl + ATL + Q";
            // 
            // ckbPintScreenIsHide
            // 
            this.ckbPintScreenIsHide.AutoSize = true;
            this.ckbPintScreenIsHide.Checked = true;
            this.ckbPintScreenIsHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbPintScreenIsHide.Location = new System.Drawing.Point(18, 20);
            this.ckbPintScreenIsHide.Name = "ckbPintScreenIsHide";
            this.ckbPintScreenIsHide.Size = new System.Drawing.Size(108, 16);
            this.ckbPintScreenIsHide.TabIndex = 8;
            this.ckbPintScreenIsHide.Text = "截屏时隐藏自己";
            this.ckbPintScreenIsHide.UseVisualStyleBackColor = true;
            // 
            // btnPintScrenn
            // 
            this.btnPintScrenn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPintScrenn.Location = new System.Drawing.Point(347, 20);
            this.btnPintScrenn.Name = "btnPintScrenn";
            this.btnPintScrenn.Size = new System.Drawing.Size(142, 47);
            this.btnPintScrenn.TabIndex = 7;
            this.btnPintScrenn.Text = "开始截图";
            this.btnPintScrenn.UseVisualStyleBackColor = true;
            this.btnPintScrenn.Click += new System.EventHandler(this.btnPintScrenn_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(6, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(453, 293);
            this.listBox1.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnGetAllWinFrom);
            this.groupBox2.Controls.Add(this.btnHideAllForm);
            this.groupBox2.Controls.Add(this.btnReceviFrom);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(528, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 508);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DM操作";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.getTopFrom);
            this.groupBox3.Controls.Add(this.btnShowFrom);
            this.groupBox3.Controls.Add(this.btnHiderFrom);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(6, 377);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(453, 128);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "信息";
            // 
            // getTopFrom
            // 
            this.getTopFrom.Location = new System.Drawing.Point(237, 65);
            this.getTopFrom.Name = "getTopFrom";
            this.getTopFrom.Size = new System.Drawing.Size(123, 23);
            this.getTopFrom.TabIndex = 3;
            this.getTopFrom.Text = "当前活动窗体信息";
            this.getTopFrom.UseVisualStyleBackColor = true;
            this.getTopFrom.Click += new System.EventHandler(this.getTopFrom_Click);
            // 
            // btnShowFrom
            // 
            this.btnShowFrom.Location = new System.Drawing.Point(140, 65);
            this.btnShowFrom.Name = "btnShowFrom";
            this.btnShowFrom.Size = new System.Drawing.Size(75, 23);
            this.btnShowFrom.TabIndex = 2;
            this.btnShowFrom.Text = "显示";
            this.btnShowFrom.UseVisualStyleBackColor = true;
            this.btnShowFrom.Click += new System.EventHandler(this.btnShowFrom_Click);
            // 
            // btnHiderFrom
            // 
            this.btnHiderFrom.Location = new System.Drawing.Point(43, 65);
            this.btnHiderFrom.Name = "btnHiderFrom";
            this.btnHiderFrom.Size = new System.Drawing.Size(75, 23);
            this.btnHiderFrom.TabIndex = 1;
            this.btnHiderFrom.Text = "隐藏";
            this.btnHiderFrom.UseVisualStyleBackColor = true;
            this.btnHiderFrom.Click += new System.EventHandler(this.btnHiderFrom_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(29, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "信息：";
            // 
            // btnGetAllWinFrom
            // 
            this.btnGetAllWinFrom.Location = new System.Drawing.Point(37, 20);
            this.btnGetAllWinFrom.Name = "btnGetAllWinFrom";
            this.btnGetAllWinFrom.Size = new System.Drawing.Size(115, 33);
            this.btnGetAllWinFrom.TabIndex = 16;
            this.btnGetAllWinFrom.Text = "获取所有窗体";
            this.btnGetAllWinFrom.UseVisualStyleBackColor = true;
            this.btnGetAllWinFrom.Click += new System.EventHandler(this.btnGetAllForm_Click);
            // 
            // btnHideAllForm
            // 
            this.btnHideAllForm.Location = new System.Drawing.Point(180, 20);
            this.btnHideAllForm.Name = "btnHideAllForm";
            this.btnHideAllForm.Size = new System.Drawing.Size(115, 33);
            this.btnHideAllForm.TabIndex = 15;
            this.btnHideAllForm.Text = "隐藏所有窗体";
            this.btnHideAllForm.UseVisualStyleBackColor = true;
            this.btnHideAllForm.Click += new System.EventHandler(this.btnHideAllForm_Click);
            // 
            // btnReceviFrom
            // 
            this.btnReceviFrom.Location = new System.Drawing.Point(313, 20);
            this.btnReceviFrom.Name = "btnReceviFrom";
            this.btnReceviFrom.Size = new System.Drawing.Size(115, 33);
            this.btnReceviFrom.TabIndex = 14;
            this.btnReceviFrom.Text = "恢复所有窗体";
            this.btnReceviFrom.UseVisualStyleBackColor = true;
            this.btnReceviFrom.Click += new System.EventHandler(this.btnReceviFrom_Click);
            // 
            // chkStopCloseFrom
            // 
            this.chkStopCloseFrom.AutoSize = true;
            this.chkStopCloseFrom.Location = new System.Drawing.Point(156, 20);
            this.chkStopCloseFrom.Name = "chkStopCloseFrom";
            this.chkStopCloseFrom.Size = new System.Drawing.Size(96, 16);
            this.chkStopCloseFrom.TabIndex = 10;
            this.chkStopCloseFrom.Text = "拦截关闭窗口";
            this.chkStopCloseFrom.UseVisualStyleBackColor = true;
            // 
            // fro_AdvancedOCRImage_PlanA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 532);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fro_AdvancedOCRImage_PlanA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "任务管理器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fro_AdvancedOCRImage_PlanA_FormClosing);
            this.Load += new System.EventHandler(this.fro_AdvancedOCRImage_PlanA_Load);
            this.LocationChanged += new System.EventHandler(this.fro_AdvancedOCRImage_PlanA_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.fro_AdvancedOCRImage_PlanA_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPintScrenn;
        private System.Windows.Forms.CheckBox ckbPintScreenIsHide;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReceviFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHideAllForm;
        private System.Windows.Forms.Button btnGetAllWinFrom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnShowFrom;
        private System.Windows.Forms.Button btnHiderFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getTopFrom;
        private System.Windows.Forms.CheckBox chkStopCloseFrom;
    }
}