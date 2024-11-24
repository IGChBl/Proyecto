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

namespace Proyecto.Forms
{
    public partial class frmActualizarFactura : Form
    {
        private Factura factura;
        public frmActualizarFactura(Factura facturaSeleccionada)
        {
            InitializeComponent();
            factura = facturaSeleccionada;

        }

        private void frmActualizarFactura_Load(object sender, EventArgs e)
        {
            // Cargar los datos de la factura en los controles del formulario
            txtCliente.Text = factura.Cliente;
            dtpFecha.Value = factura.Fecha;

            // Mostrar los servicios asociados a la factura en el DataGridView
            dgvServicios.DataSource = null;
            dgvServicios.DataSource = factura.Servicios;

            // Configurar columnas del DataGridView (opcional si no están configuradas en el diseñador)
            if (dgvServicios.Columns.Count == 0)
            {
                dgvServicios.Columns.Add("Nombre", "Servicio");
                dgvServicios.Columns.Add("Precio", "Precio");
                dgvServicios.AutoGenerateColumns = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Actualizar los datos de la factura
            factura.Cliente = txtCliente.Text;
            factura.Fecha = dtpFecha.Value;

            // Actualizar los servicios seleccionados
            var serviciosActualizados = dgvServicios.DataSource as List<Servicio>;
            if (serviciosActualizados != null)
            {
                factura.Servicios = serviciosActualizados;
                factura.Total = serviciosActualizados.Sum(s => s.Precio);
            }

            MessageBox.Show("Factura actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cerrar el formulario
            this.Close();
        }
    }
}
