using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMDemo
{
    public partial class fro_AdvancedOCRImage_PlanA : Form
    {
        private Timer GetSystemImageTimer;
        private Dictionary<string, Screen> ScreenList;
        public fro_AdvancedOCRImage_PlanA()
        {
            InitializeComponent();
        }

        private void fro_AdvancedOCRImage_PlanA_Load(object sender, EventArgs e)
        {
            GetSystemImageTimer = new Timer();
            GetSystemImageTimer.Interval = 1000;
            GetSystemImageTimer.Tick += GetSystemImageTimer_Tick;

            ScreenList = new Dictionary<string, Screen>();

            Screen[] currenScreen= Screen.AllScreens;
            this.cbSrceen.Items.Clear();
            for (int i = 0; i < currenScreen.Length; i++)
            {
                string keyName = string.Format("屏幕{0}[{1}]（{2}x{3} - [X:{4},Y:{5}]）",
                    i + 1, currenScreen[i].Primary ? "主屏" : "副屏",currenScreen[i].Bounds.Width,currenScreen[i].Bounds.Height,
                    currenScreen[i].Bounds.X,currenScreen[i].Bounds.Y);
                this.cbSrceen.Items.Add(keyName);
                ScreenList.Add(keyName, currenScreen[i]);                
            }

            if (this.cbSrceen.Items.Count > 0)
            {
                this.cbSrceen.SelectedIndex = 0;
                this.btnGetSystemImage.Enabled = true;
            }
        }

        private void GetSystemImageTimer_Tick(object sender, EventArgs e)
        {
            Image img = Clipboard.GetImage();
            if (img != null)
            {
                Screen scr= ScreenList[this.cbSrceen.Text];

                Bitmap bmp = new Bitmap(scr.Bounds.Width, scr.Bounds.Height);
                bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                Graphics gh = Graphics.FromImage(bmp);
                gh.DrawImage(img, 0, 0, scr.Bounds, GraphicsUnit.Pixel);
                this.pictureBox1.Image = bmp;
                Clipboard.Clear();
            }
        }

        private void btnGetSystemImage_Click(object sender, EventArgs e)
        {
            if (this.btnGetSystemImage.Text == "开始监听粘贴板图像")
            {
                this.btnGetSystemImage.Text = "停止监听粘贴板图像";
                GetSystemImageTimer.Start();
                this.cbSrceen.Enabled = false;
            }
            else
            {
                this.btnGetSystemImage.Text = "开始监听粘贴板图像";
                GetSystemImageTimer.Stop();
                this.cbSrceen.Enabled = true;

            }
        }        
    }
}
