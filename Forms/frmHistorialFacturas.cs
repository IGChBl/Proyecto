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

namespace Proyecto
{
    public partial class frmHistorialFacturas : Form
    {
        public frmHistorialFacturas()
        {
            InitializeComponent();
        }

        private void frmHistorialFacturas_Load(object sender, EventArgs e)
        {
            dgvHistorialFacturas.DataSource = null;
            dgvHistorialFacturas.DataSource = FacturaStorage.HistorialFacturas;

            // Configurar las columnas si no están configuradas en el diseñador
            dgvHistorialFacturas.AutoGenerateColumns = false;
            dgvHistorialFacturas.Columns.Clear();

            dgvHistorialFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Número de Factura", DataPropertyName = "Numero", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvHistorialFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "Cliente", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvHistorialFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "Fecha", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvHistorialFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total", DataPropertyName = "Total", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });

            // Enlazar el historial de facturas al DataGridView
            dgvHistorialFacturas.DataSource = FacturaStorage.HistorialFacturas;
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvHistorialFacturas.SelectedRows.Count > 0)
            {
                var facturaSeleccionada = dgvHistorialFacturas.SelectedRows[0].DataBoundItem as Factura;
                if (facturaSeleccionada != null)
                {
                    frmDetallesFactura detallesForm = new frmDetallesFactura(facturaSeleccionada);
                    detallesForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una factura para ver los detalles.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
