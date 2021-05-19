using ProyectoFinalDI___VictorFernandezCalleja.Clases;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.MySQLData.RemoteProductsDataSet;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.LocalImages;
using ProyectoFinalDI___VictorFernandezCalleja.xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ProyectoFinalDI___VictorFernandezCalleja.Vistas
{
    /// <summary>
    /// Lógica de interacción para ShowProducts.xaml
    /// </summary>
    public partial class ShowProducts : Page
    {
        private XDocument xml = XDocument.Load("../../xml/TiendaPinturas.xml");
        ProductoHandler productoHandler = new ProductoHandler();
        ObservableCollection<Producto> listaFiltrada;
        public ShowProducts(ProductoHandler productoHandler)
        {
            this.productoHandler = productoHandler;
            InitializeComponent();
            UpdateProductList();
            InitProveedorCombo();
        }

        private void InitProveedorCombo()
        {
            cmbProveedor.Items.Add("Todos ...");
            var listaProveedores = xml.Root.Elements("Proveedor").Attributes("NombreProveedor");
            foreach(XAttribute proveedorXML in listaProveedores) 
            { 
                cmbProveedor.Items.Add(proveedorXML.Value);
            }
            cmbProveedor.SelectedIndex = 0;
        }

        private void UpdateProductList()
        {
            txtBusqueda.Text = "";
            cmbProveedor.SelectedIndex = 0;
            productoHandler.UpdateProductList();
            //listaFiltrada = new ObservableCollection<Producto>(productoHandler.listaFinal);
            myDataGrid.ItemsSource = productoHandler.listaProductos;
            myDataGrid.DataContext = productoHandler.listaProductos;
            myDataGrid.Items.Refresh();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = (Producto)myDataGrid.SelectedItem;
            MainWindow.navigationFrame.NavigationService.Navigate(new NewProduct("EDITAR PRODUCTO",producto,productoHandler));
            productoHandler.BorrarProducto(producto);
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = (Producto)myDataGrid.SelectedItem;
            XMLHandler.EliminarProducto(producto.referencia);
            productoHandler.BorrarProducto(producto);
            LocalImageDBHandler.RemoveDataFromDB(producto.referencia);
            UpdateProductList();
        }
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            UpdateProductList();
            
        }

        private void cmbProveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbProveedor.SelectedIndex == 0)
            {
                txtBusqueda.Text = "";
                UpdateProductList();
            }
            else
            {
                listaFiltrada.Clear();
                //listaFiltrada = new ObservableCollection<Producto>();
                foreach (Producto producto in productoHandler.listaProductos)
                {

                    if (producto.proveedor.Equals((String)cmbProveedor.SelectedItem))
                    {
                        listaFiltrada.Add(producto);
                    }
                }
                myDataGrid.ItemsSource = listaFiltrada;
                myDataGrid.DataContext = listaFiltrada;
                myDataGrid.Items.Refresh();
            }
        }

        private void txtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<Producto> nuevaListaFiltrada = new ObservableCollection<Producto>();
            foreach(Producto producto in listaFiltrada)
            {
                if (producto.GetAllValues().Contains(txtBusqueda.Text))
                {
                    nuevaListaFiltrada.Add(producto);
                }
            }
            myDataGrid.DataContext = nuevaListaFiltrada;
            myDataGrid.ItemsSource = nuevaListaFiltrada;

        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = (Producto)myDataGrid.SelectedItem;
            if (producto.publish)
            {
                bool borradoOK = MySQLDBHandler.DeleteDataFromDB(producto.referencia);
                if (borradoOK)
                {
                    producto.publish = false;
                    XMLHandler.ModificarProducto(producto);
                    UpdateProductList();
                }
            }
            else
            {
                bool insercionOK = MySQLDBHandler.AddDataToDB(producto);
                if (insercionOK)
                {
                    producto.publish = true;
                    XMLHandler.ModificarProducto(producto);
                    UpdateProductList();
                }
            }
        }
    }
}
