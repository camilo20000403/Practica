using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductoService
    {
        private readonly ConnectionManager conexion;
        private readonly ProductoRepository repositorio;
        public string mensaje;
        public ProductoService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new ProductoRepository(conexion);
        }

        public ProductoResponse ConsultarPorCodigo(string Codigo)
        {
            try
            {
                conexion.Open();
                Producto producto = repositorio.ConsultarPorCodigo(Codigo);
                if(producto == null)
                {
                    return new ProductoResponse("Productoo inexistente");
                }
                return new ProductoResponse(producto);
            }catch (Exception e)
            {
                return new ProductoResponse(e + "");
            }finally { conexion.Close(); }
        }

        public ProductoResponse Guardar(Producto producto)
        {
            try
            {
                conexion.Open();
                repositorio.Guardar(producto);
                return new ProductoResponse(producto);
            }
            catch (Exception e)
            {
                e = null;
                return new ProductoResponse("Producto Existente");
            }
            finally { conexion.Close(); }
        }
    }
    public class ProductoResponse
    {
        public ProductoResponse(Producto producto)
        {
            Error = false;
            Producto = producto;
        }
        public ProductoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Producto Producto { get; set; }
    }
}
