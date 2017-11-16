﻿using System;
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
        public Image ReverseImage(Bitmap image)
        {
            Bitmap originalBitmap = image.Clone() as Bitmap;
            for (int x = 0; x < originalBitmap.Width; x++)
                for (int y = 0; y < originalBitmap.Height; y++)
                    originalBitmap.SetPixel(x, y, image.GetPixel(image.Width - x, y));
            return originalBitmap;
        }
    }
}