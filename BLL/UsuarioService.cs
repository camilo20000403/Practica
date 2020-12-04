using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioService
    {
        private readonly ConnectionManager conexion;
        private readonly UsuarioRepository repositorio;
        public UsuarioService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new UsuarioRepository(conexion);
        }

        public UsuarioResponse Registrar(Usuario usuario)
        {
            try
            {
                conexion.Open();
                repositorio.Guardar(usuario);
                return new UsuarioResponse(usuario);
            }catch (Exception e)
            {
                return new UsuarioResponse(e+"");
            }
            finally { conexion.Close(); }
        }

        public UsuarioResponse ValidarSesion(Usuario usuario)
        {
            try
            {
                conexion.Open();
                Usuario usuarioEncontrado = repositorio.ConsultarTodos().FirstOrDefault(p => p.IdUsuario == usuario.IdUsuario && p.Contraseña == usuario.Contraseña);
                if(usuarioEncontrado == null)
                {
                    return new UsuarioResponse("DatosErroneos");
                }
                return new UsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new UsuarioResponse(e + "");
            }
            finally { conexion.Close(); }
        }
    }

    public class UsuarioResponse
    {
        public UsuarioResponse(Usuario usuario)
        {
            Error = false;
            Usuario = usuario;
        }
        public UsuarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Usuario Usuario { get; set; }
    }
}
