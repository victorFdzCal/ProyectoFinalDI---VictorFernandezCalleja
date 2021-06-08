using ProyectoFinalDI___VictorFernandezCalleja.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProyectoFinalDI___VictorFernandezCalleja.xml
{
    public class XMLHandler
    {
        private static string XMLpath = Environment.CurrentDirectory;
        private static string XMLname = "xml/TiendaPinturas.xml";
        private static string documentoXML = Path.Combine(XMLpath, XMLname);
        private static XDocument xml;
        private static Producto producto;
        private static XElement xmlProveedor;
        private static XElement xmlMarca;


        public static void CargarXML()
        {
            xml = XDocument.Load(documentoXML);

        }

        public static void GuardarXML()
        {
            xml.Save(documentoXML);
        }

        public static XDocument ReturnXDocument()
        {
            return XDocument.Load(documentoXML);
        }

        public static void EliminarProducto(String productRef)
        {
            CargarXML();
            var listaReferenciasXML = xml.Root.Elements("Proveedor").Elements("Marca").Elements("Articulo").Attributes("Referencia");
            foreach(XAttribute referencia in listaReferenciasXML){
                if(productRef == referencia.Value)
                {
                    referencia.Parent.Remove();
                    break;
                }
            }
            GuardarXML();
        }

        public static ObservableCollection<Producto> CargarProductos()
        {
            ObservableCollection<Producto> listaProductos = new ObservableCollection<Producto>();
            CargarXML();
            var listaProductosXML = xml.Root.Elements("Proveedor").Elements("Marca").Elements("Articulo");
                
            foreach (XElement productoXML in listaProductosXML)
            {
                producto = new Producto();
                producto.proveedor = productoXML.Parent.Parent.Attribute("NombreProveedor").Value;
                producto.marca = productoXML.Parent.Attribute("NombreMarca").Value;
                producto.referencia = productoXML.Attribute("Referencia").Value;
                producto.descripcion = productoXML.Attribute("Descripcion").Value;
                producto.color = productoXML.Attribute("Color").Value;
                producto.precio = float.Parse(productoXML.Attribute("Precio").Value,NumberFormatInfo.InvariantInfo);
                producto.fechaEntrada = DateTime.Parse(productoXML.Attribute("FechaEntrada").Value);
                producto.stock = int.Parse(productoXML.Attribute("Stock").Value);
                string textoPublish = productoXML.Attribute("Publicado").Value;
                if(textoPublish == "true")
                {
                    producto.publish = true;
                }else if(textoPublish == "false")
                {
                    producto.publish = false;
                }
                
                listaProductos.Add(producto);
            }
            return listaProductos;
        }

        public static void AddProduct(Producto p)
        {
            producto = p;
            CargarXML();
            AddProveedor();
            AddMarca();
            CreateProduct();
            GuardarXML();
        }

        private static void CreateProduct()
        {
            XElement xmlProduct = new XElement("Articulo", new XAttribute("Referencia", producto.referencia), 
                new XAttribute("Descripcion",producto.descripcion), 
                new XAttribute("Color",producto.color),
                new XAttribute("Precio",producto.precio), 
                new XAttribute("FechaEntrada",producto.fechaEntrada), 
                new XAttribute("Stock",producto.stock),
                new XAttribute("Publicado",producto.publish));
            xmlMarca.Add(xmlProduct);
        }

        //<Articulo Referencia="BRU_INT_NEG" Descripcion="Bruguer Pintura Interior Negro" Color="Negro" Precio="20.0" FechaEntrada="19-01-2021" Stock="50" />
        public static bool ModificarProducto(Producto p)
        {
            CargarXML();
            var listaReferenciasXML = xml.Root.Elements("Proveedor").Elements("Marca").Elements("Articulo").Attributes("Referencia");
            foreach (XAttribute referencia in listaReferenciasXML)
            {
                if (p.referencia == referencia.Value)
                {
                    referencia.Parent.Remove();
                    break;
                }
            }
            GuardarXML();
            AddProduct(p);
            return true;
        }

        private static void AddProveedor()
        {
            var listaCategorias = xml.Root.Elements("Proveedor").Attributes("NombreProveedor");
            bool isNewCategory = true;
            foreach (XAttribute categoria in listaCategorias)
            {
                if (categoria.Value.Equals(producto.proveedor))
                {
                    xmlProveedor = categoria.Parent;
                    isNewCategory = false;
                    break;
                }
                else
                {
                    xmlProveedor = new XElement("Proveedor", new XAttribute("NombreProveedor", producto.proveedor));
                    xmlMarca = new XElement("Marca", new XAttribute("NombreMarca", producto.marca));
                    isNewCategory = true;
                }
            }
            if (isNewCategory)
            {
                xmlProveedor.Add(xmlMarca);
                xml.Root.Add(xmlProveedor);
            }
        }

        private static void AddMarca()
        {
            bool isNewBrand = true;
            foreach (XAttribute marca in xmlProveedor.Elements().Attributes("NombreMarca"))
            {
                if (marca.Value.Equals(producto.marca))
                {
                    xmlMarca = marca.Parent;
                    isNewBrand = false;
                    break;
                }
                else
                {
                    xmlMarca = new XElement("Marca", new XAttribute("NombreMarca", producto.marca));
                    isNewBrand = true;
                }
            }
            if (isNewBrand)
            {
                xmlProveedor.Add(xmlMarca);
            }
        }

    }

}
