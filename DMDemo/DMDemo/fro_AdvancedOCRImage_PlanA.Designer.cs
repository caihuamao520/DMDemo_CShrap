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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSrceen = new System.Windows.Forms.ComboBox();
            this.ckbcurrenFromScrenn = new System.Windows.Forms.CheckBox();
            this.btnPintScrenn = new System.Windows.Forms.Button();
            this.ckbPintScreenIsHide = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 394);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统粘贴板图像";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(786, 374);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ckbPintScreenIsHide);
            this.panel1.Controls.Add(this.btnPintScrenn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ckbcurrenFromScrenn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 108);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbSrceen);
            this.panel2.Location = new System.Drawing.Point(5, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 60);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "获取屏幕：";
            // 
            // cbSrceen
            // 
            this.cbSrceen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSrceen.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSrceen.FormattingEnabled = true;
            this.cbSrceen.Location = new System.Drawing.Point(74, 17);
            this.cbSrceen.Name = "cbSrceen";
            this.cbSrceen.Size = new System.Drawing.Size(410, 25);
            this.cbSrceen.TabIndex = 4;
            // 
            // ckbcurrenFromScrenn
            // 
            this.ckbcurrenFromScrenn.AutoSize = true;
            this.ckbcurrenFromScrenn.Checked = true;
            this.ckbcurrenFromScrenn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbcurrenFromScrenn.Location = new System.Drawing.Point(10, 16);
            this.ckbcurrenFromScrenn.Name = "ckbcurrenFromScrenn";
            this.ckbcurrenFromScrenn.Size = new System.Drawing.Size(132, 16);
            this.ckbcurrenFromScrenn.TabIndex = 5;
            this.ckbcurrenFromScrenn.Text = "当前窗体所在的屏幕";
            this.ckbcurrenFromScrenn.UseVisualStyleBackColor = true;
            this.ckbcurrenFromScrenn.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnPintScrenn
            // 
            this.btnPintScrenn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPintScrenn.Location = new System.Drawing.Point(633, 16);
            this.btnPintScrenn.Name = "btnPintScrenn";
            this.btnPintScrenn.Size = new System.Drawing.Size(142, 32);
            this.btnPintScrenn.TabIndex = 7;
            this.btnPintScrenn.Text = "截屏";
            this.btnPintScrenn.UseVisualStyleBackColor = true;
            this.btnPintScrenn.Click += new System.EventHandler(this.btnPintScrenn_Click);
            // 
            // ckbPintScreenIsHide
            // 
            this.ckbPintScreenIsHide.AutoSize = true;
            this.ckbPintScreenIsHide.Checked = true;
            this.ckbPintScreenIsHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbPintScreenIsHide.Location = new System.Drawing.Point(168, 16);
            this.ckbPintScreenIsHide.Name = "ckbPintScreenIsHide";
            this.ckbPintScreenIsHide.Size = new System.Drawing.Size(108, 16);
            this.ckbPintScreenIsHide.TabIndex = 8;
            this.ckbPintScreenIsHide.Text = "截屏时隐藏自己";
            this.ckbPintScreenIsHide.UseVisualStyleBackColor = true;
            // 
            // fro_AdvancedOCRImage_PlanA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 532);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "fro_AdvancedOCRImage_PlanA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图像识别（方案A）";
            this.Load += new System.EventHandler(this.fro_AdvancedOCRImage_PlanA_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbSrceen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckbcurrenFromScrenn;
        private System.Windows.Forms.Button btnPintScrenn;
        private System.Windows.Forms.CheckBox ckbPintScreenIsHide;
    }
}