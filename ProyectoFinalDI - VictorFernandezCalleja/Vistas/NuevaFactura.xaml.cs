﻿using ProyectoFinalDI___VictorFernandezCalleja.Clases;
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
            if(edtNumFactura.Text == "")
            {
                MessageBox.Show("Introduce un número de factura");
            }
            else
            {
                ObservableCollection<Producto> listaProductos = new ObservableCollection<Producto>();
                Factura factura = new Factura();
                factura.cif = edtDNI.Text;
                factura.fecha = DateTime.Today;
                factura.refFactura = edtNumFactura.Text;
                bool facturaOK = FacturasDBHandler.AddFactura(factura);
                if (!facturaOK)
                {
                    MessageBox.Show("Ya existe una factura con ese Número de Factura");
                }
                ProductoFactura producto = new ProductoFactura();
                if(dataGridProductosFactura.Items == null)
                {
                    MessageBox.Show("Debes introducir al menos un producto");
                }
                else
                {
                    ItemCollection p = dataGridProductosFactura.Items;
                    foreach (Producto pr in p)
                    {
                        producto.precioTotal = pr.stock * pr.precio;
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

        private void btnAddCliente_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = System.Windows.MessageBox.Show("¿Estás seguro de que quieres añadir este cliente?", "Añadir cliente", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                if (edtDNI.Text.Equals(""))
                {
                    MessageBox.Show("El campo DNI/CIF no puede estar vacío");
                }
                else
                {
                    Cliente cliente = new Cliente();
                    cliente.cif = edtDNI.Text;
                    cliente.direccion = edtDireccion.Text;
                    cliente.nombre = edtNombre.Text;
                    bool clienteOK = FacturasDBHandler.AddCliente(cliente);
                    if (!clienteOK)
                    {
                        MessageBox.Show("Ya existe un cliente con ese CIF");
                        Cliente clienteExistente = FacturasDBHandler.GetCliente(edtDNI.Text);
                        edtDNI.Text = clienteExistente.cif;
                        edtNombre.Text = clienteExistente.nombre;
                        edtDireccion.Text = clienteExistente.direccion;
                    }
                }
            }
            
        }
    }
}
