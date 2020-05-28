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

namespace DMDemo
{
    public partial class fro_AdvancedOCRImage_PlanA : Form
    {
        private System.Windows.Forms.Timer GetSystemImageTimer;
        private Dictionary<string, Screen> ScreenList;
        public fro_AdvancedOCRImage_PlanA()
        {
            InitializeComponent();
        }

        private void fro_AdvancedOCRImage_PlanA_Load(object sender, EventArgs e)
        {
            
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
            if (this.ckbPintScreenIsHide.Checked)
            {
                this.Hide();
            }
            Thread.Sleep(500);
            //PrintScreen();

            ShowImage si = new ShowImage();
            si.Location = Screen.FromPoint(this.Location).Bounds.Location;
            si.ShowDialog();
            if (si.ChoiceImage != null)
            {
                this.pictureBox1.Image = si.ChoiceImage;
            }



            if (this.ckbPintScreenIsHide.Checked)
            {
                this.Show();
                this.Activate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        } 
    }
}
