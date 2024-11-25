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
    public partial class frmConsultarCliente: Form
    {
        public frmConsultarCliente()
        {
            InitializeComponent();
        }
        private void CargarArchivo()
        {
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
                        //int id = lector.ReadInt32();
                        // int tamaño = lector.ReadInt32();
                        //char[] nombreArray = lector.ReadChars(tamaño);
                        string nombre = lector.ReadString();
                        string apellido = lector.ReadString();
                        string telefono = lector.ReadString();
                        string email = lector.ReadString();
                        string direccion = lector.ReadString();

                        //int poblacion = lector.ReadInt32();

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

        private void Consultar_clientes_Load(object sender, EventArgs e)
        {
            CargarArchivo();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
