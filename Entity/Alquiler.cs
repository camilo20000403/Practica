using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Alquiler
    {
        public string Cliente { get; set; }
        public Producto Producto { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public decimal TotalAlquiler { get; set; }
        public decimal Subtotal { get; set; }
        public int CantidadAlquiler { get; set; }
        public string IdFactura { get; set; }
        public decimal Deposito { get; set; }

        public List<DetalleAlquiler> detalleAlquileres = new List<DetalleAlquiler>();

        public void Agregar(int cantidad , Producto producto)
        {
            DetalleAlquiler detalle = new DetalleAlquiler(cantidad, producto);
            detalleAlquileres.Add(detalle);
        }

        public void CalcularSubtotal()
        {
            Subtotal = detalleAlquileres.Sum(s => s.Total);
        }

     

        public void CalcularDeposito()
        {
            CalcularSubtotal();
            Deposito = Subtotal * 0.3m;
        }

        public void CalcularTotal()
        {
            CalcularDeposito();
            CalcularSubtotal();
            TotalAlquiler = Deposito + Subtotal;
        }
    }
}
