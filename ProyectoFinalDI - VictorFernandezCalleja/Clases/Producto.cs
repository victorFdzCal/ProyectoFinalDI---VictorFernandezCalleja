using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDI___VictorFernandezCalleja.Clases
{
    public class Producto
    {
        public String referencia { get; set; }
        public String descripcion { get; set; }
        public String color { get; set; }
        public float precio { get; set; }
        public DateTime fechaEntrada { get; set; }
        public int stock { get; set; }

        public Producto()
        {

        }
    }
}
