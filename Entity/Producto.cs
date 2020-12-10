using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaReg { get; set; }
        public double PrecioAlquiler { get; set; }
        public double PrecioCompra { get; set; }
    }
}