using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DMDemo
{
    public partial class fro_AdvancedOCRImage_PlanA : Form
    {
        private System.Windows.Forms.Timer GetSystemImageTimer;
        private Dictionary<string, Screen> ScreenList;
        public fro_AdvancedOCRImage_PlanA()
        {
            InitializeComponent();
        }

        private void fro_AdvancedOCRImage_PlanA_Load(object sender, EventArgs e)
        {
            GetSystemImageTimer = new System.Windows.Forms.Timer();
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
                if (this.ckbcurrenFromScrenn.Checked)
                {
                    SetCurrenScreen();
                }
                else
                {
                    this.cbSrceen.SelectedIndex = 0;
                }

                GetSystemImageTimer.Start();
            }
        }

        private void SetCurrenScreen()
        {
            Screen ss = Screen.FromPoint(this.Location);
            foreach (string key in ScreenList.Keys)
            {
                if (ScreenList[key].Equals(ss))
                {
                    this.cbSrceen.Text = key;
                }
            }
        }

        private void GetSystemImageTimer_Tick(object sender, EventArgs e)
        {
            Image img = Clipboard.GetImage();
            if (img != null)
            {
                if (this.ckbcurrenFromScrenn.Checked)
                {
                    SetCurrenScreen();//判断一下在那个屏幕
                }
                Screen scr= ScreenList[this.cbSrceen.Text];
                Bitmap bmp = new Bitmap(scr.Bounds.Width, scr.Bounds.Height);
                bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                Graphics gh = Graphics.FromImage(bmp);
                gh.DrawImage(img, 0, 0, scr.Bounds, GraphicsUnit.Pixel);
                this.pictureBox1.Image = bmp;
                Clipboard.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.panel2.Enabled = !this.ckbcurrenFromScrenn.Checked;

            Screen ss = Screen.FromPoint(this.Location);
            foreach (string key in ScreenList.Keys)
            {
                if (ScreenList[key].Equals(ss))
                {
                    this.cbSrceen.Text = key;
                }
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Fro_LookImage fli = new Fro_LookImage(this.pictureBox1.Image);
            fli.Show();
        }        

        [DllImport("user32.dll")]
        static extern void keybd_event
        (
            byte bVk,// 虚拟键值  
            byte bScan,// 硬件扫描码  
            uint dwFlags,// 动作标识  
            IntPtr dwExtraInfo// 与键盘动作关联的辅加信息  
        );

        /// <summary>
        /// 模拟Print Screen键盘消息，截取全屏图片。
        /// </summary>
        public void PrintScreen()
        {
            keybd_event((byte)0x2c, 0, 0x0, IntPtr.Zero);//down
            Application.DoEvents(); 
            keybd_event((byte)0x2c, 0, 0x2, IntPtr.Zero);//up
            Application.DoEvents(); 
        }
 
        /// <summary>
        /// 模拟Alt Print Screen键盘消息，截取当前窗口图片。
        /// </summary>
        public void AltPrintScreen()
        {
            keybd_event((byte)Keys.Menu, 0, 0x0, IntPtr.Zero);
            keybd_event((byte)0x2c, 0, 0x0, IntPtr.Zero);//down
            Application.DoEvents();
            Application.DoEvents();
            keybd_event((byte)0x2c, 0, 0x2, IntPtr.Zero);//up
            keybd_event((byte)Keys.Menu, 0, 0x2, IntPtr.Zero);
            Application.DoEvents();
            Application.DoEvents();
        }

        private void btnPintScrenn_Click(object sender, EventArgs e)
        {
            if (this.ckbPintScreenIsHide.Checked)
            {
                this.Hide();
            }
            Thread.Sleep(500);
            PrintScreen();
            if (this.ckbPintScreenIsHide.Checked)
            {
                this.Show();
                this.Activate();
            }
        } 
    }
}
