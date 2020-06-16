using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMDemo.FromHwnd;
using Newtonsoft.Json;
using System.Threading;

namespace DMDemo
{
    public partial class fro_HwndAndOCR_PlanA : Form
    {
        public fro_HwndAndOCR_PlanA()
        {
            InitializeComponent();
        }

        private void fro_HwndAndOCR_PlanA_Load(object sender, EventArgs e)
        {

        }

        private MousePointHwndInfor _CurrentMousePointHwndInfo;
        private void btnGetHwnd_MouseDown(object sender, MouseEventArgs e)
        {
            GetHwndInfor ghi = new GetHwndInfor();
            if (ghi.ShowDialog() == DialogResult.Yes)
            {
                _CurrentMousePointHwndInfo = ghi.HwndInfor;
                this.labHwendTitle.Text = _CurrentMousePointHwndInfo.CurrentHwndTitle;
                this.txtHwndPath.Text = string.Join("-", GetHwndPath(_CurrentMousePointHwndInfo.CurrentHwnd));
            }
        }

        public bool IsSrceenImage 
        {
            get
            {
                return this.ckbHwndSrceen.Checked;
            }
        }

        public List<int> GetHwndPath(int hwnd)
        {
            List<int> PathLis = new List<int>();
            int rootHwnd = GetHwndInfor.GetWindow(hwnd, GetWindowFlagEnum.GetTopHwnd);
            GetHwndConfig hwndConfig = new GetHwndConfig(rootHwnd);
            //int tempHwnd = hwnd;
            PathLis.Add(hwnd);
            hwndConfig.LevelIndex.Add(GetHwndLevelIndex(hwnd));
            do
            {
                hwnd = GetHwndInfor.GetWindow(hwnd, GetWindowFlagEnum.GetParentHwnd);
                PathLis.Add(hwnd);

                if (hwnd == 0)
                {
                    MessageBox.Show("啊找到最顶层了，出问题了。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else
                {
                    if (hwnd == rootHwnd)
                    {
                        hwndConfig.LevelIndex.Add(0);
                    }
                    else
                    {
                        hwndConfig.LevelIndex.Add(GetHwndLevelIndex(hwnd));
                    }
                }
            }
            while (rootHwnd != hwnd);

            this.txtHwndConfig.Text = JsonConvert.SerializeObject(hwndConfig);

            return PathLis;
        }

        public int GetHwndLevelIndex(int hwnd)
        {
            int currHwndObjec = GetHwndInfor.GetWindow(hwnd, GetWindowFlagEnum.GetFirstHwnd);
            int endHwndObject = GetHwndInfor.GetWindow(hwnd, GetWindowFlagEnum.GetLastHwnd);
            int index = 1;
            if (currHwndObjec != hwnd)
            {
                do
                {
                    currHwndObjec = GetHwndInfor.GetWindow(currHwndObjec, GetWindowFlagEnum.GetNextHwnd);
                    if (currHwndObjec == 0 && currHwndObjec == endHwndObject)
                    {
                        index = 0;
                        break;
                    }
                    index++;

                } while (currHwndObjec != hwnd);
            }

            return index;
        }

        private Thread th;
        private void btnsynData_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnsynData.Text == "同步获取数据")
                {
                    if (string.IsNullOrWhiteSpace(this.txtHwndConfig.Text))
                    {
                        addLoog("错误，未设置获取句柄位置!");
                        return;
                    }
                    addLoog("开始准备同步数据!");
                    GetHwndConfig hwndConfig = JsonConvert.DeserializeObject<GetHwndConfig>(this.txtHwndConfig.Text);
                    if (hwndConfig == null)
                    {
                        addLoog("GetHwndConfig初始化错误!");
                        return;
                    }
                    addLoog("GetHwndConfig初始化成功!");

                    ParameterizedThreadStart pts = new ParameterizedThreadStart(SynData);
                    th = new Thread(pts);
                    th.Start(hwndConfig);

                    this.btnGetHwnd.Enabled = false;
                    this.ckbHwndSrceen.Enabled = false;
                    this.btnsynData.Text = "停止获取";
                }
                else
                {
                    if (th.ThreadState != ThreadState.Stopped)
                    {
                        th.Abort();
                        addLoog("停止同步获取数据!");
                    }
                    this.btnGetHwnd.Enabled = true;
                    this.ckbHwndSrceen.Enabled = true;
                    
                    this.btnsynData.Text = "同步获取数据";
                }
            }
            catch (Exception ex)
            {
                addLoog("异常："+ex.Message);
            }
        }

        private void SynData(object config)
        {
            try
            {
                GetHwndConfig hwndConfig = (GetHwndConfig)config;
                int currenHwnd = GetTopHwnd(hwndConfig);
                while (true)
                {
                    if (IsSrceenImage)
                    {
                        Bitmap bmp = GetHwndInfor.GetHwndImage(currenHwnd);
                        Invoke(new Action(() =>
                        {
                            this.pictureBox1.Image = bmp;

                            bmp = OCRImage.ImageProcessing(bmp);//图像处理
                            string strTitle = OCRImage.OCRBitmpa(bmp).OCRContent;
                            Invoke(new Action(() =>
                            {
                                this.labOCRConten.Text = strTitle;
                                addLoog("OCR识别到的内容为：" + strTitle);
                            }));
                        }));
                    }
                    else
                    {
                        string strTitle = GetHwndInfor.GetHwndTitle(currenHwnd);
                        if (strTitle == "")
                        {
                            addLoog("开始重新定位");
                            currenHwnd = GetTopHwnd(hwndConfig);
                        }

                        Invoke(new Action(() =>
                        {
                            this.labHwendTitle.Text = strTitle;
                            addLoog("获取到句柄内容为：" + strTitle);
                        }));
                    }
                    Thread.Sleep(1000);
                }

            }
            catch (Exception ex)
            {
                addLoog("异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取顶层窗体（直到获取到为止）
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private int GetTopHwnd(GetHwndConfig hwndConfig)
        {
            int currenHwnd = 0;
            do
            {
                currenHwnd = GetHwndInfor.FindTopForm(hwndConfig.TopFromClassName, null);
                Thread.Sleep(1000);
            } while (currenHwnd == 0);

            for (int arrIndex = hwndConfig.LevelIndex.Count; arrIndex > 0; arrIndex--)
            {
                int indexCount = hwndConfig.LevelIndex[arrIndex - 1];
                if (indexCount != 0)
                {
                    for (int index = 0; index < (indexCount - 1); index++)
                    {
                        currenHwnd = GetHwndInfor.GetWindow(currenHwnd, GetWindowFlagEnum.GetNextHwnd);
                    }
                }

                if (arrIndex > 1)
                {
                    currenHwnd = GetHwndInfor.GetWindow(currenHwnd, GetWindowFlagEnum.GetChildFirstHwnd);
                }
            }
            addLoog("定位句柄位置成功");


            return currenHwnd;
        }

        /// <summary>
        /// 添加日志信息
        /// </summary>
        /// <param name="msg"></param>
        private void addLoog(string msg)
        {
            try
            {
                string addContent = string.Format("{0} {1}{2}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), msg, System.Environment.NewLine);
                if (this.txtLog.InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        this.txtLog.AppendText(addContent);
                        this.txtLog.SelectionStart = this.txtLog.Text.Length;
                        this.txtLog.ScrollToCaret();
                    }));
                }
                else
                {
                    this.txtLog.AppendText(addContent);
                    this.txtLog.SelectionStart = this.txtLog.Text.Length;
                    this.txtLog.ScrollToCaret();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void ckbHwndSrceen_CheckedChanged(object sender, EventArgs e)
        {
            this.panel2.Enabled = this.ckbHwndSrceen.Checked;
        }

        private void linkAdvnSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditImageSet eis = EditImageSet.GetEditImageSet();
            eis.ShowDialog();
        }

        private void linkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtLog.Clear();
        }

    }
}
