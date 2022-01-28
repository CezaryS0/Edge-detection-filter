using System.Runtime.InteropServices;
namespace Prewitt
{
    public class PrewittDLLASM
    {
        /*
         * Funkcja wywołująca metodę znajdującą się bibliotce DLL napisaną w asm.
         */
        [DllImport(@"PrewittASM.dll")]
        private static extern void ASMPrewittDLL(byte[] pixelBuffer, double[] RGB, int byteOffset, int stride);
        public void ASMFilter(ref byte[] pixelbuffer, ref double[] RGB, int byteOffset, int stride)
        {
            ASMPrewittDLL(pixelbuffer, RGB, byteOffset, stride);
        }
    }
}
