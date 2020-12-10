using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AlquilerFactura
    {
        public string Cliente { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public double TotalAlquiler { get; set; }
        public double Subtotal { get; set; }
        public int CantidadAlquiler { get; set; }
        public string IdFactura { get; set; }
        public double Deposito { get; set; }

        public List<DetalleAlquiler> detalleAlquileres = new List<DetalleAlquiler>();

        public void Agregar(int cantidad , Producto producto, int dias)
        {
            DetalleAlquiler detalle = new DetalleAlquiler(cantidad, producto, dias);
            detalleAlquileres.Add(detalle);
            FechaDevolucion = FechaAlquiler.AddDays(dias);
            CalcularTotal();
        }

        public void CalcularSubtotal()
        {
            Subtotal = detalleAlquileres.Sum(s => s.Total);
        }

     

        public void CalcularDeposito()
        {
            CalcularSubtotal();
            Deposito = Subtotal * 0.3;
        }

        public void CalcularTotal()
        {
            CalcularDeposito();
            TotalAlquiler = Deposito + Subtotal;
        }
    }
}
