using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices; 

namespace DMDemo
{
    public class WindowsHwnd
    {
        /// <summary>
        /// 获得顶层窗体句柄
        /// </summary>
        /// <param name="lpClassName">类名（不区分大小写）</param>
        /// <param name="lpWindowName">窗口名（不区分大小写）</param>
        /// <returns>句柄</returns>
        [DllImport("user32", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 获得一个窗体句柄
        /// </summary>
        /// <param name="parent">子窗口的父窗口句柄，为NULL，则函数以桌面窗口为父窗口，查找桌面窗口的所有子窗口</param>
        /// <param name="childAfter">子窗口句柄。查找从在Z序中的下一个子窗口开始.子窗口必须为parent窗口的直接子窗口而非后代窗口。如果childAfter为NULL(C#中为newIntPtr(0))，查找从parent的第一个子窗口开始。如果parent 和 childAfter同时为NULL，则函数查找所有的顶层窗口及消息窗口。</param>
        /// <param name="className">指向一个指定了类名的空结束字符串，或一个标识类名字符串的成员的指针。如果该参数为一个成员，则它必须为前次调用theGlobaIAddAtom函数产生的全局成员。该成员为16位，必须位于lpClassName的低16位，高位必须为0</param>
        /// <param name="windowName">指向一个指定了窗口名（窗口标题）的空结束字符串。如果该参数为 NULL（注意：””和null是有区别的），则为所有窗口全匹配</param>
        /// <returns>找到的窗口的句柄。如未找到相符窗口，则返回零。会设置GetLastError</returns>
        [DllImport("user32", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childAfter, string className, string windowName);
       
        /// <summary>
        /// 显示或隐藏窗体
        /// </summary>
        /// <param name="hWnd">操作的窗口句柄</param>
        /// <param name="nCmdShow">1 表示显示， 0 表示隐藏</param>
        /// <returns>如果窗口之前可见，则返回值为非零。如果窗口之前被隐藏，则返回值为零。</returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowStateEunm nCmdShow);

        /// <summary>
        /// 指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。系统给创建前台窗口的线程分配的权限稍高于其他线程。
        /// </summary>
        /// <param name="hWnd">被激活，并带到前景的窗口句柄</param>
        /// <returns>如果窗口被带到前台，返回值为非零。</returns>
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 根据鼠标位置获取句柄
        /// </summary>
        /// <param name="pt">鼠标位置</param>
        /// <returns>包含该点的窗口的句柄。如果包含指定点的窗口不存在，返回值为NULL。如果该点在静态文本控件之上，返回值是在该静态文本控件的下面的窗口的句柄。</returns>
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        public static extern IntPtr WindowFromPoint(Point pt);

        /// <summary>    
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回(需要用HWND_BROADCAST通信的应用程序应当使用函数RegisterWindowMessage来为应用程序间的通信取得一个唯一的消息。)。　    
        /// </summary>    
        /// <param name="hWnd">指定要接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>    
        /// <param name="msg">指定被发送的消息</param>    
        /// <param name="wParam">指定附加的消息指定信息</param>    
        /// <param name="lParam">指定附加的消息指定信息</param>    
        /// <returns></returns>
        [DllImport("user32.dll ", EntryPoint = "SendMessage ")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
       
        /// <summary>    
        /// 返回桌面窗口的句柄。桌面窗口覆盖整个屏幕。桌面窗口是一个要在其上绘制所有的图标和其他窗口的区域。    
        /// </summary>
        [DllImport("user32", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// 通过发送重绘消息 WM_PAINT 给目标窗体来更新目标窗体客户区的无效区域(可以使用API 函数 GetLastError 来得到扩展的错误信息)。
        /// </summary>
        /// <param name="hWnd">要更新的窗口的句柄.</param>
        /// <returns>函数调用成功，返回值为非零值,函数调用不成功，返回值为零</returns> 
        [DllImport("User32.dll", EntryPoint = "UpdateWindow")]
        public static extern bool UpdateWindow(IntPtr hWnd);
        
        /// <summary>
        /// 改变一个子窗口，弹出式窗口或顶层窗口的尺寸，位置和Z序。子窗口，弹出式窗口，及顶层窗口根据它们在屏幕上出现的顺序排序、顶层窗口设置的级别最高，并且被设置为Z序的第一个窗口。
        /// </summary>
        /// <param name="hWnd">在z序中的位于被置位的窗口前的窗口句柄。该参数必须为一个窗口句柄</param>
        /// <param name="hWndInsertAfter">用于标识在z-顺序的此 CWnd 对象之前的 CWnd 对象。如果uFlags参数中设置了SWP_NOZORDER标记则本参数将被忽略。可为下列值之一</param>
        /// <param name="x">以客户坐标指定窗口新位置的左边界</param>
        /// <param name="y">以客户坐标指定窗口新位置的顶边界。</param>
        /// <param name="Width">以像素指定窗口的新的宽度。</param>
        /// <param name="Height">以像素指定窗口的新的高度。</param>
        /// <param name="flags">窗口尺寸和定位的标志。</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, SetWindowPoshWndInsertAfterEnum hWndInsertAfter, int x, int y, int Width, int Height, SetWindowPosFlagsEnum flags);

        /// <summary>
        /// 获得一个指定子窗口的父窗口句柄。
        /// </summary>
        /// <param name="hWnd">子窗口句柄，函数要获得该子窗口的父窗口句柄。</param>
        /// <returns>如果函数成功，返回值为父窗口句柄。如果窗口无父窗口，则函数返回NULL。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        /// <summary>
        /// 该函数将一个消息放入（寄送）到与指定窗口创建的线程相联系消息队列里，不等待线程处理消息就返回，是异步消息模式。消息队列里的消息通过调用GetMessage和PeekMessage取得。   
        /// </summary>
        /// <param name="hWnd">其窗口程序接收消息的窗口的句柄。可取有特定含义的两个值：HWND_BROADCAST：消息被寄送到系统的所有顶层窗口，包括无效或不可见的非自身拥有的窗口、 被覆盖的窗口和弹出式窗口。消息不被寄送到子窗口，NULL：此函数的操作和调用参数dwThread设置为当前线程的标识符PostThreadMessage函数一样/param>
        /// <param name="msg">指定被寄送的消息。</param>
        /// <param name="wParam">指定附加的消息特定的信息。</param>
        /// <param name="lParam">指定附加的消息特定的信息。</param>
        /// <returns>如果函数调用成功，返回非零，否则函数调用返回值为零</returns>   
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        /// <summary>    
        /// 该函数对指定的窗口设置键盘焦点。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        /// <summary>    
        /// 该函数改变指定子窗口的父窗口。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        /// <summary>    
        /// 获取对话框中子窗口控件的句柄    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);
        /// <summary>    
        /// 该函数获取窗口客户区的坐标。    
        /// </summary>    
        //public extern static int GetClientRect(IntPtr hWnd, ref RECT rc);    
        /// <summary>    
        /// 该函数向指定的窗体添加一个矩形，然后窗口客户区域的这一部分将被重新绘制。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static int InvalidateRect(IntPtr hWnd, IntPtr rect, int bErase);

        /// <summary>    
        /// 确定当前焦点位于哪个控件上。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetFocus();

        /// <summary>    
        /// 该函数改变指定窗口的位置和尺寸。对于顶层窗口，位置和尺寸是相对于屏幕的左上角的：对于子窗口，位置和尺寸是相对于父窗口客户区的左上角坐标的。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

        /// <summary>    
        /// 该函数改变指定窗口的属性    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>    
        /// 该函数改变指定窗口的标题栏的文本内容    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SetWindowText(IntPtr hWnd, string text);

        /// <summary>    
        /// 该函数将指定窗口的标题条文本（如果存在）拷贝到一个缓存区内。如果指定的窗口是一个控制，则拷贝控制的文本。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, out StringBuilder text, int maxCount); 

        /// <summary>    
        /// 该函数获得指定窗口所属的类的类名。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, out StringBuilder ClassName, int nMaxCount);
        //public static extern int GetClassName(IntPtr hWnd, out STRINGBUFFER ClassName, int nMaxCount);    

        /// <summary>    
        /// 该函数检索指定窗口客户区域或整个屏幕的显示设备上下文环境的句柄，在随后的GDI函数中可以使用该句柄在设备上下文环境中绘图。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRegion, uint flags);
        
        /// <summary>    
        /// 获取整个窗口（包括边框、滚动条、标题栏、菜单等）的设备场景 返回值 Long。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary>    
        /// 该函数返回指定窗口的显示状态以及被恢复的、最大化的和最小化的窗口位置。    
        /// </summary>    
        //public static extern int GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT wp);

        /// <summary>    
        /// 该函数将指定的窗口设置到Z序的顶部。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);

        /// <summary>    
        /// 该函数确定给定的窗口句柄是否识别一个已存在的窗口。    
        /// </summary>    
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int IsWindow(IntPtr hWnd);





        #region 其他API
        ////public static extern IntPtr SetWindowsHookEx(int hookid, HookProc pfnhook, IntPtr hinst, int threadid);    

        //[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]    
        //public static extern bool UnhookWindowsHookEx(IntPtr hhook);    

        //[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]    
        //public static extern IntPtr CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);    

        ///// <summary>    
        ///// 该函数在指定的矩形里写入格式化文本，根据指定的方法对文本格式化（扩展的制表符，字符对齐、折行等）。    
        ///// </summary>    
        ////public extern static int DrawText(IntPtr hdc, string lpString, int nCount, ref RECT lpRect, int uFormat);    

        ///// <summary>    
        ///// 该函数产生对其他线程的控制，如果一个线程没有其他消息在其消息队列里。    
        ///// </summary>    
        //public static extern bool WaitMessage();    
        ///// <summary>    
        ///// 该函数为一个消息检查线程消息队列，并将该消息（如果存在）放于指定的结构。    
        ///// </summary>    
        ////public static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);    
        ///// <summary>    
        ///// 该函数从调用线程的消息队列里取得一个消息并将其放于指定的结构。此函数可取得与指定窗口联系的消息和由PostThreadMesssge寄送的线程消息。此函数接收一定范围的消息值。    
        ///// </summary>    
        ////public static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);    
        ///// <summary>    
        ///// 该函数将虚拟键消息转换为字符消息。    
        ///// </summary>    
        ////public static extern bool TranslateMessage(ref MSG msg);    
        ///// <summary>    
        ///// 该函数调度一个消息给窗口程序。    
        ///// </summary>    
        ////public static extern bool DispatchMessage(ref MSG msg);    
        ///// <summary>    
        ///// 该函数从一个与应用事例相关的可执行文件（EXE文件）中载入指定的光标资源.    
        ///// </summary>    
        //public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);    
        ///// <summary>    
        ///// 该函数确定光标的形状。    
        ///// </summary>    
        //public static extern IntPtr SetCursor(IntPtr hCursor);    

        ///// <summary>    
        ///// 该函数从当前线程中的窗口释放鼠标捕获，并恢复通常的鼠标输入处理。捕获鼠标的窗口接收所有的鼠标输入（无论光标的位置在哪里），除非点击鼠标键时，光标热点在另一个线程的窗口中。    
        ///// </summary>    
        //public static extern bool ReleaseCapture();    
        ///// <summary>    
        ///// 准备指定的窗口来重绘并将绘画相关的信息放到一个PAINTSTRUCT结构中。    
        ///// </summary>    
        ////public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);    
        ///// <summary>    
        ///// 标记指定窗口的绘画过程结束,每次调用BeginPaint函数之后被请求    
        ///// </summary>    
        ////public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);    
        ///// <summary>    
        ///// 半透明窗体    
        ///// </summary>    
        ////public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);    
        ///// <summary>    
        ///// 该函数返回指定窗口的边框矩形的尺寸。该尺寸以相对于屏幕坐标左上角的屏幕坐标给出。    
        ///// </summary>    
        ////public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);    
        ///// <summary>    
        ///// 该函数将指定点的用户坐标转换成屏幕坐标。    
        ///// </summary>    
        ////public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt);    
        ///// <summary>    
        ///// 当在指定时间内鼠标指针离开或盘旋在一个窗口上时，此函数寄送消息。    
        ///// </summary>    
        ////public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);    
        ///// <summary>    
        /////     
        ///// </summary>    
        //public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);    
        ///// <summary>    
        ///// 该函数检取指定虚拟键的状态。    
        ///// </summary>    
        //public static extern ushort GetKeyState(int virtKey);
        ///// <summary>    
        ///// 该函数用指定的画刷填充矩形，此函数包括矩形的左上边界，但不包括矩形的右下边界。    
        ///// </summary>    
        ////public static extern int FillRect(IntPtr hDC, ref RECT rect, IntPtr hBrush);
        ///// <summary>    
        ///// 用于得到被定义的系统数据或者系统配置信息.    
        ///// </summary>    
        //static public extern int GetSystemMetrics(int nIndex);    
        ///// <summary>    
        ///// 该函数设置滚动条参数，包括滚动位置的最大值和最小值，页面大小，滚动按钮的位置。    
        ///// </summary>    
        ////static public extern int SetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si, int fRedraw);    
        ///// <summary>    
        ///// 该函数显示或隐藏所指定的滚动条。    
        ///// </summary>    
        //public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);    
        ///// <summary>    
        ///// 该函数可以激活一个或两个滚动条箭头或是使其失效。    
        ///// </summary>    
        //public static extern int EnableScrollBar(IntPtr hWnd, uint flags, uint arrows);   
        ///// <summary>    
        ///// 该函数滚动指定窗体客户区域的目录。    
        ///// </summary>    
        ////static public extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy,ref RECT rcScroll, ref RECT rcClip, IntPtr UpdateRegion, ref RECT rcInvalidated, uint flags);    

        ///// <summary>    
        ///// 该函数将256个虚拟键的状态拷贝到指定的缓冲区中。    
        ///// </summary>    
        //public static extern int GetKeyboardState(byte[] pbKeyState);    
        ///// <summary>    
        ///// 该函数将指定的虚拟键码和键盘状态翻译为相应的字符或字符串。该函数使用由给定的键盘布局句柄标识的物理键盘布局和输入语言来翻译代码。    
        ///// </summary>    
        //public static extern int ToAscii(int uVirtKey,int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey,int fuState);
        #endregion


    }

    /// <summary>
    /// 窗口状态
    /// </summary>
    public enum ShowWindowStateEunm
    {
        /// <summary>
        /// 隐藏窗口并激活其他窗口
        /// </summary>
        SW_HIDE = 0,
        /// <summary>
        /// 激活并显示一个窗口。如果窗口被最小化或最大化，系统将其恢复到原来的尺寸和大小。应用程序在第一次显示窗口的时候应该指定此标志。
        /// </summary>
        SW_SHOWNORMAL = 1,
        /// <summary>
        /// 激活窗口并将其最小化
        /// </summary>
        SW_SHOWMINIMIZED = 2,
        /// <summary>
        /// 激活窗口并将其最大化
        /// </summary>
        SW_SHOWMAXIMIZED = 3,
        /// <summary>
        /// 最大化指定的窗口
        /// </summary>
        SW_MAXIMIZE = 3,
        /// <summary>
        /// 以窗口最近一次的大小和状态显示窗口。激活窗口仍然维持激活状态。
        /// </summary>
        SW_SHOWNOACTIVATE = 4,
        /// <summary>
        /// 在窗口原来的位置以原来的尺寸激活和显示窗口。
        /// </summary>
        SW_SHOW = 5,
        /// <summary>
        /// 最小化指定的窗口并且激活在Z序中的下一个顶层窗口。
        /// </summary>
        SW_MINIMIZE = 6,
        /// <summary>
        /// 窗口最小化，激活窗口仍然维持激活状态。
        /// </summary>
        SW_SHOWMINNOACTIVE = 7,
        /// <summary>
        /// 以窗口原来的状态显示窗口。激活窗口仍然维持激活状态。
        /// </summary>
        SW_SHOWNA = 8,
        /// <summary>
        /// 激活并显示窗口。如果窗口最小化或最大化，则系统将窗口恢复到原来的尺寸和位置。在恢复最小化窗口时，应用程序应该指定这个标志。
        /// </summary>
        SW_RESTORE = 9,
        /// <summary>
        /// 依据在STARTUPINFO结构中指定的SW_FLAG标志设定显示状态，STARTUPINFO 结构是由启动应用程序的程序传递给CreateProcess函数的。
        /// </summary>
        SW_SHOWDEFAULT = 10,
        /// <summary>
        /// 在WindowNT5.0中最小化窗口，即使拥有窗口的线程被挂起也会最小化。在从其他线程最小化窗口时才使用这个参数。
        /// </summary>
        SW_FORCEMINIMIZE = 11
    }
    /// <summary>
    /// 枚举设置窗口位置
    /// </summary>
    public enum SetWindowPoshWndInsertAfterEnum
    {
        /// <summary>
        /// 将窗口置于所有非顶层窗口之上（即在所有顶层窗口之后）。如果窗口已经是非顶层窗口则该标志不起作用。
        /// </summary>
        HWND_NOTOPMOST = -2,
        /// <summary>
        /// 将窗口置于所有非顶层窗口之上。即使窗口未被激活窗口也将保持顶级位置。
        /// </summary>
        HWND_TOPMOST = -1,
        /// <summary>
        /// 将窗口置于Z序的顶部
        /// </summary>
        HWND_TOP = 0,
        /// <summary>
        /// 将窗口置于Z序的底部。如果参数hWnd标识了一个顶层窗口，则窗口失去顶级位置，并且被置在其他窗口的底部。
        /// </summary>
        HWND_BOTTOM = 1

    }
    /// <summary>
    /// 枚举窗口尺寸和定位的标志
    /// </summary>
    public enum SetWindowPosFlagsEnum
    {
        /// <summary>
        /// 如果调用进程不拥有窗口，系统会向拥有窗口的线程发出需求。这就防止调用线程在其他线程处理需求的时候发生死锁。
        /// </summary>
        SWP_ASYNCWINDOWPOS,
        /// <summary>
        /// 防止产生WM_SYNCPAINT消息
        /// </summary>
        SWP_DEFERERASE,
        /// <summary>
        /// 在窗口周围画一个边框（定义在窗口类描述中）。
        /// </summary>
        SWP_DRAWFRAME,
        /// <summary>
        /// 给窗口发送WM_NCCALCSIZE消息，即使窗口尺寸没有改变也会发送该消息。如果未指定这个标志，只有在改变了窗口尺寸时才发送WM_NCCALCSIZE。
        /// </summary>
        SWP_FRAMECHANGED,
        /// <summary>
        /// 隐藏窗口。
        /// </summary>
        SWP_HIDEWINDOW,
        /// <summary>
        /// 不激活窗口。如果未设置标志，则窗口被激活，并被设置到其他最高级窗口或非最高级组的顶部（根据参数hWndlnsertAfter设置）。
        /// </summary>
        SWP_NOACTIVATE,
        /// <summary>
        /// 清除客户区的所有内容。如果未设置该标志，客户区的有效内容被保存并且在窗口尺寸更新和重定位后拷贝回客户区。
        /// </summary>
        SWP_NOCOPYBITS,
        /// <summary>
        /// 维持当前位置（忽略X和Y参数）。
        /// </summary>
        SWP_NOMOVE,
        /// <summary>
        /// 不改变z序中的所有者窗口的位置。
        /// </summary>
        SWP_NOOWNERZORDER,
        /// <summary>
        /// 不重画改变的内容。如果设置了这个标志，则不发生任何重画动作。适用于客户区和非客户区（包括标题栏和滚动条）和任何由于窗回移动而露出的父窗口的所有部分。如果设置了这个标志，应用程序必须明确地使窗口无效并区重画窗口的任何部分和父窗口需要重画的部分。
        /// </summary>
        SWP_NOREDRAW,
        /// <summary>
        /// 与SWP_NOOWNERZORDER标志相同。
        /// </summary>
        SWP_NOREPOSITION,
        /// <summary>
        /// 防止窗口接收WM_WINDOWPOSCHANGING消息。
        /// </summary>
        SWP_NOSENDCHANGING,
        /// <summary>
        /// 维持当前尺寸（忽略宽度和高度参数）。
        /// </summary>
        SWP_NOSIZE,
        /// <summary>
        /// 维持当前Z序（忽略hWndlnsertAfter参数）。
        /// </summary>
        SWP_NOZORDER,
        /// <summary>
        /// 显示窗口。
        /// </summary>
        SWP_SHOWWINDOW
    }



}
