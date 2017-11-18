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
        //TODO: update to new standart

        //public static Bitmap ReplaceGreen(Image original, Image manipulator)
        //{
        //    Bitmap originalBitmap = new Bitmap(original);
        //    Bitmap manipulatorBitmap = new Bitmap(manipulator);
        //    Bitmap result = new Bitmap(originalBitmap.Width, originalBitmap.Height);
        //    int width = original.Width < manipulator.Width ? original.Width : manipulator.Width;
        //    int height = original.Height < manipulator.Height ? original.Height : manipulator.Height;
        //    for (int y = 0; y < height; y++)
        //        for (int x = 0; x < width; x++)
        //        {
        //            Color pixel = originalBitmap.GetPixel(x, y);
        //            if (IsGreen(pixel))
        //                pixel = manipulatorBitmap.GetPixel(x, y);
        //            result.SetPixel(x, y, pixel);
        //        }
        //    return result;
        //}
        //private static bool IsGreen(Color color) => color.R <= 50 && color.G >= 200 && color.B <= 50;
    }
}
