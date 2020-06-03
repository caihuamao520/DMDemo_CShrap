using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DMDemo
{
    /// <summary>
    /// 系统热键工具类
    /// </summary>
    public class HotKeysUtil
    {
        [DllImport("user32.dll")]//注册全局热键
        protected static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]//卸载全局热键
        protected static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        ///// <summary>
        ///// 注册热键
        ///// </summary>
        ///// <param name="hWnd">需要注册的窗体句柄</param>
        ///// <param name="keyValue">按键值</param>
        ///// <param name="id">热键区分ID</param>
        ///// <returns>热键区分ID，失败返回0</returns>
        //public static int RegHotKey(IntPtr hWnd, Model.HotKeyValue keyValue, int id = 0)
        //{
        //    uint fsModifiers = (keyValue.Control ? HotKeysModifiers.ModControl : 0x0)
        //         | (keyValue.Alt ? HotKeysModifiers.ModAlt : 0x0)
        //         | (keyValue.Shift ? HotKeysModifiers.ModShift : 0x0);
        //    if (id == 0)
        //    {
        //        id = (int)keyValue.KeyData;
        //    }
        //    if (RegHotKey(hWnd, fsModifiers, (uint)keyValue.KeyValue, id))
        //    {
        //        return id;
        //    }
        //    return 0;
        //}

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hWnd">需要注册的窗体句柄</param>
        /// <param name="fsModifiers">热键消息</param>
        /// <param name="vk">快捷键</param>
        /// <param name="hotkeyId">热键区分ID</param>
        /// <returns></returns>
        public static bool RegHotKey(IntPtr hWnd, uint fsModifiers, uint vk, int hotkeyId = 0)
        {
            return RegisterHotKey(hWnd, hotkeyId, fsModifiers, vk);
        }

        /// <summary>
        /// 卸载热键
        /// </summary>
        /// <param name="hWnd">需要注册的窗体句柄</param>
        /// <param name="hotkeyId"> </param>
        /// <returns></returns>
        public static bool UnregHotKey(IntPtr hWnd, int hotkeyId = 0)
        {
            return UnregisterHotKey(hWnd, hotkeyId);
        }
    }
}
