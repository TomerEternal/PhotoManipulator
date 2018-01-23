using PhotoManipulator.BLL.PixelManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManipulator.ConsoleApp.BLLExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a bitmap from a source file
            using (Bitmap carBitmap = new Bitmap(Image.FromFile($"sources/Car.jpeg")))
            using (Bitmap cloneCarBitmap = new Bitmap(carBitmap.Clone() as Image))
            {
                //Displaying the image pre manipulation
                PopupImage(carBitmap, "Photo pre manipulation");
                //Manipulating the image
                var before = DateTime.Now;
                for (int i = 0; i < 5000; i++)
                {
                    PixelManager.Manipulate(cloneCarBitmap, PixelManager.ManipulationEffect.Aesthetic);
                }
                var after = DateTime.Now;
                //Displaying the image post manipulation
                PopupImage(cloneCarBitmap, $"manipulation took {(after - before).ToString()}");
                Console.ReadKey();
            }
        }

        private static void PopupImage(Bitmap bitmap, string title)
        {
            Task.Run(() =>
            {
                using (Form form = new Form())
                {
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Size = bitmap.Size;
                    form.Text = title;

                    PictureBox pb = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        Image = bitmap
                    };

                    form.Controls.Add(pb);

                    form.ShowDialog();
                }
            });
        }
    }
}

