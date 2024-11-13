using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Models;

namespace Proyecto
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string usuario = tbUser.Text;
            string contrasena = tbPassword.Text;

            

            if (usuario == "admin" && contrasena == "admin")
            {
                MessageBox.Show("Bienvenido");
                frmMenuPrincipal frmmenuPrincipal = new frmMenuPrincipal();
                frmmenuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}