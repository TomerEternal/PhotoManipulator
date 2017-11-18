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
            byte[] arr = { 1, 2, 3, 4, 5 ,
                           6, 7, 8, 9,10};
            int height = 2;
            int stride = 5-1;
            //Act
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = 0; j < stride; j += 4)
                {
                    int index = i * stride;
                    ReplaceByteArrayBytes(arr, index + j, index + stride - j);
                    ReplaceByteArrayBytes(arr, index + j + 1, index + stride - j + 1);
                    ReplaceByteArrayBytes(arr, index + j + 2, index + stride - j + 2);
                }
            }

            //Assert
            Assert.IsTrue(arr[0] == 5 && arr[4] == 1 && arr[5] == 10 && arr[9] == 6);
        }
        // Copy pasted in order to isolate a private function from within the PixelManger logic.
        private static void ReplaceByteArrayBytes(byte[] arr, int indexA, int indexB)
        {
            byte tmp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = tmp;
        }
    }
}
