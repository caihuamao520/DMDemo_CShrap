using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMDemo.FromHwnd
{
    /// <summary>
    /// 获取目标句柄配置
    /// </summary>
    public class GetHwndConfig
    {
        /// <summary>
        /// 顶层窗体类名
        /// </summary>
        public string TopFromClassName { get; set; }
        /// <summary>
        /// 窗体名称
        /// </summary>
        public string TopFromTitle { get; set; }
        /// <summary>
        /// 指定进程名称
        /// </summary>
        public string FromProcessFilePath { get; set; }
        /// <summary>
        /// 层级遍历信息（倒序）
        /// </summary>
        public List<int> LevelIndex { get; set; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="currentHwnd"></param>
        public GetHwndConfig(int topFromHwnd)
        {
            TopFromTitle = GetHwndInfor.GetHwndTitle(topFromHwnd);
            TopFromClassName = GetHwndInfor.GetHwndClassName(topFromHwnd);
            FromProcessFilePath = GetHwndInfor.GetWindowProcessPath(topFromHwnd);
            LevelIndex = new List<int>();
        }
    }
}
