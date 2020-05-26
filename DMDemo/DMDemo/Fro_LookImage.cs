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
    public partial class Fro_LookImage : Form
    {
        private Image _img;
        public Button btnClose;
        public Fro_LookImage(Image img)
        {
            _img = img;
            InitializeComponent();
            this.Size = _img.Size;
            this.pbMain.Image = _img;
        }

        private void Fro_LookImage_Load(object sender, EventArgs e)
        {

        }

        private void pbMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
