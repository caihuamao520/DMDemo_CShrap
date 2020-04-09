﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Drawing.Imaging;
using System.Reflection;
using System.Threading;

namespace DMDemo
{
    public partial class OCRImage : Form
    {
        private string _tesseractDataFile = string.Empty;
        public OCRImage()
        {
            InitializeComponent();
        }

        private void OCRImage_Load(object sender, EventArgs e)
        {
            this.cbEngineMode.Text = "Default";
            this.cbImageContenMode.Text = "SingleLine";
            this.cbEngineVersion.Text = "2.4.0（兼容win xp）";
            _tesseractDataFile = Path.Combine(Application.StartupPath, "tessdata");
        }

        [HandleProcessCorruptedStateExceptions]
        private void btnOCRImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path.Combine(_tesseractDataFile, "eng.traineddata")))
                {
                    string strFileDLL = string.Empty;

                    if (this.cbEngineVersion.Text == "2.4.0（兼容win xp）")
                    {
                        strFileDLL = Path.Combine(Application.StartupPath, "Tesseract_2.4.dll");
                    }
                    else
                    {
                        strFileDLL = Path.Combine(Application.StartupPath, "Tesseract_3.3.dll");
                    }
                    if (!File.Exists(strFileDLL))
                    {
                        throw new Exception(string.Format("未找到 {0} 文件。", Path.GetFileName(strFileDLL)));
                    }

                    Assembly dllFromPlugin = Assembly.LoadFile(strFileDLL);
                    Type typeTE = dllFromPlugin.GetType("Tesseract.TesseractEngine");
                    Type typePC = dllFromPlugin.GetType("Tesseract.PixConverter");
                    Type psmEnum = dllFromPlugin.GetType("Tesseract.PageSegMode");
                    Type Pixs = dllFromPlugin.GetType("Tesseract.Pix");
                    Type EngineModes = dllFromPlugin.GetType("Tesseract.EngineMode");
                                       
                    object oEngineMode = Enum.Parse(EngineModes, this.cbEngineMode.Text);
                    object opsm = Enum.Parse(psmEnum, this.cbImageContenMode.Text);

                    Object oTesseractEngine = Activator.CreateInstance(typeTE, new object[] { _tesseractDataFile, "eng", oEngineMode });

                    MethodInfo miToPix = typePC.GetMethod("ToPix");
                    MethodInfo miProcess = typeTE.GetMethod("Process", new Type[] { Pixs, psmEnum });

                    Bitmap ocrImage = new Bitmap(this.pictureBox1.Image);
                    Object objImagPix = miToPix.Invoke(null, new object[] { ocrImage });
                    dynamic page = miProcess.Invoke(oTesseractEngine, new object[] { objImagPix, opsm });
                    string strOCRText = page.GetText();
                    this.txtOCRContent.Text = string.Format("时间：\r\n{0}\r\n识别内容：\r\n{1}\r\n结果信任度：{2}%\r\n图像大小：{3}\r\n引擎版本：{4}", 
                        DateTime.Now.ToString(), strOCRText, (page.GetMeanConfidence() * 100), 
                        this.pictureBox1.Image.Size,this.cbEngineVersion.Text == "2.4.0（兼容win xp）"?"2.4.0":"3.3.0");
                }
                else
                {
                    MessageBox.Show(string.Format("'{0}'数据文件不存在！", Path.GetFileName(_tesseractDataFile)), "文件不存在", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "异常");
            }
        }

        private void InitOCREngine()
        {
            string strFileDLL = string.Empty;

            if (this.cbEngineVersion.Text == "2.4.0（兼容win xp）")
            {
                strFileDLL = Path.Combine(Application.StartupPath, "Tesseract_2.4.dll");
            }
            else
            {
                strFileDLL = Path.Combine(Application.StartupPath, "Tesseract_3.3.dll");
            }
            if (!File.Exists(strFileDLL))
            {
                throw new Exception(string.Format("未找到 {0} 文件。", Path.GetFileName(strFileDLL)));
            }
        }

        private void btnOpenImageFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图像文件|*.jpg;*.bmp;*.png|所有文件|*.*";
            ofd.FilterIndex = 0;
            ofd.Multiselect = false;
            ofd.Title = "打开一张图片";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strFilePath = ofd.FileName;
                if (File.Exists(strFilePath))
                {
                    showImage(Image.FromFile(strFilePath));
                }
                else
                {
                    MessageBox.Show(string.Format("'{0}'文件不存在！", Path.GetFileName(strFilePath)), "文件不存在", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {                
                Rectangle rcc;
                if (GetScreenRegionSize(out rcc))
                {
                    
                    Bitmap bmp = new Bitmap(rcc.Width, rcc.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(rcc.Location, new System.Drawing.Point(0, 0), rcc.Size);
                    }

                    showImage(bmp);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "异常");
            }
            this.Show();
        }

        private void showImage(Image img)
        {
            btnOCRImage.Enabled = true;
            btnEditImage.Enabled = true;
            linkEditImageSet.Enabled = true;

            this.pictureBox1.Image = img;
        }

        /// <summary>
        /// 获取屏幕区域大小
        /// </summary>
        /// <param name="si"></param>
        /// <returns></returns>
        private bool GetScreenRegionSize(out Rectangle rcc)
        {
            bool isOK = false;
            Rectangle rc = new Rectangle(0,0,0,0);
            //确定
            Common.ScreenCapture.CaptureForm screenForm = new Common.ScreenCapture.CaptureForm((x, y, w, h) =>
            {
                isOK = true;
                rc.X = x;
                rc.Y = y;
                rc.Width = w;
                rc.Height = h;
            });
            //取消
            screenForm.RightAction = () =>
            {
                isOK = false;
            };

            screenForm.AutoScaleMode = AutoScaleMode.None;
            screenForm.StartPosition = FormStartPosition.Manual;

            screenForm.ShowDialog();
            screenForm.Dispose();

            System.Threading.Thread.Sleep(100);
            
            rcc = rc;
            return isOK;
        }

        private void rbSouceImageSize_CheckedChanged(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void rbAutoImageSize_CheckedChanged(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void cbImageContenMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image != null)
            {
                btnOCRImage_Click(null, null);
            }
        }
        private static Bitmap _ocrImage = null;/// 处理后的图像
        private void btnEditImage_Click(object sender, EventArgs e)
        {
            bool IsContrastRatio = EditImageSet.GetEditImageSet().IsContrastRatio;//开启对比度调整
            int ContrastRatioValue = EditImageSet.GetEditImageSet().ContrastRatioValue;
            bool IsBackgroundColorReplace = EditImageSet.GetEditImageSet().IsBackgroundColorReplace;//关闭背景色替换
            Color ReplaceBackgroundColor = EditImageSet.GetEditImageSet().ReplaceBackgroundColor;
            int BackgroundReplaceTolerance = EditImageSet.GetEditImageSet().BackgroundReplaceTolerance;
            bool IsGrayByPixels = EditImageSet.GetEditImageSet().IsGrayByPixels;//开启灰度处理
            bool IsThresholding=EditImageSet.GetEditImageSet().IsThresholding;
            bool IsClearNoise = false;//关闭降噪
            int GrayBackgroundLimit = EditImageSet.GetEditImageSet().GrayBackgroundLimit;
            int NoiseMaxNearPoints = EditImageSet.GetEditImageSet().NoiseMaxNearPoints;
            bool IsAutoImageSize = EditImageSet.GetEditImageSet().IsAutoImageSize;//自动裁剪图像
            int AutoImageHeight = EditImageSet.GetEditImageSet().AutoImageHeight;
            try
            {
                _ocrImage = new Bitmap(this.pictureBox1.Image);

                //图像处理
                ImageCodeHandle imgHandle = new ImageCodeHandle(_ocrImage);
                //调整对比度 截图过程中处理
                if (IsContrastRatio)//是否进行对比度调整
                {
                    _ocrImage = imgHandle.img_color_contrast(ContrastRatioValue);
                }
                //替换背景色
                if (IsBackgroundColorReplace)
                {
                    //取背景色
                    Color BackgroundColor = _ocrImage.GetPixel(1, 1);
                    _ocrImage = imgHandle.ReplaceColor(BackgroundColor, ReplaceBackgroundColor, BackgroundReplaceTolerance);
                }
                if (IsGrayByPixels)
                {
                    //_ocrImage = imgHandle.GrayByPixels();//灰度
                    _ocrImage = imgHandle.ToGrey();//灰度
                    if (IsThresholding)
                    {
                        _ocrImage = imgHandle.Thresholding();//二值化

                        if (IsAutoImageSize)//自动裁剪图像
                        {
                            _ocrImage = ImageCodeHandle.TailorImage(_ocrImage);//裁剪图像大小
                            if (_ocrImage.Height < AutoImageHeight)
                            {
                                float fTemp = ((float)AutoImageHeight) / ((float)_ocrImage.Height);//缩放因子

                                int iw = (int)Math.Round(_ocrImage.Width * fTemp, 0);
                                int ih = (int)Math.Round(_ocrImage.Height * fTemp, 0);

                                _ocrImage = ImageCodeHandle.KiResizeImage(_ocrImage, iw, ih);//缩放

                                imgHandle = new ImageCodeHandle(_ocrImage);
                                _ocrImage = imgHandle.Thresholding();//二值化
                            }
                        }
                    }

                    if (IsClearNoise)//黑白降噪
                    {
                        _ocrImage = imgHandle.ClearNoise(GrayBackgroundLimit, NoiseMaxNearPoints);
                    }

                }

                this.pictureBox1.Image = _ocrImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show( string.Format("图像处理异常，异常信息：{0}", ex.Message), "异常");
            }
        }

        private void linkEditImageSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.pictureBox1.Image == null) return;

            EditImageSet eis = EditImageSet.GetEditImageSet();
            eis.ShowDialog();
        }

        private void linAsSaveImageFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (this.pictureBox1.Image == null) return;

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.DefaultExt = "bmp";
                sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".bmp";
                sfd.Filter = "位图|*.bmp|所有文件|*.*";
                sfd.FilterIndex = 0;
                sfd.Title = "另存为";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBox1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "异常");
            }
        }

        //private void linkAutoImageSize_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (this.pictureBox1.Image == null) return;

        //        _ocrImage = new Bitmap(this.pictureBox1.Image);

        //        _ocrImage = ImageCodeHandle.KiResizeImage(_ocrImage, _ocrImage.Width * 2, _ocrImage.Height * 2);

        //        this.pictureBox1.Image = _ocrImage;
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message, "异常");
        //    }
        //}

        //private void linkTailorImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (this.pictureBox1.Image == null) return;
        //        _ocrImage = new Bitmap(this.pictureBox1.Image);
        //        this.pictureBox1.Image = ImageCodeHandle.TailorImage(_ocrImage);
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message, "异常");
        //    }
        //}


    }
}
