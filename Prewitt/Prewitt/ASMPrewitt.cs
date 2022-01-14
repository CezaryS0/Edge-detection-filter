using System.Runtime.InteropServices;
namespace Prewitt
{
    public class ASMPrewitt
    {
        [DllImport(@"PrewittASM.dll")]
        static extern void ASMPrewittDLL(byte[] pixelBuffer, double[] RGB, int byteOffset, int stride);
        public static void ASMFilter(ref byte[] pixelbuffer, ref double[] RGB, int byteOffset, int stride)
        {
            ASMPrewittDLL(pixelbuffer, RGB, byteOffset, stride);
        }
    }
}
