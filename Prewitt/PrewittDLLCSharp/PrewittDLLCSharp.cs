namespace PrewittDLLCSharp
{
    class Matrix
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
    public class PrewittDLLCSharp
    {
        public void Calculate(ref byte[] pixelBuffer, double[] RGB, int byteOffset, int stride)
        {
            Matrix matrix = new Matrix();
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
    }
}
