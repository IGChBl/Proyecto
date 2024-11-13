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
        private List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Nombre = "Iván", Apellido = "Chavarría", Matricula = "15021113", Carrera = "Ingeniería en Sistemas", Telefono = "", Email = "ichavarria@uamv.edu.ni", Direccion = "", FechaNacimiento = "31/07/1997", Sexo = "M", Contraseña = "ABC123!" },
            new Usuario { Nombre = "user1", Apellido = "Perez", Matricula = "0002", Carrera = "Ingeniería", Telefono = "87654321", Email = "user1@example.com", Direccion = "Direccion 2", FechaNacimiento = "02/02/1992", Sexo = "F", Contraseña = "abcd" }
        };

        public frmInicioSesion()
        {
            InitializeComponent();
        }

        // Método para validar usuario y contraseña
        private bool ValidarUsuario(string nombre, string contraseña)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.Nombre == nombre && usuario.Contraseña == contraseña)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string usuario = tbUser.Text;
            string contrasena = tbPassword.Text;

            if (ValidarUsuario(usuario, contrasena))
            {
                MessageBox.Show("Bienvenido");
                frmMenuPrincipal frmmenuPrincipal = new frmMenuPrincipal();
                frmmenuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}