using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMDemo
{
    public partial class NavigationFrom : Form
    {
        public NavigationFrom()
        {
            InitializeComponent();
        }

        private void NavigationFrom_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenHwndGetTitleDemo_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
                HwndGetTitleFrom hgtf = new HwndGetTitleFrom();
                hgtf.ShowDialog();
                this.WindowState = FormWindowState.Normal;

                //Environment.Exit(0);
            }
            catch (Exception)
            {
            }
        }

        private void btnOpenTesseractOcrDemo_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
                OCRImage ocrI = new OCRImage();
                ocrI.ShowDialog();
                this.WindowState = FormWindowState.Normal;
                //Environment.Exit(0);
            }
            catch (Exception)
            {
            }
        }

        private void btnOCR_PlanA_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
                fro_AdvancedOCRImage_PlanA planA = new fro_AdvancedOCRImage_PlanA();
                planA.ShowDialog();
                this.WindowState = FormWindowState.Normal;
                //Environment.Exit(0);
            }
            catch (Exception)
            {
            }
        }

        private void NavigationFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
