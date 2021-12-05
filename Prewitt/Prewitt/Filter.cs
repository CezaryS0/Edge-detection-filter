using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Prewitt
{
    public class Filter
    {
        Model model;
        CSharpPrewitt sharpPrewitt = new CSharpPrewitt();
        public Filter(Model m)
        {
            this.model = m;
        }
        public Bitmap PutOnTheFilterASM()
        {
            return null;
        }
        public Bitmap PutOnTheFilterCSharp(Bitmap bitmap)
        {
            return sharpPrewitt.PrewittFilter(bitmap, this.model);
        }
    }
}
