using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManipulator.BLL.PixelManager
{
    public partial class PixelManager
    {
        private static void BlackAndWhite(Bitmap bmp)
        {
            BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            var numByes = bitmapData.Stride * bitmapData.Height;
            var bytes = new byte[numByes];
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, bytes, 0, numByes);
            for (int i = 0; i < numByes; i += 4)
                bytes[i] = bytes[i + 1] = bytes[i + 2] = (byte)((bytes[i] + bytes[i + 1] + bytes[i + 2])/3);
            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, bitmapData.Scan0, numByes);
            bmp.UnlockBits(bitmapData);
        }
    }
}
