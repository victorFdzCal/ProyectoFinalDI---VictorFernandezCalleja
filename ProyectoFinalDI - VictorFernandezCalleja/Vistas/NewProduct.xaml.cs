using ProyectoFinalDI___VictorFernandezCalleja.Clases;
using System;
using System.Collections.Generic;
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
        public NewProduct()
        {
            InitializeComponent();
        }

        public NewProduct(String titulo)
        {
            InitializeComponent();
            this.titulo.Text = titulo;
            InitColorCombo();
            InitMarcaCombo();
            InitProveedorCombo();
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

        public NewProduct(String titulo, Producto producto)
        {
            InitializeComponent();
            InitColorCombo();
            InitMarcaCombo();
            InitProveedorCombo();
            this.titulo.Text = titulo;
            this.txtReferencia.Text = producto.referencia;
            this.txtDescripcion.Text = producto.descripcion;
            this.txtFechaEntrada.Text = producto.fechaEntrada.ToString();
            this.txtPrecio.Text = producto.precio.ToString();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtReferencia.Text = "";
            this.txtDescripcion.Text = "";
            this.txtFechaEntrada.Text = "";
            this.txtPrecio.Text = "";
            this.txtStock.Text = "";
        }
    }
}
