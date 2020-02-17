namespace DMDemo
{
    partial class EditImageSet
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
            this.ckbDUB = new System.Windows.Forms.CheckBox();
            this.ckbBJSTH = new System.Windows.Forms.CheckBox();
            this.ckbHD = new System.Windows.Forms.CheckBox();
            this.ckbJZ = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.pDUB = new System.Windows.Forms.Panel();
            this.txtFZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pBJSTH = new System.Windows.Forms.Panel();
            this.linSelectColor = new System.Windows.Forms.LinkLabel();
            this.pbBackGroupColor = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pHD = new System.Windows.Forms.Panel();
            this.pEZH = new System.Windows.Forms.Panel();
            this.ckbTZTXDX = new System.Windows.Forms.CheckBox();
            this.pZDTZDX = new System.Windows.Forms.Panel();
            this.txtTXGD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pJZ = new System.Windows.Forms.Panel();
            this.txtJDDX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJDJJ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbEZH = new System.Windows.Forms.CheckBox();
            this.pDUB.SuspendLayout();
            this.pBJSTH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGroupColor)).BeginInit();
            this.pHD.SuspendLayout();
            this.pEZH.SuspendLayout();
            this.pZDTZDX.SuspendLayout();
            this.pJZ.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbDUB
            // 
            this.ckbDUB.AutoSize = true;
            this.ckbDUB.Location = new System.Drawing.Point(23, 32);
            this.ckbDUB.Name = "ckbDUB";
            this.ckbDUB.Size = new System.Drawing.Size(84, 16);
            this.ckbDUB.TabIndex = 0;
            this.ckbDUB.Text = "调整对比度";
            this.ckbDUB.UseVisualStyleBackColor = true;
            this.ckbDUB.CheckedChanged += new System.EventHandler(this.ckbDUB_CheckedChanged);
            // 
            // ckbBJSTH
            // 
            this.ckbBJSTH.AutoSize = true;
            this.ckbBJSTH.Location = new System.Drawing.Point(23, 74);
            this.ckbBJSTH.Name = "ckbBJSTH";
            this.ckbBJSTH.Size = new System.Drawing.Size(84, 16);
            this.ckbBJSTH.TabIndex = 1;
            this.ckbBJSTH.Text = "背景色替换";
            this.ckbBJSTH.UseVisualStyleBackColor = true;
            this.ckbBJSTH.CheckedChanged += new System.EventHandler(this.ckbBJSTH_CheckedChanged);
            // 
            // ckbHD
            // 
            this.ckbHD.AutoSize = true;
            this.ckbHD.Location = new System.Drawing.Point(23, 116);
            this.ckbHD.Name = "ckbHD";
            this.ckbHD.Size = new System.Drawing.Size(72, 16);
            this.ckbHD.TabIndex = 2;
            this.ckbHD.Text = "灰度处理";
            this.ckbHD.UseVisualStyleBackColor = true;
            this.ckbHD.CheckedChanged += new System.EventHandler(this.ckbHD_CheckedChanged);
            // 
            // ckbJZ
            // 
            this.ckbJZ.AutoSize = true;
            this.ckbJZ.Location = new System.Drawing.Point(15, 91);
            this.ckbJZ.Name = "ckbJZ";
            this.ckbJZ.Size = new System.Drawing.Size(84, 16);
            this.ckbJZ.TabIndex = 3;
            this.ckbJZ.Text = "降噪处理：";
            this.ckbJZ.UseVisualStyleBackColor = true;
            this.ckbJZ.CheckedChanged += new System.EventHandler(this.ckbJZ_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(393, 313);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 35);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pDUB
            // 
            this.pDUB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pDUB.Controls.Add(this.txtFZ);
            this.pDUB.Controls.Add(this.label1);
            this.pDUB.Location = new System.Drawing.Point(113, 23);
            this.pDUB.Name = "pDUB";
            this.pDUB.Size = new System.Drawing.Size(368, 35);
            this.pDUB.TabIndex = 5;
            // 
            // txtFZ
            // 
            this.txtFZ.Location = new System.Drawing.Point(60, 7);
            this.txtFZ.Name = "txtFZ";
            this.txtFZ.Size = new System.Drawing.Size(61, 21);
            this.txtFZ.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "阀值：";
            // 
            // pBJSTH
            // 
            this.pBJSTH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBJSTH.Controls.Add(this.linSelectColor);
            this.pBJSTH.Controls.Add(this.pbBackGroupColor);
            this.pBJSTH.Controls.Add(this.label4);
            this.pBJSTH.Location = new System.Drawing.Point(113, 65);
            this.pBJSTH.Name = "pBJSTH";
            this.pBJSTH.Size = new System.Drawing.Size(368, 35);
            this.pBJSTH.TabIndex = 6;
            // 
            // linSelectColor
            // 
            this.linSelectColor.AutoSize = true;
            this.linSelectColor.Location = new System.Drawing.Point(137, 13);
            this.linSelectColor.Name = "linSelectColor";
            this.linSelectColor.Size = new System.Drawing.Size(53, 12);
            this.linSelectColor.TabIndex = 3;
            this.linSelectColor.TabStop = true;
            this.linSelectColor.Text = "选择颜色";
            this.linSelectColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linSelectColor_LinkClicked);
            // 
            // pbBackGroupColor
            // 
            this.pbBackGroupColor.Location = new System.Drawing.Point(60, 7);
            this.pbBackGroupColor.Name = "pbBackGroupColor";
            this.pbBackGroupColor.Size = new System.Drawing.Size(61, 20);
            this.pbBackGroupColor.TabIndex = 2;
            this.pbBackGroupColor.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "背景色：";
            // 
            // pHD
            // 
            this.pHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pHD.Controls.Add(this.pEZH);
            this.pHD.Controls.Add(this.pJZ);
            this.pHD.Controls.Add(this.ckbEZH);
            this.pHD.Controls.Add(this.ckbJZ);
            this.pHD.Location = new System.Drawing.Point(113, 107);
            this.pHD.Name = "pHD";
            this.pHD.Size = new System.Drawing.Size(368, 182);
            this.pHD.TabIndex = 6;
            // 
            // pEZH
            // 
            this.pEZH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pEZH.Controls.Add(this.ckbTZTXDX);
            this.pEZH.Controls.Add(this.pZDTZDX);
            this.pEZH.Location = new System.Drawing.Point(11, 31);
            this.pEZH.Name = "pEZH";
            this.pEZH.Size = new System.Drawing.Size(309, 45);
            this.pEZH.TabIndex = 6;
            // 
            // ckbTZTXDX
            // 
            this.ckbTZTXDX.AutoSize = true;
            this.ckbTZTXDX.Location = new System.Drawing.Point(4, 16);
            this.ckbTZTXDX.Name = "ckbTZTXDX";
            this.ckbTZTXDX.Size = new System.Drawing.Size(120, 16);
            this.ckbTZTXDX.TabIndex = 7;
            this.ckbTZTXDX.Text = "自动调整图像尺寸";
            this.ckbTZTXDX.UseVisualStyleBackColor = true;
            this.ckbTZTXDX.CheckedChanged += new System.EventHandler(this.ckbTZTXDX_CheckedChanged);
            // 
            // pZDTZDX
            // 
            this.pZDTZDX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pZDTZDX.Controls.Add(this.txtTXGD);
            this.pZDTZDX.Controls.Add(this.label5);
            this.pZDTZDX.Location = new System.Drawing.Point(130, 6);
            this.pZDTZDX.Name = "pZDTZDX";
            this.pZDTZDX.Size = new System.Drawing.Size(155, 35);
            this.pZDTZDX.TabIndex = 6;
            // 
            // txtTXGD
            // 
            this.txtTXGD.Location = new System.Drawing.Point(83, 7);
            this.txtTXGD.Name = "txtTXGD";
            this.txtTXGD.Size = new System.Drawing.Size(61, 21);
            this.txtTXGD.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "高度阀值：";
            // 
            // pJZ
            // 
            this.pJZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pJZ.Controls.Add(this.txtJDDX);
            this.pJZ.Controls.Add(this.label3);
            this.pJZ.Controls.Add(this.txtJDJJ);
            this.pJZ.Controls.Add(this.label2);
            this.pJZ.Location = new System.Drawing.Point(15, 115);
            this.pJZ.Name = "pJZ";
            this.pJZ.Size = new System.Drawing.Size(305, 35);
            this.pJZ.TabIndex = 7;
            // 
            // txtJDDX
            // 
            this.txtJDDX.Location = new System.Drawing.Point(228, 7);
            this.txtJDDX.Name = "txtJDDX";
            this.txtJDDX.Size = new System.Drawing.Size(61, 21);
            this.txtJDDX.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "噪点大小：";
            // 
            // txtJDJJ
            // 
            this.txtJDJJ.Location = new System.Drawing.Point(75, 7);
            this.txtJDJJ.Name = "txtJDJJ";
            this.txtJDJJ.Size = new System.Drawing.Size(61, 21);
            this.txtJDJJ.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "噪点间距：";
            // 
            // ckbEZH
            // 
            this.ckbEZH.AutoSize = true;
            this.ckbEZH.Location = new System.Drawing.Point(15, 9);
            this.ckbEZH.Name = "ckbEZH";
            this.ckbEZH.Size = new System.Drawing.Size(60, 16);
            this.ckbEZH.TabIndex = 8;
            this.ckbEZH.Text = "二值化";
            this.ckbEZH.UseVisualStyleBackColor = true;
            this.ckbEZH.CheckedChanged += new System.EventHandler(this.ckbEZH_CheckedChanged);
            // 
            // EditImageSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 360);
            this.Controls.Add(this.pHD);
            this.Controls.Add(this.pBJSTH);
            this.Controls.Add(this.pDUB);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ckbHD);
            this.Controls.Add(this.ckbBJSTH);
            this.Controls.Add(this.ckbDUB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditImageSet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图像处理设置";
            this.Load += new System.EventHandler(this.EditImageSet_Load);
            this.pDUB.ResumeLayout(false);
            this.pDUB.PerformLayout();
            this.pBJSTH.ResumeLayout(false);
            this.pBJSTH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGroupColor)).EndInit();
            this.pHD.ResumeLayout(false);
            this.pHD.PerformLayout();
            this.pEZH.ResumeLayout(false);
            this.pEZH.PerformLayout();
            this.pZDTZDX.ResumeLayout(false);
            this.pZDTZDX.PerformLayout();
            this.pJZ.ResumeLayout(false);
            this.pJZ.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbDUB;
        private System.Windows.Forms.CheckBox ckbBJSTH;
        private System.Windows.Forms.CheckBox ckbHD;
        private System.Windows.Forms.CheckBox ckbJZ;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pDUB;
        private System.Windows.Forms.Panel pBJSTH;
        private System.Windows.Forms.Panel pHD;
        private System.Windows.Forms.Panel pJZ;
        private System.Windows.Forms.TextBox txtFZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJDJJ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJDDX;
        private System.Windows.Forms.PictureBox pbBackGroupColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linSelectColor;
        private System.Windows.Forms.CheckBox ckbEZH;
        private System.Windows.Forms.CheckBox ckbTZTXDX;
        private System.Windows.Forms.Panel pZDTZDX;
        private System.Windows.Forms.TextBox txtTXGD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pEZH;
    }
}