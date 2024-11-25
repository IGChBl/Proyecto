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
using Proyecto.Models;
using static Proyecto.frmHistorialFacturas;
using System.IO;

namespace Proyecto
{
    public partial class frmGenerarFactura : Form
    {
        private List<Servicio> servicios = new List<Servicio>
        {
            new Servicio { Nombre = "Internet Básico", Precio = 20.00m },
            new Servicio { Nombre = "Internet Avanzado", Precio = 35.00m },
            new Servicio { Nombre = "Televisión Básica", Precio = 15.00m },
            new Servicio { Nombre = "Televisión Avanzada", Precio = 25.00m },
            new Servicio { Nombre = "Streaming Premium", Precio = 30.00m },
            new Servicio { Nombre = "Telefonía Básica", Precio = 10.00m },
            new Servicio { Nombre = "Telefonía Ilimitada", Precio = 20.00m },
            new Servicio { Nombre = "Paquete Familiar", Precio = 50.00m },
            new Servicio { Nombre = "Internet + TV Avanzada", Precio = 55.00m },
            new Servicio { Nombre = "Servicio Técnico", Precio = 5.00m },
            new Servicio { Nombre = "Canales Deportivos", Precio = 12.00m }
        };

        public frmGenerarFactura()
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
        private void Generarfacturas_Load(object sender, EventArgs e)
        {
            CargarArchivo();
            // Cargar los clientes en el ComboBox
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = ClienteData.Clientes;

            // Configurar el DataGridView para mostrar los servicios
            dgvServicios.AutoGenerateColumns = false;
            dgvServicios.Columns.Clear();

            // Columna de Checkbox para seleccionar servicios
            DataGridViewCheckBoxColumn seleccionarColumna = new DataGridViewCheckBoxColumn();
            seleccionarColumna.HeaderText = "Seleccionar";
            seleccionarColumna.Name = "Seleccionar";
            seleccionarColumna.Width = 50;
            dgvServicios.Columns.Add(seleccionarColumna);

            // Columna de Nombre del Servicio
            DataGridViewTextBoxColumn nombreColumna = new DataGridViewTextBoxColumn();
            nombreColumna.DataPropertyName = "Nombre";
            nombreColumna.HeaderText = "Servicio";
            dgvServicios.Columns.Add(nombreColumna);

            // Columna de Precio del Servicio
            DataGridViewTextBoxColumn precioColumna = new DataGridViewTextBoxColumn();
            precioColumna.DataPropertyName = "Precio";
            precioColumna.HeaderText = "Precio";
            dgvServicios.Columns.Add(precioColumna);

            // Establecer la lista de servicios como fuente de datos
            dgvServicios.DataSource = servicios;
        }

        private void btnGenerarFactura(object sender, EventArgs e)
        {
            // Obtener el cliente seleccionado
            var clienteSeleccionado = cmbCliente.SelectedItem as Cliente;
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente.");
                return;
            }

            // Recolectar los servicios seleccionados y calcular el total
            decimal totalFactura = 0;
            var serviciosSeleccionados = new List<Servicio>();

            foreach (DataGridViewRow row in dgvServicios.Rows)
            {
                // Verifica si la fila está seleccionada (si usas una columna de checkbox)
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value) == true)
                {
                    var servicio = row.DataBoundItem as Servicio;
                    if (servicio != null)
                    {
                        serviciosSeleccionados.Add(servicio);
                        totalFactura += servicio.Precio;
                    }
                }
            }

            if (serviciosSeleccionados.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos un servicio.");
                return;
            }

            // Crear la factura
            Factura nuevaFactura = new Factura
            {
                Numero = "F" + DateTime.Now.Ticks, // Genera un número único para la factura
                Cliente = clienteSeleccionado.Nombre + " " + clienteSeleccionado.Apellido,
                Fecha = DateTime.Now,
                Servicios = serviciosSeleccionados,
                Total = totalFactura
            };

            // Guardar la factura en el almacenamiento
            FacturaStorage.HistorialFacturas.Add(nuevaFactura);

            // Crear el contenido de la factura
            StringBuilder factura = new StringBuilder();
            factura.AppendLine("FACTURA");
            factura.AppendLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
            factura.AppendLine("Cliente: " + clienteSeleccionado.Nombre + " " + clienteSeleccionado.Apellido);
            factura.AppendLine("Email: " + clienteSeleccionado.Email);
            factura.AppendLine("Teléfono: " + clienteSeleccionado.Telefono);
            factura.AppendLine("\nServicios:");
            foreach (var servicio in serviciosSeleccionados)
            {
                factura.AppendLine($"- {servicio.Nombre}: ${servicio.Precio}");
            }
            factura.AppendLine("\nTotal: $" + totalFactura);

            // Guardar la factura en un archivo de texto
            string rutaFactura = @"C:\Facturas\Factura_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            System.IO.Directory.CreateDirectory(@"C:\Facturas"); // Crear el directorio si no existe
            System.IO.File.WriteAllText(rutaFactura, factura.ToString());

            // Mostrar mensaje de confirmación
            MessageBox.Show("Factura generada correctamente.\nRuta: " + rutaFactura);

            // Opcional: Abrir el archivo automáticamente
            System.Diagnostics.Process.Start("notepad.exe", rutaFactura);


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
