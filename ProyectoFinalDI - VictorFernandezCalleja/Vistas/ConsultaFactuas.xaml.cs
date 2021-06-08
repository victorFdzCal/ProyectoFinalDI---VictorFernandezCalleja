using ProyectoFinalDI___VictorFernandezCalleja.Reporting;
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
    /// Lógica de interacción para ConsultaFactuas.xaml
    /// </summary>
    public partial class ConsultaFactuas : Page
    {
        public ConsultaFactuas()
        {
            InitializeComponent();
            CargarCombo();
        }

        public void CargarCombo()
        {
            List<string> opciones = new List<string>();
            opciones.Add("DNI/CIF");
            opciones.Add("Fechas");
            opciones.Add("Nº de Factura");
            cmbConsulta.ItemsSource = opciones;
            cmbConsulta.SelectedIndex = 0;
        }

        private void cmbConsulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbConsulta.SelectedItem == "DNI/CIF")
            {
                spDni.Visibility = Visibility.Visible;
                spFechas.Visibility = Visibility.Hidden;
                spFactura.Visibility = Visibility.Hidden;
            }else if (cmbConsulta.SelectedItem == "Fechas")
            {
                spDni.Visibility = Visibility.Hidden;
                spFechas.Visibility = Visibility.Visible;
                spFactura.Visibility = Visibility.Hidden;
            }else if(cmbConsulta.SelectedItem == "Nº de Factura")
            {
                spDni.Visibility = Visibility.Hidden;
                spFechas.Visibility = Visibility.Hidden;
                spFactura.Visibility = Visibility.Visible;
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            ReportPreview reportPreview = new ReportPreview();
            if (cmbConsulta.SelectedItem == "DNI/CIF")
            {
                if(edtDni.Text == "")
                {
                    MessageBox.Show("Debes introducir un CIF / DNI");
                }
                else
                {
                    string dni = edtDni.Text;
                    bool okConsulta = reportPreview.MostrarInformeUsuario(dni);
                    if (okConsulta)
                    {
                        reportPreview.Show();
                    }
                    else
                    {
                        MessageBox.Show("No existen registros para el cliente indicado");
                    }
                }
                
            }
            else if (cmbConsulta.SelectedItem == "Fechas")
            {
                DateTime fechaInicio = (DateTime)dateFechaInicio.SelectedDate;
                DateTime fechaFin = (DateTime)dateFechaFin.SelectedDate;
                if (fechaInicio == null || fechaFin == null)
                {
                    MessageBox.Show("Introduce una fecha");
                }
                else
                {
                    bool okConsulta = reportPreview.MostrarFacturaFechas(fechaInicio, fechaFin);
                    if (okConsulta)
                    {
                        reportPreview.Show();
                    }
                    else
                    {
                        MessageBox.Show("No existen registros entre las fechas indicadas");
                    }
                }
            }
            else if (cmbConsulta.SelectedItem == "Nº de Factura")
            {
                string numFactura = edtNumFactura.Text;
                if(numFactura == "")
                {
                    MessageBox.Show("Introduce un número de factura");
                }
                else
                {
                    bool okConsulta = reportPreview.MostrarFacturaNumFactura(numFactura);
                    if (okConsulta)
                    {
                        reportPreview.Show();
                    }
                    else
                    {
                        MessageBox.Show("No existen registros para la factura indicada");
                    }
                }
                
            }
        }
    }
}
