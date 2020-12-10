using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Proyecto
{
    public partial class FormPrincipal : Form
    {

 
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHija<Alquiler>();
        }

       
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
             ReleaseCapture();

            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AbrirFormHija<T>() where T:Form, new()
        {
            Form formulario = panelContenedor.Controls.OfType<T>().FirstOrDefault();
            if (formulario != null)
            {
                if (formulario.WindowState ==  FormWindowState.Minimized)
                {
                    formulario.WindowState = FormWindowState.Normal;
                }
                formulario.BringToFront();
                return;
            }
            formulario = new T();
            formulario.TopLevel = false;
            panelContenedor.Controls.Add(formulario);
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            panelContenedor.Tag = formulario;
            formulario.Show();
        }

   
        private void button3_Click(object sender, EventArgs e)
        {
            //AbrirFormHija(new ());
            
            
            Submenu.Visible = true; 
            
        }

       

        private void btnproductos_Click(object sender, EventArgs e)
        {
            AbrirFormHija<Productos>();
        }

        private void btninventario_Click(object sender, EventArgs e)
        {
            AbrirFormHija<Inventario>();
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnagregarcliente_Click(object sender, EventArgs e)
        {
            Submenu.Visible = false;
            AbrirFormHija<FormAgregarCliente>();
        }

        private void btnmostrarcliente_Click(object sender, EventArgs e)
        {
            Submenu.Visible = false;
            AbrirFormHija<FormMostrarCliente>();
        }

        private void Submenu_Paint(object sender, PaintEventArgs e)
        {
          //P  Submenu.Visible = true;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            //Submenu.Visible = false;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
           // Submenu.Visible = false;
        }
    }
}
