using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
//using System.Threading;
using System.Windows.Forms;

namespace CropImage
{
    /// <summary>
    /// 模拟按键
    /// </summary>
    public class SimulationKey
    {
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
            keybd_event((byte)Keys.PrintScreen, 0, 0x0, IntPtr.Zero);//down
            //Application.DoEvents();
            Thread.Sleep(50);
            keybd_event((byte)Keys.PrintScreen, 0, 0x2, IntPtr.Zero);//up
            Thread.Sleep(50);
        }

        /// <summary>
        /// 模拟Alt + Print Screen键盘消息，截取当前窗口图片。
        /// </summary>
        public void Alt_PrintScreen()
        {
            keybd_event((byte)Keys.Menu, 0, 0x0, IntPtr.Zero);
            Thread.Sleep(50);
            keybd_event((byte)Keys.PrintScreen, 0, 0x0, IntPtr.Zero);//down
            Thread.Sleep(50);
            keybd_event((byte)Keys.PrintScreen, 0, 0x2, IntPtr.Zero);//up
            Thread.Sleep(50);
            keybd_event((byte)Keys.Menu, 0, 0x2, IntPtr.Zero);
            Thread.Sleep(50);
        }
        /// <summary>
        /// 隐藏或显示所有窗口
        /// </summary>
        public void Win_D()
        {
            keybd_event((byte)Keys.LWin, 0, 0x0, IntPtr.Zero);
            Thread.Sleep(50);
            keybd_event((byte)Keys.D, 0, 0x0, IntPtr.Zero);//down
            Thread.Sleep(50);
            keybd_event((byte)Keys.D, 0, 0x2, IntPtr.Zero);//up
            Thread.Sleep(50);
            keybd_event((byte)Keys.LWin, 0, 0x2, IntPtr.Zero);
            Thread.Sleep(50);
        }

        public void Win_M()
        {
            keybd_event((byte)Keys.LWin, 0, 0x0, IntPtr.Zero);
            Thread.Sleep(50);
            keybd_event((byte)Keys.M, 0, 0x0, IntPtr.Zero);//down
            Thread.Sleep(50);
            keybd_event((byte)Keys.M, 0, 0x2, IntPtr.Zero);//up
            Thread.Sleep(50);
            keybd_event((byte)Keys.LWin, 0, 0x2, IntPtr.Zero);
            Thread.Sleep(50);
        }

        public void Win_Shift_M()
        {
            keybd_event((byte)Keys.LWin, 0, 0x0, IntPtr.Zero);
            Thread.Sleep(50);
            keybd_event((byte)Keys.LShiftKey, 0, 0x0, IntPtr.Zero);
            Thread.Sleep(50);
            keybd_event((byte)Keys.M, 0, 0x0, IntPtr.Zero);//down
            Thread.Sleep(50);
            keybd_event((byte)Keys.M, 0, 0x2, IntPtr.Zero);//up
            Thread.Sleep(50);
            keybd_event((byte)Keys.LShiftKey, 0, 0x2, IntPtr.Zero);
            Thread.Sleep(50);
            keybd_event((byte)Keys.LWin, 0, 0x2, IntPtr.Zero);
            Thread.Sleep(50);
        }
    }
}
