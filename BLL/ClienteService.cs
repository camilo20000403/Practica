using DAL;
using Entity;
using Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteService
    {
        private readonly ConnectionManager conexion;
        private readonly ClienteRepository repositorio;
        public string mensaje;
        public ClienteService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ClienteRepository(conexion);
        }

        public ClienteResponse Guardar(Cliente cliente)
        {
            Email email = new Email();
            try
            {
                conexion.Open();
                repositorio.Guardar(cliente);
                // mensaje = email.EnviarEmail(cliente);
                return new ClienteResponse(cliente);
            }
            catch (Exception e)
            {
                e = null;
                return new ClienteResponse("Cliente Existente");
            }
            finally { conexion.Close(); }
        }

        public List<Cliente> Todos()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                conexion.Open();
                clientes = repositorio.ConsultarTodos();
            }catch (Exception e)
            {
                e = null;
            }
            finally { conexion.Close(); }
            return clientes;
        }

        public List<Cliente> ConsultarPorIdentificacion(string Cedula)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                conexion.Open();
                clientes = repositorio.ConsultarPorIdentificacion(Cedula);
            }
            catch (Exception e)
            {
                e = null;
            }
            finally { conexion.Close(); }
            return clientes;
        }

        public void Actualizar(string Campo, string Dato, string Cedula)
        {
            try
            {
                conexion.Open();
                repositorio.Actualizar(Campo,Dato,Cedula);
            }
            catch (Exception e)
            {
                e = null;
            }
            finally { conexion.Close(); }
        }
    }
    public class ClienteResponse
    {
        public ClienteResponse(Cliente cliente)
        {
            Error = false;
            Cliente = cliente;
        }
        public ClienteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Cliente Cliente { get; set; }
    }
}
