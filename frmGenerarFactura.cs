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

namespace Proyecto
{
    public partial class frmGenerarFactura : Form
    {
        private List<Servicio> servicios = new List<Servicio>
        {
            new Servicio { Nombre = "Internet Básico", Precio = 20.00m },
            new Servicio { Nombre = "Internet Avanzado", Precio = 35.00m },
            new Servicio { Nombre = "Televisión Básica", Precio = 15.00m },
            new Servicio { Nombre = "Televisión Avanzada", Precio = 25.00m }
        };

        public frmGenerarFactura()
        {
            InitializeComponent();
        }

        private void Generarfacturas_Load(object sender, EventArgs e)
        {
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
    }
}
