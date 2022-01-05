using System.Runtime.InteropServices;
namespace Prewitt
{
    public class ASMPrewitt
    {
        [DllImport(@"C:\Users\czare\source\repos\Edge-detection-filter\Prewitt\x64\Debug\PrewittASM.dll")]
        static extern void ASMPrewittDLL(byte[] pixelBuffer, double[] RGB, int byteOffset, int stride);
        public static void ASMFilter(ref byte[] pixelbuffer, ref double[] RGB, int byteOffset, int stride)
        {
            ASMPrewittDLL(pixelbuffer, RGB, byteOffset, stride);
        }
    }
}
