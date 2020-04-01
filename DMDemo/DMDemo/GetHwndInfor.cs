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
using System.Diagnostics;
using System.IO;

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
        private string _hwndClassName = string.Empty;//句柄类名
        private string _HwbdProcessPath = string.Empty;//句柄线程名称
        private Point _mousePoint;
        private int _hwnd;
        private int _hwndTopFrom;
        private string _topFromTitle = string.Empty;
        private string _yopFromClassName = string.Empty;
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
        /// 父窗体句柄
        /// </summary>
        public int HwndTopFrom
        {
            get
            {
                return _hwndTopFrom;
            }
        }
        /// <summary>
        /// 父窗体句柄内容
        /// </summary>
        public string TopFromTitle
        {
            get
            {
                return _topFromTitle;
            }
        }
        /// <summary>
        /// 父窗体类名
        /// </summary>
        public string TopFromClassName
        {
            get
            {
                return _yopFromClassName;
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
        
        /// <summary>
        /// 句柄类名
        /// </summary>
        public string HwndClassName
        {
            get
            {
                return _hwndClassName;
            }
        }
        /// <summary>
        /// 句柄类名
        /// </summary>
        public string HwndProcessPath
        {
            get
            {
                return _HwbdProcessPath;
            }
        }
        /// <summary>
        /// 获取句柄时鼠标停留的位置
        /// </summary>
        public Point MousePoint 
        {
            get
            {
                return _mousePoint;
            }
        }

        public GetHwndInfor()
        {
            _rc = new Rectangle();
            _mousePoint = new Point(0);
            _hwnd = 0;
            //判断组件是否注册
            if (!CheckRegistredOcx(@"CLSID\{26037A0E-7CBD-4FFF-9C63-56F2D0770214}"))
            {
                AutoRegCom("regsvr32 -s dm.dll");
            }
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
                    _hwndClassName = mydm.GetWindowClass(_hwnd);
                    
                    _hwndTopFrom=mydm.GetWindow(_hwnd, 7);
                    _topFromTitle = mydm.GetWindowTitle(_hwndTopFrom); ;
                    _yopFromClassName = mydm.GetWindowClass(_hwndTopFrom);
                                        
                    _HwbdProcessPath = mydm.GetWindowProcessPath(_hwnd);

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
        /// 获取指定句柄的内容
        /// </summary>
        /// <param name="hwend"></param>
        /// <returns></returns>
        public static string GetHwndTitle(int hwend)
        {
            return mydm.GetWindowTitle(hwend);
        }
        /// <summary>
        /// 根据鼠标位置获取句柄
        /// </summary>
        /// <param name="poi"></param>
        /// <returns></returns>
        public static int MousePointGetHwnd(Point poi)
        {
            return mydm.GetPointWindow(poi.X, poi.Y);//获取句柄
        }
        /// <summary>
        /// 根据父窗口和类名获取句柄
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static int ClassNameGetHwnd(int parent, string className,string strTitle)
        {
            return mydm.FindWindowEx(parent, className, strTitle);
        }
        /// <summary>
        /// 获取父窗体句柄
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static int GetHwndParentHwnd(int hwnd)
        {
            return mydm.GetWindow(hwnd, 0);
        }
        /// <summary>
        /// 获取类名称
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static string GetHwndClassName(int hwnd)
        {
            return mydm.GetWindowClass(hwnd);
        }
        /// <summary>
        /// 根据类名与题名查找窗体
        /// </summary>
        /// <param name="title"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static List<int> ClassNameAndTitleToParentHwnd(string title, string className)
        {
            List<int> FormHwndList = new List<int>();
            string strFormHwnds = mydm.EnumWindow(0, title, className, 1 + 2 + 16);
            foreach(string s in strFormHwnds.Split(','))
            {
                if (!string.IsNullOrEmpty(s))
                {
                    FormHwndList.Add(int.Parse(s));
                }
            }
            return FormHwndList;
        }
        /// <summary>
        /// 计算父窗体坐标距离目标组件的偏移量
        /// </summary>
        /// <param name="parentHwnd"></param>
        /// <param name="mousePoint"></param>
        /// <returns></returns>
        public Point CalculationTopFormOffsetPoint(int parentHwnd, Point mousePoint)
        {
            Point ResultPoint = new Point();
            object hwndS_x, hwndS_y, hwndE_x, hwndE_y;//父窗体位置
            if (mydm.GetClientRect(parentHwnd, out hwndS_x, out hwndS_y, out hwndE_x, out hwndE_y) == 1)
            {
                ResultPoint = new Point(mousePoint.X - int.Parse(hwndS_x.ToString()), mousePoint.Y - int.Parse(hwndS_y.ToString()));
            }
            return ResultPoint;
        }
        /// <summary>
        /// 依据父窗体和偏移量获取子窗体
        /// </summary>
        /// <param name="parentHwnd"></param>
        /// <param name="mousePoint"></param>
        /// <returns></returns>
        public static int ParentHwndAndOffsetPointGetHwnd(int parentHwnd, Point offsetPoint)
        { 
            object hwndS_x, hwndS_y, hwndE_x, hwndE_y;//父窗体位置
            if (mydm.GetClientRect(parentHwnd, out hwndS_x, out hwndS_y, out hwndE_x, out hwndE_y) == 1)
            {
                Point temp = new Point(offsetPoint.X + int.Parse(hwndS_x.ToString()), offsetPoint.Y + int.Parse(hwndS_y.ToString()));
                return mydm.GetPointWindow(temp.X, temp.Y);
                //return mydm.GetPointWindow(offsetPoint.X + int.Parse(hwndS_x.ToString()), offsetPoint.Y + int.Parse(hwndS_y.ToString()));
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取顶层窗口
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static int GetTopFormHwnd(int hwnd)
        {
            return mydm.GetWindow(hwnd, 7);
        }
        /// <summary>
        /// 置顶指定窗体
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static bool TopShowForm(int hwnd)
        {
            if (mydm.GetWindowState(hwnd, 0) == 1)//是否存在
            {
                mydm.SetWindowState(hwnd, 1);
                if (mydm.SetWindowState(hwnd, 8) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 取消置顶指定窗体
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static bool CancelTopShowForm(int hwnd)
        {
            if (mydm.GetWindowState(hwnd, 0) == 1)//是否存在
            {
                if (mydm.SetWindowState(hwnd, 9) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查找顶层窗口
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static int FindTopForm(string className,string title)
        {
            return mydm.FindWindow(className, title);
        }

        /// <summary>
        /// 注册组件
        /// </summary>
        /// <param name="strCmd"></param>
        /// <returns></returns>
        public static string AutoRegCom(string strCmd)
        {
            string rInfo;
            try
            {
                Process myProcess = new Process();
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("cmd.exe");
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo = myProcessStartInfo;
                myProcessStartInfo.Arguments = "/c " + strCmd;
                myProcess.Start();
                StreamReader myStreamReader = myProcess.StandardOutput;
                rInfo = myStreamReader.ReadToEnd();
                myProcess.Close();
                rInfo = strCmd + "\r\n" + rInfo;
                return rInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 检测ocx是否注册
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public static bool CheckRegistredOcx(string ClassId)
        {
            Microsoft.Win32.RegistryKey Regkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ClassId);
            if (Regkey != null)
            {
                string res = Regkey.OpenSubKey("InprocServer32").GetValue("").ToString();
                if (!File.Exists(res))
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
