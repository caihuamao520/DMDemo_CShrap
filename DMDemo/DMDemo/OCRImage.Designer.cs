namespace DMDemo
{
    partial class OCRImage
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
            this.btnOCRImage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEngineVersion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkEditImageSet = new System.Windows.Forms.LinkLabel();
            this.btnEditImage = new System.Windows.Forms.Button();
            this.cbEngineMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbImageContenMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.txtOCRContent = new System.Windows.Forms.TextBox();
            this.btnOpenImageFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbAutoImageSize = new System.Windows.Forms.RadioButton();
            this.rbSouceImageSize = new System.Windows.Forms.RadioButton();
            this.linAsSaveImageFile = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOCRImage
            // 
            this.btnOCRImage.Enabled = false;
            this.btnOCRImage.Location = new System.Drawing.Point(44, 260);
            this.btnOCRImage.Name = "btnOCRImage";
            this.btnOCRImage.Size = new System.Drawing.Size(88, 34);
            this.btnOCRImage.TabIndex = 0;
            this.btnOCRImage.Text = "OCR识别";
            this.btnOCRImage.UseVisualStyleBackColor = true;
            this.btnOCRImage.Click += new System.EventHandler(this.btnOCRImage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbEngineVersion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.linkEditImageSet);
            this.groupBox1.Controls.Add(this.btnEditImage);
            this.groupBox1.Controls.Add(this.cbEngineMode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbImageContenMode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnScreenshot);
            this.groupBox1.Controls.Add(this.txtOCRContent);
            this.groupBox1.Controls.Add(this.btnOpenImageFile);
            this.groupBox1.Controls.Add(this.btnOCRImage);
            this.groupBox1.Location = new System.Drawing.Point(612, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 527);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // cbEngineVersion
            // 
            this.cbEngineVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineVersion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbEngineVersion.FormattingEnabled = true;
            this.cbEngineVersion.Items.AddRange(new object[] {
            "2.4.0（兼容win xp）",
            "3.3.0（新版）"});
            this.cbEngineVersion.Location = new System.Drawing.Point(99, 20);
            this.cbEngineVersion.Name = "cbEngineVersion";
            this.cbEngineVersion.Size = new System.Drawing.Size(154, 25);
            this.cbEngineVersion.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "引擎版本:";
            // 
            // linkEditImageSet
            // 
            this.linkEditImageSet.AutoSize = true;
            this.linkEditImageSet.Enabled = false;
            this.linkEditImageSet.Location = new System.Drawing.Point(162, 225);
            this.linkEditImageSet.Name = "linkEditImageSet";
            this.linkEditImageSet.Size = new System.Drawing.Size(77, 12);
            this.linkEditImageSet.TabIndex = 10;
            this.linkEditImageSet.TabStop = true;
            this.linkEditImageSet.Text = "图像处理设置";
            this.linkEditImageSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditImageSet_LinkClicked);
            // 
            // btnEditImage
            // 
            this.btnEditImage.Enabled = false;
            this.btnEditImage.Location = new System.Drawing.Point(44, 203);
            this.btnEditImage.Name = "btnEditImage";
            this.btnEditImage.Size = new System.Drawing.Size(88, 34);
            this.btnEditImage.TabIndex = 9;
            this.btnEditImage.Text = "图像处理";
            this.btnEditImage.UseVisualStyleBackColor = true;
            this.btnEditImage.Click += new System.EventHandler(this.btnEditImage_Click);
            // 
            // cbEngineMode
            // 
            this.cbEngineMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbEngineMode.FormattingEnabled = true;
            this.cbEngineMode.Items.AddRange(new object[] {
            "TesseractOnly",
            "CubeOnly",
            "TesseractAndCube",
            "Default"});
            this.cbEngineMode.Location = new System.Drawing.Point(99, 59);
            this.cbEngineMode.Name = "cbEngineMode";
            this.cbEngineMode.Size = new System.Drawing.Size(154, 25);
            this.cbEngineMode.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "引擎模式:";
            // 
            // cbImageContenMode
            // 
            this.cbImageContenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageContenMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbImageContenMode.FormattingEnabled = true;
            this.cbImageContenMode.Items.AddRange(new object[] {
            "OsdOnly",
            "AutoOsd",
            "AutoOnly",
            "Auto",
            "SingleColumn",
            "SingleBlockVertText",
            "SingleBlock",
            "SingleLine",
            "SingleWord",
            "CircleWord",
            "SingleChar",
            "SparseText",
            "SparseTextOsd",
            "RawLine",
            "Count"});
            this.cbImageContenMode.Location = new System.Drawing.Point(99, 99);
            this.cbImageContenMode.Name = "cbImageContenMode";
            this.cbImageContenMode.Size = new System.Drawing.Size(154, 25);
            this.cbImageContenMode.TabIndex = 5;
            this.cbImageContenMode.SelectedIndexChanged += new System.EventHandler(this.cbImageContenMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "内容排列方式:";
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Location = new System.Drawing.Point(164, 143);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(88, 34);
            this.btnScreenshot.TabIndex = 3;
            this.btnScreenshot.Text = "截图";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // txtOCRContent
            // 
            this.txtOCRContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOCRContent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOCRContent.Location = new System.Drawing.Point(6, 322);
            this.txtOCRContent.Multiline = true;
            this.txtOCRContent.Name = "txtOCRContent";
            this.txtOCRContent.Size = new System.Drawing.Size(265, 199);
            this.txtOCRContent.TabIndex = 2;
            // 
            // btnOpenImageFile
            // 
            this.btnOpenImageFile.Location = new System.Drawing.Point(44, 143);
            this.btnOpenImageFile.Name = "btnOpenImageFile";
            this.btnOpenImageFile.Size = new System.Drawing.Size(88, 34);
            this.btnOpenImageFile.TabIndex = 1;
            this.btnOpenImageFile.Text = "打开图像";
            this.btnOpenImageFile.UseVisualStyleBackColor = true;
            this.btnOpenImageFile.Click += new System.EventHandler(this.btnOpenImageFile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(582, 492);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // rbAutoImageSize
            // 
            this.rbAutoImageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbAutoImageSize.AutoSize = true;
            this.rbAutoImageSize.Location = new System.Drawing.Point(28, 519);
            this.rbAutoImageSize.Name = "rbAutoImageSize";
            this.rbAutoImageSize.Size = new System.Drawing.Size(83, 16);
            this.rbAutoImageSize.TabIndex = 3;
            this.rbAutoImageSize.Text = "自适应大小";
            this.rbAutoImageSize.UseVisualStyleBackColor = true;
            this.rbAutoImageSize.CheckedChanged += new System.EventHandler(this.rbAutoImageSize_CheckedChanged);
            // 
            // rbSouceImageSize
            // 
            this.rbSouceImageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbSouceImageSize.AutoSize = true;
            this.rbSouceImageSize.Checked = true;
            this.rbSouceImageSize.Location = new System.Drawing.Point(153, 519);
            this.rbSouceImageSize.Name = "rbSouceImageSize";
            this.rbSouceImageSize.Size = new System.Drawing.Size(95, 16);
            this.rbSouceImageSize.TabIndex = 4;
            this.rbSouceImageSize.TabStop = true;
            this.rbSouceImageSize.Text = "原始图像大小";
            this.rbSouceImageSize.UseVisualStyleBackColor = true;
            this.rbSouceImageSize.CheckedChanged += new System.EventHandler(this.rbSouceImageSize_CheckedChanged);
            // 
            // linAsSaveImageFile
            // 
            this.linAsSaveImageFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linAsSaveImageFile.AutoSize = true;
            this.linAsSaveImageFile.Location = new System.Drawing.Point(513, 523);
            this.linAsSaveImageFile.Name = "linAsSaveImageFile";
            this.linAsSaveImageFile.Size = new System.Drawing.Size(65, 12);
            this.linAsSaveImageFile.TabIndex = 5;
            this.linAsSaveImageFile.TabStop = true;
            this.linAsSaveImageFile.Text = "图像另存为";
            this.linAsSaveImageFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linAsSaveImageFile_LinkClicked);
            // 
            // OCRImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 551);
            this.Controls.Add(this.linAsSaveImageFile);
            this.Controls.Add(this.rbSouceImageSize);
            this.Controls.Add(this.rbAutoImageSize);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "OCRImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tesseract OCR识别";
            this.Load += new System.EventHandler(this.OCRImage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOCRImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpenImageFile;
        private System.Windows.Forms.TextBox txtOCRContent;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.RadioButton rbAutoImageSize;
        private System.Windows.Forms.RadioButton rbSouceImageSize;
        private System.Windows.Forms.ComboBox cbImageContenMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEngineMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEditImage;
        private System.Windows.Forms.LinkLabel linkEditImageSet;
        private System.Windows.Forms.LinkLabel linAsSaveImageFile;
        private System.Windows.Forms.ComboBox cbEngineVersion;
        private System.Windows.Forms.Label label3;

    }
}