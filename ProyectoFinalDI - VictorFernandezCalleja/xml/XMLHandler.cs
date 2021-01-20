using ProyectoFinalDI___VictorFernandezCalleja.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProyectoFinalDI___VictorFernandezCalleja.xml
{
    public class XMLHandler
    {
        private static XDocument xml;
        private static Producto producto;

        public static void CargarXML()
        {
            xml = XDocument.Load("../../xml/TiendaPinturas.xml");

        }

        public static ObservableCollection<Producto> CargarProductos()
        {
            ObservableCollection<Producto> listaProductos = new ObservableCollection<Producto>();
            CargarXML();
            var listaProductosXML = xml.Root.Elements("Proveedor").Elements("Marca").Elements("Articulo");
            foreach(XElement productoXML in listaProductosXML)
            {
                producto = new Producto();
                producto.referencia = productoXML.Attribute("Referencia").Value;
                producto.descripcion = productoXML.Attribute("Descripcion").Value;
                producto.color = productoXML.Attribute("Color").Value;
                producto.precio = float.Parse(productoXML.Attribute("Precio").Value);
                producto.fechaEntrada = DateTime.Parse(productoXML.Attribute("FechaEntrada").Value);
                producto.stock = int.Parse(productoXML.Attribute("Stock").Value);
                listaProductos.Add(producto);
            }
            return listaProductos;
        }
    }
}
