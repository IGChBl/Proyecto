using Proyecto.Forms;
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
    public partial class frmActualizarEliminarFacturaErronea : Form
    {
        public frmActualizarEliminarFacturaErronea()
        {
            InitializeComponent();
        }

        private void Actualizar_o_Eliminar_Facturas_Erróneas_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string criterio = txtCriterioBusqueda.Text; // Obtener el texto del cuadro de búsqueda

            // Buscar facturas que coincidan con el número o el cliente
            var resultados = FacturaStorage.HistorialFacturas
                .Where(f => f.Numero.Contains(criterio) || f.Cliente.Contains(criterio))
                .ToList();

            // Mostrar los resultados en el DataGridView
            dgvResultados.DataSource = null; // Limpiar los datos anteriores
            dgvResultados.DataSource = resultados; // Mostrar los nuevos resultados

            // Verificar si hay resultados
            if (resultados.Count == 0)
            {
                MessageBox.Show("No se encontraron facturas con ese criterio.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dgvResultados.SelectedRows.Count > 0)
            {
                // Obtener la factura seleccionada
                var facturaSeleccionada = dgvResultados.SelectedRows[0].DataBoundItem as Factura;

                if (facturaSeleccionada != null)
                {
                    // Abrir el formulario de actualización
                    frmActualizarFactura frmActualizar = new frmActualizarFactura(facturaSeleccionada);
                    frmActualizar.ShowDialog();

                    // Actualizar la lista después de cerrar el formulario
                    btnBuscar_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una factura para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarFactura_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dgvResultados.SelectedRows.Count > 0)
            {
                // Obtener la factura seleccionada
                var facturaSeleccionada = dgvResultados.SelectedRows[0].DataBoundItem as Factura;

                if (facturaSeleccionada != null)
                {
                    // Confirmar la eliminación
                    var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar la factura {facturaSeleccionada.Numero}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        // Eliminar la factura de la lista
                        FacturaStorage.HistorialFacturas.Remove(facturaSeleccionada);

                        // Actualizar el DataGridView
                        btnBuscar_Click(sender, e);

                        // Mostrar mensaje de éxito
                        MessageBox.Show("Factura eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una factura para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
