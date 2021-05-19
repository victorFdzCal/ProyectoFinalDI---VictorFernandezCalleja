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

        public static byte[] EncodeImage(BitmapImage bitmapSource)
        {
            byte[] imageByte;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

            using(MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageByte = ms.ToArray();
            }
            return imageByte;
        }

        public static BitmapImage DecodeImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public static void AddImage(String productRef, BitmapImage bitmapImage)
        {
            LocalImageDBHandler.AddData_toDB(productRef, EncodeImage(bitmapImage));
        }

        public static BitmapImage LoadDefaultImage()
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri("/Images/imagenDefecto.png", UriKind.Relative);
            bitmapImage.EndInit();
            return bitmapImage;
        }

        public static BitmapImage LoadImage(string productRef)
        {
            byte[] imageData = LocalImageDBHandler.GetDataFromDB(productRef);
            BitmapImage bitmapImage = new BitmapImage();
            if(imageData != null)
            {
                bitmapImage = DecodeImage(imageData);
            }
            return bitmapImage;
        }

        public static void ModifyImage(string referencia, BitmapImage source)
        {
            LocalImageDBHandler.UpdateDataFromDB(referencia, EncodeImage(source));
        }
    }
}
