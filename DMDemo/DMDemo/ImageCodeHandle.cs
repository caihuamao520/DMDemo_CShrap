using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DMDemo
{
    /// <summary>
    /// 图片处理类
    /// </summary>
    public class ImageCodeHandle
    {
        /// <summary>
        /// 图片信息
        /// </summary>
        private Bitmap _bmpobj;
        private int _dgGrayValue;

        public ImageCodeHandle(Bitmap pic)
        {
            _bmpobj = pic;
            //_bmpobj = new Bitmap(pic);
        }

        /// <summary>
        /// 根据RGB，计算灰度值
        /// </summary>
        /// <param name="posClr">Color值</param>
        /// <returns>灰度值，整型</returns>
        private int GetGrayNumColor(Color posClr)
        {
            return (posClr.R * 19595 + posClr.G * 38469 + posClr.B * 7472) >> 16;
        }

        /// <summary>
        /// 灰度转换,逐点方式
        /// </summary>
        public Bitmap GrayByPixels()
        {
            for (var i = 0; i < _bmpobj.Height; i++)
            {
                for (var j = 0; j < _bmpobj.Width; j++)
                {
                    var tmpValue = GetGrayNumColor(_bmpobj.GetPixel(j, i));
                    _bmpobj.SetPixel(j, i, Color.FromArgb(tmpValue, tmpValue, tmpValue));
                }
            }
            return _bmpobj;
        }

        /// <summary>
        /// 去图形边框
        /// </summary>
        /// <param name="borderWidth"></param>
        public Bitmap ClearPicBorder(int borderWidth)
        {
            for (var i = 0; i < _bmpobj.Height; i++)
            {
                for (var j = 0; j < _bmpobj.Width; j++)
                {
                    if (i < borderWidth || j < borderWidth || j > _bmpobj.Width - 1 - borderWidth || i > _bmpobj.Height - 1 - borderWidth)
                    {
                        _bmpobj.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            return _bmpobj;
        }

        /// <summary>
        /// 灰度转换,逐行方式
        /// </summary>
        public Bitmap GrayByLine()
        {
            var rec = new Rectangle(0, 0, _bmpobj.Width, _bmpobj.Height);
            BitmapData bmpData = _bmpobj.LockBits(rec, ImageLockMode.ReadWrite, _bmpobj.PixelFormat);
            // PixelFormat.Format32bppPArgb);
            //    bmpData.PixelFormat = PixelFormat.Format24bppRgb;
            var scan0 = bmpData.Scan0;
            var len = _bmpobj.Width * _bmpobj.Height;
            var pixels = new int[len];
            Marshal.Copy(scan0, pixels, 0, len);

            //对图片进行处理
            var grayValue = 0;
            for (var i = 0; i < len; i++)
            {
                grayValue = GetGrayNumColor(Color.FromArgb(pixels[i]));
                pixels[i] = (byte)(Color.FromArgb(grayValue, grayValue, grayValue)).ToArgb(); //Color转byte
            }
            _bmpobj.UnlockBits(bmpData);
            return _bmpobj;
        }

        /// <summary>
        /// 得到有效图形并调整为可平均分割的大小
        /// </summary>
        /// <param name="dgGrayValue">灰度背景分界值</param>
        /// <param name="charsCount">有效字符数</param>
        /// <returns></returns>
        public void GetPicValidByValue(int dgGrayValue, int charsCount)
        {
            var posx1 = _bmpobj.Width;
            var posy1 = _bmpobj.Height;
            var posx2 = 0;
            var posy2 = 0;
            for (var i = 0; i < _bmpobj.Height; i++) //找有效区
            {
                for (var j = 0; j < _bmpobj.Width; j++)
                {
                    int pixelValue = _bmpobj.GetPixel(j, i).R;
                    if (pixelValue < dgGrayValue) //根据灰度值
                    {
                        if (posx1 > j) posx1 = j;
                        if (posy1 > i) posy1 = i;

                        if (posx2 < j) posx2 = j;
                        if (posy2 < i) posy2 = i;
                    }
                }
            }
            // 确保能整除
            var span = charsCount - (posx2 - posx1 + 1) % charsCount; //可整除的差额数
            if (span < charsCount)
            {
                int leftSpan = span / 2; //分配到左边的空列 ，如span为单数,则右边比左边大1
                if (posx1 > leftSpan)
                    posx1 = posx1 - leftSpan;
                if (posx2 + span - leftSpan < _bmpobj.Width)
                    posx2 = posx2 + span - leftSpan;
            }
            //复制新图
            var cloneRect = new Rectangle(posx1, posy1, posx2 - posx1 + 1, posy2 - posy1 + 1);
            _bmpobj = _bmpobj.Clone(cloneRect, _bmpobj.PixelFormat);
        }

        /// <summary>
        /// 得到有效图形,图形为类变量
        /// </summary>
        /// <param name="dgGrayValue">灰度背景分界值</param>
        /// <returns></returns>
        public void GetPicValidByValue(int dgGrayValue)
        {
            var posx1 = _bmpobj.Width;
            var posy1 = _bmpobj.Height;
            var posx2 = 0;
            var posy2 = 0;
            for (var i = 0; i < _bmpobj.Height; i++) //找有效区
            {
                for (var j = 0; j < _bmpobj.Width; j++)
                {
                    var pixelValue = _bmpobj.GetPixel(j, i).R;
                    if (pixelValue < dgGrayValue) //根据灰度值
                    {
                        if (posx1 > j) posx1 = j;
                        if (posy1 > i) posy1 = i;

                        if (posx2 < j) posx2 = j;
                        if (posy2 < i) posy2 = i;
                    }
                }
            }
            //复制新图
            var cloneRect = new Rectangle(posx1, posy1, posx2 - posx1 + 1, posy2 - posy1 + 1);
            _bmpobj = _bmpobj.Clone(cloneRect, _bmpobj.PixelFormat);
        }

        /// <summary>
        /// 得到有效图形,图形由外面传入
        /// </summary>
        /// <param name="singlepic">灰度图</param>
        /// <param name="dgGrayValue">灰度背景分界值</param>
        /// <returns></returns>
        public Bitmap GetPicValidByValue(Bitmap singlepic, int dgGrayValue)
        {
            var posx1 = singlepic.Width;
            var posy1 = singlepic.Height;
            var posx2 = 0;
            var posy2 = 0;
            for (var i = 0; i < singlepic.Height; i++) //找有效区
            {
                for (var j = 0; j < singlepic.Width; j++)
                {
                    var pixelValue = singlepic.GetPixel(j, i).R;
                    if (pixelValue < dgGrayValue) //根据灰度值
                    {
                        if (posx1 > j) posx1 = j;
                        if (posy1 > i) posy1 = i;

                        if (posx2 < j) posx2 = j;
                        if (posy2 < i) posy2 = i;
                    }
                }
            }
            //复制新图
            var cloneRect = new Rectangle(posx1, posy1, posx2 - posx1 + 1, posy2 - posy1 + 1);
            return singlepic.Clone(cloneRect, singlepic.PixelFormat);
        }

        /// <summary>
        /// 平均分割图片
        /// </summary>
        /// <param name="rowNum">水平上分割数</param>
        /// <param name="colNum">垂直上分割数</param>
        /// <returns>分割好的图片数组</returns>
        public Bitmap[] GetSplitPics(int rowNum, int colNum)
        {
            if (rowNum == 0 || colNum == 0)
                return null;
            var singW = _bmpobj.Width / rowNum;
            var singH = _bmpobj.Height / colNum;
            var picArray = new Bitmap[rowNum * colNum];

            Rectangle cloneRect;
            for (int i = 0; i < colNum; i++) //找有效区
            {
                for (int j = 0; j < rowNum; j++)
                {
                    cloneRect = new Rectangle(j * singW, i * singH, singW, singH);
                    picArray[i * rowNum + j] = _bmpobj.Clone(cloneRect, _bmpobj.PixelFormat); //复制小块图
                }
            }
            return picArray;
        }

        /// <summary>
        /// 返回灰度图片的点阵描述字串，1表示灰点，0表示背景
        /// </summary>
        /// <param name="singlepic">灰度图</param>
        /// <param name="dgGrayValue">背前景灰色界限</param>
        /// <returns></returns>
        public string GetSingleBmpCode(Bitmap singlepic, int dgGrayValue)
        {
            Color piexl;
            var code = string.Empty;
            for (var posy = 0; posy < singlepic.Height; posy++)
                for (var posx = 0; posx < singlepic.Width; posx++)
                {
                    piexl = singlepic.GetPixel(posx, posy);
                    if (piexl.R < dgGrayValue) // Color.Black )
                        code = code + "1";
                    else
                        code = code + "0";
                }
            return code;
        }

        /// <summary>
        /// 去掉噪点
        /// </summary>
        /// <param name="dgGrayValue">背前景灰色界限</param>
        /// <param name="maxNearPoints">最大靠近点</param>
        public Bitmap ClearNoise(int dgGrayValue, int maxNearPoints)
        {
            Color piexl;
            var nearDots = 0;
            //int xSpan, ySpan, tmpX, tmpY;
            //逐点判断
            for (int i = 0; i < _bmpobj.Width; i++)
                for (int j = 0; j < _bmpobj.Height; j++)
                {
                    piexl = _bmpobj.GetPixel(i, j);
                    if (piexl.R < dgGrayValue)
                    {
                        nearDots = 0;
                        //判断周围8个点是否全为空
                        if (i == 0 || i == _bmpobj.Width - 1 || j == 0 || j == _bmpobj.Height - 1) //边框全去掉
                        {
                            _bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));//边缘不处理
                            continue;
                        }
                        else
                        {
                            if (_bmpobj.GetPixel(i - 1, j - 1).R < dgGrayValue) nearDots++;
                            if (_bmpobj.GetPixel(i, j - 1).R < dgGrayValue) nearDots++;
                            if (_bmpobj.GetPixel(i + 1, j - 1).R < dgGrayValue) nearDots++;
                            if (_bmpobj.GetPixel(i - 1, j).R < dgGrayValue) nearDots++;
                            if (_bmpobj.GetPixel(i + 1, j).R < dgGrayValue) nearDots++;
                            if (_bmpobj.GetPixel(i - 1, j + 1).R < dgGrayValue) nearDots++;
                            if (_bmpobj.GetPixel(i, j + 1).R < dgGrayValue) nearDots++;
                            if (_bmpobj.GetPixel(i + 1, j + 1).R < dgGrayValue) nearDots++;
                        }

                        if (nearDots < maxNearPoints)
                            _bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255)); //去掉单点 && 粗细小3邻边点
                    }
                    else //背景
                        _bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            return _bmpobj;
        }

        /// <summary>
        /// 扭曲图片校正
        /// </summary>
        public Bitmap ReSetBitMap()
        {
            var g = Graphics.FromImage(_bmpobj);
            var x = new Matrix();
            //  X.Rotate(30);
            x.Shear((float)0.16666666667, 0); //  2/12
            g.Transform = x;
            // Draw image
            //Rectangle cloneRect = GetPicValidByValue(128);  //Get Valid Pic Rectangle
            var cloneRect = new Rectangle(0, 0, _bmpobj.Width, _bmpobj.Height);
            var tmpBmp = _bmpobj.Clone(cloneRect, _bmpobj.PixelFormat);
            g.DrawImage(tmpBmp,
                        new Rectangle(0, 0, _bmpobj.Width, _bmpobj.Height),
                        0, 0, tmpBmp.Width,
                        tmpBmp.Height,
                        GraphicsUnit.Pixel);

            return tmpBmp;
        }

        /// <summary>
        /// 调节图像的对比度
        /// </summary>
        /// <param name="threshold">阈值，通过该参数控制调节</param>
        /// <returns>调整后的图像</returns>
        public Bitmap img_color_contrast(int threshold)
        {
            BitmapData sourceData = _bmpobj.LockBits(new Rectangle(0, 0,
                                        _bmpobj.Width, _bmpobj.Height),
                                        ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            _bmpobj.UnlockBits(sourceData);

            double contrastLevel = Math.Pow((100.0 + threshold) / 100.0, 2);

            double blue = 0;
            double green = 0;
            double red = 0;

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = ((((pixelBuffer[k] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;

                green = ((((pixelBuffer[k + 1] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;

                red = ((((pixelBuffer[k + 2] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;

                if (blue > 255)
                { blue = 255; }
                else if (blue < 0)
                { blue = 0; }

                if (green > 255)
                { green = 255; }
                else if (green < 0)
                { green = 0; }

                if (red > 255)
                { red = 255; }
                else if (red < 0)
                { red = 0; }

                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;
            }

            Bitmap resultBitmap = new Bitmap(_bmpobj.Width, _bmpobj.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                        resultBitmap.Width, resultBitmap.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        /// <summary>
        /// 颜色替换
        /// </summary>
        /// <param name="souceColor">要替换的颜色</param>
        /// <param name="rpColor">替换后的颜色</param>
        /// <param name="tolerance">容差值</param>
        public Bitmap ReplaceColor(Color souceColor, Color rpColor, int tolerance)
        {
            if (_bmpobj != null)
            {
                for (int x = 0; x < _bmpobj.Width; x++)
                {
                    for (int y = 0; y < _bmpobj.Height; y++)
                    {
                        Color minColor = Color.FromArgb(CalculationColorValue(souceColor.R - tolerance), CalculationColorValue(souceColor.G - tolerance), CalculationColorValue(souceColor.B - tolerance));
                        Color maxColor = Color.FromArgb(CalculationColorValue(souceColor.R + tolerance), CalculationColorValue(souceColor.G + tolerance), CalculationColorValue(souceColor.B + tolerance));

                        if (compareColor(minColor, maxColor, _bmpobj.GetPixel(x, y)))
                        {
                            _bmpobj.SetPixel(x, y, rpColor);
                        }
                    }
                }
            }

            return _bmpobj;
        }
        /// <summary>
        /// 容差色准比较
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool compareColor(Color min, Color max, Color c)
        {
            bool bR = false;
            bool bG = false;
            bool bB = false;

            if (c.R >= min.R && c.R <= max.R)
            {
                bR = true;
            }
            if (c.G >= min.G && c.G <= max.G)
            {
                bG = true;
            }
            if (c.B >= min.B && c.B <= max.B)
            {
                bB = true;
            }

            if (bR && bG && bB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 容差颜色计算（防止超过色域）
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        private int CalculationColorValue(int dat)
        {
            if (dat < 0)
            {
                return 0;
            }
            else
            {
                if (dat > 255)
                {
                    return 255;
                }
                else
                {
                    return dat;
                }
            }
        }

        public Bitmap ToGrey()
        {
            for (int i = 0; i < _bmpobj.Width; i++)
            {
                for (int j = 0; j < _bmpobj.Height; j++)
                {
                    Color pixelColor = _bmpobj.GetPixel(i, j);
                    //计算灰度值
                    int grey = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                    Color newColor = Color.FromArgb(grey, grey, grey);
                    _bmpobj.SetPixel(i, j, newColor);
                }
            }
            return _bmpobj;
        }
        public Bitmap Thresholding()
        {
            //int[] histogram = new int[256];
            //int minGrayValue = 255, maxGrayValue = 0;
            ////求取直方图
            //for (int i = 0; i < _bmpobj.Width; i++)
            //{
            //    for (int j = 0; j < _bmpobj.Height; j++)
            //    {
            //        Color pixelColor = _bmpobj.GetPixel(i, j);
            //        histogram[pixelColor.R]++;
            //        if (pixelColor.R > maxGrayValue) maxGrayValue = pixelColor.R;
            //        if (pixelColor.R < minGrayValue) minGrayValue = pixelColor.R;
            //    }
            //}
            ////迭代计算阀值
            //int threshold = -1;
            //int newThreshold = (minGrayValue + maxGrayValue) / 2;
            //for (int iterationTimes = 0; threshold != newThreshold && iterationTimes < 100; iterationTimes++)
            //{
            //    threshold = newThreshold;
            //    int lP1 = 0;
            //    int lP2 = 0;
            //    int lS1 = 0;
            //    int lS2 = 0;
            //    //求两个区域的灰度的平均值
            //    for (int i = minGrayValue; i < threshold; i++)
            //    {
            //        lP1 += histogram[i] * i;
            //        lS1 += histogram[i];
            //    }
            //    if (lS1 == 0) continue;
            //    int mean1GrayValue = (lP1 / lS1);
            //    for (int i = threshold + 1; i < maxGrayValue; i++)
            //    {
            //        lP2 += histogram[i] * i;
            //        lS2 += histogram[i];
            //    }
            //    if (lS2 == 0) continue;
            //    int mean2GrayValue = (lP2 / lS2);
            //    newThreshold = (mean1GrayValue + mean2GrayValue) / 2;
            //}

            _dgGrayValue = GetGrayValue(_bmpobj);

            //计算二值化
            for (int i = 0; i < _bmpobj.Width; i++)
            {
                for (int j = 0; j < _bmpobj.Height; j++)
                {
                    Color pixelColor = _bmpobj.GetPixel(i, j);
                    if (pixelColor.R > _dgGrayValue) _bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    else _bmpobj.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }

            return _bmpobj;
        }

        public int GetGrayValue(Bitmap bit)
        {
            int[] histogram = new int[256];
            int minGrayValue = 255, maxGrayValue = 0;
            //求取直方图
            for (int i = 0; i < _bmpobj.Width; i++)
            {
                for (int j = 0; j < _bmpobj.Height; j++)
                {
                    Color pixelColor = _bmpobj.GetPixel(i, j);
                    histogram[pixelColor.R]++;
                    if (pixelColor.R > maxGrayValue) maxGrayValue = pixelColor.R;
                    if (pixelColor.R < minGrayValue) minGrayValue = pixelColor.R;
                }
            }
            //迭代计算阀值
            int threshold = -1;
            int newThreshold = (minGrayValue + maxGrayValue) / 2;
            for (int iterationTimes = 0; threshold != newThreshold && iterationTimes < 100; iterationTimes++)
            {
                threshold = newThreshold;
                int lP1 = 0;
                int lP2 = 0;
                int lS1 = 0;
                int lS2 = 0;
                //求两个区域的灰度的平均值
                for (int i = minGrayValue; i < threshold; i++)
                {
                    lP1 += histogram[i] * i;
                    lS1 += histogram[i];
                }
                if (lS1 == 0) continue;
                int mean1GrayValue = (lP1 / lS1);
                for (int i = threshold + 1; i < maxGrayValue; i++)
                {
                    lP2 += histogram[i] * i;
                    lS2 += histogram[i];
                }
                if (lS2 == 0) continue;
                int mean2GrayValue = (lP2 / lS2);
                newThreshold = (mean1GrayValue + mean2GrayValue) / 2;
            }

            return newThreshold;
        }

        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }

        public static Bitmap TailorImage(Bitmap bmp)
        {
            int x1, y1, x2, y2;
            x1 = x2 = y1 = y2 = 0;

            Color backGroundColor = bmp.GetPixel(0, 0);

            #region 计算边界
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (bmp.GetPixel(x, y) != backGroundColor)
                    {
                        x1 = x;
                        goto Next1;
                    }
                }
            }

            Next1:
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (bmp.GetPixel(x, y) != backGroundColor)
                    {
                        y1 = y;
                        goto Next2;
                    }
                }
            }

            Next2:
            for (int x = bmp.Width-1; x >0; x--)
            {
                for (int y = bmp.Height-1; y >0; y--)
                {
                    if (bmp.GetPixel(x, y) != backGroundColor)
                    {
                        x2 = x;
                        goto Next3;
                    }
                }
            }

            Next3:
            for (int y = bmp.Height-1; y > 0; y--)
            {
                for (int x = bmp.Width-1; x > 0; x--)
                {
                    if (bmp.GetPixel(x, y) != backGroundColor)
                    {
                        y2 = y;
                        goto Next4;
                    }
                }
            }
            #endregion
            Next4:
            int temp = x1 - 5;
            if (temp > 0)
            {
                x1 = temp;
            }

            temp = y1 - 5;
            if (temp > 0)
            {
                y1 = temp;
            }

            temp = x2 + 5;
            if (temp < bmp.Width)
            {
                x2 = temp;
            }

            temp = y2 + 5;
            if (temp < bmp.Height)
            {
                y2 = temp;
            }

            int w = x2 - x1;
            int h = y2 - y1;
            if (w > 0 && h > 0)
            {
                Rectangle rec = new Rectangle(new Point(x1, y1), new Size(w, h));
                Bitmap ResultImag = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(ResultImag);
                g.DrawImage(bmp, new Rectangle(0, 0, w, h), rec, GraphicsUnit.Pixel);
                g.Dispose();

                return ResultImag;
            }
            else
            {
                return bmp;
            }
        }

        public static Bitmap hough_line(Bitmap bmpobj, int cross_num)
        {
            Bitmap I_out = bmpobj;
            int x = bmpobj.Width;
            int y = bmpobj.Height;
            for (int ii = 0; ii < 10; ii++)
            {
 
                int rho_max = (int)Math.Floor(Math.Sqrt(x * x + y * y)) + 1; //由原图数组坐标算出ρ最大值，并取整数部分加1
                //此值作为ρ，θ坐标系ρ最大值
                int[,] accarray = new int[rho_max, 180]; //定义ρ，θ坐标系的数组，初值为0。
                //θ的最大值，180度
 
                double[] Theta = new double[180];
                //定义θ数组，确定θ取值范围
                double i = 0;
                for (int index = 0; index < 180; index++)
                {
                    Theta[index] = i;
                    i += Math.PI / 180;
                }
 
                double rho;
                int rho_int;
                for (int n = 0; n < x; n++)
                {
                    for (int m = 0; m < y; m++)
                    {
                        Color pixel = bmpobj.GetPixel(n, m);
                        if (pixel.R == 255)
                        {
                            for (int k = 0; k < 180; k++)
                            {
                                //将θ值代入hough变换方程，求ρ值
                                rho = (m * Math.Cos(Theta[k])) + (n * Math.Sin(Theta[k]));
                                //将ρ值与ρ最大值的和的一半作为ρ的坐标值（数组坐标），这样做是为了防止ρ值出现负数
                                rho_int = (int)Math.Round(rho / 2 + rho_max / 2);
                                //在ρθ坐标（数组）中标识点，即计数累加
                                accarray[rho_int, k] = accarray[rho_int, k] + 1;
                            }
                        }
                    }
                }
 
                //=======利用hough变换提取直线======
                //寻找100个像素以上的直线在hough变换后形成的点
                const int max_line = 100;
                int[] case_accarray_n = new int[max_line];
                int[] case_accarray_m = new int[max_line];
                int K = 0; //存储数组计数器
                for (int rho_n = 0; rho_n < rho_max; rho_n++) //在hough变换后的数组中搜索
                {
                    for (int theta_m = 0; theta_m < 180; theta_m++)
                    {
                        if (accarray[rho_n, theta_m] >= cross_num && K < max_line) //设定直线的最小值
                        {
                            case_accarray_n[K] = rho_n; //存储搜索出的数组下标
                            case_accarray_m[K] = theta_m;
                            K = K + 1;
                        }
                    }
                }
 
                //把这些点构成的直线提取出来,输出图像数组为I_out
                //I_out=ones(x,y).*255;
                
                for (int n = 0; n < x; n++)
                {
                    for (int m = 0; m < y; m++)
                    {
                        //首先设置为白色
 
                        Color pixel = bmpobj.GetPixel(n, m);
                        if (pixel.R == 255)
                        {
                            for (int k = 0; k < 180; k++)
                            {
                                rho = (m * Math.Cos(Theta[k])) + (n * Math.Sin(Theta[k]));
                                rho_int = (int)Math.Round(rho / 2 + rho_max / 2);
                                //如果正在计算的点属于100像素以上点，则把它提取出来
                                for (int a = 0; a < K - 1; a++)
                                {
                                    //if rho_int==case_accarray_n(a) && k==case_accarray_m(a)%%%==gai==%%% k==case_accarray_m(a)&rho_int==case_accarray_n(a)
                                    if (rho_int == case_accarray_n[a] && k == case_accarray_m[a])
                                        I_out.SetPixel(n, m, Color.Black);
                                }
                            }
                        }
 
                    }
                }
            }
           
            return I_out;
        }
    }
}
