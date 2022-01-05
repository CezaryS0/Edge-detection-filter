using System.Drawing;
namespace Prewitt
{
    public class Filter
    {
        private readonly Model model;
        private readonly CSharpPrewitt sharpPrewitt = new CSharpPrewitt();
        public Filter(Model m)
        {
            this.model = m;
        }
        public Bitmap PutOnTheFilterASM(Bitmap bitmap)
        {
            return sharpPrewitt.PrewittFilter(bitmap, this.model, false, true);
        }
        public Bitmap PutOnTheFilterCSharp(Bitmap bitmap)
        {
            return sharpPrewitt.PrewittFilter(bitmap, this.model);
        }
    }
}
