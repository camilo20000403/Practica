using BLL;
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
    public partial class FormMostrarCliente : Form
    {
        ClienteService clienteService;
        bool Buscar = false;
        public FormMostrarCliente()
        {
            InitializeComponent();
            clienteService = new ClienteService(ConfigConnection.connectionString);
            CmbModificar.SelectedIndex = 0;
            BuscarTodos();
        }

        private void BuscarTodos()
        {
            DtgTodos.DataSource = clienteService.Todos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if(TxtCedula.Text.Trim() == "")
            {
                MensajeError("Debe ingresar una Cedula para buscar el cliente");
            }
            else
            {
                Buscar = true;
                DtgTodos.DataSource = clienteService.ConsultarPorIdentificacion(TxtCedula.Text.Trim());
            }
        }
        private void MensajeError(String texto)
        {
            MessageBox.Show(texto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Buscar)
            {
                if(CmbModificar.SelectedIndex == 0)
                {
                    MensajeError("Debe seleccionar el campo que va a modificar.");
                }else if (TxtModificar.Text.Trim() == "")
                {
                    MensajeError("Debe ingresar el dato que va a modificar.");
                }
                else
                {
                    clienteService.Actualizar(CmbModificar.Text, TxtModificar.Text.Trim(), TxtCedula.Text.Trim());
                    DtgTodos.DataSource = clienteService.ConsultarPorIdentificacion(TxtCedula.Text.Trim());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarTodos();
        }
    }
}
