namespace DMDemo
{
    partial class NavigationFrom
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
            this.btnOpenHwndGetTitleDemo = new System.Windows.Forms.Button();
            this.btnOpenTesseractOcrDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenHwndGetTitleDemo
            // 
            this.btnOpenHwndGetTitleDemo.Location = new System.Drawing.Point(41, 45);
            this.btnOpenHwndGetTitleDemo.Name = "btnOpenHwndGetTitleDemo";
            this.btnOpenHwndGetTitleDemo.Size = new System.Drawing.Size(124, 49);
            this.btnOpenHwndGetTitleDemo.TabIndex = 0;
            this.btnOpenHwndGetTitleDemo.Text = "窗体识别";
            this.btnOpenHwndGetTitleDemo.UseVisualStyleBackColor = true;
            this.btnOpenHwndGetTitleDemo.Click += new System.EventHandler(this.btnOpenHwndGetTitleDemo_Click);
            // 
            // btnOpenTesseractOcrDemo
            // 
            this.btnOpenTesseractOcrDemo.Location = new System.Drawing.Point(193, 45);
            this.btnOpenTesseractOcrDemo.Name = "btnOpenTesseractOcrDemo";
            this.btnOpenTesseractOcrDemo.Size = new System.Drawing.Size(124, 49);
            this.btnOpenTesseractOcrDemo.TabIndex = 1;
            this.btnOpenTesseractOcrDemo.Text = "TesseractOCR识别";
            this.btnOpenTesseractOcrDemo.UseVisualStyleBackColor = true;
            this.btnOpenTesseractOcrDemo.Click += new System.EventHandler(this.btnOpenTesseractOcrDemo_Click);
            // 
            // NavigationFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 139);
            this.Controls.Add(this.btnOpenTesseractOcrDemo);
            this.Controls.Add(this.btnOpenHwndGetTitleDemo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NavigationFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "全部DEMO";
            this.Load += new System.EventHandler(this.NavigationFrom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenHwndGetTitleDemo;
        private System.Windows.Forms.Button btnOpenTesseractOcrDemo;
    }
}