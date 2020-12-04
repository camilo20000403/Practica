using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRepository
    {
        private readonly SqlConnection _connection;
        List<Usuario> usuarios = new List<Usuario>();
        public UsuarioRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Usuario usuario)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Usuario 
                                        values (@Usuario,@Contraseña)";
                command.Parameters.Add("@Usuario", System.Data.SqlDbType.VarChar).Value = usuario.IdUsuario;
                command.Parameters.Add("@Contraseña", System.Data.SqlDbType.Int).Value = usuario.Contraseña;
                command.ExecuteNonQuery();
            }
        }

        public List<Usuario> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Usuario> usuarios = new List<Usuario>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Usuario";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Usuario usuario = DataReaderMapToUsuario(dataReader);
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }
        private Usuario DataReaderMapToUsuario(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Usuario usuario = new Usuario();
            usuario.IdUsuario = (string)dataReader["Usuario"];
            usuario.Contraseña = (string)dataReader["Contraseña"];
            return usuario;
        }
    }
}
