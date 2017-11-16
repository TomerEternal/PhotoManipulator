using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.IO;

namespace PhotoManipulator.BLL.Test
{
    [TestClass]
    public partial class PixelManagerTest
    {
        [TestMethod]
        public void ReverseImageTest()
        {
            //Arrange
            BLL.PixelManager.PixelManager pixelManager = new BLL.PixelManager.PixelManager();
            Bitmap image = new Bitmap(Image.FromFile($@"..\..\MockImages\Car.jpeg"));
            Color originalPixel;
            Color newPixel;

            //Act
            Bitmap manipulated = new Bitmap(pixelManager.ReverseImage(image));
            originalPixel = image.GetPixel(0, 0);
            newPixel = manipulated.GetPixel(manipulated.Width-1, 0);

            //Rearrange
            image.Dispose();
            manipulated.Dispose();

            //Assert
            Assert.IsTrue(originalPixel.Equals(newPixel));


        }
    }
}
