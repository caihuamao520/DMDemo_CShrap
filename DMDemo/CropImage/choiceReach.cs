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
    public partial class choiceReach : Form
    {
        /// <summary>
        /// 通知操作任务委托
        /// </summary>
        /// <param name="rec"></param>
        /// <param name="btnType"></param>
        public delegate void NoticeTaskDel(Rectangle rec, ToolbarBtnEnum btnType);
        /// <summary>
        /// 通知任务事件
        /// </summary>
        public event NoticeTaskDel NoticeTaskEvn;
        /// <summary>
        /// 窗体是否弹出
        /// </summary>
        public bool IsShowFrom { get; private set; }
        /// <summary>
        /// 是否弹出确认
        /// </summary>
        public bool IsShowOK { get; private set; }
        public choiceReach(Point location)
        {
            InitializeComponent();
            this.TransparencyKey = this.panel1.BackColor;
            IsShowFrom = false;
            this.Location = location;
        }

        private void choiceReach_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 显示工具栏
        /// </summary>
        /// <param name="mousePosition"></param>
        /// <param name="Bounds"></param>
        public void ShowToolBars(Rectangle Bounds)
        {
            if (IsShowOK == false)
            {
                ToolBarsFrom tbf = new ToolBarsFrom();
                tbf.ToolbarBtnClickEvn += tbf_ToolbarBtnClickEvn;
                Point rightPoint = new Point(this.Location.X + this.Size.Width, this.Location.Y + this.Size.Height);
                if ((rightPoint.Y + tbf.Size.Height + 5) < Bounds.Height)
                {
                    tbf.Location = new Point(rightPoint.X - tbf.Size.Width, rightPoint.Y + 2);
                }
                else
                {
                    tbf.Location = new Point(rightPoint.X - tbf.Size.Width - 10, rightPoint.Y - tbf.Size.Height - 2);
                }
                tbf.Show();

                this.FormClosing += (object sender, FormClosingEventArgs e) => 
                {
                    if (tbf != null)
                    {
                        tbf.Close();
                    }
                };

                IsShowOK = true;
            }
        }
        /// <summary>
        /// 工具栏点击了按钮
        /// </summary>
        /// <param name="btnType"></param>
        private void tbf_ToolbarBtnClickEvn(ToolbarBtnEnum btnType)
        {
            if (btnType == ToolbarBtnEnum.Save)
            {
                if (NoticeTaskEvn != null)
                {
                    Rectangle rec = new Rectangle(this.PointToScreen(this.panel1.Location), this.panel1.Size);
                    NoticeTaskEvn(rec, btnType);
                }
            }
            else if (btnType == ToolbarBtnEnum.OK)
            {
                if (NoticeTaskEvn != null)
                {
                    Rectangle rec = new Rectangle(this.PointToScreen(this.panel1.Location), this.panel1.Size);
                    NoticeTaskEvn(rec, btnType);
                }
                this.Close();
            }
            else if (btnType == ToolbarBtnEnum.Cancel)
            {
                if (NoticeTaskEvn != null)
                {
                    Rectangle rec = default(Rectangle);
                    NoticeTaskEvn(rec, btnType);
                }
                this.Close();
            }
        }

        /// <summary>
        /// 依据参考位置和鼠标位置绘制一个矩形框
        /// </summary>
        /// <param name="start">参考屏幕坐标</param>
        /// <param name="mousePosition">当前鼠标位置</param>
        public void MousePositionToDrawArea(Point start, Point mousePosition)
        {
            this.SuspendLayout();
            Point currFormPoint = start;
            Size currFromSize = this.Size;
            int sx = start.X, xy = start.Y;

            bool xIsNegative = false, yIsNegative = false;
            if (mousePosition.X < sx) xIsNegative = true;
            if (mousePosition.Y < xy) yIsNegative = true;

            if (xIsNegative == false && yIsNegative == false)
            {
                currFromSize.Width = Math.Abs(mousePosition.X - start.X);
                currFromSize.Height = Math.Abs(mousePosition.Y - start.Y);
            }
            else if (xIsNegative == false && yIsNegative == true)
            {
                currFromSize.Width = Math.Abs(mousePosition.X - start.X);
                currFromSize.Height = Math.Abs(start.Y - mousePosition.Y);
                currFormPoint.Y = Math.Abs(start.Y - (start.Y - mousePosition.Y));
            }
            else if (xIsNegative == true && yIsNegative == true)
            {
                currFromSize.Width = Math.Abs(start.X - mousePosition.X);
                currFromSize.Height = Math.Abs(start.Y - mousePosition.Y);
                currFormPoint.X = Math.Abs(start.X - (start.X - mousePosition.X));
                currFormPoint.Y = Math.Abs(start.Y - (start.Y - mousePosition.Y));
            }
            else if (xIsNegative == true && yIsNegative == false)
            {
                currFromSize.Width = Math.Abs(start.X - mousePosition.X);
                currFromSize.Height = Math.Abs(mousePosition.Y - start.Y);
                currFormPoint.X = Math.Abs(start.X - (start.X - mousePosition.X));
            }

            this.Location = currFormPoint;
            this.Size = currFromSize;

            this.ResumeLayout();
            if (IsShowFrom == false)
            {
                this.Show();
                IsShowFrom = true;
            }
        }
    }
}
