using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CropImage
{
    /// <summary>
    /// 工具栏按钮枚举
    /// </summary>
    public enum ToolbarBtnEnum
    { 
        /// <summary>
        /// 未定义按钮
        /// </summary>
        Undefine,
        /// <summary>
        /// 确定按钮
        /// </summary>
        OK,
        /// <summary>
        /// 取消按钮
        /// </summary>
        Cancel,
        /// <summary>
        /// 保存按钮
        /// </summary>
        Save
    }
    public partial class ToolBarsFrom : Form
    {
        /// <summary>
        /// 点击按钮委托
        /// </summary>
        /// <param name="btnType">按钮类型</param>
        public delegate void ToolbarBtnClickDel(ToolbarBtnEnum btnType);
        /// <summary>
        /// 点击按钮事件
        /// </summary>
        public event ToolbarBtnClickDel ToolbarBtnClickEvn;

        public ToolBarsFrom()
        {
            InitializeComponent();
        }

        private void ToolBarsFrom_Load(object sender, EventArgs e)
        {

        }

        private void tsbtnSaveImage_Click(object sender, EventArgs e)
        {
            if (ToolbarBtnClickEvn != null)
            {
                ToolbarBtnClickEvn(ToolbarBtnEnum.Save);
            }
        }

        private void tsbtnYes_Click(object sender, EventArgs e)
        {
            if (ToolbarBtnClickEvn != null)
            {
                ToolbarBtnClickEvn(ToolbarBtnEnum.OK);
            }
            this.Close();
        }

        private void tsbtnNo_Click(object sender, EventArgs e)
        {
            if (ToolbarBtnClickEvn != null)
            {
                ToolbarBtnClickEvn(ToolbarBtnEnum.Cancel);
            }
            this.Close();
        }
    }
}
