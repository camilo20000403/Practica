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
using System.Runtime.CompilerServices;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Contador = 0;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
            private extern static void ReleaseCapture();

            [DllImport("user32.DLL", EntryPoint = "SendMessage")]
            private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

     


        private void txtuser_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text == "USUARIO") {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;

            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if(txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if(txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();

            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();

            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
          
            
                if (Contador < 3)
                {
                    if (txtuser.Text == "USUARIO" || txtpass.Text == "CONTRASEÑA")
                    {
                        MessageBox.Show("Hay campos vacíos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (txtuser.Text.Equals("Perez") && txtpass.Text.Equals("123"))
                        {
                        this.Hide();
                        FormBienvenida bienvenida = new FormBienvenida();
                        bienvenida.ShowDialog();
                            //MessageBox.Show("Bienvenida, señor Camilo", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            AbrirFormPrincipal();
                            //this.Hide();
                        }
                        else
                        {
                        MessageBox.Show("Usuario/Contraseña incorrecta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Contador++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Número máximo de intentos alcanzados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
        }
        private void AbrirFormPrincipal()
            {
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();
            }

        private void btnmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
    }

