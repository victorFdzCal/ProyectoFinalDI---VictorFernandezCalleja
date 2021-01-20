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

        public ProductoHandler()
        {
            this.listaProductos = new ObservableCollection<Producto>();
            UpdateProductList();
        }

        public void UpdateProductList()
        {
            this.listaProductos = XMLHandler.CargarProductos();
        }

        public void AgregarProducto(Producto producto)
        {
            listaProductos.Add(producto);
        }
    }
}
