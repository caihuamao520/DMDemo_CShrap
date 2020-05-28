namespace CropImage
{
    partial class ToolBarsFrom
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnYes = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSaveImage = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnYes,
            this.tsbtnNo,
            this.toolStripSeparator1,
            this.tsbtnSaveImage});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(250, 30);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnYes
            // 
            this.tsbtnYes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnYes.Image = global::CropImage.Properties.Resources.yes_ok;
            this.tsbtnYes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnYes.Name = "tsbtnYes";
            this.tsbtnYes.Size = new System.Drawing.Size(61, 27);
            this.tsbtnYes.Text = "确定";
            this.tsbtnYes.Click += new System.EventHandler(this.tsbtnYes_Click);
            // 
            // tsbtnNo
            // 
            this.tsbtnNo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnNo.Image = global::CropImage.Properties.Resources.cancel;
            this.tsbtnNo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNo.Name = "tsbtnNo";
            this.tsbtnNo.Size = new System.Drawing.Size(61, 27);
            this.tsbtnNo.Text = "取消";
            this.tsbtnNo.Click += new System.EventHandler(this.tsbtnNo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // tsbtnSaveImage
            // 
            this.tsbtnSaveImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnSaveImage.Image = global::CropImage.Properties.Resources.save;
            this.tsbtnSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveImage.Name = "tsbtnSaveImage";
            this.tsbtnSaveImage.Size = new System.Drawing.Size(61, 27);
            this.tsbtnSaveImage.Text = "保存";
            this.tsbtnSaveImage.Click += new System.EventHandler(this.tsbtnSaveImage_Click);
            // 
            // ToolBarsFrom
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(250, 30);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolBarsFrom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ToolBarsFrom";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ToolBarsFrom_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnYes;
        private System.Windows.Forms.ToolStripButton tsbtnNo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnSaveImage;
    }
}