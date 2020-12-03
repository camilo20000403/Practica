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
        public decimal Total { get; set; }
        public decimal Subtotal { get; set; }
        public int CantidadDias { get; set; }

        public DetalleAlquiler(int cantidad , Producto producto)
        {
            Cantidad = cantidad;
            Producto = producto;
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            CalcularSubtotal();
            Total = Subtotal * CantidadDias;
        }

        public void CalcularSubtotal()
        {
            Subtotal = Producto.PrecioAlquiler * Cantidad;
        }

    }
}
