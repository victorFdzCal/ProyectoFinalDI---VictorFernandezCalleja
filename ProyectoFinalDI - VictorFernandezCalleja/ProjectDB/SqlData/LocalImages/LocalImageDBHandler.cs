using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.LocalImages.LocalImagesDataSet;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.LocalImages.LocalImagesDataSet.DataSet_Local_ImagesTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.LocalImages
{
    public class LocalImageDBHandler
    {
        private static ImagesTableAdapter imagesAdapter = new ImagesTableAdapter();
        private static DataSet_Local_Images dataset = new DataSet_Local_Images();

        public static void AddData_toDB(String idImage, byte[] productImage)
        {
            imagesAdapter.Insert(idImage, productImage);
            imagesAdapter.Update(dataset);

        }

        public static byte[] GetDataFromDB(string idImage)
        {
            byte[] imageData = null;
            try
            {
                imageData = imagesAdapter.GetImage(idImage).ElementAt(0).productImage;
            }
            catch(Exception e)
            {
                
            }
            return imageData;
        }

        public static void UpdateDataFromDB(string idImage, byte[] productImage)
        {
            byte [] dataImage = GetDataFromDB(idImage);
            if(dataImage == null)
            {
                AddData_toDB(idImage, productImage);
            }
            else
            {
                imagesAdapter.UpdateData(productImage, idImage);
                imagesAdapter.Update(dataset);
            }
        }

        public static void RemoveDataFromDB(string idImage)
        {
            imagesAdapter.Delete(idImage);
            imagesAdapter.Update(dataset);
        }
    }
}
