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
        object Lock = new object();
        byte[] pixelBuffer;
        byte[] resultBuffer;
        public CSharpPrewitt()
        {
            partsOfBitmap = new List<BitmapSegment>();
            manualResetEvents = new List<ManualResetEvent>();
            matrix = new Matrix();
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
        private void ThreadFunction(int offsetX,int offsetY,int stride)
        {
            double blueX = 0, greenX = 0, redX = 0;
            double blueY = 0, greenY = 0, redY = 0;
            int byteOffset = offsetY * stride + offsetX * 4;

            for (int filterY = -1; filterY <= 1; filterY++)
            {
                for (int filterX = -1; filterX <= 1; filterX++)
                {
                    int calcOffset = byteOffset + (filterX * 4) + (filterY *stride);
                  
                        blueX += (double)(pixelBuffer[calcOffset]) * matrix.Prewitt3x3Horizontal[filterY + 1, filterX + 1];
                        greenX += (double)(pixelBuffer[calcOffset + 1]) * matrix.Prewitt3x3Horizontal[filterY + 1, filterX + 1];
                        redX += (double)(pixelBuffer[calcOffset + 2]) * matrix.Prewitt3x3Horizontal[filterY + 1, filterX + 1];
                        blueY += (double)(pixelBuffer[calcOffset]) * matrix.Prewitt3x3Vertical[filterY + 1, filterX + 1];
                        greenY += (double)(pixelBuffer[calcOffset + 1]) * matrix.Prewitt3x3Vertical[filterY + 1, filterX + 1];
                        redY += (double)(pixelBuffer[calcOffset + 2]) * matrix.Prewitt3x3Vertical[filterY + 1, filterX + 1];
                }
            }
            double blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
            double greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
            double redTotal = Math.Sqrt((redX * redX) + (redY * redY));

            if (blueTotal > 255)
                blueTotal = 255;
            if (greenTotal > 255)
                greenTotal = 255;
            if (redTotal > 255)
                redTotal = 255;
            lock (Lock)
            {
                resultBuffer[byteOffset] = (byte)(blueTotal);
                resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                resultBuffer[byteOffset + 2] = (byte)(redTotal);
                resultBuffer[byteOffset + 3] = 255;
            }
        }
        private void MakeCalculations(ref Bitmap sourceBitmap, ref BitmapData sourceData)
        {
            for (int offsetY = 1; offsetY < sourceBitmap.Height - 1; offsetY++)
            {
                for (int offsetX = 1; offsetX < sourceBitmap.Width - 1; offsetX++)
                {
                    int stride = sourceData.Stride;
                    var resetEvent = new ManualResetEvent(false);
                    int offX = offsetX;
                    int offY = offsetY;
                    ThreadPool.QueueUserWorkItem(arg =>
                    {
                        ThreadFunction(offX, offY, stride);
                        resetEvent.Set();
                    });
                    manualResetEvents.Add(resetEvent);
                }
            }
            foreach (var e in manualResetEvents)
            {
                e.WaitOne();
            }
        }
        public Bitmap ConvolutionFilter(Bitmap sourceBitmap,double[,] xFilterMatrix,double[,] yFilterMatrix,bool grayscale = false)
        {
            BitmapData sourceData =sourceBitmap.LockBits(new Rectangle(0, 0,sourceBitmap.Width, sourceBitmap.Height),ImageLockMode.ReadOnly,PixelFormat.Format32bppArgb);
            pixelBuffer = new byte[sourceData.Stride *sourceData.Height];

            resultBuffer = new byte[sourceData.Stride *sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                ApplyGrayScale(ref pixelBuffer);
            }
            MakeCalculations(ref sourceBitmap, ref sourceData);
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData =resultBitmap.LockBits(new Rectangle(0, 0,resultBitmap.Width, resultBitmap.Height),ImageLockMode.WriteOnly,PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0,resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        public Bitmap PrewittFilter(Bitmap sourceBitmap, Model m, bool grayscale = false)
        {
            int minIOC, maxIOC;
            ThreadPool.GetMaxThreads(out _, out maxIOC);
            ThreadPool.SetMaxThreads(m.GetNnumberOfThreads(), maxIOC);
            Bitmap OutputBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            using (Graphics g = Graphics.FromImage(OutputBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
                int i = 0;
                var res = ConvolutionFilter(sourceBitmap, matrix.Prewitt3x3Horizontal, matrix.Prewitt3x3Vertical, grayscale);
                g.DrawImage(res,new Point(0,0));
            }
            return OutputBitmap;
        }

    }
  
}
