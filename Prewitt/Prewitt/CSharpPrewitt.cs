using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
namespace Prewitt
{
    public class Matrix
    {
        public double[,] Prewitt3x3Horizontal => new double[,]
                { { 1,  0,  -1, },
                  { 1,  0,  -1, },
                  { 1,  0,  -1, },
                };
        public double[,] Prewitt3x3Vertical => new double[,]
                { {  1,  1,  1, },
                  {  0,  0,  0, },
                  { -1, -1, -1, },
                };
    }
    public class CSharpPrewitt
    {
        private readonly Matrix matrix;
        private readonly List<ManualResetEvent> manualResetEvents;
        private byte[] pixelBuffer;
        private byte[] resultBuffer;
        public CSharpPrewitt()
        {
            manualResetEvents = new List<ManualResetEvent>();
            matrix = new Matrix();
        }

        private void ApplyGrayScale(ref byte[] pixelBuffer)
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
        private void ThreadFunction(int byteOffset, int stride, bool useASM = false)
        {
            double[] RGB = new double[6];
            if (useASM == true)
            {
                ASMPrewitt.ASMFilter(ref pixelBuffer, ref RGB, byteOffset, stride);

            }
            else
            {
                for (int filterY = -1; filterY <= 1; filterY++)
                {
                    for (int filterX = -1; filterX <= 1; filterX++)
                    {
                        int calcOffset = byteOffset + (filterX * 4) + (filterY * stride);
                        for (int i = 0; i < 3; i++)
                        {
                            RGB[i] += pixelBuffer[calcOffset + i] * matrix.Prewitt3x3Horizontal[filterY + 1, filterX + 1];
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            RGB[i + 3] += pixelBuffer[calcOffset + i] * matrix.Prewitt3x3Vertical[filterY + 1, filterX + 1];
                        }
                    }
                }
            }
            double blueTotal = Math.Sqrt((RGB[0] * RGB[0]) + (RGB[3] * RGB[3]));
            double greenTotal = Math.Sqrt((RGB[1] * RGB[1]) + (RGB[4] * RGB[4]));
            double redTotal = Math.Sqrt((RGB[2] * RGB[2]) + (RGB[5] * RGB[5]));

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
        private void divideAndSetThreads(ref Bitmap sourceBitmap, ref BitmapData sourceData, bool useASM = false)
        {
            for (int offsetY = 1; offsetY < sourceBitmap.Height - 1; offsetY++)
            {
                int stride = sourceData.Stride;
                var resetEvent = new ManualResetEvent(false);
                int width = sourceBitmap.Width;
                int offY = offsetY;
                ThreadPool.QueueUserWorkItem(arg =>
                {
                    for (int offsetX = 1; offsetX < width - 1; offsetX++)
                    {
                        int byteOffset =offY * stride + offsetX * 4;
                        ThreadFunction(byteOffset, stride, useASM);  
                    }
                    resetEvent.Set();
                });
                manualResetEvents.Add(resetEvent);
            }
            foreach (var e in manualResetEvents)
            {
                e.WaitOne();
            }
        }
        private Bitmap ConvolutionFilter(Bitmap sourceBitmap, bool grayscale, bool useASM)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                ApplyGrayScale(ref pixelBuffer);
            }
            divideAndSetThreads(ref sourceBitmap, ref sourceData, useASM);
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);
            return resultBitmap;
        }
        public Bitmap PrewittFilter( Model m)
        {
            ThreadPool.GetMaxThreads(out _, out int maxIOC);
            ThreadPool.SetMaxThreads(m.GetNnumberOfThreads(), maxIOC);

            Bitmap sourceBitmap = m.ReturnLoadedImage();
            Bitmap OutputBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            using (Graphics g = Graphics.FromImage(OutputBitmap))
            {
                var res = ConvolutionFilter(sourceBitmap, m.getGrayScale(),m.getUseASM());
                g.DrawImage(res, new Point(0, 0));
            }
            return OutputBitmap;
        }

    }

}
