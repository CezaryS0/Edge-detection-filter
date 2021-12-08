using System.Drawing;
namespace Prewitt
{
    public class Model
    {
        private readonly Bitmap LoadedImage;
        public string path;
        private int NThreads;
        public Model(string path)
        {
            this.path = path;
            this.LoadedImage = new Bitmap(path);
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
