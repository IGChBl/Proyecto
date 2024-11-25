using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto.frmAgregarCliente;

namespace Proyecto
{
    public partial class frmModificarDatosClientes : Form
    {

        private Cliente clienteSeleccionado;
        public frmModificarDatosClientes()
        {
            InitializeComponent();
        }

        private void frmModificarDatosClientes_Load(object sender, EventArgs e)
        {
            btnModificarCliente.Enabled = false;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string criterio = txtCriterioBusqueda.Text.Trim(); // Obtener el texto del cuadro de búsqueda

            // Buscar cliente por nombre o correo
            clienteSeleccionado = ClienteData.Clientes
                .FirstOrDefault(c => c.Nombre.Contains(criterio) || c.Email.Contains(criterio));

            if (clienteSeleccionado != null)
            {
                // Cargar los datos del cliente en los campos
                txtNombre.Text = clienteSeleccionado.Nombre;
                txtApellido.Text = clienteSeleccionado.Apellido;
                txtDireccion.Text = clienteSeleccionado.Direccion;
                txtCorreo.Text = clienteSeleccionado.Email;
                txtTelefono.Text = clienteSeleccionado.Telefono;
                L
                // Habilitar el botón de modificar
                btnModificarCliente.Enabled = true;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnModificarCliente.Enabled = false; // Deshabilitar el botón de modificar
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado != null)
            {
                // Actualizar los datos del cliente
                clienteSeleccionado.Nombre = txtNombre.Text.Trim();
                clienteSeleccionado.Apellido = txtApellido.Text.Trim();
                clienteSeleccionado.Direccion = txtDireccion.Text.Trim();
                clienteSeleccionado.Email = txtCorreo.Text.Trim();
                clienteSeleccionado.Telefono = txtTelefono.Text.Trim();

                MessageBox.Show("Datos del cliente modificados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: Limpiar los campos después de modificar
                txtCriterioBusqueda.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtDireccion.Clear();
                txtCorreo.Clear();
                txtTelefono.Clear();

                // Deshabilitar el botón de modificar
                btnModificarCliente.Enabled = false;
            }
            else
            {
                MessageBox.Show("No hay cliente seleccionado para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        p
    }
}
