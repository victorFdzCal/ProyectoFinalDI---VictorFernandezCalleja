using MySql.Data.MySqlClient;
using ProyectoFinalDI___VictorFernandezCalleja.Clases;
using ProyectoFinalDI___VictorFernandezCalleja.Images;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.MySQLData.RemoteProductsDataSet.projectdbDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.MySQLData.RemoteProductsDataSet
{
    class MySQLDBHandler
    {
        private static publishvfTableAdapter dataAdapter = new publishvfTableAdapter();
        private static projectdbDataSet dataset = new projectdbDataSet();


        public static bool DeleteDataFromDB(string referencia)
        {
            int borrado = dataAdapter.BorrarDatos(referencia);
            if(borrado > 0)
            {
                dataAdapter.Update(dataset);
                return true;
            }
            return false;
        }
        public static bool AddDataToDB(Producto producto)
        {
            int insercion = dataAdapter.Insert(producto.referencia,producto.proveedor,producto.marca,producto.descripcion,producto.color,producto.precio,producto.fechaEntrada,producto.stock,producto.imagen);
            dataAdapter.Update(dataset);
            if (insercion > 0)
            {
                return true;
            }
            return false;
        }

        public static bool ModifyDataDB (Producto producto)
        {
            int modificacion = dataAdapter.ModifyData(producto.proveedor, producto.marca, producto.descripcion, producto.color, (decimal)producto.precio, producto.fechaEntrada, producto.stock, producto.referencia);
            if(modificacion > 0)
            {
                return true;
            }
            return false;
        }

        public static Producto GetDataFromDB(String referencia)
        {
            Producto producto = new Producto();
            producto.referencia = referencia;
            try
            {
                producto.precio = dataAdapter.GetProducto(referencia).ElementAt(0).precio;
                byte [] imagen = dataAdapter.GetProducto(referencia).ElementAt(0).imagen;
                producto.imagen = ImageHandler.DecodeImage(imagen);
                producto.fechaEntrada = dataAdapter.GetProducto(referencia).ElementAt(0).fechaEntrada;
                producto.color = dataAdapter.GetProducto(referencia).ElementAt(0).color;
                producto.descripcion = dataAdapter.GetProducto(referencia).ElementAt(0).descripcion;
                producto.stock = dataAdapter.GetProducto(referencia).ElementAt(0).stock;
                producto.proveedor = dataAdapter.GetProducto(referencia).ElementAt(0).proveedor;
                producto.marca = dataAdapter.GetProducto(referencia).ElementAt(0).marca;
            }catch(Exception e)
            {

            }

            return producto;
        }

        public static ObservableCollection<Producto> GetListaProductos()
        {
            ObservableCollection<Producto> listaProductos = new ObservableCollection<Producto>();
            foreach(var row in dataAdapter.CogerDatos())
            {
                Producto producto = new Producto()
                {
                    referencia = (string)row["referencia"],
                    proveedor = (string)row["proveedor"],
                    marca = (string)row["marca"],
                    descripcion = (string)row["descripcion"],
                    color = (string)row["color"],
                    precio = (float)row["precio"],
                    fechaEntrada = (DateTime)row["fechaEntrada"],
                    stock = (int)row["stock"],
                    publish = true
                };
                listaProductos.Add(producto);
            }
            
            return listaProductos;
        }
    }
}
