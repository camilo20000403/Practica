using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetalleAlquiler
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public double Subtotal { get; set; }
        public int Dias { get; set; }

        public DetalleAlquiler(int cantidad , Producto producto, int dias)
        {
            Dias = dias;
            Cantidad = cantidad;
            Producto = producto;
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            CalcularSubtotal();
            Total = Subtotal * Dias;
        }

        public void CalcularSubtotal()
        {
            Subtotal = Producto.PrecioAlquiler * Cantidad;
        }

    }
}
