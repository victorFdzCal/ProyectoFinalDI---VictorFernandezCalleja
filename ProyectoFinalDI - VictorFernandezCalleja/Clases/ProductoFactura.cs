using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDI___VictorFernandezCalleja.Clases
{
    public class ProductoFactura
    {
        public string refProducto { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }
        public string descripcion { get; set; }
        public string refFactura { get; set; }
        public float precioTotal { get; set; }

        public ProductoFactura()
        {
           
        }
    }
}
