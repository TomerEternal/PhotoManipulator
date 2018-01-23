using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManipulator.BLL.PixelManager
{

    public partial class PixelManager
    {
        public enum ManipulationEffect
        {
            BlackAndWhite,
            Reverse,
            Aesthetic
        }
        public static void Manipulate(Bitmap bmp, ManipulationEffect manipulationEffect)
        {
            switch (manipulationEffect)
            {
                case ManipulationEffect.BlackAndWhite:
                    BlackAndWhite(bmp);
                    break;
                case ManipulationEffect.Reverse:
                    ReverseImage(bmp);
                    break;
                case ManipulationEffect.Aesthetic:
                    Aesthetic(bmp);
                    break;
                default:
                    break;
            }
        }
    }
}
