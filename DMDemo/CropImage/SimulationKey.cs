using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
            keybd_event((byte)0x2c, 0, 0x0, IntPtr.Zero);//down
            Application.DoEvents();
            keybd_event((byte)0x2c, 0, 0x2, IntPtr.Zero);//up
            Application.DoEvents();
        }

        /// <summary>
        /// 模拟Alt + Print Screen键盘消息，截取当前窗口图片。
        /// </summary>
        public void AltPrintScreen()
        {
            keybd_event((byte)18, 0, 0x0, IntPtr.Zero);
            keybd_event((byte)0x2c, 0, 0x0, IntPtr.Zero);//down
            Application.DoEvents();
            Application.DoEvents();
            keybd_event((byte)0x2c, 0, 0x2, IntPtr.Zero);//up
            keybd_event((byte)18, 0, 0x2, IntPtr.Zero);
            Application.DoEvents();
            Application.DoEvents();
        }
    }
}
