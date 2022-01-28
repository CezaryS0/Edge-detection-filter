using System.Drawing;
namespace Prewitt
{
    /*
     * Klasa przechowywująca wszelkie dane wykorzystywane w programie, pełni ona funkcje modelu.
     */
    public class Model
    {
        private Bitmap LoadedImage;
        private string path;
        private int NThreads;
        private bool applyGrayScale;
        private bool useASM;
        public void setPath(string path)
        {
            this.path = path;
            LoadedImage = new Bitmap(path);
        }
        public string getPath()
        {
            return path;
        }
        public void setUseASM(bool b)
        {
            this.useASM = b;
        }
        public bool getUseASM()
        {
            return useASM;
        }
        public void setGrayScale(bool b)
        {
            this.applyGrayScale = b;
        }
        public bool getGrayScale()
        {
            return applyGrayScale;
        }
        public void SetNumberOfThreads(int n)
        {
            NThreads = n;
        }
        public int GetNnumberOfThreads()
        {
            return NThreads;
        }
        public Bitmap ReturnLoadedImage()
        {
            return LoadedImage;
        }
    }
}
