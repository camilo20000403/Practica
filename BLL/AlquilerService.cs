using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AlquilerService
    {
        private readonly ConnectionManager conexion;
        private readonly AlquilerRepository repositorio;
        public string mensaje;
        public AlquilerService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repositorio = new AlquilerRepository(conexion);
        }

        public void Guardar(AlquilerFactura alquiler)
        {
            
            try
            {
                conexion.Open();
                repositorio.GuardarAlquiler(alquiler);
                conexion.Close();
                foreach(DetalleAlquiler detalle in alquiler.detalleAlquileres)
                {
                    conexion.Open();
                    repositorio.GuardarDetalleAlquiler(detalle, alquiler.IdFactura);
                    conexion.Close();
                }
            }
            catch (Exception e)
            {
                e = null;
            }
            finally { conexion.Close(); }
        }

        public string ObteberCodigo()
        {
            int codigo = 0;
            try
            {
                conexion.Open();
                codigo = repositorio.CodigoFactura();
            }catch ( Exception e)
            {
                e = null;
            }finally { conexion.Close(); }
            return codigo.ToString();
        }
    }
}
