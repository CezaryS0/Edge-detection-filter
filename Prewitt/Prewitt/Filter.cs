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
            return CSharpPrewitt.PrewittFilter(bitmap, this.model);
        }
    }
}
