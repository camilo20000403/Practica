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
    public partial class Productos : Form
    {
        private ProductoService productoService;

        public Productos()
        {
            InitializeComponent();
            productoService = new ProductoService(ConfigConnection.connectionString);
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void ValidarCampos()
        {
            if(TxtCodigo.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el precio de codigo");
            }
            else if (TxtNombre.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el precio de nombres");
            }
            else if (TxtCantidad.Text.Trim() == "")
            {
                MensajeError("Debe ingresar la cantidad");
            }
            else if(CmbCategoria.SelectedIndex == 0)
            {
                MensajeError("Debe seleccionar la categoria");
            }
            else if (TxtPrecioC.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el precio de Compra");
            }
            else if (TxtPrecioA.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el precio de alquires");
            }
            else
            {
                Producto producto = new Producto()
                {
                    Cantidad = int.Parse(TxtCantidad.Text.Trim()),
                    Codigo = TxtCodigo.Text.Trim(),
                    Categoria = CmbCategoria.Text,
                    Nombre = TxtNombre.Text.Trim(),
                    FechaReg = DateTime.Now,
                    PrecioAlquiler = double.Parse(TxtPrecioA.Text.Trim()),
                    PrecioCompra = double.Parse(TxtPrecioC.Text.Trim())
                };

                var respuesta  = productoService.Guardar(producto);
                if (respuesta.Error)
                {
                    MensajeError("Producto Existente");
                }
                else
                {
                    MensajeError("Producto Registrado");
                }
            }
        }

        private void MensajeError(String texto)
        {
            MessageBox.Show(texto);
        }
    }
}
