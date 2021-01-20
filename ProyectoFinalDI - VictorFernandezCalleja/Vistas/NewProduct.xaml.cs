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

namespace ProyectoFinalDI___VictorFernandezCalleja.Vistas
{
    /// <summary>
    /// Lógica de interacción para NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Page
    {
        public NewProduct()
        {
            InitializeComponent();
        }

        public NewProduct(String titulo)
        {
            InitializeComponent();
            this.titulo.Text = titulo;
        }
    }
}
