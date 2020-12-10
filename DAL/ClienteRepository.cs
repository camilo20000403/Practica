using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteRepository
    {
        private readonly SqlConnection _connection;
        public ClienteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Cliente (Cedula,PNombre,SNombre, PApellido, SApellido,Celular, Direccion, Sexo, Email) 
                                        values (@Cedula,@Pnombre,@Snombre, @Papellido,@Sapellido ,@Celular,@Direccion,@Sexo, @Email)";
                command.Parameters.Add("@Cedula", System.Data.SqlDbType.NVarChar).Value = cliente.Cedula;
                command.Parameters.Add("@Pnombre", System.Data.SqlDbType.NVarChar).Value = cliente.PrimerNombre;
                command.Parameters.Add("@Snombre", System.Data.SqlDbType.NVarChar).Value = cliente.SegundoNombre;
                command.Parameters.Add("@Papellido", System.Data.SqlDbType.NVarChar).Value = cliente.PrimerApellido;
                command.Parameters.Add("@Sapellido", System.Data.SqlDbType.NVarChar).Value = cliente.SegundoApellido;
                command.Parameters.Add("@Celular", System.Data.SqlDbType.NVarChar).Value = cliente.Celular;
                command.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar).Value = cliente.Direccion;
                command.Parameters.Add("@Sexo", System.Data.SqlDbType.NVarChar).Value = cliente.Sexo;
                command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = cliente.Email;
                command.ExecuteNonQuery();
            }
        }

        public List<Cliente> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Cliente> clientes = new List<Cliente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Cliente";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Cliente cliente = DataReaderMapToCliente(dataReader);
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }

        public List<Cliente> ConsultarPorIdentificacion(string Cedula)
        {
            SqlDataReader dataReader;
            List<Cliente> clientes = new List<Cliente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Cliente where Cedula = @Cedula";
                command.Parameters.Add("@Cedula", System.Data.SqlDbType.NVarChar).Value = Cedula;
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Cliente cliente = DataReaderMapToCliente(dataReader);
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }

        public void Actualizar(string Campo, string Dato, string Cedula)
        {
            using (var command = _connection.CreateCommand())
            {
                switch (Campo)
                {
                    case "Primer nombre":
                        command.CommandText = "update Cliente Set PNombre = @Dato where Cedula = @Cedula";
                        break;
                    case "Segundo nombre":
                        command.CommandText = "update Cliente Set SNombre = @Dato where Cedula = @Cedula";
                        break;
                    case "Primer apellido":
                        command.CommandText = "update Cliente Set PApellido = @Dato where Cedula = @Cedula";
                        break;
                    case "Segundo apellido":
                        command.CommandText = "update Cliente Set SApellido = @Dato where Cedula = @Cedula";
                        break;
                    case "Celular":
                        command.CommandText = "update Cliente Set Celular = @Dato where Cedula = @Cedula";
                        break;
                    case "Direccion":
                        command.CommandText = "update Cliente Set Direccion = @Dato where Cedula = @Cedula";
                        break;
                }
                command.Parameters.Add("@Cedula", System.Data.SqlDbType.NVarChar).Value = Cedula;
                command.Parameters.Add("@Dato", System.Data.SqlDbType.NVarChar).Value = Dato;
                command.ExecuteNonQuery();
            }
        }

        private Cliente DataReaderMapToCliente(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Cliente cliente = new Cliente();
            cliente.Cedula = (string)dataReader["Cedula"];
            cliente.Celular = (string)dataReader["Celular"];
            cliente.PrimerNombre = (string)dataReader["PNombre"];
            cliente.SegundoNombre = (string)dataReader["SNombre"];
            cliente.PrimerApellido = (string)dataReader["PApellido"];
            cliente.SegundoApellido = (string)dataReader["SApellido"];
            cliente.Sexo = (string)dataReader["Sexo"];
            cliente.Email = (string)dataReader["Email"];
            cliente.Direccion = (string)dataReader["Direccion"];
            return cliente;
        }

    }
}
