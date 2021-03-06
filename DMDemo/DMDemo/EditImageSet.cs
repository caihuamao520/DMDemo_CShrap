﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMDemo
{
    public partial class EditImageSet : Form
    {
        private static EditImageSet _eis;
        private bool _isContrastRatio = false;//开启对比度调整
        private int _contrastRatioValue = 100;
        private bool _isBackgroundColorReplace = false;//关闭背景色替换
        private Color _replaceBackgroundColor = Color.FromArgb(255, 0, 0, 0);
        private int _backgroundReplaceTolerance = 100;
        private bool _isGrayByPixels = true;//开启灰度处理
        private bool _isThresholding = true;//二值化
        private bool _autoImageSize = true;//自动图像大小
        private bool _isHoughLine = false;//霍夫去除直线
        private int _houghLineHeight = 2;//叠加阀值
        private int _autoImageHeight = 72;
        private bool _isClearNoise = false;//关闭降噪
        private int _grayBackgroundLimit = 128;
        private int _noiseMaxNearPoints = 1;
        /// <summary>
        /// 霍夫检测直线通过阈值
        /// </summary>
        public int HouhtLineHeight
        {
            get
            {
                return _houghLineHeight;
            }
        }
        /// <summary>
        /// 是否开启霍夫直线检测
        /// </summary>
        public bool IsHouhtLine
        {
            get
            {
                return _isHoughLine;
            }
        }
        /// <summary>
        /// 噪点的最大像素点
        /// </summary>
        public int NoiseMaxNearPoints
        {
            get
            {
                return _noiseMaxNearPoints;
            }
        }
        /// <summary>
        /// 噪点的间距
        /// </summary>
        public int GrayBackgroundLimit
        {
            get
            {
                return _grayBackgroundLimit;
            }
        }
        /// <summary>
        /// 是否开启降噪
        /// </summary>
        public bool IsClearNoise
        {
            get
            {
                return _isClearNoise;
            }
        }
        /// <summary>
        /// 是否开启灰度处理
        /// </summary>
        public bool IsGrayByPixels
        {
            get
            {
                return _isGrayByPixels;
            }
        }
        /// <summary>
        /// 是否开启二值化处理
        /// </summary>
        public bool IsThresholding
        {
            get
            {
                return _isThresholding;
            }
        }
        /// <summary>
        /// 开启自动调整图像大小
        /// </summary>
        public bool IsAutoImageSize 
        {
            get
            {
                return _autoImageSize;
            }
        }
        /// <summary>
        /// 自动调整图像高度阀值
        /// </summary>
        public int AutoImageHeight 
        {
            get 
            {
                return _autoImageHeight;
            }
        }
        /// <summary>
        /// 背景色替换阈值
        /// </summary>
        public int BackgroundReplaceTolerance
        {
            get
            {
                return _backgroundReplaceTolerance;
            }            
        }
        /// <summary>
        /// 背景色
        /// </summary>
        public Color ReplaceBackgroundColor
        {
            get
            {
                return _replaceBackgroundColor;
            }
            set
            {
                _replaceBackgroundColor = value;
            }
        }
        /// <summary>
        /// 是否开启背景色替换
        /// </summary>
        public bool IsBackgroundColorReplace
        {
            get
            {
                return _isBackgroundColorReplace;
            }
        }
        /// <summary>
        /// 对比度阀值
        /// </summary>
        public int ContrastRatioValue
        {
            get
            {
                return _contrastRatioValue;
            }
        }
        /// <summary>
        /// 是否开启对比度调整
        /// </summary>
        public bool IsContrastRatio 
        {
            get 
            {
                return _isContrastRatio;
            }
        }

        private EditImageSet()
        {
            InitializeComponent();
        }

        public static EditImageSet GetEditImageSet()
        {
            if (_eis == null)
            {
                _eis = new EditImageSet();
            }

            return _eis;
        }

        private void EditImageSet_Load(object sender, EventArgs e)
        {
            this.ckbDUB.Checked = _isContrastRatio;
            this.txtFZ.Text = _contrastRatioValue.ToString();

            this.ckbBJSTH.Checked = _isBackgroundColorReplace;
            Bitmap bit = new Bitmap(100, 20);
            for (int y = 0; y < bit.Height; y++)
            {
                for (int x = 0; x < bit.Width; x++)
                {
                    bit.SetPixel(x, y, _replaceBackgroundColor);
                }
            }
            this.pbBackGroupColor.Image = bit;

            this.ckbHD.Checked = _isGrayByPixels;
            this.ckbEZH.Checked = _isThresholding;
            this.ckbTZTXDX.Checked = _autoImageSize;
            this.txtTXGD.Text = _autoImageHeight.ToString();

            this.ckbHoughLine.Checked = _isHoughLine;
            this.panel1.Enabled = _isHoughLine;
            this.txtHoughLine_Cross.Text = _houghLineHeight.ToString();

            this.ckbJZ.Checked = _isClearNoise;
            this.txtJDJJ.Text = _grayBackgroundLimit.ToString();
            this.txtJDDX.Text = _noiseMaxNearPoints.ToString();

            this.pDUB.Enabled = _isContrastRatio;
            this.pBJSTH.Enabled = _isBackgroundColorReplace;
            this.pHD.Enabled = _isGrayByPixels;
            this.pJZ.Enabled = _isClearNoise;
            this.pEZH.Enabled = _isThresholding;
        }

        private void ckbDUB_CheckedChanged(object sender, EventArgs e)
        {
            this.pDUB.Enabled = this.ckbDUB.Checked;
        }

        private void ckbBJSTH_CheckedChanged(object sender, EventArgs e)
        {
            this.pBJSTH.Enabled = this.ckbBJSTH.Checked;
        }

        private void ckbHD_CheckedChanged(object sender, EventArgs e)
        {
            this.pHD.Enabled = this.ckbHD.Checked;
        }

        private void ckbJZ_CheckedChanged(object sender, EventArgs e)
        {
            this.pJZ.Enabled = this.ckbJZ.Checked;
        }

        private void ckbEZH_CheckedChanged(object sender, EventArgs e)
        {
            this.pEZH.Enabled = this.ckbEZH.Checked;
        }

        private void ckbTZTXDX_CheckedChanged(object sender, EventArgs e)
        {
            this.pZDTZDX.Enabled = this.ckbTZTXDX.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _isContrastRatio = this.ckbDUB.Checked;
            int temp = 0;

            if (int.TryParse(this.txtFZ.Text, out temp))
            {
                _contrastRatioValue = temp;
            }
            else
            {
                MessageBox.Show("错误的 阀值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _isBackgroundColorReplace = this.ckbBJSTH.Checked;
            _isGrayByPixels = this.ckbHD.Checked;
            _isThresholding = this.ckbEZH.Checked;
            _autoImageSize = this.ckbTZTXDX.Checked;
            _isClearNoise = this.ckbJZ.Checked;

            temp = 72;
            if (int.TryParse(txtTXGD.Text, out temp))
            {
                _autoImageHeight = temp;
            }
            else
            {
                MessageBox.Show("错误的 高度阀值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isHoughLine = this.ckbHoughLine.Checked;
            temp = 2;
            if (int.TryParse(this.txtHoughLine_Cross.Text, out temp))
            {
                _houghLineHeight = temp;
            }
            else
            {
                MessageBox.Show("错误的 霍夫通过阀值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            temp = 0;
            if (int.TryParse(txtJDJJ.Text, out temp))
            {
                _grayBackgroundLimit = temp;
            }
            else
            {
                MessageBox.Show("错误的 噪点间距", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            temp = 0;
            if (int.TryParse(txtJDDX.Text, out temp))
            {
                _noiseMaxNearPoints = temp;
            }
            else
            {
                MessageBox.Show("错误的 噪点大小", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.Yes;
        }

        private void linSelectColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = _replaceBackgroundColor;
            cd.ShowDialog();
            _replaceBackgroundColor = cd.Color;

            Bitmap bit = new Bitmap(100, 20);
            for (int y = 0; y < bit.Height; y++)
            {
                for (int x = 0; x < bit.Width; x++)
                {
                    bit.SetPixel(x, y, _replaceBackgroundColor);
                }
            }
            this.pbBackGroupColor.Image = bit;
        }

        private void ckbHoughLine_CheckedChanged(object sender, EventArgs e)
        {
            this.panel1.Enabled = this.ckbHoughLine.Checked;
        }

        
    }
}
