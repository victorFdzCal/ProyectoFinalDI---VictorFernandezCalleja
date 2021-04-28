using Microsoft.Win32;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.LocalImages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProyectoFinalDI___VictorFernandezCalleja.Images
{
    public class ImageHandler
    {
        public static BitmapImage GetBitmapFromFile()
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Elige imagen|*.jpg; *.png";
            BitmapImage bitmapImage = new BitmapImage();

            bool? dialogOK = opf.ShowDialog();

            if(dialogOK == true)
            {
                String imageName = opf.FileName;
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(imageName, UriKind.Absolute);
                bitmapImage.EndInit();
                return bitmapImage;
            }

            return null;
        }

        /*public static byte[] EncodeImage(BitmapImage bitmapSource)
        {
            byte[] imageByte;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

            using(MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageByte = ms.ToArray();
            }
        }*/

        public static void AddImage(String productRef)
        {
            //LocalImageDBHandler.AddData_toDB(productRef);
        }
    }
}
