using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Prewitt
{
    public class Model
    {
        private Bitmap LoadedImage;
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
