using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace DMDemo
{
    public partial class HwndGetTitleFrom : Form
    {
        public HwndGetTitleFrom()
        {
            InitializeComponent();
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            this.txtMousePoint.Text=Properties.Settings.Default.mousePoint;
            this.txtClassName.Text = Properties.Settings.Default.className;
            this.txtLikeTitle.Text = Properties.Settings.Default.LikeTitle;
            _topFormClassName = Properties.Settings.Default.TopFormClassName;
            _topFormTitle=Properties.Settings.Default.TopFormTitle;

            this.txtTitle.Text = string.Format("顶层窗体类名:{0}\r\n顶层窗体题名:{1}", _topFormClassName, _topFormTitle);
        }
        private int iActiveHwnd;
        private void btnGetActiveLocation_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.ckbIsHidForm.Checked)
                {
                    this.Hide();
                }
                this.btnGetActiveLocation.Text = "获取位置中……";

                GetHwndInfor getHwnd = new GetHwndInfor();
                if (getHwnd.ShowDialog() == DialogResult.Yes)
                {
                    iActiveHwnd = getHwnd.intHwnd;
                    this.txtHwnd.Text = iActiveHwnd.ToString();
                    this.txtTitle.Text = string.Format("文本：{0}\r\n类名：{1}\r\n进程路径：{2}\r\n顶层窗体句柄：{3}\r\n鼠标位置：{4}\r\n组件距离顶层窗体的偏移量：{5}\r\n顶层窗体类名：{6}\r\n顶层窗体文本：{7}\r\n父窗体文本：{8}\r\n父窗体类名：{9}",
                         getHwnd.HwndTitle, getHwnd.HwndClassName, getHwnd.HwndProcessPath, getHwnd.HwndTopFrom, getHwnd.MousePoint, 
                         //getHwnd.CalculationTopFormOffsetPoint(GetHwndInfor.GetTopFormHwnd(iActiveHwnd), getHwnd.MousePoint),
                         getHwnd.CalculationTopFormOffsetPoint(iActiveHwnd),
                         getHwnd.TopFromClassName, getHwnd.TopFromTitle,
                         getHwnd.ParentTitle,getHwnd.ParentClassName);

                    //getHwnd.TopFromTitle

                    this.btnGetActiveLocation.Text = "获取位置";
                }
                else
                {
                    this.btnGetActiveLocation.Text = "获取失败";
                }
                if (this.ckbIsHidForm.Checked)
                {
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常");
            }
        }
        private Thread RealTimeGetContent;
        private void btnRealTimeGetHwndData_Click(object sender, EventArgs e)
        {
            if (this.btnRealTimeGetHwndData.Text == "同步当前数据")
            {
                RealTimeGetContent = new Thread(new ThreadStart(GetHwndTitle));
                RealTimeGetContent.Start();
                this.btnRealTimeGetHwndData.Text = "停止同步";
            }
            else
            {
                if (RealTimeGetContent != null)
                {
                    RealTimeGetContent.Abort();
                }

                this.btnRealTimeGetHwndData.Text = "同步当前数据";
            }
        }

        private void GetHwndTitle()
        {
            try
            {
                while (true)
                {
                    if (iActiveHwnd <= 0)
                    {
                        break;
                    }
                    this.Invoke(new Action(() =>
                    {
                        this.txtTitle.Text = GetHwndInfor.GetHwndTitle(iActiveHwnd);
                    }));
                    Thread.Sleep(500);
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtHwnd_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHwnd.Text))
            {
                btnRealTimeGetHwndData.Enabled = false;
            }
            else
            {
                btnRealTimeGetHwndData.Enabled = true;
            }
        }

        private void MainFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.mousePoint = this.txtMousePoint.Text;
            Properties.Settings.Default.className = this.txtClassName.Text;
            Properties.Settings.Default.LikeTitle = this.txtLikeTitle.Text;
            Properties.Settings.Default.TopFormClassName = _topFormClassName;
            Properties.Settings.Default.TopFormTitle = _topFormTitle;
            Properties.Settings.Default.Save();
        }

        private void linkRegsActiveX_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                GetHwndInfor.AutoRegCom("regsvr32 -s dm.dll");

                MessageBox.Show("注册成功！", "注册信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "异常");
            }
        }
        public int TopWindowHwnd = 0;
        private string _topFormClassName = string.Empty;
        private string _topFormTitle = string.Empty;
        private void btnSelectHwnd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_topFormClassName) || !string.IsNullOrEmpty(_topFormTitle))
            {
                TopWindowHwnd = GetHwndInfor.FindTopForm(_topFormClassName, _topFormTitle);
            }

            if (TopWindowHwnd != 0)
            {
                //收银系统
                if (!GetHwndInfor.TopShowForm(TopWindowHwnd))
                {
                    MessageBox.Show("置顶窗口失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
            Regex rg = new Regex("^(?<x>[0-9]+),(?<y>[0-9]+)$");
            if (rg.IsMatch(this.txtMousePoint.Text))
            {
                GroupCollection group = rg.Match(this.txtMousePoint.Text).Groups;
                Point p = new Point(int.Parse(group["x"].ToString()), int.Parse(group["y"].ToString()));

                iActiveHwnd = GetHwndInfor.MousePointGetHwnd(p);

                this.txtHwnd.Text = iActiveHwnd.ToString();
                this.txtClassName.Text = GetHwndInfor.GetHwndClassName(iActiveHwnd);

                TopWindowHwnd = GetHwndInfor.GetTopFormHwnd(iActiveHwnd);                

                //取消置顶
                if (!GetHwndInfor.CancelTopShowForm(TopWindowHwnd))
                {
                    MessageBox.Show("取消置顶窗口失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                _topFormClassName = GetHwndInfor.GetHwndClassName(TopWindowHwnd);
                _topFormTitle = GetHwndInfor.GetHwndTitle(TopWindowHwnd);

                this.txtTitle.Text = string.Format("顶层窗体类名:{0}\r\n顶层窗体题名:{1}", _topFormClassName, _topFormTitle);

                string tempTitle = GetHwndInfor.GetHwndTitle(iActiveHwnd);
                Regex rg2 = new Regex(@"^(?<NotNuber>\D*)");
                if (rg2.IsMatch(tempTitle))
                {
                    txtLikeTitle.Text = rg2.Match(tempTitle).Groups["NotNuber"].ToString();
                }
                else
                {
                    Regex rg3 = new Regex(@"(?<NotNuber>\D*)$");
                    if (rg3.IsMatch(tempTitle))
                    {
                        txtLikeTitle.Text = rg3.Match(tempTitle).Groups["NotNuber"].ToString();
                    }
                    else
                    {
                        txtLikeTitle.Text = tempTitle;
                    }
                }
            }
            else
            {
                MessageBox.Show("错误的鼠标位置，正确的格式(x,y):23,89", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLikeHwnd_Click(object sender, EventArgs e)
        {
            List<int> list = GetHwndInfor.ClassNameAndTitleToParentHwnd(this.txtLikeTitle.Text, this.txtClassName.Text);
            if (list.Count == 1)
            {
                iActiveHwnd=list[0];
                this.txtHwnd.Text = iActiveHwnd.ToString();
                this.txtTitle.Text = GetHwndInfor.GetHwndTitle(iActiveHwnd);
                MessageBox.Show("获取成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show(string.Format("获取到{0}个相同符合条件的句柄位置。", list.Count), "不能唯一确定", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
        }

        private void btnLikeHwnd2_Click(object sender, EventArgs e)
        {
            List<int> list = GetHwndInfor.ClassNameAndTitleToParentHwnd(this.txtTopFormTitle.Text, this.txtTopFormClassName.Text);
            if (list.Count == 1)
            {
                int tempHwnd = list[0];
                Regex rg = new Regex("^(?<x>[0-9]+),(?<y>[0-9]+)$");
                if (rg.IsMatch(this.txtOffsetPoint.Text))
                {
                    GroupCollection group = rg.Match(this.txtOffsetPoint.Text).Groups;
                    Point p = new Point(int.Parse(group["x"].ToString()), int.Parse(group["y"].ToString()));

                    iActiveHwnd = GetHwndInfor.TopFromHwndAndOffsetPointGetHwnd(tempHwnd, p,this.txtParentClassName.Text);
                    if (iActiveHwnd != 0)
                    {
                        this.txtHwnd.Text = iActiveHwnd.ToString();
                        this.txtTitle.Text = GetHwndInfor.GetHwndTitle(iActiveHwnd);
                        MessageBox.Show("获取成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        this.txtHwnd.Text = "0";
                        this.txtTitle.Text = "获取失败";
                    }
                }
                else
                {
                    MessageBox.Show("错误的鼠标位置，正确的格式(x,y):23,89", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(string.Format("获取到{0}个相同符合条件的句柄位置。", list.Count), "不能唯一确定", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkCreatActive_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TextBox txt = new TextBox();
            txt.Name = string.Format("txt_{0}", DateTime.Now.ToString("yyyyMMddHHmmss"));
            txt.Text = txt.Name;
            txt.Width = 120;
            txt.Location = new Point(10, 20);

            this.gbDynamicActive.Controls.Clear();

            this.gbDynamicActive.Controls.Add(txt);
        }

        private void gbDynamicActive_Enter(object sender, EventArgs e)
        {

        }
    }
}
