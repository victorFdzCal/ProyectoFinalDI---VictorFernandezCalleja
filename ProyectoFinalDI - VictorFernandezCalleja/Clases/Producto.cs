using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProyectoFinalDI___VictorFernandezCalleja.Clases
{
    public class Producto
    {
        public String proveedor { get; set; }
        public String marca { get; set; }
        public String referencia { get; set; }
        public String descripcion { get; set; }
        public String color { get; set; }
        public float precio { get; set; }
        public DateTime fechaEntrada { get; set; }
        public int stock { get; set; }
        public BitmapImage imagen { get; set; }
        public bool publish { get; set; }

        public Producto()
        {

        }

        public override string ToString()
        {
            return descripcion;
        }
        public String GetAllValues()
        {
            return descripcion;
        }
    }
}
