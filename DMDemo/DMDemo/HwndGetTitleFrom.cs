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
            if (!CheckRegistredOcx(@"CLSID\{26037A0E-7CBD-4FFF-9C63-56F2D0770214}"))
            {
                AutoRegCom("regsvr32 -s dm.dll");
            }
        }
        private int iActiveHwnd;
        private void btnGetActiveLocation_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                this.Hide();
                this.btnGetActiveLocation.Text = "获取位置中……";

                GetHwndInfor getHwnd = new GetHwndInfor();
                if (getHwnd.ShowDialog() == DialogResult.Yes)
                {
                    iActiveHwnd = getHwnd.intHwnd;
                    this.txtHwnd.Text = iActiveHwnd.ToString();
                    this.txtTitle.Text = getHwnd.HwndTitle;

                    this.btnGetActiveLocation.Text = "获取位置";
                }
                else
                {
                    this.btnGetActiveLocation.Text = "获取失败";
                }

                this.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "异常");
            }
        }
        private Thread RealTimeGetContent;
        private void btnRealTimeGetHwndData_Click(object sender, EventArgs e)
        {
            if (this.btnRealTimeGetHwndData.Text == "开始同步获取内容")
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

                this.btnRealTimeGetHwndData.Text = "开始同步获取内容";
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

        private string AutoRegCom(string strCmd)
        {
            string rInfo;
            try
            {
                Process myProcess = new Process();
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("cmd.exe");
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo = myProcessStartInfo;
                myProcessStartInfo.Arguments = "/c " + strCmd;
                myProcess.Start();
                StreamReader myStreamReader = myProcess.StandardOutput;
                rInfo = myStreamReader.ReadToEnd();
                myProcess.Close();
                rInfo = strCmd + "\r\n" + rInfo;
                return rInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 检测ocx是否注册
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        private bool CheckRegistredOcx(string ClassId)
        {
            Microsoft.Win32.RegistryKey Regkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ClassId);
            if (Regkey != null)
            {
                string res = Regkey.OpenSubKey("InprocServer32").GetValue("").ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MainFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void linkRegsActiveX_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AutoRegCom("regsvr32 -s dm.dll");

                MessageBox.Show("注册成功！", "注册信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "异常");
            }
        }
    }
}
