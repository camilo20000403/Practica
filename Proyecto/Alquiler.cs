using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Alquiler : Form
    {
        ClienteService clienteService;
        Cliente clienteSeleccionado;
        Producto productoSeleccionado;
        ProductoService ProductoService;
        AlquilerFactura alquiler;
        AlquilerService alquilerService;
        public Alquiler()
        {
            InitializeComponent();
            alquilerService = new AlquilerService(ConfigConnection.connectionString);
            clienteService = new ClienteService(ConfigConnection.connectionString);
            ProductoService = new ProductoService(ConfigConnection.connectionString);
            DtgDetalles.Columns.Add("Codigo Producto", "Codigo Producto");
            DtgDetalles.Columns.Add("Cantidad", "Cantidad");
            DtgDetalles.Columns.Add("Valor unitario", "Valor unitario");
            DtgDetalles.Columns.Add("Dias", "Dias");
            DtgDetalles.Columns.Add("Subtotal", "Subtotal");
            DtgDetalles.Columns.Add("Total", "Total");
            TxtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TxtCondigoFactura.Text = alquilerService.ObteberCodigo();
        }

        private void Alquiler_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TxtCedula.Text.Trim() == "")
            {
                MensajeError("Debe ingresar la cedula del cliente.");
            }
            else
            {
                List<Cliente> clientes = clienteService.ConsultarPorIdentificacion(TxtCedula.Text.Trim());
                if(clientes.Count == 0)
                {
                    MensajeError("Cliente inexistente.");
                }
                else
                {

                    clienteSeleccionado = clientes[0];
                    TxtPNombre.Text = clientes[0].PrimerNombre;
                    TxtSNombre.Text = clientes[0].SegundoNombre;
                    TxtPApellido.Text = clientes[0].PrimerApellido;
                    TxtSApellido.Text = clientes[0].SegundoApellido;
                }
            }
        }
        
        private void MensajeError(String texto)
        {
            MessageBox.Show(texto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(TxtCodigo.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el codigo a buscar");
            }
            else
            {
                var respuesta = ProductoService.ConsultarPorCodigo(TxtCodigo.Text.Trim());
                if (respuesta.Error)
                {
                    MensajeError(respuesta.Mensaje);
                }
                else
                {
                    SeleccionarProducto(respuesta.Producto);
                }
            }
        }

        private void SeleccionarProducto(Producto producto)
        {
            productoSeleccionado = producto;
            TxtNombreProducto.Text = productoSeleccionado.Nombre;
            TxtCantidad.Text = productoSeleccionado.Cantidad.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(TxtCantidadAlquler.Text.Trim() == "")
            {
                MensajeError("Debe ingresar la cantidad a agregar");
            }else if(productoSeleccionado == null)
            {
                MensajeError("Debe buscar un producto.");
            }
            else if(clienteSeleccionado == null)
            {
                MensajeError("Debe buscar un cliente");
            }
            else if (TxtCantidadDias.Text.Trim() == "")
            {
                MensajeError("Debe ingresar la cantidad de dias");
            }
            else
            {
                if (alquiler == null)
                {
                    alquiler = new AlquilerFactura();
                }
                alquiler.FechaAlquiler = DateTime.Parse(TxtFecha.Text);
                alquiler.IdFactura = TxtCondigoFactura.Text;
                alquiler.Cliente = clienteSeleccionado.Cedula;
                alquiler.Agregar(int.Parse(TxtCantidadAlquler.Text.Trim()), productoSeleccionado, int.Parse(TxtCantidadDias.Text.Trim()));
                ResetearProductoSeleccionado();
                AgregarEnLaTabla(alquiler.detalleAlquileres);
            }
        }

        private void AgregarEnLaTabla(List<DetalleAlquiler> detalles)
        {

            DtgDetalles.Rows.Clear();
            foreach (DetalleAlquiler detalle in detalles)
            {
                string[] row1 = new string[] { detalle.Producto.Codigo, detalle.Cantidad.ToString(),detalle.Producto.PrecioAlquiler.ToString(),detalle.Dias.ToString(),detalle.Subtotal.ToString(),detalle.Total.ToString()};
                DtgDetalles.Rows.Add(row1);
            }
            MostrarTotales();
        }


        private void MostrarTotales()
        {
            TxtDeposito.Text = alquiler.Deposito.ToString();
            TxtTotal.Text = alquiler.TotalAlquiler.ToString();

        }

        private void ResetearProductoSeleccionado()
        {
            productoSeleccionado = null;
            TxtCantidad.Text = TxtNombreProducto.Text = TxtCantidad.Text = TxtCantidadAlquler.Text = TxtCodigo.Text = "";
        }
        private void ResetearClienteSeleccionado()
        {
            clienteSeleccionado = null;
            TxtPNombre.Text = TxtSNombre.Text = TxtPApellido.Text = TxtSApellido.Text = TxtCedula.Text ="";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(alquiler == null)
            {
                MensajeError("Debe ingresar los datos del alquiler");
            }
            else
            {
                alquilerService.Guardar(alquiler);
                MensajeError("Alquiler registrado en la base de datos.");
                TxtCondigoFactura.Text = alquilerService.ObteberCodigo();
                ResetearProductoSeleccionado();
                ResetearClienteSeleccionado();
                txtCantidadProductos.Text = "";
                DtgDetalles.Rows.Clear();
            }
        }
    }
}
