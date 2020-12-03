using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura
    {
        public int IdCuota { get; set; }
        public int IdFactura { get; set; }
        public double Valor { get; set; }
        public string Fecha { get; set; }
    }
}
