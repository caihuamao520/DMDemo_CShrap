using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DMDemo.FromHwnd
{
    /// <summary>
    /// 跟随鼠标获取到的句柄信息
    /// </summary>
    public class MousePointHwndInfor
    {
        /// <summary>
        /// 获取句柄时鼠标停留的位置
        /// </summary>
        public Point MousePoint { get; internal set; }

        /// <summary>
        /// 句柄
        /// </summary>
        public int CurrentHwnd { get; internal set; }

        /// <summary>
        /// 句柄内容
        /// </summary>
        public string CurrentHwndTitle { get; internal set; }

        /// <summary>
        /// 句柄类名
        /// </summary>
        public string CurrentHwndClassName { get; internal set; }

        /// <summary>
        /// 父窗体句柄
        /// </summary>
        public int ParentHwnd { get; internal set; }

        /// <summary>
        /// 父窗体文本
        /// </summary>
        public string ParentTitle { get; internal set; }

        /// <summary>
        /// 父窗体类名
        /// </summary>
        public string ParentClassName { get; internal set; }

        /// <summary>
        /// 顶层窗体句柄
        /// </summary>
        public int TopFromHwnd { get; internal set; }

        /// <summary>
        /// 顶层窗体句柄内容
        /// </summary>
        public string TopFromTitle { get; internal set; }

        /// <summary>
        /// 顶层窗体类名
        /// </summary>
        public string TopFromClassName { get; internal set; }

        /// <summary>
        /// 句柄线程名称
        /// </summary>
        public string HwndProcessPath { get; internal set; }

        /// <summary>
        /// 句柄控件尺寸大小
        /// </summary>
        public Rectangle HwndRect { get; internal set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public MousePointHwndInfor()
        {
            HwndRect = new Rectangle(0, 0, 0, 0);
            MousePoint = new Point(0, 0);
            CurrentHwnd = 0;
        }
    }
}
