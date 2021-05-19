using ProyectoFinalDI___VictorFernandezCalleja.Clases;
using ProyectoFinalDI___VictorFernandezCalleja.Images;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.MySQLData.RemoteProductsDataSet;
using ProyectoFinalDI___VictorFernandezCalleja.xml;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Page
    {
        private XDocument xml = XDocument.Load("../../xml/TiendaPinturas.xml");
        private ProductoHandler productoHandler;
        private bool modify;
        private Producto producto;
        public bool nuevaImagen = false;
        public bool publish = false;
        public NewProduct()
        {
            InitializeComponent();
        }

        private void InitProveedorCombo()
        {
            var listaProveedores = xml.Root.Elements("Proveedor").Attributes("NombreProveedor");

            for(int i = 0; i < listaProveedores.Count(); i++)
            {
                cmbProveedor.Items.Add(listaProveedores.ElementAt(i).Value);
            }
        }
        private void InitMarcaCombo()
        {
            var listaMarcas = xml.Root.Elements("Proveedor").Elements("Marca").Attributes("NombreMarca");

            for(int i = 0; i < listaMarcas.Count(); i++)
            {
                cmbMarca.Items.Add(listaMarcas.ElementAt(i).Value);
            }
        }
        private void InitColorCombo()
        {
            var listaColores = xml.Root.Elements("Colores").Elements("Color").Attributes("IdColor");

            for(int i = 0; i < listaColores.Count(); i++)
            {
                cmbColor.Items.Add(listaColores.ElementAt(i).Value);
            }
        }

        public NewProduct(String titulo, Producto producto, ProductoHandler productoHandler)
        {
            this.producto = producto;
            this.productoHandler = productoHandler;
            InitializeComponent();
            InitColorCombo();
            InitMarcaCombo();
            InitProveedorCombo();
            this.cmbColor.SelectedItem = producto.color;
            this.cmbMarca.SelectedItem = producto.marca;
            this.cmbProveedor.SelectedItem = producto.proveedor;
            this.titulo.Text = titulo;
            this.txtReferencia.Text = producto.referencia;
            this.txtReferencia.IsReadOnly = true;
            this.txtDescripcion.Text = producto.descripcion;
            this.txtFechaEntrada.Text = producto.fechaEntrada.ToString();
            this.txtPrecio.Text = producto.precio.ToString();
            this.txtStock.Text = producto.stock.ToString();
            myImage.Source = ImageHandler.LoadImage(producto.referencia);
            modify = true;
            publish = producto.publish;
        }

        public NewProduct(String titulo, ProductoHandler productoHandler)
        {
            this.productoHandler = productoHandler;
            InitializeComponent();
            this.titulo.Text = titulo;
            InitColorCombo();
            InitMarcaCombo();
            InitProveedorCombo();
            myImage.Source = ImageHandler.LoadDefaultImage();
            modify = false;
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtReferencia.Text = "";
            this.txtDescripcion.Text = "";
            this.txtFechaEntrada.Text = "";
            this.txtPrecio.Text = "";
            this.txtStock.Text = "";
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = new Producto();
            if (cmbProveedor.IsVisible)
            {
                producto.proveedor = cmbProveedor.SelectedItem.ToString();
            }
            else
            {
                producto.proveedor = txtProveedor.Text;
            }
            if (cmbMarca.IsVisible)
            {
                producto.marca = cmbMarca.SelectedItem.ToString();
            }
            else
            {
                producto.marca = txtMarca.Text;
            }
            producto.referencia = txtReferencia.Text;
            producto.descripcion = txtDescripcion.Text;
            producto.precio = float.Parse(txtPrecio.Text, CultureInfo.InvariantCulture.NumberFormat);
            producto.fechaEntrada = DateTime.Parse(txtFechaEntrada.Text);
            producto.stock = int.Parse(txtStock.Text);
            producto.color = cmbColor.SelectedItem.ToString();
            producto.publish = publish;
            if (txtReferencia.Text.Length > 0)
            {
                if(modify)
                {
                    //productoHandler.ModificarProducto(producto, pos);
                    XMLHandler.ModificarProducto(producto);
                    productoHandler.AgregarProducto(producto);
                    if (nuevaImagen)
                    {
                        ImageHandler.ModifyImage(producto.referencia, (BitmapImage)myImage.Source);
                    }
                    if (publish)
                    {
                        bool modificadoOK = MySQLDBHandler.ModifyDataDB(producto);
                        if (modificadoOK)
                        {
                            MainWindow.navigationFrame.NavigationService.Navigate(new ShowProducts(productoHandler));
                        }
                    }
                }
                else
                {
                    //productoHandler.AgregarProducto(producto);
                    XMLHandler.AddProduct(producto);
                    if (nuevaImagen)
                    {
                        ImageHandler.AddImage(producto.referencia, (BitmapImage)myImage.Source);
                    }
                }
            }
        }

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmapImage = ImageHandler.GetBitmapFromFile();
            if(bitmapImage != null)
            {
                myImage.Source = bitmapImage;
                nuevaImagen = true;
            }
        }

        private void addProveedor_Checked(object sender, RoutedEventArgs e)
        {
            if (cmbProveedor.IsVisible)
            {
                cmbProveedor.Visibility = Visibility.Hidden;
                txtProveedor.Visibility = Visibility.Visible;
            }
            else
            {
                cmbProveedor.Visibility = Visibility.Visible;
                txtProveedor.Visibility = Visibility.Hidden;
            }
        }

        private void addMarca_Checked(object sender, RoutedEventArgs e)
        {
            if (cmbMarca.IsVisible)
            {
                cmbMarca.Visibility = Visibility.Hidden;
                txtMarca.Visibility = Visibility.Visible;
            }
            else
            {
                cmbMarca.Visibility = Visibility.Visible;
                txtMarca.Visibility = Visibility.Hidden;
            }
        }

        private void addColor_Checked(object sender, RoutedEventArgs e)
        {
            if (cmbColor.IsVisible)
            {
                cmbColor.Visibility = Visibility.Hidden;
                txtColor.Visibility = Visibility.Visible;
            }
            else
            {
                cmbColor.Visibility = Visibility.Visible;
                txtColor.Visibility = Visibility.Hidden;
            }
        }
    }
}
