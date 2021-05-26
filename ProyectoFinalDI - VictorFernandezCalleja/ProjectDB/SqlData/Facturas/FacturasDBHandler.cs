using ProyectoFinalDI___VictorFernandezCalleja.Clases;
using ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.Facturas.FacturasDataSet.FacturasDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.Facturas.FacturasDataSet.FacturasDataSet;

namespace ProyectoFinalDI___VictorFernandezCalleja.ProjectDB.SqlData.Facturas
{
    public class FacturasDBHandler
    {
        private static ClienteTableAdapter clienteAdapter = new ClienteTableAdapter();
        private static FacturaTableAdapter facturaAdapter = new FacturaTableAdapter();
        private static ProductoFacturaTableAdapter productoAdapter = new ProductoFacturaTableAdapter();
        private static InformeFacturasTableAdapter adapter = new InformeFacturasTableAdapter();
        private static FacturasDataSet.FacturasDataSet adapter2 = new FacturasDataSet.FacturasDataSet();
        
        public static bool AddFactura(Factura f)
        {
            int filas = facturaAdapter.Insert(f.refFactura, f.cif, f.fecha);
            if(filas == 1)
            {
                facturaAdapter.Update(adapter2);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool AddCliente(Cliente c)
        {
            int filas = clienteAdapter.Insert(c.cif, c.nombre, c.direccion);
            if(filas == 1)
            {
                clienteAdapter.Update(adapter2);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static void AddProducto(ProductoFactura p)
        {
            productoAdapter.Insert(p.refProducto, p.cantidad, p.precio, p.descripcion, p.refFactura);
            productoAdapter.Update(adapter2);
        }

        public static InformeFacturasDataTable GetFacturaById(string cif)
        {
            return adapter.GetFacturaUsuario(cif);
        }

        public static InformeFacturasDataTable GetFacturas(string numFactura)
        {
            return adapter.GetDataFacturas(numFactura);
        }

        public static InformeFacturasDataTable GetFacturasFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return adapter.GetDataFechas(fechaInicio, fechaFin);
        }
    }
}
