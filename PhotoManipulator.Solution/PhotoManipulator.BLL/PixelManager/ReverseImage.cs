using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManipulator.BLL.PixelManager
{
    public static partial class PixelManager
    {
        private static void ReverseImage(Bitmap bmp)
        {
            BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = bitmapData.Stride;
            int height = bitmapData.Height;
            int numByes = stride * height;
            var bytes = new byte[numByes];
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, bytes, 0, numByes);
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = 0; j < stride/2; j += 4)
                {
                    int index = i * stride;
                    ReplaceByteArrayBytes(bytes, index + j, index + stride - j);
                    ReplaceByteArrayBytes(bytes, index + j + 1, index + stride - j + 1);
                    ReplaceByteArrayBytes(bytes, index + j + 2, index + stride - j + 2);
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, bitmapData.Scan0, numByes);
            bmp.UnlockBits(bitmapData);
        }
        private static void ReplaceByteArrayBytes(byte[] arr, int indexA, int indexB)
        {
            byte tmp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = tmp;
        }
    }
}
