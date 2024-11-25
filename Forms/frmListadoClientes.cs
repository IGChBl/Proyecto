using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto.frmAgregarCliente;

namespace Proyecto
{
    public partial class frmListadoClientes : Form
    {
        public frmListadoClientes()
        {
            InitializeComponent();
        }
        private void CargarArchivo()
        {
            ClienteData.Clientes.Clear();
            string rutaArchivo = "clientes.dat";
            if (!File.Exists(rutaArchivo))
            {
                return;
            }

            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivo))
                {
                    while (archivo.Position != archivo.Length)
                    {
                        
                        string nombre = lector.ReadString();
                        string apellido = lector.ReadString();
                        string telefono = lector.ReadString();
                        string email = lector.ReadString();
                        string direccion = lector.ReadString();


                        Cliente cliente = new Cliente();
                        cliente.Nombre = nombre;
                        cliente.Apellido = apellido;
                        cliente.Telefono = telefono;
                        cliente.Email = email;
                        cliente.Direccion = direccion;

                        ClienteData.Clientes.Add(cliente);
                    }
                }
            }
        }
        private void frmListadoClientes_Load(object sender, EventArgs e)
        {

            // Configurar columnas del DataGridView
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            // Añadir columnas personalizadas
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono"
            });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Correo Electrónico"
            });

            CargarArchivo();
            // Configurar el DataGridView
            dgvClientes.DataSource = null; // Limpiar cualquier dato previo
            dgvClientes.DataSource = ClienteData.Clientes; // Mostrar la lista de clientes
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
