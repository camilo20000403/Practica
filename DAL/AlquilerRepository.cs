using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AlquilerRepository
    {
        private readonly SqlConnection _connection;
        public AlquilerRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void GuardarAlquiler(AlquilerFactura alquiler)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Alquiler (IdFactura, Cliente, FechaAlquiler, FechaDevolucion, SubTotal, Cantidad, Deposito, Total)
                                        values (@IdFactura,@Cliente,@FechaAlquiler, @FechaDevolucion,@SubTotal,@Cantidad,@Deposito,@Total)";
                command.Parameters.Add("@IdFactura", System.Data.SqlDbType.NVarChar).Value = alquiler.IdFactura;
                command.Parameters.Add("@Cliente", System.Data.SqlDbType.NVarChar).Value = alquiler.Cliente;
                command.Parameters.Add("@FechaAlquiler", System.Data.SqlDbType.Date).Value = alquiler.FechaAlquiler;
                command.Parameters.Add("@FechaDevolucion", System.Data.SqlDbType.Date).Value = alquiler.FechaDevolucion;
                command.Parameters.Add("@SubTotal", System.Data.SqlDbType.Real).Value = alquiler.Subtotal;
                command.Parameters.Add("@Cantidad", System.Data.SqlDbType.Real).Value = alquiler.CantidadAlquiler;
                command.Parameters.Add("@Deposito", System.Data.SqlDbType.Real).Value = alquiler.Deposito;
                command.Parameters.Add("@Total", System.Data.SqlDbType.Real).Value = alquiler.TotalAlquiler;
                command.ExecuteNonQuery();
            }
        }
        public void GuardarDetalleAlquiler(DetalleAlquiler detalle, string codigoAlquiler)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into DetalleAlquiler (CodAlquiler, CodProducto, Cantidad, Dias, SubTotal, Total)
                                        values (@CodAlquiler,@CodProducto,@Cantidad, @Dias,@SubTotal,@Total)";
                command.Parameters.Add("@CodAlquiler", System.Data.SqlDbType.NVarChar).Value = codigoAlquiler;
                command.Parameters.Add("@CodProducto", System.Data.SqlDbType.NVarChar).Value = detalle.Producto.Codigo;
                command.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int).Value = detalle.Cantidad;
                command.Parameters.Add("@Dias", System.Data.SqlDbType.Int).Value = detalle.Dias;
                command.Parameters.Add("@SubTotal", System.Data.SqlDbType.Real).Value = detalle.Subtotal;
                command.Parameters.Add("@Total", System.Data.SqlDbType.Real).Value = detalle.Total;
                command.ExecuteNonQuery();
            }
        }

        public int CodigoFactura()
        {
            SqlDataReader dataReader;
            int codigo = 0;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select count(*) from Alquiler";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                         codigo = dataReader.GetInt32(0);
                    }
                }
            }
            return codigo;
        }
    }
}
