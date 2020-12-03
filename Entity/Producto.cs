using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaReg { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public decimal PrecioCompraUnitario { get; set; }
    }
}