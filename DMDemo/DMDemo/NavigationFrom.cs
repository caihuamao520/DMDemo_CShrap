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
            this.Hide();
            HwndGetTitleFrom hgtf = new HwndGetTitleFrom();
            hgtf.ShowDialog();
            Environment.Exit(0);
        }

        private void btnOpenTesseractOcrDemo_Click(object sender, EventArgs e)
        {
            this.Hide();
            OCRImage ocrI = new OCRImage();
            ocrI.ShowDialog();
            Environment.Exit(0);
        }

        private void btnOCR_PlanA_Click(object sender, EventArgs e)
        {
            fro_AdvancedOCRImage_PlanA planA = new fro_AdvancedOCRImage_PlanA();
            planA.ShowDialog();
            Environment.Exit(0);
        }
    }
}
