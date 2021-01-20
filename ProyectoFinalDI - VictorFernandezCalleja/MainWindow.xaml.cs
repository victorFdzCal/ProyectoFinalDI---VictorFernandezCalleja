using ProyectoFinalDI___VictorFernandezCalleja.Vistas;
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

namespace ProyectoFinalDI___VictorFernandezCalleja
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame navigationFrame;
        NewProduct newProduct
        public MainWindow()
        {
            navigationFrame = frame;
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            navigationFrame.NavigationService.Navigate(new NewProduct("NUEVO PRODUCTO"));
        }
    }
}
