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

namespace DMDemo.FromHwnd
{
    public partial class GetHwndInfor : Form
    {
        [DllImport("user32.dll ")]
        public static extern short GetKeyState(int nVirtKey);
        public const int VK_LBUTTON = 1;
        public const int VK_RBUTTON = 2;
        private Thread GetMousePintTh;
        private static dmsoft mydm = new dmsoft();//大漠插件
        private MousePointHwndInfor _hwndInfor;
        /// <summary>
        /// 句柄信息
        /// </summary>
        public MousePointHwndInfor HwndInfor
        {
            get
            {
                return _hwndInfor;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public GetHwndInfor()
        {
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

        /// <summary>
        /// 跟随当前鼠标位置获取句柄信息
        /// </summary>
        private void GetMousePoint()
        {
            _hwndInfor = new MousePointHwndInfor();
            while (true)
            {
                if ((GetKeyState(VK_LBUTTON) & 0x80) == 0x80)
                {
                    //当前句柄
                    _hwndInfor.MousePoint = Control.MousePosition;
                    _hwndInfor.CurrentHwnd = mydm.GetPointWindow(_hwndInfor.MousePoint.X, _hwndInfor.MousePoint.Y);//获取句柄
                    _hwndInfor.CurrentHwndTitle = mydm.GetWindowTitle(_hwndInfor.CurrentHwnd);
                    _hwndInfor.CurrentHwndClassName = mydm.GetWindowClass(_hwndInfor.CurrentHwnd);
                    _hwndInfor.HwndProcessPath = mydm.GetWindowProcessPath(_hwndInfor.CurrentHwnd);

                    //父窗体句柄
                    _hwndInfor.ParentHwnd = mydm.GetWindow(_hwndInfor.CurrentHwnd, 0);
                    _hwndInfor.ParentTitle = mydm.GetWindowTitle(_hwndInfor.ParentHwnd);
                    _hwndInfor.ParentClassName = mydm.GetWindowClass(_hwndInfor.ParentHwnd);

                    //顶层窗体句柄
                    _hwndInfor.TopFromHwnd = mydm.GetWindow(_hwndInfor.CurrentHwnd, 7);
                    _hwndInfor.TopFromTitle = mydm.GetWindowTitle(_hwndInfor.TopFromHwnd);
                    _hwndInfor.TopFromClassName = mydm.GetWindowClass(_hwndInfor.TopFromHwnd);
                    
                    _hwndInfor.HwndRect = GetHwndRec(_hwndInfor.CurrentHwnd);
                    SetFormSize(_hwndInfor.HwndRect);
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

        private static Rectangle GetHwndRec(int hwnd)
        {
            object x1, y1, x2, y2;
            Rectangle rc = new Rectangle(0, 0, 0, 0);
            if (mydm.GetClientRect(hwnd, out x1, out y1, out x2, out y2) == 1)
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

            return rc;
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
        /// 获取顶层窗口
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static int GetTopFormHwnd(int hwnd)
        {
            return mydm.GetWindow(hwnd, 7);
        }
        /// <summary>
        /// 获取窗口所在的进程的exe文件全路径
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static string GetWindowProcessPath(int hwnd)
        {
            return mydm.GetWindowProcessPath(hwnd);
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
        public Point CalculationTopFormOffsetPoint(int Hwnd)
        {
            Point ResultPoint = new Point(0,0);
            if (Hwnd == 0)
                return ResultPoint;
            object hwndS_x, hwndS_y, hwndE_x, hwndE_y;
            if (mydm.GetClientRect(Hwnd, out hwndS_x, out hwndS_y, out hwndE_x, out hwndE_y) == 1)
            {
                int topFormHwnd = mydm.GetWindow(Hwnd, 7);//顶层窗体句柄
                object tophwndS_x, tophwndS_y, tophwndE_x, tophwndE_y;
                if (mydm.GetClientRect(topFormHwnd, out tophwndS_x, out tophwndS_y, out tophwndE_x, out tophwndE_y) == 1)
                {
                    //开始转换数据
                    int ihwndS_x,ihwndS_y, ihwndE_y;
                    int itophwndS_x, itophwndS_y;
                    if (!int.TryParse(hwndS_x.ToString(), out ihwndS_x))
                    {
                        return ResultPoint;//转换失败
                    }
                    if (!int.TryParse(hwndS_y.ToString(), out ihwndS_y))
                    {
                        return ResultPoint;//转换失败
                    }
                    if(!int.TryParse(hwndE_y.ToString(),out ihwndE_y ))
                    {
                        return ResultPoint;//转换失败
                    }
                    if (!int.TryParse(tophwndS_x.ToString(), out itophwndS_x))
                    {
                        return ResultPoint;//转换失败
                    }
                    if (!int.TryParse(tophwndS_y.ToString(), out itophwndS_y))
                    {
                        return ResultPoint;//转换失败
                    }

                    int pyl = (ihwndE_y - ihwndS_y) / 4;//计算偏移量
                    Point xnPoin = new Point(ihwndS_x + pyl, ihwndS_y + pyl);//参考点

                    ResultPoint = new Point(xnPoin.X - itophwndS_x, xnPoin.Y - itophwndS_y);
                }
            }
            return ResultPoint;
        }

        /// <summary>
        /// 依据顶层窗体和偏移量获取子窗体
        /// </summary>
        /// <param name="parentHwnd"></param>
        /// <param name="mousePoint"></param>
        /// <returns></returns>
        public static int TopFromHwndAndOffsetPointGetHwnd(int parentHwnd, Point offsetPoint,string pramentClassName=null)
        {
            int iResult = 0;
            if (parentHwnd == 0)
            {
                return iResult;
            }
            object hwndS_x, hwndS_y, hwndE_x, hwndE_y;//顶级窗体位置
            if (mydm.GetClientRect(parentHwnd, out hwndS_x, out hwndS_y, out hwndE_x, out hwndE_y) == 1)
            {
                int ihwndS_x, ihwndS_y;
                if (!int.TryParse(hwndS_x.ToString(), out ihwndS_x))
                {
                    return 0;//转换失败
                }
                if (!int.TryParse(hwndS_y.ToString(), out ihwndS_y))
                {
                    return 0;//转换失败
                }
                Point temp = new Point(offsetPoint.X + ihwndS_x, offsetPoint.Y + ihwndS_y);

                iResult= mydm.GetPointWindow(temp.X, temp.Y);
                //根据父窗体判断是否符合句柄赛选
                if (!string.IsNullOrEmpty(pramentClassName) && iResult != 0)
                {
                    int tempParentHwnd = mydm.GetWindow(iResult, 0);//获取父窗体句柄
                    if (mydm.GetWindowClass(tempParentHwnd) == pramentClassName)//吻合
                    {
                        return iResult;
                    }
                    else
                    {
                        return 0;
                    }
                    //if (mydm.GetWindowTitle(tempParentHwnd) == pramentTitle && mydm.GetWindowClass(tempParentHwnd) == pramentClassName)//吻合
                    //{
                    //    return iResult;
                    //}
                    //else
                    //{
                    //    return 0;
                    //}

                }
                return iResult;
            }
            else
            {
                return iResult;
            }
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
        /// 获取给定窗口相关的窗口句柄
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static int GetWindow(int hwnd,GetWindowFlagEnum flag) 
        {
            int iflag = (int)flag;
            return mydm.GetWindow(hwnd, iflag);
        }
        /// <summary>
        /// 获取句柄图像
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static Bitmap GetHwndImage(int hwnd)
        {
            Rectangle rc = GetHwndRec(hwnd);
            Bitmap bmp = new Bitmap(rc.Width, rc.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(rc.Location, new System.Drawing.Point(0, 0), rc.Size);
            }
            return bmp;
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
    /// <summary>
    /// 查找窗口句柄动作枚举
    /// </summary>
    public enum GetWindowFlagEnum
    { 
        /// <summary>
        /// 获取父窗口
        /// </summary>
        GetParentHwnd,
        /// <summary>
        /// 获取子节点的第一个窗口
        /// </summary>
        GetChildFirstHwnd,
        /// <summary>
        /// 获取第一个窗口
        /// </summary>
        GetFirstHwnd,
        /// <summary>
        /// 获取最后一个窗口
        /// </summary>
        GetLastHwnd,
        /// <summary>
        /// 获取下一个窗口
        /// </summary>
        GetNextHwnd,
        /// <summary>
        /// 获取上一个窗口
        /// </summary>
        GetUpHwnd,
        /// <summary>
        /// 获取窗体的拥有者
        /// </summary>
        GetOwnHwnd,
        /// <summary>
        /// 获取顶层窗口
        /// </summary>
        GetTopHwnd
    }
}
