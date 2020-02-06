using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dm;
using System.Threading;
using System.Runtime.InteropServices;

namespace DMDemo
{
    public partial class GetHwndInfor : Form
    {
        [DllImport("user32.dll ")]
        public static extern short GetKeyState(int nVirtKey);
        public const int VK_LBUTTON = 1;
        public const int VK_RBUTTON = 2;

        private Thread GetMousePintTh;
        private static dmsoft mydm = new dmsoft();//大漠插件
        private Rectangle _rc;//句柄控件的位置、大小
        private string _hwndTitle = string.Empty;//句柄内容
        private Point _mousePoint;
        private int _hwnd;
        /// <summary>
        /// 句柄
        /// </summary>
        public int intHwnd 
        {
            get
            {
                return _hwnd;
            }
        }
        /// <summary>
        /// 句柄尺寸大小
        /// </summary>
        public Rectangle HwndRect 
        {
            get
            {
                return _rc;
            }
        }
        /// <summary>
        /// 句柄内容
        /// </summary>
        public string HwndTitle 
        {
            get 
            {
                return _hwndTitle;
            }
        }

        public GetHwndInfor()
        {
            _rc = new Rectangle();
            _mousePoint = new Point(0);
            _hwnd = 0;

            InitializeComponent();
        }
        
        private void GetHwndInfor_Shown(object sender, EventArgs e)
        {
            GetMousePintTh = new Thread(new ThreadStart(GetMousePoint));
            GetMousePintTh.Start();
        }

        private void GetHwndInfor_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = this.panel1.BackColor;
        }

        private void GetMousePoint()
        {
            while (true)
            {
                if ((GetKeyState(VK_LBUTTON) & 0x80) == 0x80)
                {
                    _mousePoint = MousePosition;
                    _hwnd = mydm.GetPointWindow(_mousePoint.X, _mousePoint.Y);//获取句柄

                    _hwndTitle = mydm.GetWindowTitle(_hwnd);
                    object x1, y1, x2, y2;

                    Rectangle rc = new Rectangle(0, 0, 0, 0);
                    if (mydm.GetClientRect(_hwnd, out x1, out y1, out x2, out y2) == 1)
                    {
                        int iTemp = -1;
                        if (int.TryParse(x1.ToString(), out iTemp))
                        {
                            rc.X = iTemp;
                        }
                        iTemp = -1;
                        if (int.TryParse(y1.ToString(), out iTemp))
                        {
                            rc.Y = iTemp;
                        }
                        iTemp = 0;
                        if (int.TryParse(x2.ToString(), out iTemp))
                        {
                            rc.Width = (iTemp - rc.X);
                        }
                        iTemp = 0;
                        if (int.TryParse(y2.ToString(), out iTemp))
                        {
                            rc.Height = (iTemp - rc.Y);
                        }
                    }
                    _rc = rc;
                    SetFormSize(rc);
                }
                else
                {
                    break;
                }

                Thread.Sleep(100);
            }
            this.Invoke(new Action(() =>
            {
                this.DialogResult = DialogResult.Yes;
            }));
        }

        public void SetFormSize(Rectangle rc)
        {
            this.Invoke(new Action(()=>{
                this.Location = new Point(rc.Location.X - 2, rc.Location.Y - 2);
                this.Size = new System.Drawing.Size(rc.Size.Width + 4, rc.Size.Height + 4);
            }));
        }
        /// <summary>
        /// 获取指定组件的内容
        /// </summary>
        /// <param name="hwend"></param>
        /// <returns></returns>
        public static string GetHwndTitle(int hwend)
        {
            return mydm.GetWindowTitle(hwend);
        }
    }
}
