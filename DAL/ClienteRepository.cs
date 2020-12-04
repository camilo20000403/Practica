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
        List<Cliente> clientes = new List<Cliente>();
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

        //public List<Persona> ConsultarTodos()
        //{
        //    SqlDataReader dataReader;
        //    List<Persona> personas = new List<Persona>();
        //    using (var command = _connection.CreateCommand())
        //    {
        //        command.CommandText = "Select * from Persona ";
        //        dataReader = command.ExecuteReader();
        //        if (dataReader.HasRows)
        //        {
        //            while (dataReader.Read())
        //            {
        //                Persona persona = DataReaderMapToPerson(dataReader);
        //                personas.Add(persona);
        //            }
        //        }
        //    }
        //    return personas;
        //}

        /*public Persona BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }*/

        //private Persona DataReaderMapToPerson(SqlDataReader dataReader)
        //{
        //    if (!dataReader.HasRows) return null;
        //    Persona persona = new Persona();
        //    persona.Identificacion = (string)dataReader["Identificacion"];
        //    persona.Nombres = (string)dataReader["nombres"];
        //    persona.Apellidos = (string)dataReader["apellidos"];
        //    persona.Sexo = (string)dataReader["Sexo"];
        //    persona.Edad = (int)dataReader["Edad"];
        //    persona.Departamento = (string)dataReader["departamento"];
        //    persona.Ciudad = (string)dataReader["ciudad"];
        //    return persona;
        //}
    }
}
