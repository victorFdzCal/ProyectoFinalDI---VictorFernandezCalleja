using ProyectoFinalDI___VictorFernandezCalleja.Images;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.MySQLData.RemoteProductsDataSet;
using ProyectoFinalDI___VictorFernandezCalleja.xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDI___VictorFernandezCalleja.Clases
{
    public class ProductoHandler
    {
        public ObservableCollection<Producto> listaProductos { set; get; }
        //public ObservableCollection<Producto> listaProductosMySQL { set; get; }
        //public ObservableCollection<Producto> listaFinal { set; get; }

        public ProductoHandler()
        {
            this.listaProductos = new ObservableCollection<Producto>();
            //this.listaProductosMySQL = new ObservableCollection<Producto>();
            //this.listaFinal = new ObservableCollection<Producto>();
            UpdateProductList();
        }

        public void UpdateProductList()
        {
            this.listaProductos = XMLHandler.CargarProductos();

            foreach (Producto producto in listaProductos)
            {
                producto.imagen = ImageHandler.LoadImage(producto.referencia);
            }
        }

        public void AgregarProducto(Producto producto)
        {
            listaProductos.Add(producto);
        }

        public void BorrarProducto(Producto producto)
        {
            listaProductos.Remove(producto);
        }
    }
}
