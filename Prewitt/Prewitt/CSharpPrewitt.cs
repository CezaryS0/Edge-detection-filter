using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
namespace Prewitt
{
    public class Matrix
    {
        public double[,] Prewitt3x3Horizontal
        {
            get
            {
                return new double[,]
                { { 1,  0,  -1, },
                  { 1,  0,  -1, },
                  { 1,  0,  -1, }, 
                };
            }
        }
        public double[,] Prewitt3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  1,  1, },
                  {  0,  0,  0, },
                  { -1, -1, -1, }, 
                };
            }
        }
    }
    public class CSharpPrewitt
    {
        Matrix matrix;
        List<BitmapSegment> partsOfBitmap;
        List<ManualResetEvent> manualResetEvents;
        List<Bitmap> bitmaps;
        object Lock = new object();
        public CSharpPrewitt()
        {
            partsOfBitmap = new List<BitmapSegment>();
            manualResetEvents = new List<ManualResetEvent>();
            matrix = new Matrix();
            bitmaps = new List<Bitmap>();
        }
        public void DivideBitmap(Bitmap bitmap, int size)
        {
            int PartsAmount = bitmap.Height / size;
            int sum = 0;
            for (int i = 0; i < PartsAmount; i++)
            {
                var bmp = bitmap.Clone(new Rectangle(0, i * size, bitmap.Width, size), bitmap.PixelFormat);
                partsOfBitmap.Add(new BitmapSegment(bmp, new Point(0, i * size)));
                sum += size;
            }
            sum = bitmap.Height - sum;
            if (sum > 0)
            {
                var bmp = bitmap.Clone(new Rectangle(0, PartsAmount * size, bitmap.Width, sum), bitmap.PixelFormat);
                partsOfBitmap.Add(new BitmapSegment(bmp,new Point(0,PartsAmount*size)));
            }
        }
        private void ApplyGrayScale(ref byte[]pixelBuffer)
        {
            float rgb = 0;
            for (int k = 0; k < pixelBuffer.Length; k += 4)
            {
                rgb = pixelBuffer[k] * 0.11f;
                rgb += pixelBuffer[k + 1] * 0.59f;
                rgb += pixelBuffer[k + 2] * 0.3f;

                pixelBuffer[k] = (byte)rgb;
                pixelBuffer[k + 1] = pixelBuffer[k];
                pixelBuffer[k + 2] = pixelBuffer[k];
                pixelBuffer[k + 3] = 255;
            }
        }
        private void MakeCalculations(ref Bitmap sourceBitmap,ref BitmapData sourceData,ref byte[]pixelBuffer,ref byte[] resultBuffer)
        {
            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            double blueTotal = 0.0;
            double greenTotal = 0.0;
            double redTotal = 0.0;

            int calcOffset = 0;
            int byteOffset = 0;
            for (int offsetY = 1; offsetY < sourceBitmap.Height- 1; offsetY++)
            {
                for (int offsetX = 1; offsetX < sourceBitmap.Width- 1; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;
                    byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = -1; filterY <= 1; filterY++)
                    {
                        for (int filterX = -1; filterX <= 1; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);
                            blueX += (double)(pixelBuffer[calcOffset]) * matrix.Prewitt3x3Horizontal[filterY + 1, filterX + 1];
                            greenX += (double)(pixelBuffer[calcOffset + 1]) * matrix.Prewitt3x3Horizontal[filterY + 1, filterX + 1];
                            redX += (double)(pixelBuffer[calcOffset + 2]) * matrix.Prewitt3x3Horizontal[filterY + 1, filterX + 1];
                            blueY += (double)(pixelBuffer[calcOffset]) * matrix.Prewitt3x3Vertical[filterY + 1, filterX + 1];
                            greenY += (double)(pixelBuffer[calcOffset + 1]) * matrix.Prewitt3x3Vertical[filterY + 1, filterX + 1];
                            redY += (double)(pixelBuffer[calcOffset + 2]) * matrix.Prewitt3x3Vertical[filterY + 1, filterX + 1];
                        }
                    }
                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                        blueTotal = 255;
                    if (greenTotal > 255)
                        greenTotal = 255;
                    if (redTotal > 255)
                        redTotal = 255;
                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }
        }
        public static Bitmap cropAtRect(Bitmap b, Rectangle r)
        {
            Bitmap nb = new Bitmap(r.Width, r.Height);
            using (Graphics g = Graphics.FromImage(nb))
            {
                g.DrawImage(b, -r.X, -r.Y);
                return nb;
            }
        }
        public Bitmap ConvolutionFilter(Bitmap sourceBitmap,double[,] xFilterMatrix,double[,] yFilterMatrix,bool grayscale = false)
        {
            BitmapData sourceData =sourceBitmap.LockBits(new Rectangle(0, 0,sourceBitmap.Width, sourceBitmap.Height),ImageLockMode.ReadOnly,PixelFormat.Format32bppArgb);
            byte[] pixelBuffer = new byte[sourceData.Stride *sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                ApplyGrayScale(ref pixelBuffer);
            }
            MakeCalculations(ref sourceBitmap, ref sourceData, ref pixelBuffer, ref resultBuffer);
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData =resultBitmap.LockBits(new Rectangle(0, 0,resultBitmap.Width, resultBitmap.Height),ImageLockMode.WriteOnly,PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0,resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        public Bitmap PrewittFilter(Bitmap sourceBitmap, Model m, bool grayscale = false)
        {
            DivideBitmap(sourceBitmap, m.GetNnumberOfThreads());
            int minIOC,maxIOC;
            ThreadPool.GetMaxThreads(out _, out maxIOC);
            ThreadPool.SetMaxThreads(m.GetNnumberOfThreads(), maxIOC);
            Bitmap OutputBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            using (Graphics g = Graphics.FromImage(OutputBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
                foreach (var bmp in partsOfBitmap)
                {
                    var resetEvent = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(arg =>
                    {
                        var res = ConvolutionFilter(bmp.bitmap, matrix.Prewitt3x3Horizontal, matrix.Prewitt3x3Vertical, grayscale);
                        lock (Lock)
                        {
                            g.DrawImage(res,bmp.point);
                        }
                        resetEvent.Set();
                    });
                    manualResetEvents.Add(resetEvent);
                }
                foreach(var e in manualResetEvents)
                {
                    e.WaitOne();
                }
            }
            return OutputBitmap;
        }

    }
  
}
