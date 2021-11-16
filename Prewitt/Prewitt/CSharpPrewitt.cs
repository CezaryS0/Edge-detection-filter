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
    public static class Matrix
    {
        
        public static double[,] Prewitt3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -1,  0,  1, },
                  { -1,  0,  1, }, 
                };
            }
        }
        public static double[,] Prewitt3x3Vertical
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
    public static class CSharpPrewitt
    {
        private static bool done;
        static object Lock = new object();
        private static void ApplyGrayScale(ref byte[]pixelBuffer)
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
        private static void MakeCalculations(ref Bitmap sourceBitmap,ref BitmapData sourceData,ref byte[]pixelBuffer,ref byte[] resultBuffer)
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

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;
            for (int offsetY = filterOffset; offsetY < sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;
                    blueTotal = greenTotal = redTotal = 0.0;
                    byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);
                            blueX += (double)(pixelBuffer[calcOffset]) * Matrix.Prewitt3x3Horizontal[filterY + filterOffset, filterX + filterOffset];
                            greenX += (double)(pixelBuffer[calcOffset + 1]) * Matrix.Prewitt3x3Horizontal[filterY + filterOffset, filterX + filterOffset];
                            redX += (double)(pixelBuffer[calcOffset + 2]) * Matrix.Prewitt3x3Horizontal[filterY + filterOffset, filterX + filterOffset];
                            blueY += (double)(pixelBuffer[calcOffset]) * Matrix.Prewitt3x3Vertical[filterY + filterOffset, filterX + filterOffset];
                            greenY += (double)(pixelBuffer[calcOffset + 1]) * Matrix.Prewitt3x3Vertical[filterY + filterOffset, filterX + filterOffset];
                            redY += (double)(pixelBuffer[calcOffset + 2]) * Matrix.Prewitt3x3Vertical[filterY + filterOffset, filterX + filterOffset];
                        }
                    }
                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                        blueTotal = 255;
                    else if (blueTotal < 0)
                        blueTotal = 0;

                    if (greenTotal > 255)
                        greenTotal = 255;
                    else if (greenTotal < 0)
                        greenTotal = 0;

                    if (redTotal > 255)
                        redTotal = 255;
                    else if (redTotal < 0)
                        redTotal = 0;

                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }
            lock (Lock)
            {
                done = true;
            }
        }
        public static Bitmap ConvolutionFilter(Bitmap sourceBitmap,int NThreads,double[,] xFilterMatrix,double[,] yFilterMatrix,bool grayscale = false)
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
            int minIOC,maxIOC;
            ThreadPool.GetMinThreads(out _, out minIOC);
            ThreadPool.SetMinThreads(NThreads, minIOC);
            ThreadPool.GetMaxThreads(out _, out maxIOC);
            ThreadPool.SetMaxThreads(NThreads, maxIOC);
            ThreadPool.QueueUserWorkItem(state => MakeCalculations(ref sourceBitmap, ref sourceData, ref pixelBuffer, ref resultBuffer));
            while (done==false);
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,sourceBitmap.Height);

            BitmapData resultData =resultBitmap.LockBits(new Rectangle(0, 0,resultBitmap.Width, resultBitmap.Height),ImageLockMode.WriteOnly,PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0,resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        public static Bitmap PrewittFilter(Bitmap sourceBitmap,Model m, bool grayscale = true)
        {
            done= false;
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,m.GetNnumberOfThreads(),Matrix.Prewitt3x3Horizontal,Matrix.Prewitt3x3Vertical, grayscale);


            return resultBitmap;
        }
    }
  
}
