using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CropImage;
using Dm;
using System.Diagnostics;

namespace DMDemo
{
    
    public partial class fro_AdvancedOCRImage_PlanA : Form
    {
        //private System.Windows.Forms.Timer GetSystemImageTimer;
        //private Dictionary<string, Screen> ScreenList;
        
        public fro_AdvancedOCRImage_PlanA()
        {
            InitializeComponent();
        }
        private const int MOD_ALT = 0x1; //ALT
        private const int MOD_CONTROL = 0x2; //CTRL
        private const int MOD_SHIFT = 0x4; //SHIFT
        private const int VK_SPACE = 0x20; //SPACE
        private void fro_AdvancedOCRImage_PlanA_Load(object sender, EventArgs e)
        {
            if (!HotKeysUtil.RegHotKey(this.Handle, MOD_CONTROL | MOD_ALT, (int)Keys.Q, 1))
            {
                this.Text = "快捷键注册失败";
                MessageBox.Show(this.Text, "警告");
            }

        }

        private void GetSystemImageTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Fro_LookImage fli = new Fro_LookImage(this.pictureBox1.Image);
            fli.Show();
        }        

        

        private void btnPintScrenn_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => {
                ShowImage si = new ShowImage();
                si.IsHideFrom = false;
                si.Location = Screen.FromPoint(this.Location).Bounds.Location;

                if (this.ckbPintScreenIsHide.Checked)
                {
                    //this.Hide();
                    this.WindowState = FormWindowState.Minimized;
                    Thread.Sleep(1000);
                }
                Application.DoEvents();
                si.ShowDialog();
                if (si.ChoiceImage != null)
                {
                    this.pictureBox1.Image = si.ChoiceImage;
                }

                if (this.ckbPintScreenIsHide.Checked)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                }

            }));
        }
        private dmsoft mydm = new dmsoft();
        private Dictionary<string, int> HideFormList = new Dictionary<string, int>();
        private void btnHideFromAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string key in HideFormList.Keys)
                {
                    int inPrt = HideFormList[key];
                    if (mydm.GetWindowState(inPrt, 0) == 1)//窗口存在
                    {
                        if (mydm.GetWindowState(inPrt, 2) == 1)//窗口是否可见
                        {
                            if (mydm.GetWindowState(inPrt, 3) == 0)//窗口是最小化
                            {
                                mydm.SetWindowState(inPrt, 2);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常");
            }
        }

        private void btnGetAllForm_Click(object sender, EventArgs e)
        {
            try
            {
                int iModer= 4;

                HideFormList.Clear();
                this.listBox1.Items.Clear();
                int topIntprt = mydm.GetSpecialWindow(0);
                string strInfor = mydm.EnumWindow(topIntprt, "", "", iModer);
                int i = 0;

                foreach (string s in strInfor.Split(','))
                {
                    int inPrt = 0;
                    if (int.TryParse(s, out inPrt))
                    {
                        if (mydm.GetWindowState(inPrt, 0) == 1)//窗口存在
                        {
                            if (mydm.GetWindowState(inPrt, 2) == 1)//窗口是否可见
                            {
                                if (mydm.GetWindowState(inPrt, 3) == 0)//窗口是最小化
                                {
                                    string strFromTitle = mydm.GetWindowTitle(inPrt);
                                    if (inPrt == this.Handle.ToInt32())
                                    {
                                        continue;
                                    }
                                    
                                    if (!string.IsNullOrWhiteSpace(strFromTitle))
                                    {
                                        i++;
                                        strFromTitle = string.Format("{0}、{1}", i, strFromTitle);
                                        HideFormList.Add(strFromTitle, inPrt);
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (string key in HideFormList.Keys)
                {
                    this.listBox1.Items.Add(key);
                }
                this.Text = string.Format("共获取到{0}个窗体", this.listBox1.Items.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常");
            }
        }
        private void btnHideAllForm_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string keyName in HideFormList.Keys)
                {
                    int inPrt = HideFormList[keyName];
                    if (mydm.GetWindowState(inPrt, 3) == 0)
                    {
                        mydm.SetWindowState(inPrt, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常");
            }
        }
        private void btnReceviFrom_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string keyName in HideFormList.Keys)
                {
                    int inPrt = HideFormList[keyName];
                    if (mydm.GetWindowState(inPrt, 3) == 1)
                    {
                        mydm.SetWindowState(inPrt, 5);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常");
            }
        }

        private void btnHiderFrom_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                int inPrt = HideFormList[this.listBox1.SelectedItem.ToString()];
                if (mydm.GetWindowState(inPrt, 3) == 0)
                {
                    mydm.SetWindowState(inPrt, 2);
                }
            }
        }

        private void btnShowFrom_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                int inPrt = HideFormList[this.listBox1.SelectedItem.ToString()];
                if (mydm.GetWindowState(inPrt, 3) == 1)
                {
                    mydm.SetWindowState(inPrt, 5);
                }
            }
        }
        private int IntPret = 0;
        private int ThreadId = 0;
        private void getTopFrom_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.getTopFrom.Text == "恢复挂起的进程")
                {
                    if (ThreadId != 0)
                    {
                        this.WindowState = FormWindowState.Minimized;
                        //this.Hide();
                        Thread.Sleep(500);
                        ProcessMgr.ResumeProcess(ThreadId);                        
                    }

                    this.getTopFrom.Text = "当前活动窗体信息";
                    return;
                }
                IntPret = mydm.GetForegroundWindow();

                if (IntPret != 0 && IntPret != mydm.GetSpecialWindow(0) && IntPret != mydm.GetSpecialWindow(1))
                {
                    if (IntPret == ((int)this.Handle))
                    {
                        this.label2.Text = "找到自己啦！";
                    }
                    else
                    {
                        ThreadId = mydm.GetWindowProcessId(IntPret);
                        this.label2.Text = string.Format("进程ID：{1}，目标程序位置：{0}", mydm.GetWindowProcessPath(IntPret), ThreadId);
                        return;
                    }
                }
                else 
                {
                    this.label2.Text = "找到桌面或者任务栏啦！";
                }
                IntPret = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常");
            }
        }

        private const int WM_HOTKEY = 0x312; //窗口消息-热键
        //bool isOK = false;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键
                    switch (m.WParam.ToInt32())
                    {
                        case 1:
                            this.Invoke(new Action(() => {
                                //btnPintScrenn_Click(null, null);
                                //this.Show();

                                getTopFrom_Click(null, null);//获取活动窗体进程
                                //暂停目标进程
                                if (IntPret != 0)
                                {
                                    this.getTopFrom.Text = "恢复挂起的进程";
                                    ProcessMgr.SuspendProcess(ThreadId);
                                }

                                btnPintScrenn_Click(null, null);
                            }));
                           

                            break;
                    }
                    break;
                //case 0x112:
                    //switch ((int)m.WParam)
                    //{
                    //    ////禁止最小化按钮
                    //    //case 0xf020:
                    //    //    m.WParam = IntPtr.Zero;
                    //    //    MessageBox.Show("我不要最小化", "提示0x112");
                    //    //    break;
                    //    ////禁止最大化按钮
                    //    //case 0xf030:                            
                    //    //    m.WParam = IntPtr.Zero;
                    //    //    MessageBox.Show("我不要最大化", "提示0x112");
                    //    //    break;
                    //    //case 61458:
                    //    //    break;
                    //    //case 0xF060:
                    //    //    m.WParam = IntPtr.Zero;
                    //    //    MessageBox.Show("我不要关闭", "提示0x112");
                    //    //    break;
                    //    //default:
                    //    //    MessageBox.Show(m.WParam.ToString(), "提示0x112");
                    //    //    break;
                    //}
                    //break;
                //case 0x0018:
                    //switch ((int)m.WParam)
                    //{
                    //    case 0:
                    //        m.WParam = IntPtr.Zero;
                    //        m.Result = IntPtr.Zero;
                    //        MessageBox.Show("我不要被隐藏。", "提示0x0018");
                    //        break;
                    //    default:
                    //        //MessageBox.Show(m.WParam.ToString(), "提示0x0018");
                    //        break;
                    //}                    
                    //break;
                //case 0x0002:
                //     m.WParam = IntPtr.Zero;
                //    MessageBox.Show(m.WParam.ToString(), "提示0x0002");
                //    break;
                //case 0x0010:
                //     m.WParam = IntPtr.Zero;
                //     m.HWnd = IntPtr.Zero;
                //     m.LParam = IntPtr.Zero;
                //     m.Msg = 0;
                //     m.Result = IntPtr.Zero;
                //    MessageBox.Show(m.WParam.ToString(), "提示0x0010");
                //    break;
                //case 0x0011:
                //    MessageBox.Show(m.WParam.ToString(), "提示0x0011");
                //    break;
                //case 0x0012:
                //    MessageBox.Show(m.WParam.ToString(), "提示0x0012");
                //    break;
            }
            //Debug.WriteLine(string.Format("Msg:{0},WParam:{1}", m.Msg, m.WParam), "DMDemo");

            base.WndProc(ref m);
        }

        private void fro_AdvancedOCRImage_PlanA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.getTopFrom.Text == "恢复挂起的进程")
            {
                getTopFrom_Click(null, null);
            }

            if (chkStopCloseFrom.Checked)
            {
                switch (e.CloseReason)
                {
                    case CloseReason.ApplicationExitCall:
                        e.Cancel = true;
                        MessageBox.Show("拦截关闭要求！");
                        break;
                    case CloseReason.FormOwnerClosing:
                        e.Cancel = true;
                        MessageBox.Show("拦截自身关闭！");
                        break;
                    case CloseReason.MdiFormClosing:
                        e.Cancel = true;
                        MessageBox.Show("拦截MDI窗体关闭！");
                        break;
                    case CloseReason.None:
                        break;
                    case CloseReason.TaskManagerClosing:
                        e.Cancel = true;
                        MessageBox.Show("拦截任务管理器关闭！");
                        break;
                    case CloseReason.UserClosing:
                        e.Cancel = true;
                        MessageBox.Show("拦截用户关闭！");
                        break;
                    case CloseReason.WindowsShutDown:
                        e.Cancel = true;
                        MessageBox.Show("拦截关机！");
                        break;
                    default:
                        break;
                }
                //this.Show();
            }
            //base.OnFormClosing(e);
        }

        private void fro_AdvancedOCRImage_PlanA_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(string.Format("我发生了变化，大小为：{0}",this.Size), "提示");
        }

        private void fro_AdvancedOCRImage_PlanA_LocationChanged(object sender, EventArgs e)
        {
            //if (this.ckbPintScreenIsHide.Checked)
            //{
            //    MessageBox.Show(string.Format("我的位置发生了变化，位置为：{0}", this.Location), "提示");
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Show();
        }
    }
    public static class ProcessMgr
    {
        [Flags]
        public enum ProcessAccess : uint
        {
            Terminate = 0x1,
            CreateThread = 0x2,
            SetSessionId = 0x4,
            VmOperation = 0x8,
            VmRead = 0x10,
            VmWrite = 0x20,
            DupHandle = 0x40,
            CreateProcess = 0x80,
            SetQuota = 0x100,
            SetInformation = 0x200,
            QueryInformation = 0x400,
            SetPort = 0x800,
            SuspendResume = 0x800,
            QueryLimitedInformation = 0x1000,
            Synchronize = 0x100000
        }

        [DllImport("ntdll.dll")]
        private static extern uint NtResumeProcess([In] IntPtr processHandle);

        [DllImport("ntdll.dll")]
        private static extern uint NtSuspendProcess([In] IntPtr processHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(
        ProcessAccess desiredAccess,
        bool inheritHandle,
        int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr handle);

        public static void SuspendProcess(int processId)
        {
            IntPtr hProc = IntPtr.Zero;
            try
            {
                hProc = OpenProcess(ProcessAccess.SuspendResume, false, processId);
                if (hProc != IntPtr.Zero)
                    NtSuspendProcess(hProc);
            }
            finally
            {
                if (hProc != IntPtr.Zero)
                    CloseHandle(hProc);
            }
        }

        public static void ResumeProcess(int processId)
        {
            IntPtr hProc = IntPtr.Zero;
            try
            {
                hProc = OpenProcess(ProcessAccess.SuspendResume, false, processId);
                if (hProc != IntPtr.Zero)
                    NtResumeProcess(hProc);
            }
            finally
            {
                if (hProc != IntPtr.Zero)
                    CloseHandle(hProc);
            }
        }
    }
}
