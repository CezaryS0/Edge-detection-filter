using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Prewitt
{
    public class BitmapSegment
    {
        public Bitmap bitmap;
        public Point point;
        public BitmapSegment(Bitmap bitmap,Point point)
        {
            this.bitmap = bitmap;
            this.point = point;
        }
    }
}
