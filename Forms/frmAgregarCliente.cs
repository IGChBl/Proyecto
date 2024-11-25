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

namespace Proyecto
{
    public partial class frmAgregarCliente : Form
    {
        public frmAgregarCliente()
        {
            InitializeComponent();
        }

        private void frmAgregarCliente_Load(object sender, EventArgs e)
        {
            CargarArchivo();
        }
        public static class ClienteData
        {
            public static List<Cliente> Clientes = new List<Cliente>();
        }
        private void GuardarArchivo()
        {
            string rutaArchivo = "clientes.dat";
            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter escritor = new BinaryWriter(archivo))
                {
                    foreach (Cliente c in ClienteData.Clientes)
                    {
                        escritor.Write(c.Nombre);
                        escritor.Write(c.Apellido);
                        escritor.Write(c.Telefono);
                        escritor.Write(c.Email);
                        escritor.Write(c.Direccion);
                    }
                }
            }
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
        private void btnGuardarCliente_Click(object sender, EventArgs e)

        {
            string telefono = tbTelefono.Text;
            string email = tbEmail.Text;

            // Validación del Teléfono
            if (telefono.Length != 8 || !System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{8}$")) // expresión regular para validar un número de teléfono de 8 dígitos
            {
                MessageBox.Show("El número de teléfono debe ser de 8 dígitos y contener solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detiene el proceso de guardado si la validación falla
            }

            // Validación del Correo Electrónico
            if (!email.Contains("@") || !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // expresión regular para validar un correo electrónico
            {
                MessageBox.Show("Ingrese un correo electrónico válido que contenga '@' y un dominio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detiene el proceso de guardado si la validación falla
            }
            // Crear una nueva instancia de Cliente con los datos ingresados
            Cliente nuevoCliente = new Cliente
            {
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                Telefono = tbTelefono.Text,
                Email = tbEmail.Text,
                Direccion = tbDireccion.Text
            };

            // Agregar el cliente a la lista estática
            ClienteData.Clientes.Add(nuevoCliente);

            GuardarArchivo();

            // Mostrar un mensaje de confirmación
            MessageBox.Show("Cliente agregado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos de texto
            tbNombre.Clear();
            tbApellido.Clear();
            tbTelefono.Clear();
            tbEmail.Clear();
            tbDireccion.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
