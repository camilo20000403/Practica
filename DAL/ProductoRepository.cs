using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoRepository
    {
        private readonly SqlConnection _connection;
        public ProductoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Producto producto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Producto (Codigo,Nombre,Cantidad,Categoria,FechaRegistro,PrecioCompra,PrecioAlquiler) 
                                        values (@Codigo,@Nombre,@Cantidad, @Categoria,@Fecha ,@PrecioCompra,@PrecioAlquiler)";
                command.Parameters.Add("@Codigo", System.Data.SqlDbType.NVarChar).Value = producto.Codigo;
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar).Value = producto.Nombre;
                command.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int).Value = producto.Cantidad;
                command.Parameters.Add("@Categoria", System.Data.SqlDbType.NVarChar).Value = producto.Categoria;
                command.Parameters.Add("@Fecha", System.Data.SqlDbType.Date).Value = producto.FechaReg;
                command.Parameters.Add("@PrecioCompra", System.Data.SqlDbType.Real).Value = producto.PrecioCompra;
                command.Parameters.Add("@PrecioAlquiler", System.Data.SqlDbType.Real).Value = producto.PrecioAlquiler;
                command.ExecuteNonQuery();
            }
        }

        public Producto ConsultarPorCodigo(string Codigo)
        {
            SqlDataReader dataReader;
            Producto producto = null;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Producto where Codigo = @Codigo";
                command.Parameters.Add("@Codigo", System.Data.SqlDbType.NVarChar).Value = Codigo;
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        producto = DataReaderMapToProducto(dataReader);
                    }
                }
            }
            return producto;
        }
        private Producto DataReaderMapToProducto(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Producto producto = new Producto();
            producto.Cantidad = (int)dataReader["Cantidad"];
            producto.Codigo = (string)dataReader["Codigo"];
            producto.Categoria = (string)dataReader["Categoria"];
            producto.FechaReg = (DateTime)dataReader["FechaRegistro"];
            producto.Nombre = (string)dataReader["Nombre"];
            producto.PrecioCompra = (float)dataReader["PrecioCompra"];
            producto.PrecioAlquiler = (float)dataReader["PrecioCompra"];
            return producto;
        }
    }
}
