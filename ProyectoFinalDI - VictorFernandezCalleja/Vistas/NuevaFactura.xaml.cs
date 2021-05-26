using ProyectoFinalDI___VictorFernandezCalleja.Clases;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.Facturas;
using ProyectoFinalDI___VictorFernandezCalleja.Reporting;
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

namespace ProyectoFinalDI___VictorFernandezCalleja.Vistas
{
    /// <summary>
    /// Lógica de interacción para NuevaFactura.xaml
    /// </summary>
    public partial class NuevaFactura : Page
    {
        public ProductoHandler productoHandler;
        public NuevaFactura(ProductoHandler productoHandler)
        {
            this.productoHandler = productoHandler;
            InitializeComponent();
            InitCmbProductos();
        }

        private void InitCmbProductos()
        {
            var listaProductos = productoHandler.listaProductos;
            foreach(Producto producto in listaProductos)
            {
                cmbProductos.Items.Add(producto);
            }
        }

        private void btnAddProducto_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = (Producto)cmbProductos.SelectedItem;
            dataGridProductosFactura.Items.Add(producto);
        }

        private void btnCrearFactura_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Producto> listaProductos = new ObservableCollection<Producto>();
            Factura factura = new Factura();
            factura.cif = edtDNI.Text;
            factura.fecha = DateTime.Today;
            factura.refFactura = edtNumFactura.Text;
            Cliente cliente = new Cliente();
            cliente.cif = edtDNI.Text;
            cliente.direccion = edtDireccion.Text;
            cliente.nombre = edtNombre.Text;
            bool clienteOK = FacturasDBHandler.AddCliente(cliente);
            if (!clienteOK)
            {
                MessageBox.Show("Ya existe un cliente con ese CIF");
            }
            bool facturaOK = FacturasDBHandler.AddFactura(factura);
            if (!facturaOK) {
                MessageBox.Show("Ya existe una factura con ese Número de Factura");
            }
            ProductoFactura producto = new ProductoFactura();
            ItemCollection p = dataGridProductosFactura.Items; 
            foreach (Producto pr in p)
            {
                producto.cantidad = pr.stock;
                producto.descripcion = pr.descripcion;
                producto.precio = pr.precio;
                producto.refProducto = pr.referencia;
                producto.refFactura = edtNumFactura.Text;
                FacturasDBHandler.AddProducto(producto);
            }
            ReportPreview reportPreview = new ReportPreview();
            bool facturaCompletaOK = reportPreview.MostrarFacturaNumFactura(edtNumFactura.Text);
            if (facturaCompletaOK)
            {
                reportPreview.Show();
                MainWindow.navigationFrame.NavigationService.Navigate(new PaginaInicio());
            }

        }
    }
}
