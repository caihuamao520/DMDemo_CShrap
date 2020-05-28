using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CropImage
{
    public partial class ShowImage : Form
    {
        private Image _img;
        private choiceReach cr;
        private Point starPoint;
        /// <summary>
        /// 选取的图像
        /// </summary>
        public Image ChoiceImage {get;private set; }
        public ShowImage()
        {
            //_img = img;
            InitializeComponent();

            if (_img != null)
            {
                this.Size = _img.Size;
                this.BackgroundImage = _img;
                this.Cursor = Cursors.Cross;
            }            
        }

        private void ShowImage_Load(object sender, EventArgs e)
        {

        }
        private void ShowImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && cr != null)
            {
                cr.MousePositionToDrawArea(starPoint, Control.MousePosition);
            }
            else
            {
                if (cr != null && cr.IsShowFrom)
                {
                    cr.ShowToolBars(Screen.FromPoint(this.Location).Bounds);
                }
            }
        }

        private void ShowImage_MouseDown(object sender, MouseEventArgs e)
        {
            starPoint = Control.MousePosition;
            if (cr == null)
            {
                cr = new choiceReach(starPoint);
                cr.NoticeTaskEvn += cr_NoticeTaskEvn;
            }
            else
            {
                cr.Close();
                cr = new choiceReach(starPoint);
                cr.NoticeTaskEvn += cr_NoticeTaskEvn;
            }
        }

        private void cr_NoticeTaskEvn(Rectangle rec, ToolbarBtnEnum btnType)
        {
            if (btnType == ToolbarBtnEnum.Cancel)
            {
                this.Close();
            }
            else if(btnType == ToolbarBtnEnum.Save)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.DefaultExt = "bmp";
                sfd.Filter = "BMP图像|*.bmp|JPG图像|*.jpg|GIF图片|*.gif|PNG图片|*.png|TIFF传真格式|*.tif|所有文件|*.*";
                sfd.FilterIndex = 0;
                sfd.Title = "另存为";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = sfd.FileName;
                    if (File.Exists(strFileName))
                    {
                        File.Delete(strFileName);
                    }
                    System.Drawing.Imaging.ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                    switch (Path.GetExtension(strFileName))
                    {
                        case ".jpg": imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                        case ".bmp": imageFormat = System.Drawing.Imaging.ImageFormat.Bmp; break;
                        case ".gif": imageFormat = System.Drawing.Imaging.ImageFormat.Tiff; break;
                        case ".png": imageFormat = System.Drawing.Imaging.ImageFormat.Png; break;
                        case ".tif": imageFormat = System.Drawing.Imaging.ImageFormat.Tiff; break;
                    }

                    CropImage(rec).Save(strFileName, imageFormat);
                    MessageBox.Show("保存成功。","提示");
                }
            }
            else if (btnType == ToolbarBtnEnum.OK)
            {
                ChoiceImage = CropImage(rec);

                this.Close();
            }
        }

        private Image CropImage(Rectangle rec)
        {
            if (_img != null)
            {
                Bitmap ResultImage = new Bitmap(rec.Size.Width, rec.Size.Height);
                ResultImage.SetResolution(_img.HorizontalResolution, _img.VerticalResolution);
                using (Graphics gh = Graphics.FromImage(ResultImage))
                {
                    Rectangle rg = new Rectangle(this.PointToClient(rec.Location), rec.Size);
                    gh.DrawImage(_img, 0, 0, rg, GraphicsUnit.Pixel);
                }
                return ResultImage;
            }
            else
            {
                return null;
            }
        }

        private void ShowImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cr != null)
            {
                cr.Close();
            }
        }
    }
}
