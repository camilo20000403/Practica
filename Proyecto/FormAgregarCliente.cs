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
    public partial class FormAgregarCliente : Form
    {
        ClienteService clienteService;
        public FormAgregarCliente()
        {
            InitializeComponent();
            CmbSexo.SelectedIndex = 0;
            clienteService = new ClienteService(ConfigConnection.connectionString);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormAgregarCliente_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void ValidarCampos()
        {
            if(TxtCedula.Text.Trim() == "")
            {
                MensajeError("Debe ingresar la cedula");
            }
            else if (TxtPNombre.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el primer nombre");
            }else if (TxtSNombre.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el segundo nombre");
            }
            else if (TxtPApellido.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el primer apellido");
            }
            else if (TxtSApellido.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el segundo apellido");
            }
            else if (TxtCorreo.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el correo");
            }
            else if (TxtCelular.Text.Trim() == "")
            {
                MensajeError("Debe ingresar el celular");
            }
            else if (TxtDireccion.Text.Trim() == "")
            {
                MensajeError("Debe ingresar la direccion");
            }
            else if (CmbSexo.SelectedIndex == 0)
            {
                MensajeError("Debe seleccionar un sexo");
            }
            else
            {
                Cliente cliente = new Cliente()
                {
                    Cedula = TxtCedula.Text.Trim(),
                    Direccion = TxtDireccion.Text.Trim(),
                    Celular = TxtCelular.Text.Trim(),
                    Email = TxtCorreo.Text.Trim(),
                    PrimerApellido = TxtPApellido.Text.Trim(),
                    PrimerNombre = TxtPNombre.Text.Trim(),
                    SegundoApellido = TxtSApellido.Text.Trim(),
                    SegundoNombre = TxtSNombre.Text.Trim(),
                    Sexo = CmbSexo.Text
                };
                var respuesta = clienteService.Guardar(cliente);
                if (respuesta.Error)
                {
                    MensajeError(respuesta.Mensaje);
                    
                }
                else
                {
                    MensajeError("Cliente Registrado,"+clienteService.mensaje);
                }
            }
        }

        private void MensajeError(String texto)
        {
            MessageBox.Show(texto);
        }
    }
}
