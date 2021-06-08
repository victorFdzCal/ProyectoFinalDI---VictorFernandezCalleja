using Microsoft.Reporting.WinForms;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.Facturas;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ProyectoFinalDI___VictorFernandezCalleja.Reporting
{
    /// <summary>
    /// Lógica de interacción para ReportPreview.xaml
    /// </summary>
    public partial class ReportPreview : Window
    {
        private static string CurrentPath = Environment.CurrentDirectory;
        private static string reportRef = "Reporting/InformeNumFacturas.rdlc";
        private static string reportCif = "Reporting/InformeFacturas.rdlc";
        private static string reportFechas = "Reporting/InformeFechas.rdlc";
        public ReportPreview()
        {
            InitializeComponent();
        }

        public bool MostrarInformeUsuario(string cif)
        {
            bool okConsulta = false;
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DatosUsuario";
            DataTable listaFacturas = FacturasDBHandler.GetFacturaById(cif);
            if (listaFacturas.Rows.Count > 0)
            {
                rds.Value = listaFacturas;

                myReportView.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath,reportCif);
                myReportView.LocalReport.DataSources.Add(rds);
                myReportView.RefreshReport();

                okConsulta = true;
            }
            return okConsulta;
        }

        public bool MostrarFacturaNumFactura(string numFactura)
        {
            bool okConsulta = false;
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DatosFactura";
            DataTable listaFacturas = FacturasDBHandler.GetFacturas(numFactura);
            if (listaFacturas.Rows.Count > 0)
            {
                rds.Value = listaFacturas;

                myReportView.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, reportRef);
                myReportView.LocalReport.DataSources.Add(rds);
                myReportView.RefreshReport();
                okConsulta = true;
            }
            return okConsulta;
        }

        internal bool MostrarFacturaFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            bool okConsulta = false;
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DatosFechas";
            DataTable listaFacturas = FacturasDBHandler.GetFacturasFechas(fechaInicio, fechaFin);
            if (listaFacturas.Rows.Count > 0)
            {
                rds.Value = listaFacturas;

                myReportView.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, reportFechas);
                myReportView.LocalReport.DataSources.Add(rds);
                myReportView.RefreshReport();

                okConsulta = true;
            }
            return okConsulta;
        }

        
      
    }
}
